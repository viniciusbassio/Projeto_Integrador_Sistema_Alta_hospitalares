using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View
{
    public partial class TelaPrincipal : System.Web.UI.Page
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["ProjetoIntegradorConnection"].ConnectionString;

        // ============================
        // GRUPOS – NORMALIZADOS
        // ============================
        private static readonly HashSet<string> gruposPTA = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "enfermagem", "fisioterapia", "nutrição", "nutricao",
            "psicologia", "serviço social", "servico social",
            "assistente social"
        };

        private static readonly HashSet<string> gruposPTS = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "médico", "medico", "enfermagem", "fisioterapia"
        };

        private static readonly HashSet<string> gruposAlta = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "médico", "medico", "enfermagem", "assistente social"
        };


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] == null)
            {
                Response.Redirect("TelaLogin.aspx");
                return;
            }

            if (!IsPostBack)
            {
                ConfigurarInterfaceUsuario();
                CarregarDashboard();
            }
        }

        // ===============================
        // Obter grupo
        // ===============================
        private string ObterGrupoUsuario(int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT g.NOME
                    FROM USUARIO u
                    INNER JOIN GRUPOUSUARIO g ON g.ID_GRUPO_USUARIO = u.ID_GRUPO_USUARIO
                    WHERE u.ID_USUARIO = @idUsuario";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

                    object o = cmd.ExecuteScalar();
                    return o == null ? null : o.ToString().Trim().ToLower();
                }
            }
        }

        // ===============================
        // Obter nome do usuário
        // ===============================
        private string ObterNomeUsuario(int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT USUARIO FROM USUARIO WHERE ID_USUARIO = @id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;

                    object o = cmd.ExecuteScalar();
                    return o == null ? string.Empty : o.ToString().Trim();
                }
            }
        }

        // ===============================
        // Contador para dashboard
        // ===============================
        private int Contar(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    object o = cmd.ExecuteScalar();
                    if (o == null || o == DBNull.Value) return 0;
                    return Convert.ToInt32(o);
                }
            }
        }

        // ===============================
        // VISIBILIDADE DOS MENUS – CORRIGIDO
        // ===============================
        private void ConfigurarInterfaceUsuario()
        {
            if (!int.TryParse(Session["idUsuario"]?.ToString(), out int idUsuario))
            {
                menuAdmin.Visible = false;
                return;
            }

            string grupo = ObterGrupoUsuario(idUsuario);
            string nome = ObterNomeUsuario(idUsuario);

            lblUsuarioLogado.Text = nome;

            // Reset inicial
            menuAdmin.Visible = false;
            menuPTA.Visible = false;
            menuPTS.Visible = false;
            menuAlta.Visible = false;

            // ADMIN – tudo liberado
            if (!string.IsNullOrEmpty(grupo) && grupo.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                menuAdmin.Visible = true;
                menuPTA.Visible = true;
                menuPTS.Visible = true;
                menuAlta.Visible = true;
                return;
            }

            // MÉDICO – acesso global
            if (!string.IsNullOrEmpty(grupo) &&
                (grupo.Equals("médico", StringComparison.OrdinalIgnoreCase) || grupo.Equals("medico", StringComparison.OrdinalIgnoreCase)))
            {
                menuAdmin.Visible = false;
                menuPTA.Visible = true;
                menuPTS.Visible = true;
                menuAlta.Visible = true;
                return;
            }

            // GRUPOS REGULARES
            if (!string.IsNullOrEmpty(grupo))
            {
                menuPTA.Visible = gruposPTA.Contains(grupo);
                menuPTS.Visible = gruposPTS.Contains(grupo);
                menuAlta.Visible = gruposAlta.Contains(grupo);
            }
        }

        // ===============================
        // Botões
        // ===============================
        protected void btnPTA_Click(object sender, EventArgs e) => RedirecionarPorGrupo("PTA");
        protected void btnPTS_Click(object sender, EventArgs e) => RedirecionarPorGrupo("PTS");
        protected void btnAlta_Click(object sender, EventArgs e) => RedirecionarPorGrupo("ALTA");

        // ===============================
        // REDIRECIONAMENTO CORRIGIDO
        // ===============================
        private void RedirecionarPorGrupo(string tipo)
        {
            if (!int.TryParse(Session["idUsuario"]?.ToString(), out int idUsuario))
            {
                Response.Redirect("TelaLogin.aspx");
                return;
            }

            string grupo = ObterGrupoUsuario(idUsuario);
            if (string.IsNullOrEmpty(grupo))
            {
                Response.Write("<script>alert('Grupo de usuário não encontrado.');</script>");
                return;
            }

            var paginas = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                // PTA
                { "enfermagem|PTA", "PTA_Enfermeiro.aspx" },
                { "fisioterapia|PTA", "PTA_Fisioterapia.aspx" },
                { "nutrição|PTA", "PTA_Nutricao.aspx" },
                { "nutricao|PTA", "PTA_Nutricao.aspx" },
                { "psicologia|PTA", "PTA_Psicologia.aspx" },
                { "serviço social|PTA", "PTA_Servico_Social.aspx" },
                { "servico social|PTA", "PTA_Servico_Social.aspx" },
                { "assistente social|PTA", "PTA_Servico_Social.aspx" },

                // MÉDICO – PTA universal
                { "médico|PTA", "PTA_Medico.aspx" },
                { "medico|PTA", "PTA_Medico.aspx" },

                // PTS
                { "médico|PTS", "PTS_Medico.aspx" },
                { "medico|PTS", "PTS_Medico.aspx" },
                { "enfermagem|PTS", "PTS_Enfermeiro.aspx" },
                { "fisioterapia|PTS", "PTS_Fisioterapia.aspx" },

                // Alta
                { "médico|ALTA", "Alta.aspx" },
                { "medico|ALTA", "Alta.aspx" },
                { "enfermagem|ALTA", "Alta.aspx" },
                { "assistente social|ALTA", "Alta.aspx" }
            };

            string chave = string.Format("{0}|{1}", grupo, tipo.ToUpperInvariant());

            if (paginas.TryGetValue(chave, out string pagina))
            {
                Response.Redirect(pagina);
                return;
            }

            Response.Write("<script>alert('Seu grupo não possui acesso a essa funcionalidade.');</script>");
        }

        // ===============================
        // DASHBOARD
        // ===============================
        private void CarregarDashboard()
        {
            int totalPacientes = Contar("SELECT COUNT(*) FROM PACIENTE");
            int totalAltas = Contar("SELECT COUNT(*) FROM ALTA");

            int ocupados = totalPacientes - totalAltas;
            if (ocupados < 0) ocupados = 0;

            lblPacientesInternados.Text = ocupados.ToString();

            lblAltasHoje.Text = Contar(
                "SELECT COUNT(*) FROM ALTA WHERE CONVERT(date, data_alta) = CONVERT(date, GETDATE())"
            ).ToString();

            // Soma PTS
            string[] tabelasPTS = { "PTS_ENFERMEIRO", "PTS_FISIOTERAPIA", "PTS_MEDICO" };

            int ptsTotal = 0;
            foreach (string tabela in tabelasPTS)
            {
                ptsTotal += Contar(string.Format("SELECT COUNT(*) FROM {0}", tabela));
            }

            lblPTS.Text = ptsTotal.ToString();
            lblProfissionais.Text = Contar("SELECT COUNT(*) FROM USUARIO").ToString();

            int vagos = totalPacientes > 0 ? totalPacientes - ocupados : 0;

            imgGraficoOcupacao.ImageUrl =
                string.Format("https://quickchart.io/chart?c={{type:'doughnut',data:{{labels:['Ocupados','Vagos'],datasets:[{{data:[{0},{1}]}}]}}}}", ocupados, vagos);
        }
    }
}
