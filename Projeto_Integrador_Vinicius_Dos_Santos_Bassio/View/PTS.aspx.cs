using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View
{
    public partial class PTS : System.Web.UI.Page
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString;
        string conexao = connectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarPaciente();
                CarregarEnfermeiros();
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
                // Trate a exceção conforme necessário, por exemplo, logando o erro
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

                string endereco = ObterEnderecoPaciente(nome);
                lblEndereco.Text = "Endereço:" + endereco.ToString();
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

        private string ObterEnderecoPaciente(string nome)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexao))
                {
                    connection.Open();
                    string query = "SELECT Endereco FROM PACIENTE WHERE Nome = @Nome";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", nome);
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Trate a exceção conforme necessário, por exemplo, logando o erro
                Console.WriteLine("Erro ao obter endereço do paciente: " + ex.Message);
            }
            return "Endereço não encontrado";
        }
        private void CarregarEnfermeiros()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexao))
                {
                    connection.Open();
                    string query = "SELECT USUARIO FROM USUARIO U INNER JOIN GRUPOUSUARIO GU ON U.ID_GRUPO_USUARIO = GU.ID_GRUPO_USUARIO WHERE GU.NOME = 'ENFERMEIRO'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        while (reader.Read())
                        {
                            sb.AppendFormat("<option value=\"{0}\"></option>", reader["USUARIO"].ToString());
                        }
                        listaenfermeiros.InnerHtml = sb.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar enfermeiros" + ex.Message);
            }
        }
        private void CarregarMedicas()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexao))
                {
                    connection.Open();
                    string query = @"SELECT U.USUARIO 
                             FROM USUARIO U
                             INNER JOIN GRUPOUSUARIO GU ON U.ID_GRUPO_USUARIO = GU.ID_GRUPO_USUARIO
                             WHERE GU.NOME = 'MEDICA'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        while (reader.Read())
                        {
                            sb.AppendFormat("<option value=\"{0}\"></option>", reader["USUARIO"].ToString());
                        }
                        listaMedicas.InnerHtml = sb.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar médicas: " + ex.Message);
            }
        }

        private void CarregarNutricionistas()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexao))
                {
                    connection.Open();
                    string query = @"SELECT U.USUARIO 
                             FROM USUARIO U
                             INNER JOIN GRUPOUSUARIO GU ON U.ID_GRUPO_USUARIO = GU.ID_GRUPO_USUARIO
                             WHERE GU.NOME = 'NUTRICIONISTA'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        while (reader.Read())
                        {
                            sb.AppendFormat("<option value=\"{0}\"></option>", reader["USUARIO"].ToString());
                        }
                        listaNutricionistas.InnerHtml = sb.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar nutricionistas: " + ex.Message);
            }
        }

        private void CarregarFisioterapeutas()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexao))
                {
                    connection.Open();
                    string query = @"SELECT U.USUARIO 
                             FROM USUARIO U
                             INNER JOIN GRUPOUSUARIO GU ON U.ID_GRUPO_USUARIO = GU.ID_GRUPO_USUARIO
                             WHERE GU.NOME = 'FISIOTERAPEUTA'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        while (reader.Read())
                        {
                            sb.AppendFormat("<option value=\"{0}\"></option>", reader["USUARIO"].ToString());
                        }
                        listaFisioterapeutas.InnerHtml = sb.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar fisioterapeutas: " + ex.Message);
            }
        }

        private void CarregarPsicologos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexao))
                {
                    connection.Open();
                    string query = @"SELECT U.USUARIO 
                             FROM USUARIO U
                             INNER JOIN GRUPOUSUARIO GU ON U.ID_GRUPO_USUARIO = GU.ID_GRUPO_USUARIO
                             WHERE GU.NOME = 'PSICOLOGO'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        while (reader.Read())
                        {
                            sb.AppendFormat("<option value=\"{0}\"></option>", reader["USUARIO"].ToString());
                        }
                        listaPsicologos.InnerHtml = sb.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar psicólogos: " + ex.Message);
            }
        }

    }
}