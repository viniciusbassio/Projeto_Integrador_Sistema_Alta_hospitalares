using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View
{
    public partial class TelaEsqueciSenha : System.Web.UI.Page
    {
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            int userId = 0;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString))
            {
                conn.Open();

                // 1. Verificar se existe usuário com esse e-mail
                SqlCommand cmdUser = new SqlCommand(
                    "SELECT ID_USUARIO FROM USUARIO WHERE EMAIL=@Email AND ATIVO=1", conn);
                cmdUser.Parameters.AddWithValue("@Email", email);

                var result = cmdUser.ExecuteScalar();

                if (result == null)
                {
                    lblMensagem.CssClass = "text-danger fw-bold";
                    lblMensagem.Text = "E-mail não encontrado.";
                    return;
                }

                userId = Convert.ToInt32(result);

                // 2. Gerar token
                Guid token = Guid.NewGuid();

                // 3. Inserir na tabela RESET_SENHA_TOKEN
                SqlCommand cmdToken = new SqlCommand(@"
                    INSERT INTO RESET_SENHA_TOKEN (ID_USUARIO, TOKEN, EXPIRA_EM) 
                    VALUES (@UserId, @Token, DATEADD(HOUR,1,GETDATE()))", conn);

                cmdToken.Parameters.AddWithValue("@UserId", userId);
                cmdToken.Parameters.AddWithValue("@Token", token);
                cmdToken.ExecuteNonQuery();

                // 4. Montar link de redefinição
                string link = $"https://localhost:44393/View/TelaRedefinirSenha.aspx?token={token}";


                // 5. Enviar e-mail
                try
                {

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("84423@fai.com.br", "cacl jtmg xemk ypjz");


                    MailMessage mensagem = new MailMessage();
                        mensagem.From = new MailAddress("84423@fai.com.br", "Seu Sistema");
                        mensagem.To.Add(email);
                        mensagem.Subject = "Redefinição de Senha";
                        mensagem.Body = $"Olá!\n\nVocê solicitou a redefinição de senha.\nClique no link abaixo para criar uma nova senha (válido por 1 hora):\n\n{link}";
                        mensagem.IsBodyHtml = false;

                        smtp.Send(mensagem);
                    }

                    lblMensagem.CssClass = "text-success fw-bold";
                    lblMensagem.Text = "Um link de redefinição foi enviado para seu e-mail.";
                }
                catch (SmtpException ex)
                {
                    lblMensagem.CssClass = "text-danger fw-bold";
                    lblMensagem.Text = "Erro ao enviar e-mail. Verifique as configurações SMTP: " + ex.Message;
                }
                catch (Exception ex)
                {
                    lblMensagem.CssClass = "text-danger fw-bold";
                    lblMensagem.Text = "Erro inesperado: " + ex.Message;
                }
            }
        }
    }
}
