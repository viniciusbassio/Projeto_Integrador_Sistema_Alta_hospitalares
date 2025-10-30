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
    public partial class PTA_Enfermeiro : System.Web.UI.Page
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString;
        string conexao = connectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarPaciente();
                CarregarMedicos();
            }
        }
        private void CarregarPaciente()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                {
                    conn.Open();
                    string query = "SELECT NOME FROM PACIENTE";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();

                        while (reader.Read())
                        {
                            sb.AppendFormat("<option value=\"{0}\"></option>", reader["Nome"].ToString());
                        }
                        listaPacientes.InnerHtml = sb.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar pacientes: " + ex.Message);
            }
        }

        protected void txtNome_TextChanged(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            if (!string.IsNullOrEmpty(nome))
            {
                int idade = ObterIdadePaciente(nome);
                lblIdade.Text = "Idade: " + (idade > 0 ? idade.ToString() + " anos" : "não encontrada");
            }
        }



        private int ObterIdadePaciente(string nome)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexao))
                {
                    connection.Open();
                    string query = "SELECT Data_Nascimento FROM PACIENTE WHERE Nome = @Nome";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", nome);
                        object result = command.ExecuteScalar();

                        if (result != null && DateTime.TryParse(result.ToString(), out DateTime dataNascimento))
                        {
                            int idade = DateTime.Now.Year - dataNascimento.Year;
                            if (DateTime.Now < dataNascimento.AddYears(idade))
                                idade--; // corrige se ainda não fez aniversário este ano
                            return idade;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Trate a exceção conforme necessário, por exemplo, logando o erro
                Console.WriteLine("Erro ao obter idade do paciente: " + ex.Message);
            }
            return 0;
        }
        private void CarregarMedicos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                {
                    conn.Open();

                    string query = @"
                SELECT U.ID_USUARIO, U.USUARIO
                FROM USUARIO U
                INNER JOIN GRUPOUSUARIO GU ON U.ID_GRUPO_USUARIO = GU.ID_GRUPO_USUARIO
                WHERE GU.ID_GRUPO_USUARIO = 2";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ddlMedico.DataSource = reader;
                        ddlMedico.DataTextField = "USUARIO";  // Nome exibido
                        ddlMedico.DataValueField = "ID_USUARIO";  // Valor interno
                        ddlMedico.DataBind();

                        ddlMedico.Items.Insert(0, new ListItem("Selecione...", ""));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar médicos: " + ex.Message);
            }
        }

    }
}