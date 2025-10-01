<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PTS.aspx.cs" Inherits="Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View.PTS" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <title>Plano Terapêutico Singular</title>
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
            <h1 class="mb-4 text-center">Plano Terapêutico Singular</h1>
            <div class="row mb-3">
                <div class="col-md-6">
                    <asp:Label runat="server" ID="lblNome" Text="Digite aqui o nome do paciente:" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtNome" list="listaPacientes" AutoPostBack="true" OnTextChanged="txtNome_TextChanged" CssClass="form-control" placeholder="Digite o nome" />
                    <datalist id="listaPacientes" runat="server"></datalist>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblIdade" Text="Idade:" CssClass="form-label" />
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblEndereco" Text="Endereço:" CssClass="form-label" />
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblEsf" Text="Preencha aqui o ESF" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtESF" CssClass="form-control" />
                </div>
                <div class="col-md-4">
                    <asp:Label Text="Enfermeiro:" runat="server" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtEnfermeiro" list="listaenfermeiros" AutoPostBack="true" CssClass="form-control" />
                    <datalist id="listaenfermeiros" runat="server"></datalist>
                </div>
                <div class="col-md-4">
                    <asp:Label Text="Médica:" runat="server" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtMedica" list="listaMedicas" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                    <datalist id="listaMedicas" runat="server"></datalist>
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-md-4">
                    <asp:Label Text="Nutricionista:" runat="server" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtNutricionista" list="listaNutricionistas" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                    <datalist id="listaNutricionistas" runat="server"></datalist>
                </div>
                <div class="col-md-4">
                    <asp:Label Text="Fisioterapeuta:" runat="server" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtFisioterapeuta" list="listaFisioterapeutas" AutoPostBack="true" CssClass="form-control" />
                    <datalist id="listaFisioterapeutas" runat="server"></datalist>
                </div>
                <div class="col-md-4">
                    <asp:Label Text="Psicólogo:" runat="server" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtPsicologo" list="listaPsicologos" AutoPostBack="true" CssClass="form-control" />
                    <datalist id="listaPsicologos" runat="server"></datalist>
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-md-6">
                    <asp:Label ID="lblMedicamentos" runat="server" CssClass="form-label">Medicamento de uso contínuo:</asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lblEnfermagem" runat="server" CssClass="form-label">Enfermagem:</asp:Label>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <asp:Label runat="server" ID="lblFisioterapia" CssClass="form-label">Fisioterapia:</asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" ID="lblNutricao" CssClass="form-label">Nutrição:</asp:Label>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <asp:Label runat="server" ID="lblCuidadores" CssClass="form-label">Cuidadores:</asp:Label>
                    <asp:TextBox runat="server" ID="txtCuidadores" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <asp:RadioButtonList ID="RBLPrazo" runat="server" CssClass="form-check">
                        <asp:ListItem Value="CurtoPrazo" Text="Curto Prazo"></asp:ListItem>
                        <asp:ListItem Value="MedioPrazo" Text="Médio Prazo"></asp:ListItem>
                        <asp:ListItem Value="LongoPrazo" Text="Longo Prazo"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-12">
                    <asp:Label ID="lblacoes" runat="server" CssClass="form-label">Adicione as ações a serem tomadas:</asp:Label>
                    <asp:TextBox runat="server" ID="txtAcoes"></asp:TextBox>
                </div>
                 <asp:Button runat="server" ID="btnSalvarPTS" Text="Salvar PTS" CssClass="btn btn-success mt-3" />
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
