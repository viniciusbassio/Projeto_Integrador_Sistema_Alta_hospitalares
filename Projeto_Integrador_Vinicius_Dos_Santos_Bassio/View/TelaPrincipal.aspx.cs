using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View
{
    public partial class TelaPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VerificarPermissao();
            }
        }

        private void VerificarPermissao()
        {
            // Garante que a sessão existe para evitar NullReferenceException
            if (Session["IdUsuario"] == null)
            {
                menuAdmin.Visible = false;
                return;
            }

            int idUsuario;
            if (!int.TryParse(Session["IdUsuario"].ToString(), out idUsuario))
            {
                menuAdmin.Visible = false;
                return;
            }

            // Conexão com o banco
            string connStr = ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Consulta para buscar o idgrupousuario
                string sql = "SELECT idgrupousuario FROM usuario WHERE idusuario = @idusuario";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idusuario", idUsuario);

                    object result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int idGrupoUsuario))
                    {
                        // Define o grupo 1 como administrador
                        menuAdmin.Visible = (idGrupoUsuario == 1);
                    }
                    else
                    {
                        menuAdmin.Visible = false;
                    }
                }
            }
        }
    }
}
