using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador_Vinicius_Dos_Santos_Bassio
{
    public partial class TelaLogin : System.Web.UI.Page
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString;
        string conexao = connectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnLogar_Click1(object sender, EventArgs e)
        {
            string usuario = TXTusuario.Text.Trim();
            string senha = TXTSenha.Text.Trim();
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                lblMensagemErro.Visible = true;
                lblMensagemErro.Text = "Usuário e senha são obrigatórios.";
                return;
            }
            try
            {
                using (var conexaoSql = new System.Data.SqlClient.SqlConnection(conexao))
                {
                    conexaoSql.Open();
                    string query = "SELECT COUNT(*) FROM Usuario WHERE Usuario = @Usuario AND Senha = @Senha";
                    using (var comando = new System.Data.SqlClient.SqlCommand(query, conexaoSql))
                    {
                        comando.Parameters.AddWithValue("@Usuario", usuario);
                        comando.Parameters.AddWithValue("@Senha", senha);
                        int count = (int)comando.ExecuteScalar();
                        if (count > 0)
                        {
                            Session["UsuarioLogado"] = usuario;
                            Response.Redirect("TelaPrincipal.aspx");
                        }
                        else
                        {
                            lblMensagemErro.Visible = true;
                            lblMensagemErro.Text = "Usuário ou senha inválidos.";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensagemErro.Text = "Erro ao conectar ao banco de dados: " + ex.Message;
            }
        }
    }
}