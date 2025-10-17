using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View
{
    public partial class TelaPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] == null)
            {
                Response.Redirect("TelaLogin.aspx");
                return;
            }

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
        protected void btnPTA_Click(object sender, EventArgs e)
        {
            if (Session["idUsuario"] == null)
            {
                Response.Redirect("TelaLogin.aspx");
                return;
            }

            int idUsuario;
            if (!int.TryParse(Session["idUsuario"].ToString(), out idUsuario))
                return;

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

                    if (result != null)
                    {
                        string nomeGrupo = result.ToString().Trim().ToLower();

                        // Dicionário com o mapeamento dos grupos e suas páginas
                        var paginasPTA = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    { "enfermagem", "PTA_Enfermeiro.aspx" },
                    { "enfermeiro", "PTA_Enfermeiro.aspx" },
                    { "fisioterapia", "PTA_Fisioterapia.aspx" },
                    { "médico", "PTA_MEDICO.aspx" },
                    { "medico", "PTA_MEDICO.aspx" },
                    { "nutrição", "PTA_Nutricao.aspx" },
                    { "nutricao", "PTA_Nutricao.aspx" },
                    { "psicologia", "PTA_Psicologia.aspx" },
                    { "serviço social", "PTA_Servico_Social.aspx" },
                    { "servico social", "PTA_Servico_Social.aspx" }
                };

                        if (paginasPTA.TryGetValue(nomeGrupo, out string pagina))
                        {
                            Response.Redirect(pagina);
                        }
                        else
                        {
                            // Caso o grupo não tenha um PTA definido
                            Response.Write("<script>alert('Seu grupo não possui um PTA específico.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Grupo de usuário não encontrado.');</script>");
                    }
                }
            }
        }

    }
}
