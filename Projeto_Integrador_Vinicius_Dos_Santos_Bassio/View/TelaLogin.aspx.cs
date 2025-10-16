using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

            // Login fixo do admin
            if (usuario.Equals("adm", StringComparison.OrdinalIgnoreCase) && senha == "123456")
            {
                Session["idUsuario"] = "1";
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
                                int idUsuario = Convert.ToInt32(reader["id_usuario"]);

                                bool valido = false;

                                // 1 - Tenta validar como PBKDF2
                                valido = ValidarHashPBKDF2(senha, hashBanco);

                                // 2 - Se não for PBKDF2, tenta SHA256
                                if (!valido && hashBanco == GerarHashSHA256(senha))
                                {
                                    valido = true;

                                    // Migra para PBKDF2 automaticamente
                                    string novoHash = GerarHashPBKDF2(senha);
                                    AtualizarSenhaParaPBKDF2(conexaoSql, idUsuario, novoHash);
                                }

                                if (valido)
                                {
                                    Session["idUsuario"] = idUsuario.ToString();
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
        private bool ValidarHashPBKDF2(string senhaDigitada, string hashArmazenado)
        {
            try
            {
                byte[] hashBytes = Convert.FromBase64String(hashArmazenado);

                if (hashBytes.Length != 36) // hash PBKDF2 tem 36 bytes (16 salt + 20 hash)
                    return false;

                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);

                byte[] hashOriginal = new byte[20];
                Array.Copy(hashBytes, 16, hashOriginal, 0, 20);

                var pbkdf2 = new Rfc2898DeriveBytes(senhaDigitada, salt, 10000);
                byte[] hashTestado = pbkdf2.GetBytes(20);

                for (int i = 0; i < 20; i++)
                    if (hashOriginal[i] != hashTestado[i])
                        return false;

                return true;
            }
            catch
            {
                return false; // se não conseguir converter, não é PBKDF2
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

        private string GerarHashPBKDF2(string senha)
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        private void AtualizarSenhaParaPBKDF2(SqlConnection conexao, int idUsuario, string novoHash)
        {
            string update = "UPDATE Usuario SET Senha = @Senha, Atualizado_Em = GETDATE() WHERE id_usuario = @Id";
            using (var cmd = new SqlCommand(update, conexao))
            {
                cmd.Parameters.AddWithValue("@Senha", novoHash);
                cmd.Parameters.AddWithValue("@Id", idUsuario);
                cmd.ExecuteNonQuery();
            }
        }

      
    }
}