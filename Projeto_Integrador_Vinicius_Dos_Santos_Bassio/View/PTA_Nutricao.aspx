<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PTA_Nutricao.aspx.cs" Inherits="Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View.PTA_Nutricao" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>PTA Nutrição</title>
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

        .nutricao-table th, .nutricao-table td {
            vertical-align: middle;
            text-align: center;
        }

        .btn-acao {
            width: 100%;
            margin-bottom: 2px;
        }

        .card-header {
            font-weight: bold;
            text-transform: uppercase;
            background-color: #007ACC;
            color: white;
        }

        .form-check {
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h3 class="text-center mb-4">PLANO TERAPÊUTICO PARA ALTA RESPONSÁVEL - NUTRIÇÃO</h3>

            <!-- Dados do Paciente -->
            <div class="card mb-4 shadow-sm">
                <div class="card-header">Dados do Paciente</div>
                <div class="card-body">
                    <div class="row g-3">
                        <div class="col-md-4">
                            <label class="form-label">Nome</label>
                            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-2">
                            <label class="form-label">Idade</label>
                            <asp:TextBox ID="txtIdade" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-2">
                            <label class="form-label">Setor</label>
                            <asp:TextBox ID="txtSetor" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-2">
                            <label class="form-label">Leito</label>
                            <asp:TextBox ID="txtLeito" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-2">
                            <label class="form-label">Médico</label>
                            <asp:TextBox ID="txtMedico" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-2">
                            <label class="form-label">CRM</label>
                            <asp:TextBox ID="txtCRM" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-2">
                            <label class="form-label">Data Internação</label>
                            <asp:TextBox ID="txtDataInternacao" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-2">
                            <label class="form-label">Data Alta</label>
                            <asp:TextBox ID="txtDataAlta" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-2">
                            <label class="form-label">N.Int</label>
                            <asp:TextBox ID="txtNInt" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                </div>
            </div>

            <!-- Indicadores de Necessidade Nutricional -->
            <div class="card mb-4 shadow-sm">
                <div class="card-header">Indicadores de Necessidade Nutricional</div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-check">
                                <asp:CheckBox ID="chkInapetencia" runat="server" CssClass="form-check-input" />
                                <label class="form-check-label" for="chkInapetencia">Inapetência</label>
                            </div>
                            <div class="form-check">
                                <asp:CheckBox ID="chkDesnutricao" runat="server" CssClass="form-check-input" />
                                <label class="form-check-label" for="chkDesnutricao">Desnutrição</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-check">
                                <asp:CheckBox ID="chkRiscoDesnutricao" runat="server" CssClass="form-check-input" />
                                <label class="form-check-label" for="chkRiscoDesnutricao">Risco de Desnutrição</label>
                            </div>
                            <div class="form-check">
                                <asp:CheckBox ID="chkSobrepeso" runat="server" CssClass="form-check-input" />
                                <label class="form-check-label" for="chkSobrepeso">Sobrepeso</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-check">
                                <asp:CheckBox ID="chkObesidade" runat="server" CssClass="form-check-input" />
                                <label class="form-check-label" for="chkObesidade">Obesidade</label>
                            </div>
                            <div class="form-check">
                                <asp:CheckBox ID="chkNPT" runat="server" CssClass="form-check-input" />
                                <label class="form-check-label" for="chkNPT">NPT</label>
                            </div>
                        </div>
                    </div>
                    <div class="mt-2">
                        <label class="form-label">Outros:</label>
                        <asp:TextBox ID="txtOutrosIndicadores" runat="server" CssClass="form-control" />
                    </div>
                </div>
            </div>

            <!-- Tipo de Dieta -->
            <div class="card mb-4 shadow-sm">
                <div class="card-header">Paciente terá alta usando</div>
                <div class="card-body">
                    <div class="form-check">
                        <asp:CheckBox ID="chkOral" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkOral">Oral</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkOralAssistida" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkOralAssistida">Oral Assistida</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkEnteral" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkEnteral">Enteral</label>
                    </div>
                    <div class="mt-2">
                        <label class="form-label">Outros:</label>
                        <asp:TextBox ID="txtOutrosDieta" runat="server" CssClass="form-control" />
                    </div>
                </div>
            </div>

            <!-- Orientações -->
            <div class="card mb-4 shadow-sm">
                <div class="card-header">Orientações realizadas para</div>
                <div class="card-body">
                    <div class="form-check">
                        <asp:CheckBox ID="chkOrientacaoPaciente" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkOrientacaoPaciente">Paciente</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkOrientacaoFamiliar" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkOrientacaoFamiliar">Familiar/Cuidador</label>
                    </div>
                    <div class="mt-2">
                        <label class="form-label">Outros:</label>
                        <asp:TextBox ID="txtOutrosOrientacoes" runat="server" CssClass="form-control" />
                    </div>
                </div>
            </div>

            <!-- Ações Desenvolvidas -->
            <div class="card mb-4 shadow-sm">
                <div class="card-header">Ações Desenvolvidas</div>
                <div class="card-body">
                    <div class="form-check">
                        <asp:CheckBox ID="chkOrientacaoDietaEnteral" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkOrientacaoDietaEnteral">Orientação para administração de dieta enteral</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkEncaminhamento" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkEncaminhamento">Encaminhamento</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkContatoRedeBasica" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkContatoRedeBasica">Contato com a rede básica</label>
                    </div>
                    <div class="mt-2">
                        <label class="form-label">Outras orientações:</label>
                        <asp:TextBox ID="txtOutrasAcoes" runat="server" CssClass="form-control" />
                    </div>
                </div>
            </div>

            <!-- Descrição do Caso Clínico -->
            <div class="card mb-4 shadow-sm">
                <div class="card-header">Descrição do Caso Clínico</div>
                <div class="card-body">
                    <asp:TextBox ID="txtDescricaoCaso" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="6" />
                </div>
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
