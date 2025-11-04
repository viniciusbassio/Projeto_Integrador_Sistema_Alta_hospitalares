using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View
{
    public partial class CadastroPaciente : System.Web.UI.Page
    {
        // Declaração única da connection string
        private static readonly string conexao = System.Configuration.ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] == null)
            {
                Response.Redirect("TelaLogin.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CarregarEstados(); // carrega os estados ao abrir a página
            }
        }

        private void CarregarEstados()
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                string query = "SELECT Id_estado, Nome FROM Estado ORDER BY Nome";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    ddlEstado.Items.Clear();
                    ddlEstado.Items.Add(new ListItem("Selecione...", ""));
                    while (reader.Read())
                    {
                        ddlEstado.Items.Add(new ListItem(reader["Nome"].ToString(), reader["Id_estado"].ToString()));
                    }
                }
            }
            // Limpa cidades ao carregar estados
            ddlCidade.Items.Clear();
            ddlCidade.Items.Add(new ListItem("Selecione um estado primeiro...", ""));
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEstado = string.IsNullOrEmpty(ddlEstado.SelectedValue) ? 0 : Convert.ToInt32(ddlEstado.SelectedValue);

            if (idEstado > 0)
                CarregarCidades(idEstado);
            else
            {
                ddlCidade.Items.Clear();
                ddlCidade.Items.Add(new ListItem("Selecione um estado primeiro...", ""));
            }
        }

        private void CarregarCidades(int idEstado)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                string query = "SELECT Id_cidade, Nome FROM Cidade WHERE id_Estado = @EstadoId ORDER BY Nome";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EstadoId", idEstado);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ddlCidade.Items.Clear();
                        ddlCidade.Items.Add(new ListItem("Selecione...", ""));
                        while (reader.Read())
                        {
                            ddlCidade.Items.Add(new ListItem(reader["Nome"].ToString(), reader["Id_cidade"].ToString()));
                        }
                    }
                }
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string cpf = txtCPF.Text.Trim();
            string telefone = txtTelefone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string endereco = txtEndereco.Text.Trim();
            string dataNascimento = txtDataNascimento.Text.Trim();
            string sexo = rblSexo.SelectedValue;
            int cidade = string.IsNullOrEmpty(ddlCidade.SelectedValue) ? 0 : Convert.ToInt32(ddlCidade.SelectedValue);
            string esf = txtEsf.Text.Trim();

            // Validação simples
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(dataNascimento) || cidade == 0)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "Preencha todos os campos obrigatórios, incluindo a Cidade.";
                return;
            }

            // Validações adicionais
            if (!ValidarCPF(cpf))
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "CPF inválido.";
                return;
            }
            if (!ValidarEmail(email))
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "E-mail inválido.";
                return;
            }
            if (!ValidarTelefone(telefone))
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "Telefone inválido.";
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                {
                    conn.Open();
                    string query = @"
                INSERT INTO Paciente 
                (Nome, CPF, Telefone, Email, Endereco, Data_Nascimento, Sexo, id_cidade, ESF, Criado_em)
                VALUES
                (@Nome, @CPF, @Telefone, @Email, @Endereco, @DataNascimento, @Sexo, @CidadeId, @ESF, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nome", nome);
                        cmd.Parameters.AddWithValue("@CPF", cpf);
                        cmd.Parameters.AddWithValue("@Telefone", telefone);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Endereco", endereco);
                        cmd.Parameters.AddWithValue("@DataNascimento", dataNascimento);
                        cmd.Parameters.AddWithValue("@Sexo", sexo.Substring(0, 1));
                        cmd.Parameters.AddWithValue("@CidadeId", cidade);
                        cmd.Parameters.AddWithValue("@ESF", esf);

                        cmd.ExecuteNonQuery();
                    }
                }
                lblMensagem.ForeColor = System.Drawing.Color.Green;
                lblMensagem.Text = "Paciente cadastrado com sucesso!";
                LimparCampos();
            }
            catch (Exception ex)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "Erro ao cadastrar paciente: " + ex.Message;
            }
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtEndereco.Text = "";
            txtDataNascimento.Text = "";
            rblSexo.ClearSelection();
            ddlEstado.SelectedIndex = 0;
            ddlCidade.Items.Clear();
        }

        private bool ValidarCPF(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11 || !cpf.All(char.IsDigit)) return false;
            if (cpf.Distinct().Count() == 1) return false;

            int[] mult1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++) soma += int.Parse(tempCpf[i].ToString()) * mult1[i];
            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            string digito = resto.ToString();

            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++) soma += int.Parse(tempCpf[i].ToString()) * mult2[i];
            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }

        private bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch { return false; }
        }

        private bool ValidarTelefone(string telefone)
        {
            telefone = telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            return telefone.All(char.IsDigit) && (telefone.Length == 10 || telefone.Length == 11);
        }
    }
}
