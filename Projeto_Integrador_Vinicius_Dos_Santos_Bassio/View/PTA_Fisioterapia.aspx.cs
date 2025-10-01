using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador_Vinicius_Dos_Santos_Bassio
{
    public partial class PTA_Fisioterapia : System.Web.UI.Page
    {
        // Guarda os pontos temporariamente em ViewState
        private const string PontosKey = "PontosDependencia";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopularDependencias();
                // Inicializa pontos
                ViewState[PontosKey] = 0.0;
                AtualizarResumo();
            }
        }

        private void PopularDependencias()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Atividade");
            dt.Columns.Add("Caracteristica");

            dt.Rows.Add("Banho", "Higienização completa ou parcial do corpo");
            dt.Rows.Add("Alimentação", "Capacidade de se alimentar sozinho ou precisar de ajuda");
            dt.Rows.Add("Mobilidade", "Locomoção no quarto ou hospital, uso de cadeira de rodas");
            dt.Rows.Add("Vestir-se", "Colocar e tirar roupas sozinho ou com auxílio");
            dt.Rows.Add("Higiene Oral", "Escovação e cuidados com a boca");
            dt.Rows.Add("Uso de banheiro", "Ida ao banheiro e higiene pessoal");

            gvDependencia.DataSource = dt;
            gvDependencia.DataBind();
        }

        protected void gvDependencia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string atividade = e.CommandArgument.ToString();
            double pontos = (double)ViewState[PontosKey];

            switch (e.CommandName)
            {
                case "Independente":
                    pontos += 1.0;
                    break;
                case "DependenteParcial":
                    pontos += 0.5;
                    break;
                case "DependenteTotal":
                    pontos += 0.0;
                    break;
            }

            ViewState[PontosKey] = pontos;
            AtualizarResumo();
        }


        private void AtualizarResumo()
        {
            double pontos = (double)ViewState[PontosKey];
            lblTotal.Text = pontos.ToString("0.0");

            // Classificação exemplo
            if (pontos == 6)
                lblClassificacao.Text = "Independente";
            else if (pontos >= 3)
                lblClassificacao.Text = "Dependente Parcial";
            else
                lblClassificacao.Text = "Dependente Total";
        }
    }
}
