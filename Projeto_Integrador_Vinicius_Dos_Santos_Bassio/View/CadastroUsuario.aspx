<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroUsuario.aspx.cs" Inherits="Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View.CadastroUsuario" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastro de Usuário</title>
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
                    <a class="nav-link" href="Pacientes.aspx">Pacientes</a>
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

                <!-- Administração (visível apenas para grupo permitido) -->
                <li id="menuAdmin" runat="server" class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="dropdownAdmin" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                        Administração
                    </a>
                    <ul class="dropdown-menu" aria-labelledby="dropdownAdmin">
                        <li><h6 class="dropdown-header">Usuários</h6></li>
                        <li><a class="dropdown-item" href="#">Listar Usuários</a></li>
                        <li><a class="dropdown-item" href="CadastroUsuario.aspx">Cadastrar Usuário</a></li>
                        <li><a class="dropdown-item" href="#">Editar Usuário</a></li>
                        <li><a class="dropdown-item" href="#">Excluir Usuário</a></li>
                    </ul>
                </li>
            </ul>
        </div>
    </div>
</nav>
        <div class="container mt-5" style="max-width:400px;">
            <h2 class="mb-4">Cadastro de Usuário</h2>
            <div class="mb-3">
                <label for="TXTusuario" class="form-label">Usuário</label>
                <asp:TextBox runat="server" ID="TXTusuario" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="TXTSenha" class="form-label">Senha</label>
                <asp:TextBox runat="server" ID="TXTSenha" TextMode="Password" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="DDLGrupo" class="form-label">Grupo de Usuário</label>
                <asp:DropDownList runat="server" ID="DDLGrupo" CssClass="form-select">
                    <asp:ListItem Value="" Text="Selecione qual o Tipo de usuario" />
                </asp:DropDownList>
            </div>
            <asp:Button runat="server" ID="btnCadastrar" Text="Cadastrar" CssClass="btn btn-primary w-100" OnClick="btnCadastrar_Click" />
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>