using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View
{
    public partial class ALTA : System.Web.UI.Page
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 1️⃣ Verifica se o usuário está logado
                if (Session["idUsuario"] == null)
                {
                    Response.Redirect("TelaLogin.aspx");
                    return;
                }

                // 2️⃣ Pega o grupo do usuário
                int grupoUsuario = Convert.ToInt32(Session["idGrupoUsuario"]);

                // 3️⃣ Carrega dados do paciente e PTA, se houver
                if (Request.QueryString["idPaciente"] != null)
                {
                    int idPaciente = Convert.ToInt32(Request.QueryString["idPaciente"]);
                    CarregarDadosPaciente(idPaciente);

                    // ✅ Habilita o botão apenas se for médico
                    btnSalvar.Enabled = (grupoUsuario == 2);
                    btnSalvar.CssClass = grupoUsuario == 2
                        ? "btn btn-success btn-lg me-2"
                        : "btn btn-secondary btn-lg me-2 disabled";
                }
            }
        }

        private void CarregarDadosPaciente(int idPaciente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
SELECT TOP 1
    p.ID_PACIENTE,
    p.NOME AS nome_paciente,
    DATEDIFF(YEAR, p.DATA_NASCIMENTO, GETDATE()) AS idade,
    p.CPF,
    p.SEXO,
    p.ENDERECO,
    p.TELEFONE,
    p.EMAIL,
    p.ESF,
    c.NOME AS cidade,
    e.UF AS estado,
    pta.SETOR,
    pta.LEITO,
    pta.HD,
    pta.DATA_INTERNACAO,
    pta.DESCRICAO_CASO,
    u.USUARIO AS medico_responsavel
FROM PACIENTE p
LEFT JOIN CIDADE c ON p.ID_CIDADE = c.ID_CIDADE
LEFT JOIN ESTADO e ON c.ID_ESTADO = e.ID_ESTADO
LEFT JOIN PTA_Enfermeiro pta ON pta.ID_PACIENTE = p.ID_PACIENTE
LEFT JOIN USUARIO u ON u.ID_USUARIO = pta.ID_MEDICO_RESPONSAVEL
WHERE p.ID_PACIENTE = @idPaciente
ORDER BY pta.DATA_INTERNACAO DESC;";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Paciente
                    txtNomePaciente.Text = reader["nome_paciente"].ToString();
                    txtIdadePaciente.Text = reader["idade"].ToString();
                    txtSetor.Text = reader["setor"].ToString();
                    txtLeito.Text = reader["leito"].ToString();
                    txtMedico.Text = reader["medico_responsavel"].ToString();

                    if (reader["data_internacao"] != DBNull.Value)
                        txtDataInternacao.Text = Convert.ToDateTime(reader["data_internacao"]).ToString("dd/MM/yyyy");

                    txtDiagnostico.Text = reader["hd"].ToString(); // se HD for o diagnóstico médico
                    txtMotivoInternacao.Text = reader["descricao_caso"].ToString();
                    txtPacientePortador.Text = reader["sexo"].ToString();
                    txtDadosInternacao.Text = $"{reader["endereco"]}, {reader["cidade"]}-{reader["estado"]}";
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["idPaciente"] == null)
                return;

            int idPaciente = Convert.ToInt32(Request.QueryString["idPaciente"]);
            int idUsuario = Convert.ToInt32(Session["idUsuario"]);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string insertQuery = @"
                        INSERT INTO ALTA (id_paciente, id_usuario, data_alta, status)
                        VALUES (@idPaciente, @idUsuario, GETDATE(), @status)";

                    SqlCommand cmd = new SqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@status", "Concluída");

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }

                btnSalvar.Enabled = false;
                btnSalvar.CssClass = "btn btn-secondary btn-lg me-2 disabled";
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar a alta: " + ex.Message);
            }

            Response.Redirect("ListaPacientes_Alta.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaPacientes_Alta.aspx");
        }
    }
}
