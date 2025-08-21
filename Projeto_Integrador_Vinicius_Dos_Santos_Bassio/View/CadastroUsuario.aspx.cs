using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View
{
    public partial class CadastroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarGrupos();
            }
        }

        private void CarregarGrupos()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT id_grupo_usuario, nome FROM GRUPOUSUARIO";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DDLGrupo.Items.Clear();
                            DDLGrupo.Items.Add(new ListItem("Selecione...", "")); // opção padrão

                            while (reader.Read())
                            {
                                string id = reader["id_grupo_usuario"].ToString();
                                string nome = reader["nome"].ToString();
                                DDLGrupo.Items.Add(new ListItem(nome, id));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Erro ao carregar grupos: {ex.Message}');", true);
                    }
                }
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string usuario = TXTusuario.Text.Trim();
            string senha = TXTSenha.Text.Trim();
            string grupo = DDLGrupo.SelectedValue;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(grupo))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Preencha todos os campos!');", true);
                return;
            }

            string senhaCriptografada = GerarHashSHA256(senha);

            string connStr = ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "INSERT INTO usuario (usuario, senha, ID_GRUPO_USUARIO, criado_em, ATIVO) VALUES (@usuario, @senha, @idgrupousuario, GETDATE()), 1";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@senha", senhaCriptografada);
                    cmd.Parameters.AddWithValue("@idgrupousuario", grupo);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Usuário cadastrado com sucesso!');", true);
                        TXTusuario.Text = "";
                        TXTSenha.Text = "";
                        DDLGrupo.SelectedIndex = 0;
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Erro ao cadastrar: {ex.Message}');", true);
                    }
                }
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