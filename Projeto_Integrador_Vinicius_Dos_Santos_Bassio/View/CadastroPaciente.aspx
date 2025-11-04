<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroPaciente.aspx.cs" Inherits="Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View.CadastroPaciente" %>

<!DOCTYPE html>
<%-- Pronto Adicionar validações para CPF Telefone e EMAIL CASO Sobre tempo e corrigir NAVBAR --%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cadastro Pacientes</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
            <div class="container-fluid">
                <a class="navbar-brand" href="TelaPrincipal.aspx">Sistema de Alta</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Alternar navegação">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarNavDropdown">
                    <ul class="navbar-nav">

                        <!-- Pacientes -->
                        <li class="nav-item">
                            <a class="nav-link" href="CadastroPaciente.aspx">Pacientes</a>
                        </li>

                        <!-- Profissionais -->
                        <li class="nav-item">
                            <a class="nav-link" href="Profissionais.aspx">Profissionais</a>
                        </li>

                        <!-- PTS -->
                        <li class="nav-item">
                            <a class="nav-link" href="PTS.aspx">PTS</a>
                        </li>

                        <!-- PTA -->
                        <li class="nav-item">
                            <a class="nav-link" href="PTA.aspx">PTA</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="ALTA.aspx">Alta</a>
                        </li>
                        <!-- Administração (visível apenas para grupo permitido) -->
                        <li id="menuAdmin" runat="server" class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="dropdownAdmin" role="button" data-bs-toggle="dropdown" aria-expanded="false">Administração
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="dropdownAdmin">
                                <li>
                                    <h6 class="dropdown-header">Adminstrativo</h6>
                                </li>
                                <li><a class="dropdown-item" href="#">Listar Usuários</a></li>
                                <li><a class="dropdown-item" href="CadastroGrupoUsuario.aspx">Cadastrar Tipo de Profissional</a></li>
                                <li><a class="dropdown-item" href="CadastroUsuario.aspx">Cadastrar Usuário</a></li>
                                <li><a class="dropdown-item" href="#">Redefinir Senha do Usuário</a></li>
                                <li><a class="dropdown-item" href="#">Excluir Usuário</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <div class="container mt-5" style="max-width: 400px;">
            <h1 class="mb-4 text-center">Cadastro de Paciente</h1>
            <p accesskey="1" class="mb-4 text-muted text-center">Preencha os campos abaixo para cadastrar um novo paciente.</p>
            <div class="mb-3">
                <asp:Label ID="lblNome" runat="server" Text="Nome Completo:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" Placeholder="Nome Completo"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblDataNascimento" runat="server" Text="Data de Nascimento:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="form-control" Placeholder="DD/MM/AAAA"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblCPF" runat="server" Text="CPF:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control" Placeholder="000.000.000-00"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblEndereco" runat="server" Text="Endereço:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtEndereco" runat="server" CssClass="form-control" Placeholder="Endereço Completo"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblTelefone" runat="server" Text="Telefone:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control" Placeholder="(00) 00000-0000"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblSexo" runat="server" Text="Sexo:" CssClass="form-label"></asp:Label>
                <asp:RadioButtonList ID="rblSexo" runat="server" CssClass="mb-3">
                    <asp:ListItem Value="Masculino">Masculino</asp:ListItem>
                    <asp:ListItem Value="Feminino">Feminino</asp:ListItem>
                    <asp:ListItem Value="Outro">Outro</asp:ListItem>
                </asp:RadioButtonList>
            </div>

            <div class="mb-3">
                <asp:Label ID="lblEsf" runat="server" Text="ESF:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtEsf" runat="server" CssClass="form-control" Placeholder="ESF:"></asp:TextBox>
            </div>

            <asp:ScriptManager ID="ScriptManager1" runat="server" />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Label ID="lblEstado" runat="server" Text="Selecione o Estado do paciente:" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" />
                        <p></p>
                        <asp:Label ID="lblCidade" runat="server" Text="Selecione a Cidade do paciente:" CssClass="form-label mt-3"></asp:Label>
                        <asp:DropDownList ID="ddlCidade" runat="server" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="mb-3">
                <asp:Label ID="lblMensagem" runat="server" Text="" ForeColor="Red" CssClass="form-text"></asp:Label>
            </div>
            <div class="d-grid">
                <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="btn btn-primary btn-block" OnClick="btnCadastrar_Click" />
            </div>
        </div>
    </form>
</body>
</html>
