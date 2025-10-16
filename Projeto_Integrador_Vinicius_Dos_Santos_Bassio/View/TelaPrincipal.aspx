<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaPrincipal.aspx.cs" Inherits="Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View.TelaPrincipal" %>

<!DOCTYPE html>
<html lang="pt-br">
<head runat="server">
    <meta charset="utf-8" />
    <title>Sistema de Alta</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navbar -->
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

                        <!-- PTS -->
                        <li class="nav-item">
                            <a class="nav-link" href="PTS.aspx">PTS</a>
                        </li>

                        <!-- PTA -->
                        <li class="nav-item">
                            <a class="nav-link" href="PTA_Enfermeiro.aspx">PTA</a>
                        </li>

                        <!-- Administração (visível apenas para grupo permitido) -->
                        <li id="menuAdmin" runat="server" class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="dropdownAdmin" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                Administração
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="dropdownAdmin">
                                <li><h6 class="dropdown-header">Adminstrativo</h6></li>
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

        <!-- Conteúdo principal -->
        <div class="container mt-4">
            <h1>Bem-vindo ao Sistema de Alta</h1>
            <p>Escolha uma opção no menu acima para continuar.</p>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
