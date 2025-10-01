using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View
{
    public partial class CadastroPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarEstados(); // carrega os estados ao abrir a página
            }
        }

        private void CarregarEstados()
        {
            string conexao = System.Configuration.ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                string query = "SELECT Id_estado, Nome FROM Estado ORDER BY Nome";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ddlEstado.Items.Clear();
                        ddlEstado.Items.Add(new ListItem("Selecione...", ""));
                        while (reader.Read())
                        {
                            ddlEstado.Items.Add(new ListItem(reader["Nome"].ToString(), reader["Id_estado"].ToString()));
                        }
                    }
                }
            }
            // Limpa cidades ao carregar estados
            ddlCidade.Items.Clear();
            ddlCidade.Items.Add(new ListItem("Selecione um estado primeiro...", ""));
        }

        // Evento chamado quando o usuário seleciona um estado
        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEstado = string.IsNullOrEmpty(ddlEstado.SelectedValue) ? 0 : Convert.ToInt32(ddlEstado.SelectedValue);

            if (idEstado > 0)
            {
                CarregarCidades(idEstado);
            }
            else
            {
                ddlCidade.Items.Clear();
                ddlCidade.Items.Add(new ListItem("Selecione um estado primeiro...", ""));
            }
        }

        // Carrega cidades do estado selecionado
        private void CarregarCidades(int idEstado)
        {
            string conexao = System.Configuration.ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                string query = "SELECT Id_cidade, Nome FROM Cidade WHERE id_Estado = @EstadoId ORDER BY Nome";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EstadoId", idEstado);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ddlCidade.Items.Clear();
                        ddlCidade.Items.Add(new ListItem("Selecione...", ""));
                        while (reader.Read())
                        {
                            ddlCidade.Items.Add(new ListItem(reader["Nome"].ToString(), reader["Id_cidade"].ToString()));
                        }
                    }
                }
            }
        }


        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string conexao = System.Configuration.ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString;
            string nome = txtNome.Text.Trim();
            string cpf = txtCPF.Text.Trim();
            string telefone = txtTelefone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string endereco = txtEndereco.Text.Trim();
            string dataNascimento = txtDataNascimento.Text.Trim();
            string sexo = rblSexo.SelectedValue;

            // Captura o ID da cidade selecionada
            int cidade = string.IsNullOrEmpty(ddlCidade.SelectedValue) ? 0 : Convert.ToInt32(ddlCidade.SelectedValue);

            // Validação simples
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(dataNascimento) || cidade == 0)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "Preencha todos os campos obrigatórios, incluindo a Cidade.";
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                {
                    conn.Open();
                    string query = @"INSERT INTO Paciente (Nome, CPF, Telefone, Email, Endereco, Data_Nascimento, Sexo, id_cidade, Criado_em)
                             VALUES (@Nome, @CPF, @Telefone, @Email, @Endereco, @DataNascimento, @Sexo, @CidadeId, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nome", nome);
                        cmd.Parameters.AddWithValue("@CPF", cpf);
                        cmd.Parameters.AddWithValue("@Telefone", telefone);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Endereco", endereco);
                        cmd.Parameters.AddWithValue("@DataNascimento", dataNascimento);
                        cmd.Parameters.AddWithValue("@Sexo", sexo.Substring(0, 1));
                        cmd.Parameters.AddWithValue("@CidadeId", cidade);

                        cmd.ExecuteNonQuery();
                    }
                }
                lblMensagem.ForeColor = System.Drawing.Color.Green;
                lblMensagem.Text = "Paciente cadastrado com sucesso!";
                LimparCampos();
            }
            catch (Exception ex)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "Erro ao cadastrar paciente: " + ex.Message;
            }
        }


        private void LimparCampos()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtEndereco.Text = "";
            txtDataNascimento.Text = "";
            rblSexo.ClearSelection();
            ddlEstado.SelectedIndex = 0;
            ddlCidade.Items.Clear();
        }
    }
}