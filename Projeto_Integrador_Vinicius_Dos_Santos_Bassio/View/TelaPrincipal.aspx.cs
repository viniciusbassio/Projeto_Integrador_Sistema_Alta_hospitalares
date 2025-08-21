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
            if (Session["idUsuario"] == null)
            {
                menuAdmin.Visible = false;
                return;
            }

            int idUsuario;
            if (!int.TryParse(Session["idUsuario"].ToString(), out idUsuario))
            {
                menuAdmin.Visible = false;
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = "SELECT id_grupo_usuario FROM usuario WHERE id_usuario = @idusuario";
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
