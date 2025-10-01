<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PTA_Fisioterapia.aspx.cs" Inherits="Projeto_Integrador_Vinicius_Dos_Santos_Bassio.PTA_Fisioterapia" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>PTA Fisioterapia</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
        }
        .section-title {
            font-weight: bold;
            margin-top: 20px;
            margin-bottom: 10px;
            text-transform: uppercase;
        }
        .dependencia-table th, .dependencia-table td {
            vertical-align: middle;
            text-align: center;
        }
        .btn-indep, .btn-dep {
            width: 100%;
            margin-bottom: 2px;
        }
        .card-header {
            font-weight: bold;
            text-transform: uppercase;
            background-color: #007ACC;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navbar -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary mb-4">
            <div class="container-fluid">
                <a class="navbar-brand" href="TelaPrincipal.aspx">Sistema de Alta</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNavDropdown">
                    <ul class="navbar-nav">
                        <li class="nav-item"><a class="nav-link" href="CadastroPaciente.aspx">Pacientes</a></li>
                        <li class="nav-item"><a class="nav-link" href="Profissionais.aspx">Profissionais</a></li>
                        <li class="nav-item"><a class="nav-link" href="PTS.aspx">PTS</a></li>
                        <li class="nav-item"><a class="nav-link active" href="PTA_Fisioterapia.aspx">PTA Fisioterapia</a></li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="container">

            <h3 class="text-center mb-4">PLANO TERAPÊUTICO PARA ALTA RESPONSÁVEL - FISIOTERAPIA</h3>

            <!-- Dados do Paciente -->
            <div class="card mb-4 p-3 shadow-sm">
                <div class="card-header">Dados do Paciente</div>
                <div class="row g-3 mt-2">
                    <div class="col-md-4">
                        <label class="form-label">Nome</label>
                        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">Idade</label>
                        <asp:TextBox ID="txtIdade" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">Setor</label>
                        <asp:TextBox ID="txtSetor" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">Leito</label>
                        <asp:TextBox ID="txtLeito" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">Médico</label>
                        <asp:TextBox ID="txtMedico" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">CRM</label>
                        <asp:TextBox ID="txtCRM" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">Data Internação</label>
                        <asp:TextBox ID="txtDataInternacao" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">Data Alta</label>
                        <asp:TextBox ID="txtDataAlta" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">HD</label>
                        <asp:TextBox ID="txtHD" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <!-- Comorbidades -->
            <div class="card mb-4 p-3 shadow-sm">
                <div class="card-header">Comorbidades</div>
                <div class="card-body">
                    <asp:CheckBox ID="chkDiabetes" runat="server" Text="Diabetes" CssClass="form-check-input me-2" />
                    <asp:CheckBox ID="chkHAS" runat="server" Text="HAS" CssClass="form-check-input me-2" />
                    <asp:CheckBox ID="chkClinico" runat="server" Text="Clínico" CssClass="form-check-input me-2" />
                    <asp:CheckBox ID="chkCirurgico" runat="server" Text="Cirúrgico" CssClass="form-check-input me-2" />
                </div>
            </div>

            <!-- Necessidade de Fisioterapia -->
            <div class="card mb-4 p-3 shadow-sm">
                <div class="card-header">Necessidade de Fisioterapia</div>
                <div class="card-body">
                    <asp:CheckBox ID="chkMotora" runat="server" Text="Motora" CssClass="form-check-input me-2" />
                    <asp:CheckBox ID="chkRespiratoria" runat="server" Text="Respiratória" CssClass="form-check-input me-2" />
                    <asp:CheckBox ID="chkDeambulacao" runat="server" Text="Deambulação precoce" CssClass="form-check-input me-2" /><br />
                    <asp:CheckBox ID="chkTosseProdutiva" runat="server" Text="Tosse Produtiva" CssClass="form-check-input me-2" />
                    <asp:CheckBox ID="chkTosseImprodutiva" runat="server" Text="Tosse Improdutiva" CssClass="form-check-input me-2" />
                    <asp:CheckBox ID="chkAspiracao" runat="server" Text="Aspiração - Realizar periódico" CssClass="form-check-input me-2" />
                </div>
            </div>

            <!-- Níveis de Dependência fixos -->
            <div class="card mb-4 p-3 shadow-sm">
                <div class="card-header">Níveis de Dependência / Independência</div>
                <asp:GridView ID="gvDependencia" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered dependencia-table" OnRowCommand="gvDependencia_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Atividade" HeaderText="Atividade" />
                        <asp:BoundField DataField="Caracteristica" HeaderText="Descrição/Característica" />
                        <asp:TemplateField HeaderText="Independente (1)">
                            <ItemTemplate>
                                <asp:Button ID="btnIndependente" runat="server" Text="✓" CssClass="btn btn-success btn-indep" CommandName="Independente" CommandArgument='<%# Eval("Atividade") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dependente Parcial (0,5)">
                            <ItemTemplate>
                                <asp:Button ID="btnDepParcial" runat="server" Text="◐" CssClass="btn btn-warning btn-dep" CommandName="DependenteParcial" CommandArgument='<%# Eval("Atividade") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dependente Total (0)">
                            <ItemTemplate>
                                <asp:Button ID="btnDepTotal" runat="server" Text="✗" CssClass="btn btn-danger btn-dep" CommandName="DependenteTotal" CommandArgument='<%# Eval("Atividade") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            <!-- Informações de Alta -->
            <div class="card mb-4 p-3 shadow-sm">
                <div class="card-header">Informações de Alta</div>
                <div class="card-body">
                    <asp:TextBox ID="txtInfoAlta" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="6"></asp:TextBox>
                </div>
            </div>

            <!-- Orientação para Alta Qualificada -->
            <div class="card mb-4 p-3 shadow-sm">
                <div class="card-header">Orientação para Alta Qualificada</div>
                <div class="row g-3 mt-2">
                    <div class="col-md-6">
                        <label class="form-label">Tipo de Orientação</label>
                        <asp:TextBox ID="txtTipoOrientacao" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label class="form-label">Descrição da Orientação</label>
                        <asp:TextBox ID="txtDescricaoOrientacao" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="3"></asp:TextBox>
                    </div>
                    <div class="col-md-12 mt-2">
                        <asp:CheckBox ID="chkOrientacaoPaciente" runat="server" Text="Paciente" CssClass="form-check-input me-2" />
                        <asp:CheckBox ID="chkOrientacaoFamiliar" runat="server" Text="Familiar" CssClass="form-check-input me-2" />
                        <asp:CheckBox ID="chkOrientacaoCuidador" runat="server" Text="Cuidador" CssClass="form-check-input me-2" />
                        <div class="mt-2">
                            <label class="form-label">Outros:</label>
                            <asp:TextBox ID="txtOutrosOrientacao" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Resumo Final -->
            <div class="card mb-4 p-3 shadow-sm">
                <p><b>Total de Pontos:</b> <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label></p>
                <p><b>Classificação:</b> <asp:Label ID="lblClassificacao" runat="server" Text="-"></asp:Label></p>
            </div>

            <!-- Botão Salvar -->
            <div class="row mb-4">
                <div class="col-md-12 text-center">
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar PTA" CssClass="btn btn-primary btn-lg" />
                </div>
            </div>

        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
