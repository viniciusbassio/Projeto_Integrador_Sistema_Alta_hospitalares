using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View
{
    public partial class PTA_Enfermeiro : System.Web.UI.Page
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString;
        string conexao = connectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarPaciente();
                CarregarMedicos();
            }
        }

        private void CarregarPaciente()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                {
                    conn.Open();
                    string query = "SELECT NOME FROM PACIENTE";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        while (reader.Read())
                        {
                            sb.AppendFormat("<option value=\"{0}\"></option>", reader["Nome"].ToString());
                        }
                        listaPacientes.InnerHtml = sb.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar pacientes: " + ex.Message);
            }
        }

        protected void txtNome_TextChanged(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            if (!string.IsNullOrEmpty(nome))
            {
                int idade = ObterIdadePaciente(nome);
                lblIdade.Text = "Idade: " + (idade > 0 ? idade.ToString() + " anos" : "não encontrada");
            }
        }

        private int ObterIdadePaciente(string nome)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexao))
                {
                    connection.Open();
                    string query = "SELECT Data_Nascimento FROM PACIENTE WHERE Nome = @Nome";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", nome);
                        object result = command.ExecuteScalar();
                        if (result != null && DateTime.TryParse(result.ToString(), out DateTime dataNascimento))
                        {
                            int idade = DateTime.Now.Year - dataNascimento.Year;
                            if (DateTime.Now < dataNascimento.AddYears(idade))
                                idade--;
                            return idade;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao obter idade do paciente: " + ex.Message);
            }
            return 0;
        }

        private void CarregarMedicos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                {
                    conn.Open();
                    string query = @"
                        SELECT U.ID_USUARIO, U.USUARIO
                        FROM USUARIO U
                        INNER JOIN GRUPOUSUARIO GU ON U.ID_GRUPO_USUARIO = GU.ID_GRUPO_USUARIO
                        WHERE GU.ID_GRUPO_USUARIO = 2";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ddlMedico.DataSource = reader;
                        ddlMedico.DataTextField = "USUARIO";
                        ddlMedico.DataValueField = "ID_USUARIO";
                        ddlMedico.DataBind();
                        ddlMedico.Items.Insert(0, new ListItem("Selecione...", ""));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar médicos: " + ex.Message);
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO PTA_Enfermeiro
                        (id_paciente, id_enfermeiro, id_medico_responsavel, setor, leito, crm, data_internacao, hd, glasgow, descricao_caso,
                         tipo_orientacao, descricao_orientacao,
                         orientacao_paciente, orientacao_familiar, orientacao_cuidador,
                         comorbidade_diabetes, comorbidade_has, comorbidade_clinico, comorbidade_cirurgico,
                         nec_ulcera_pressao, nec_estomas, nec_sonda_vesical, nec_traqueostomia, nec_oxigenio, nec_aspiracao, nec_curativos,
                         orient_paciente, orient_familiar,
                         orient_curativos, orient_prevencao_ulcera, orient_sondas_estomas, orient_aspiracao_traqueo, orient_dieta_assistida, orient_cuidados_pele)
                        VALUES
                        (@id_paciente, @id_enfermeiro, @id_medico_responsavel, @setor, @leito, @crm, @data_internacao, @hd, @glasgow, @descricao_caso,
                         @tipo_orientacao, @descricao_orientacao,
                         @orientacao_paciente, @orientacao_familiar, @orientacao_cuidador,
                         @comorbidade_diabetes, @comorbidade_has, @comorbidade_clinico, @comorbidade_cirurgico,
                         @nec_ulcera_pressao, @nec_estomas, @nec_sonda_vesical, @nec_traqueostomia, @nec_oxigenio, @nec_aspiracao, @nec_curativos,
                         @orient_paciente, @orient_familiar,
                         @orient_curativos, @orient_prevencao_ulcera, @orient_sondas_estomas, @orient_aspiracao_traqueo, @orient_dieta_assistida, @orient_cuidados_pele)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Paciente
                        cmd.Parameters.AddWithValue("@id_paciente", ObterIdPaciente(txtNome.Text));
                        cmd.Parameters.AddWithValue("@id_enfermeiro", ObterIdUsuarioLogado());
                        cmd.Parameters.AddWithValue("@id_medico_responsavel", string.IsNullOrEmpty(ddlMedico.SelectedValue) ? (object)DBNull.Value : int.Parse(ddlMedico.SelectedValue));
                        cmd.Parameters.AddWithValue("@setor", txtSetor.Text);
                        cmd.Parameters.AddWithValue("@leito", txtLeito.Text);
                        cmd.Parameters.AddWithValue("@crm", txtCRM.Text);
                        cmd.Parameters.AddWithValue("@data_internacao", string.IsNullOrEmpty(txtDataInternacao.Text) ? (object)DBNull.Value : DateTime.Parse(txtDataInternacao.Text));
                        cmd.Parameters.AddWithValue("@hd", txtHD.Text);
                        cmd.Parameters.AddWithValue("@glasgow", string.IsNullOrEmpty(txtGlasgow.Text) ? (object)DBNull.Value : int.Parse(txtGlasgow.Text));
                        cmd.Parameters.AddWithValue("@descricao_caso", txtDescricao.Text);

                        // Orientações
                        cmd.Parameters.AddWithValue("@tipo_orientacao", txtTipoOrientacao.Text);
                        cmd.Parameters.AddWithValue("@descricao_orientacao", txtDescricaoOrientacao.Text);
                        cmd.Parameters.AddWithValue("@orientacao_paciente", chkOrientacaoPaciente.Checked);
                        cmd.Parameters.AddWithValue("@orientacao_familiar", chkOrientacaoFamiliar.Checked);
                        cmd.Parameters.AddWithValue("@orientacao_cuidador", chkOrientacaoCuidador.Checked);

                        // Comorbidades
                        cmd.Parameters.AddWithValue("@comorbidade_diabetes", chkDiabetes.Checked);
                        cmd.Parameters.AddWithValue("@comorbidade_has", chkHAS.Checked);
                        cmd.Parameters.AddWithValue("@comorbidade_clinico", chkClinico.Checked);
                        cmd.Parameters.AddWithValue("@comorbidade_cirurgico", chkCirurgico.Checked);

                        // Necessidades
                        cmd.Parameters.AddWithValue("@nec_ulcera_pressao", chkUlceraPressao.Checked);
                        cmd.Parameters.AddWithValue("@nec_estomas", chkEstomas.Checked);
                        cmd.Parameters.AddWithValue("@nec_sonda_vesical", chkSondaVesical.Checked);
                        cmd.Parameters.AddWithValue("@nec_traqueostomia", chkTraqueostomia.Checked);
                        cmd.Parameters.AddWithValue("@nec_oxigenio", chkOxigenio.Checked);
                        cmd.Parameters.AddWithValue("@nec_aspiracao", chkAspiracao.Checked);
                        cmd.Parameters.AddWithValue("@nec_curativos", chkCurativos.Checked);

                        // Tipos de Orientações
                        cmd.Parameters.AddWithValue("@orient_paciente", chkOrientPaciente.Checked);
                        cmd.Parameters.AddWithValue("@orient_familiar", chkOrientFamiliar.Checked);
                        cmd.Parameters.AddWithValue("@orient_curativos", chkCurativosOrient.Checked);
                        cmd.Parameters.AddWithValue("@orient_prevencao_ulcera", chkPrevencao.Checked);
                        cmd.Parameters.AddWithValue("@orient_sondas_estomas", chkSondasEstomas.Checked);
                        cmd.Parameters.AddWithValue("@orient_aspiracao_traqueo", chkAspiracaoTraqueo.Checked);
                        cmd.Parameters.AddWithValue("@orient_dieta_assistida", chkDietaAssistida.Checked);
                        cmd.Parameters.AddWithValue("@orient_cuidados_pele", chkCuidadosPele.Checked);

                        cmd.ExecuteNonQuery();
                    }
                }

                // Mensagem de sucesso
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('PTA salvo com sucesso!');", true);
                LimparCampos();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Erro ao salvar PTA: {ex.Message}');", true);
            }
        }

        private int ObterIdPaciente(string nome)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                string query = "SELECT ID_PACIENTE FROM PACIENTE WHERE Nome = @Nome";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        private int ObterIdUsuarioLogado()
        {
            if (Session["idUsuario"] != null)
            {
                return Convert.ToInt32(Session["idUsuario"]);
            }
            else
            {
                throw new Exception("Usuário não logado. Por favor, faça login novamente.");
            }
        }



        private void LimparCampos()
        {
            txtNome.Text = "";
            lblIdade.Text = "Idade:";
            txtSetor.Text = "";
            txtLeito.Text = "";
            ddlMedico.SelectedIndex = 0;
            txtCRM.Text = "";
            txtDataInternacao.Text = "";
            txtHD.Text = "";
            txtGlasgow.Text = "";
            txtDescricao.Text = "";
            txtTipoOrientacao.Text = "";
            txtDescricaoOrientacao.Text = "";

            // Checkboxes
            chkOrientacaoPaciente.Checked = false;
            chkOrientacaoFamiliar.Checked = false;
            chkOrientacaoCuidador.Checked = false;

            chkDiabetes.Checked = false;
            chkHAS.Checked = false;
            chkClinico.Checked = false;
            chkCirurgico.Checked = false;

            chkUlceraPressao.Checked = false;
            chkEstomas.Checked = false;
            chkSondaVesical.Checked = false;
            chkTraqueostomia.Checked = false;
            chkOxigenio.Checked = false;
            chkAspiracao.Checked = false;
            chkCurativos.Checked = false;

            chkOrientPaciente.Checked = false;
            chkOrientFamiliar.Checked = false;
            chkCurativosOrient.Checked = false;
            chkPrevencao.Checked = false;
            chkSondasEstomas.Checked = false;
            chkAspiracaoTraqueo.Checked = false;
            chkDietaAssistida.Checked = false;
            chkCuidadosPele.Checked = false;
        }
    }
}
