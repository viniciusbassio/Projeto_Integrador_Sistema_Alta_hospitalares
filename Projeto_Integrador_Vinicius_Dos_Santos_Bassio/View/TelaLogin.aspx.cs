using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

            // Permite login do usuário admin com senha 123456 em texto puro
            if (usuario.Equals("adm", StringComparison.OrdinalIgnoreCase) && senha == "123456")
            {
                // Você pode buscar o id_usuario do admin no banco, ou definir um valor fixo
                Session["idUsuario"] = "1"; // Supondo que o id do admin é 1
                Response.Redirect("TelaPrincipal.aspx");
                return;
            }

            try
            {
                using (var conexaoSql = new System.Data.SqlClient.SqlConnection(conexao))
                {
                    conexaoSql.Open();
                    string query = "SELECT id_usuario, Senha FROM Usuario WHERE Usuario = @Usuario";
                    using (var comando = new System.Data.SqlClient.SqlCommand(query, conexaoSql))
                    {
                        comando.Parameters.AddWithValue("@Usuario", usuario);

                        using (var reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string hashBanco = reader["Senha"].ToString();
                                string hashDigitado = GerarHashSHA256(senha);

                                if (hashBanco == hashDigitado)
                                {
                                    Session["idUsuario"] = reader["id_usuario"].ToString();
                                    Response.Redirect("TelaPrincipal.aspx");
                                }
                                else
                                {
                                    lblMensagemErro.Visible = true;
                                    lblMensagemErro.Text = "Usuário ou senha inválidos.";
                                }
                            }
                            else
                            {
                                lblMensagemErro.Visible = true;
                                lblMensagemErro.Text = "Usuário ou senha inválidos.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensagemErro.Text = "Erro ao conectar ao banco de dados: " + ex.Message;
            }
        }
        private string GerarHashSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}