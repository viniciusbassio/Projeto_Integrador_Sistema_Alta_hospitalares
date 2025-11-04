<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ALTA.aspx.cs" Inherits="Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View.ALTA" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Relatório de Alta</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
        }

        .card-header {
            font-weight: bold;
            text-transform: uppercase;
            background-color: #007ACC;
            color: white;
        }

        .section-title {
            font-weight: bold;
            margin-top: 20px;
            margin-bottom: 10px;
            text-transform: uppercase;
        }

        .form-label {
            font-weight: bold;
        }

        .readonly-textbox {
            background-color: #e9ecef;
            border: 1px solid #ced4da;
            padding: 0.375rem 0.75rem;
            border-radius: 0.25rem;
            width: 100%;
            resize: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h3 class="text-center mb-4">RELATÓRIO DE ALTA</h3>

            <!-- Dados do Paciente -->
            <div class="card mb-4 shadow-sm">
                <div class="card-header">Dados do Paciente</div>
                <div class="card-body">
                    <div class="row g-3 mb-2">
                        <div class="col-md-6">
                            <label class="form-label">Nome do Paciente</label>
                            <asp:TextBox ID="txtNomePaciente" runat="server" CssClass="readonly-textbox" ReadOnly="true" />
                        </div>
                        <div class="col-md-2">
                            <label class="form-label">Idade</label>
                            <asp:TextBox ID="txtIdadePaciente" runat="server" CssClass="readonly-textbox" ReadOnly="true" />
                        </div>
                        <div class="col-md-2">
                            <label class="form-label">Setor</label>
                            <asp:TextBox ID="txtSetor" runat="server" CssClass="readonly-textbox" ReadOnly="true" />
                        </div>
                        <div class="col-md-2">
                            <label class="form-label">Leito</label>
                            <asp:TextBox ID="txtLeito" runat="server" CssClass="readonly-textbox" ReadOnly="true" />
                        </div>
                        <div class="col-md-2">
                            <label class="form-label">N.Int</label>
                            <asp:TextBox ID="txtNInt" runat="server" CssClass="readonly-textbox" ReadOnly="true" />
                        </div>
                        <div class="col-md-6">
                            <label class="form-label">Médico</label>
                            <asp:TextBox ID="txtMedico" runat="server" CssClass="readonly-textbox" ReadOnly="true" />
                        </div>
                        <div class="col-md-6">
                            <label class="form-label">Data Internação / Alta</label>
                            <asp:TextBox ID="txtDataInternacao" runat="server" CssClass="readonly-textbox" ReadOnly="true" />
                        </div>
                    </div>
                </div>
            </div>

            <!-- Diagnóstico e Motivo da Internação -->
            <div class="card mb-4 shadow-sm">
                <div class="card-header">Diagnóstico / Motivo da Internação</div>
                <div class="card-body">
                    <div class="mb-2">
                        <label class="form-label">Diagnóstico</label>
                        <asp:TextBox ID="txtDiagnostico" runat="server" CssClass="readonly-textbox" TextMode="MultiLine" Rows="3" ReadOnly="true" />
                    </div>
                    <div class="mb-2">
                        <label class="form-label">Motivo da Internação (Sintomas)</label>
                        <asp:TextBox ID="txtMotivoInternacao" runat="server" CssClass="readonly-textbox" TextMode="MultiLine" Rows="3" ReadOnly="true" />
                    </div>
                    <div class="mb-2">
                        <label class="form-label">Alergias</label>
                        <asp:TextBox ID="txtAlergias" runat="server" CssClass="readonly-textbox" ReadOnly="true" />
                    </div>
                    <div class="mb-2">
                        <label class="form-label">Paciente Portador de</label>
                        <asp:TextBox ID="txtPacientePortador" runat="server" CssClass="readonly-textbox" ReadOnly="true" />
                    </div>
                </div>
            </div>

            <!-- Dados da Internação -->
            <div class="card mb-4 shadow-sm">
                <div class="card-header">Dados da Internação</div>
                <div class="card-body">
                    <asp:TextBox ID="txtDadosInternacao" runat="server" CssClass="readonly-textbox" TextMode="MultiLine" Rows="6" ReadOnly="true" />
                </div>
            </div>

            <!-- Informações de Alta -->
            <div class="card mb-4 shadow-sm">
                <div class="card-header">Informações de Alta</div>
                <div class="card-body">
                    <asp:TextBox ID="txtInformacoesAlta" runat="server" CssClass="readonly-textbox" TextMode="MultiLine" Rows="6" ReadOnly="true" />
                </div>
            </div>

            <!-- Orientação fornecida -->
            <div class="card mb-4 shadow-sm">
                <div class="card-header">Orientação Fornecida</div>
                <div class="card-body">
                    <div class="mb-2">
                        <label class="form-label">Tipo de Orientação</label>
                        <asp:TextBox ID="txtTipoOrientacao" runat="server" CssClass="readonly-textbox" ReadOnly="true" />
                    </div>
                    <div class="mb-2">
                        <label class="form-label">Descrição da Orientação</label>
                        <asp:TextBox ID="txtDescricaoOrientacao" runat="server" CssClass="readonly-textbox" TextMode="MultiLine" Rows="4" ReadOnly="true" />
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkPaciente" runat="server" CssClass="form-check-input" Enabled="false" />
                        <label class="form-check-label" for="chkPaciente">Paciente</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkFamiliar" runat="server" CssClass="form-check-input" Enabled="false" />
                        <label class="form-check-label" for="chkFamiliar">Familiar</label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="chkCuidador" runat="server" CssClass="form-check-input" Enabled="false" />
                        <label class="form-check-label" for="chkCuidador">Cuidador</label>
                    </div>
                </div>
            </div>

            <!-- Botão Voltar / Imprimir -->
            <div class="row mb-4">
                <div class="col-md-12 text-center">
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar Alta" CssClass="btn btn-success btn-lg me-2" OnClick="btnSalvar_Click" />
                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn btn-secondary btn-lg me-2" OnClick="btnVoltar_Click" />
                    <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="btn btn-outline-primary btn-lg" />
                </div>
            </div>


        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
