<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PTA_Enfermeiro.aspx.cs" Inherits="Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View.PTA_Enfermeiro" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js"></script>
    <title>PTA Enfermeiro</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navbar -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary mb-4">
            <div class="container-fluid">
                <a class="navbar-brand" href="TelaPrincipal.aspx">Sistema de Alta</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Alternar navegação">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNavDropdown">
                    <ul class="navbar-nav">
                        <li class="nav-item"><a class="nav-link" href="CadastroPaciente.aspx">Pacientes</a></li>
                        <li class="nav-item"><a class="nav-link" href="Profissionais.aspx">Profissionais</a></li>
                        <li class="nav-item"><a class="nav-link" href="PTS.aspx">PTS</a></li>
                        <li class="nav-item"><a class="nav-link" href="PTA_Enfermeiro.aspx">PTA</a></li>
                        <li id="menuAdmin" runat="server" class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="dropdownAdmin" role="button" data-bs-toggle="dropdown" aria-expanded="false">Administração</a>
                            <ul class="dropdown-menu" aria-labelledby="dropdownAdmin">
                                <li>
                                    <h6 class="dropdown-header">Administrativo</h6>
                                </li>
                                <li><a class="dropdown-item" href="#">Listar Usuários</a></li>
                                <li><a class="dropdown-item" href="CadastroGrupoUsuario.aspx">Cadastrar Tipo de Profissional</a></li>
                                <li><a class="dropdown-item" href="CadastroUsuario.aspx">Cadastrar Usuário</a></li>
                                <li><a class="dropdown-item" href="#">Editar Usuário</a></li>
                                <li><a class="dropdown-item" href="#">Excluir Usuário</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="container">
            <h2 class="mb-4 text-center">PLANO TERAPÊUTICO PARA ALTA RESPONSÁVEL - ENFERMAGEM</h2>

            <!-- Dados do Paciente -->
            <div class="card mb-4">
                <div class="card-header">Dados do Paciente</div>
                <div class="card-body row g-3">
                    <label class="form-label">Nome:</label>
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtNome_TextChanged" list="listaPacientes"></asp:TextBox>
                    <datalist id="listaPacientes" runat="server"></datalist>
                    <div class="col-md-2">
                        <asp:Label runat="server" ID="lblIdade" CssClass="form-label" Text="Idade:" />
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">Setor:</label>
                        <asp:TextBox ID="txtSetor" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">Leito:</label>
                        <asp:TextBox ID="txtLeito" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">Médico responsável:</label>
                        <asp:DropDownList ID="ddlMedico" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">CRM:</label>
                        <asp:TextBox ID="txtCRM" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">Data Internação:</label>
                        <asp:TextBox ID="txtDataInternacao" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">HD:</label>
                        <asp:TextBox ID="txtHD" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <!-- Comorbidades -->
            <div class="card mb-4">
                <div class="card-header">Comorbidades</div>
                <div class="card-body">
                    <asp:CheckBox ID="chkDiabetes" runat="server" Text="Diabetes" CssClass="form-check-input me-2" />
                    <asp:CheckBox ID="chkHAS" runat="server" Text="HAS" CssClass="form-check-input me-2" />
                    <asp:CheckBox ID="chkClinico" runat="server" Text="Clínico" CssClass="form-check-input me-2" />
                    <asp:CheckBox ID="chkCirurgico" runat="server" Text="Cirúrgico" CssClass="form-check-input me-2" />
                </div>
            </div>

            <!-- Nível de Consciência -->
            <div class="card mb-4">
                <div class="card-header">Nível de Consciência (Glasgow)</div>
                <div class="card-body">
                    <asp:TextBox ID="txtGlasgow" runat="server" CssClass="form-control w-25"></asp:TextBox>
                </div>
            </div>

            <!-- Necessidades na Alta -->
            <div class="card mb-4">
                <div class="card-header">Necessidades na Alta</div>
                <div class="card-body row">
                    <div class="col-md-4">
                        <asp:CheckBox ID="chkUlceraPressao" runat="server" Text="Cuidados com úlcera de pressão" CssClass="form-check-input me-2" /><br />
                        <asp:CheckBox ID="chkEstomas" runat="server" Text="Estomas" CssClass="form-check-input me-2" /><br />
                        <asp:CheckBox ID="chkSondaVesical" runat="server" Text="Sonda vesical" CssClass="form-check-input me-2" /><br />
                        <asp:CheckBox ID="chkTraqueostomia" runat="server" Text="Traqueostomia" CssClass="form-check-input me-2" /><br />
                    </div>
                    <div class="col-md-4">
                        <asp:CheckBox ID="chkOxigenio" runat="server" Text="Oxigênio" CssClass="form-check-input me-2" /><br />
                        <asp:CheckBox ID="chkAspiracao" runat="server" Text="Aspiração orotraqueal/endotraqueal" CssClass="form-check-input me-2" /><br />
                        <asp:CheckBox ID="chkCurativos" runat="server" Text="Curativos" CssClass="form-check-input me-2" />
                    </div>
                </div>
            </div>

            <!-- Orientações -->
            <div class="card mb-4">
                <div class="card-header">Orientações Realizadas Para</div>
                <div class="card-body">
                    <asp:CheckBox ID="chkOrientPaciente" runat="server" Text="Paciente" CssClass="form-check-input me-2" />
                    <asp:CheckBox ID="chkOrientFamiliar" runat="server" Text="Familiar/Cuidador" CssClass="form-check-input me-2" />
                </div>
            </div>

            <!-- Tipos de Orientações -->
            <div class="card mb-4">
                <div class="card-header">Tipos de Orientações</div>
                <div class="card-body row">
                    <div class="col-md-6">
                        <asp:CheckBox ID="chkCurativosOrient" runat="server" Text="Para curativos" CssClass="form-check-input me-2" /><br />
                        <asp:CheckBox ID="chkPrevencao" runat="server" Text="Prevenção e cuidados com úlcera de pressão" CssClass="form-check-input me-2" /><br />
                        <asp:CheckBox ID="chkSondasEstomas" runat="server" Text="Cuidados com sondas/estomas" CssClass="form-check-input me-2" /><br />
                    </div>
                    <div class="col-md-6">
                        <asp:CheckBox ID="chkAspiracaoTraqueo" runat="server" Text="Aspiração de vias aéreas e traqueostomias" CssClass="form-check-input me-2" /><br />
                        <asp:CheckBox ID="chkDietaAssistida" runat="server" Text="Orientação da dieta assistida" CssClass="form-check-input me-2" /><br />
                        <asp:CheckBox ID="chkCuidadosPele" runat="server" Text="Cuidados com a pele e higienização corporal" CssClass="form-check-input me-2" />
                    </div>
                </div>
            </div>

            <!-- Descrição do Caso -->
            <div class="card mb-4">
                <div class="card-header">Descrição do Caso Clínico</div>
                <div class="card-body">
                    <asp:TextBox ID="txtDescricao" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="4"></asp:TextBox>
                </div>
            </div>

            <!-- Orientação Alta Qualificada -->
            <div class="card mb-4">
                <div class="card-header">Orientação para Alta Qualificada</div>
                <div class="card-body row g-3">
                    <div class="col-md-6">
                        <label class="form-label">Tipo de Orientação:</label>
                        <asp:TextBox ID="txtTipoOrientacao" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label class="form-label">Descrição da Orientação:</label>
                        <asp:TextBox ID="txtDescricaoOrientacao" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="3"></asp:TextBox>
                    </div>
                    <div class="col-md-12 mt-2">
                        <asp:CheckBox ID="chkOrientacaoPaciente" runat="server" Text="Paciente" CssClass="form-check-input me-2" />
                        <asp:CheckBox ID="chkOrientacaoFamiliar" runat="server" Text="Familiar" CssClass="form-check-input me-2" />
                        <asp:CheckBox ID="chkOrientacaoCuidador" runat="server" Text="Cuidador" CssClass="form-check-input me-2" />
                    </div>
                </div>
            </div>

            <!-- Botão Salvar -->
            <div class="row mb-4">
                <div class="col-md-12 text-end">
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-success" OnClick="btnSalvar_Click" />
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#<%= ddlMedico.ClientID %>').select2({
                placeholder: "Selecione o médico...",
                allowClear: true,
                width: '100%'
            });
        });
    </script>

</body>
</html>
