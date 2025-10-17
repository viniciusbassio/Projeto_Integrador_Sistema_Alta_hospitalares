using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View
{
    public partial class PTA_Servico_Social : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] == null)
            {
                Response.Redirect("TelaLogin.aspx");
                return;
            }

            // Verifica o grupo do usuário logado
            VerificarPermissaoAcesso();
        }

        private void VerificarPermissaoAcesso()
        {
            int idUsuario;
            if (!int.TryParse(Session["idUsuario"]?.ToString(), out idUsuario))
            {
                Response.Redirect("TelaLogin.aspx");
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"SELECT g.NOME  FROM USUARIO U
                    INNER JOIN GRUPOUSUARIO G ON g.id_grupo_usuario = u.id_grupo_usuario
                WHERE u.id_usuario = @idusuario";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idusuario", idUsuario);
                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        Response.Redirect("TelaPrincipal.aspx");
                        return;
                    }

                    string grupo = result.ToString().Trim().ToLower();

                    if (grupo != "serviço social" && grupo != "servico social")
                    {
                        // Bloqueia o acesso de outros grupos
                        Response.Redirect("TelaPrincipal.aspx");
                    }
                }
            }
        }

    }
}