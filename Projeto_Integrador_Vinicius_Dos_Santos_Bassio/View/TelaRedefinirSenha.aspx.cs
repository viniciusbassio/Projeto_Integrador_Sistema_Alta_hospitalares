using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View
{
    public partial class TelaRedefinirSenha : System.Web.UI.Page
    {
        protected void btnRedefinir_Click(object sender, EventArgs e)
        {
            string tokenStr = Request.QueryString["token"];
            if (string.IsNullOrEmpty(tokenStr))
            {
                lblMensagem.CssClass = "text-danger fw-bold";
                lblMensagem.Text = "Token inválido.";
                return;
            }

            string senha = txtSenha.Text.Trim();
            string confirmar = txtConfirmar.Text.Trim();

            if (senha != confirmar)
            {
                lblMensagem.CssClass = "text-danger fw-bold";
                lblMensagem.Text = "As senhas não coincidem.";
                return;
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString))
            {
                conn.Open();
                int userId = 0;
                DateTime expiraEm;

                // Ler token usando "using" para garantir fechamento do reader
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT TOP 1 ID_USUARIO, EXPIRA_EM 
                    FROM RESET_SENHA_TOKEN 
                    WHERE TOKEN=@Token", conn))
                {
                    cmd.Parameters.AddWithValue("@Token", tokenStr);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            lblMensagem.CssClass = "text-danger fw-bold";
                            lblMensagem.Text = "Token inválido.";
                            return;
                        }

                        userId = Convert.ToInt32(reader["ID_USUARIO"]);
                        expiraEm = Convert.ToDateTime(reader["EXPIRA_EM"]);
                    }
                }

                if (DateTime.Now > expiraEm)
                {
                    lblMensagem.CssClass = "text-danger fw-bold";
                    lblMensagem.Text = "Token expirado.";
                    return;
                }

                // Gerar hash da senha com PBKDF2
                string senhaHash = GerarHashPBKDF2(senha);

                // Atualizar senha e apagar token em transação
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    SqlCommand cmdUpdate = new SqlCommand(
                        "UPDATE USUARIO SET SENHA=@Senha, ATUALIZADO_EM=GETDATE() WHERE ID_USUARIO=@Id", conn, tran);
                    cmdUpdate.Parameters.AddWithValue("@Senha", senhaHash);
                    cmdUpdate.Parameters.AddWithValue("@Id", userId);
                    cmdUpdate.ExecuteNonQuery();

                    SqlCommand cmdDelete = new SqlCommand(
                        "DELETE FROM RESET_SENHA_TOKEN WHERE TOKEN=@Token", conn, tran);
                    cmdDelete.Parameters.AddWithValue("@Token", tokenStr);
                    cmdDelete.ExecuteNonQuery();

                    tran.Commit();
                }

                lblMensagem.CssClass = "text-success fw-bold";
                lblMensagem.Text = "Senha redefinida com sucesso! Agora você pode entrar.";

                // Limpar campos de senha
                txtSenha.Text = "";
                txtConfirmar.Text = "";
            }
        }

        private string GerarHashPBKDF2(string senha)
        {
            // Gerar salt aleatório
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(salt);

            // Gerar hash PBKDF2
            var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Combinar salt + hash
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
