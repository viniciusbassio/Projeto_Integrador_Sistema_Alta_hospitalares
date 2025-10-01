<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PTA_Servico_Social.aspx.cs" Inherits="Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View.PTA_Servico_Social" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>PTA Serviço Social</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
        }

        .card-header {
            font-weight: bold;
            text-transform: uppercase;
            background-color: #007ACC; /* Azul igual ao Psicologia */
            color: white;
        }

        .form-check {
            margin-bottom: 5px;
        }

        .section-title {
            font-weight: bold;
            margin-top: 20px;
            margin-bottom: 10px;
            text-transform: uppercase;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h3 class="text-center mb-4">PLANO TERAPÊUTICO PARA ALTA RESPONSÁVEL - SERVIÇO SOCIAL</h3>

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
                            <label class="form-label">N.Int</label>
                            <asp:TextBox ID="txtNInt" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                </div>
            </div>

            <!-- Moradia -->
            <div class="card mb-4 shadow-sm">
                <div class="card-header">Mora com alguém</div>
                <div class="card-body">
                    <div class="form-check">
                        <asp:CheckBox ID="chkSozinho" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkSozinho">Sozinho</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkConjuge" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkConjuge">Cônjuge</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkFilho" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkFilho">Filho(a)</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkIrmao" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkIrmao">Irmão(a)</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkNoraGenro" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkNoraGenro">Nora/Genro</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkInstitucionalizado" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkInstitucionalizado">Institucionalizado</label>
                    </div>
                </div>
            </div>

            <!-- Familiar responsável -->
            <div class="card mb-4 shadow-sm">
                <div class="card-header">Familiar responsável / Referência</div>
                <div class="card-body">
                    <div class="row g-3">
                        <div class="col-md-6">
                            <label class="form-label">Nome</label>
                            <asp:TextBox ID="txtFamiliarResponsavel" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-6">
                            <label class="form-label">Telefone</label>
                            <asp:TextBox ID="txtTelefoneFamiliar" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                </div>
            </div>

            <!-- Renda -->
            <div class="card mb-4 shadow-sm">
                <div class="card-header">Renda Proveniente de</div>
                <div class="card-body">
                    <div class="form-check">
                        <asp:CheckBox ID="chkAposentadoria" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkAposentadoria">Aposentadoria</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkBolsaFamilia" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkBolsaFamilia">Bolsa Família</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkPensao" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkPensao">Pensão</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkSalario" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkSalario">Salário</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkBPC" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkBPC">BPC</label>
                    </div>
                </div>
            </div>

            <!-- Ações Desenvolvidas -->
            <div class="card mb-4 shadow-sm">
                <div class="card-header">Ações Desenvolvidas</div>
                <div class="card-body">
                    <div class="form-check">
                        <asp:CheckBox ID="chkOrientacaoDireitos" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkOrientacaoDireitos">Orientação sobre direitos / previdência</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkSituacaoNegligencia" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkSituacaoNegligencia">Situação de negligência / violência</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkEncaminhamentoSaude" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkEncaminhamentoSaude">Encaminhamento para rede básica de saúde</label>
                    </div>
                    <div class="mt-2">
                        <label class="form-label">Outros:</label>
                        <asp:TextBox ID="txtOutrosAcoes" runat="server" CssClass="form-control" />
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

            <!-- Orientação para Alta -->
            <div class="card mb-4 shadow-sm">
                <div class="card-header">Orientação para Alta Qualificada</div>
                <div class="card-body">
                    <div class="form-check">
                        <asp:CheckBox ID="chkOrientacaoPaciente" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkOrientacaoPaciente">Paciente</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkOrientacaoFamiliar" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkOrientacaoFamiliar">Familiar / Cuidador</label>
                    </div>
                    <div class="mt-2">
                        <label class="form-label">Descrição da Orientação:</label>
                        <asp:TextBox ID="txtDescricaoOrientacao" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="4" />
                    </div>
                </div>
            </div>

            <!-- Botão Salvar -->
            <div class="row mb-4">
                <div class="col-md-12 text-center">
                    <asp:Button ID="btnSalvarServicoSocial" runat="server" Text="Salvar PTA" CssClass="btn btn-primary btn-lg" />
                </div>
            </div>

        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
