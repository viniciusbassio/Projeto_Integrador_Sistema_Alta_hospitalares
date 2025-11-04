using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View
{
    public partial class ListaPacientes_Alta : System.Web.UI.Page
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarPacientesSemAlta();
            }
        }

        private void CarregarPacientesSemAlta(string filtro = "")
        {
            string query = @"
                SELECT DISTINCT P.ID_PACIENTE, P.NOME, P.CPF, P.TELEFONE, P.ESF
                FROM PACIENTE P
                LEFT JOIN ALTA A ON P.ID_PACIENTE = A.ID_PACIENTE
                WHERE (A.ID_ALTA IS NULL OR A.STATUS <> 'Finalizada')
            ";

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query += " AND (P.NOME LIKE @FILTRO OR P.CPF LIKE @FILTRO) ";
            }

            query += " ORDER BY P.NOME;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (!string.IsNullOrWhiteSpace(filtro))
                    cmd.Parameters.AddWithValue("@FILTRO", "%" + filtro + "%");

                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gvPacientesSemAlta.DataSource = dt;
                    gvPacientesSemAlta.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Erro ao carregar pacientes: " + ex.Message + "');</script>");
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBusca.Text.Trim();
            CarregarPacientesSemAlta(filtro);
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtBusca.Text = "";
            CarregarPacientesSemAlta();
        }

        protected void gvPacientesSemAlta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DarAlta")
            {
                string idPaciente = e.CommandArgument.ToString();
                // Redireciona para a tela de alta passando o ID do paciente
                Response.Redirect("ALTA.aspx?idPaciente=" + idPaciente);

            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("TelaPrincipal.aspx");
        }
    }
}
