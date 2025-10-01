using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View
{
    public partial class CadastroGrupoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrarGrupousuario_Click(object sender, EventArgs e)
        {
            string nomeGrupo = txtNomeGrupoUsuario.Text;
            string DescricaoGrupo = txtDescricaoGrupo.Text;
            if(string.IsNullOrWhiteSpace(nomeGrupo) || string.IsNullOrWhiteSpace(DescricaoGrupo))
            {
                lblMensagem.Text = "Por favor, preencha todos os campos.";
                return;
            }
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "INSERT INTO GRUPOUSUARIO (nome, descricao) VALUES (@nome, @descricao)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nomeGrupo);
                    cmd.Parameters.AddWithValue("@descricao", DescricaoGrupo);
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            lblMensagem.Text = "Grupo de usuário cadastrado com sucesso!";
                            txtNomeGrupoUsuario.Text = "";
                            txtDescricaoGrupo.Text = "";
                        }
                        else
                        {
                            lblMensagem.Text = "Erro ao cadastrar o grupo de usuário.";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMensagem.Text = $"Erro ao cadastrar o grupo de usuário: {ex.Message}";
                    }
                }
            }
        }
    }
}