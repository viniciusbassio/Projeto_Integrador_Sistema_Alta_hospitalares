<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaPrincipal.aspx.cs"
    Inherits="Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View.TelaPrincipal" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Tela Principal</title>

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Ícones -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">

       
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary shadow-sm">
            <div class="container-fluid">

                <a class="navbar-brand fw-bold" href="#">
                    Sistema Hospitalar
                </a>

                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" 
                        data-bs-target="#navbarPrincipal">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarPrincipal">

                    <!-- MENUS ESQUERDA -->
                    <ul class="navbar-nav me-auto">

                        <!-- Menu Admin -->
                        <li class="nav-item dropdown" id="menuAdmin" runat="server">
                            <a class="nav-link dropdown-toggle" href="#" data-bs-toggle="dropdown">
                                Administração
                            </a>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="CadastroUsuario.aspx">Usuários</a></li>
                                <li><a class="dropdown-item" href="CadastroGrupo.aspx">Grupos</a></li>
                                <li><a class="dropdown-item" href="CadastroCidade.aspx">Cidades</a></li>
                                <li><a class="dropdown-item" href="CadastroEstado.aspx">Estados</a></li>
                            </ul>
                        </li>

                        <!-- Menu PTA -->
                        <li class="nav-item dropdown" id="menuPTA" runat="server">
                            <a class="nav-link dropdown-toggle" href="#" data-bs-toggle="dropdown">
                                PTA
                            </a>
                            <ul class="dropdown-menu">
                                <li>
                                    <asp:LinkButton ID="btnPTA" runat="server" CssClass="dropdown-item" 
                                        OnClick="btnPTA_Click">
                                        Acessar PTA
                                    </asp:LinkButton>
                                </li>
                            </ul>
                        </li>

                        <!-- Menu PTS -->
                        <li class="nav-item dropdown" id="menuPTS" runat="server">
                            <a class="nav-link dropdown-toggle" href="#" data-bs-toggle="dropdown">
                                PTS
                            </a>
                            <ul class="dropdown-menu">
                                <li>
                                    <asp:LinkButton ID="btnPTS" runat="server" CssClass="dropdown-item" 
                                        OnClick="btnPTS_Click">
                                        Acessar PTS
                                    </asp:LinkButton>
                                </li>
                            </ul>
                        </li>

                        <!-- Menu ALTA -->
                        <li class="nav-item dropdown" id="menuAlta" runat="server">
                            <a class="nav-link dropdown-toggle" href="#" data-bs-toggle="dropdown">
                                Alta
                            </a>
                            <ul class="dropdown-menu">
                                <li>
                                    <asp:LinkButton ID="btnAlta" runat="server" CssClass="dropdown-item" 
                                        OnClick="btnAlta_Click">
                                        Registrar Alta
                                    </asp:LinkButton>
                                </li>
                            </ul>
                        </li>

                    </ul>

                    <!-- DIREITA (usuário + logout) -->
                    <ul class="navbar-nav ms-auto">

                        <li class="nav-item">
                            <span class="navbar-text text-white me-3">
                                <i class="bi bi-person-circle"></i>
                                <asp:Label ID="lblUsuarioLogado" runat="server" />
                            </span>
                        </li>

                        <li class="nav-item">
                            <a href="TelaLogin.aspx" class="nav-link text-warning fw-bold">
                                Sair
                            </a>
                        </li>

                    </ul>

                </div>
            </div>
        </nav>

        <!-- =============================== -->
        <!-- DASHBOARD                       -->
        <!-- =============================== -->
        <div class="container py-4">

            <div class="row g-4">

                <!-- Card Pacientes Internados -->
                <div class="col-md-3">
                    <div class="card shadow-sm text-center">
                        <div class="card-body">
                            <i class="bi bi-hospital fs-1"></i>
                            <h5 class="mt-2">Internados</h5>
                            <asp:Label ID="lblPacientesInternados" runat="server" 
                                CssClass="fw-bold fs-4 text-primary"></asp:Label>
                        </div>
                    </div>
                </div>

                <!-- Card Altas Hoje -->
                <div class="col-md-3">
                    <div class="card shadow-sm text-center">
                        <div class="card-body">
                            <i class="bi bi-journal-check fs-1"></i>
                            <h5 class="mt-2">Altas Hoje</h5>
                            <asp:Label ID="lblAltasHoje" runat="server" 
                                CssClass="fw-bold fs-4 text-success"></asp:Label>
                        </div>
                    </div>
                </div>

                <!-- Card PTS Realizados -->
                <div class="col-md-3">
                    <div class="card shadow-sm text-center">
                        <div class="card-body">
                            <i class="bi bi-clipboard-pulse fs-1"></i>
                            <h5 class="mt-2">PTS Emitidos</h5>
                            <asp:Label ID="lblPTS" runat="server" 
                                CssClass="fw-bold fs-4 text-info"></asp:Label>
                        </div>
                    </div>
                </div>

                <!-- Card Profissionais -->
                <div class="col-md-3">
                    <div class="card shadow-sm text-center">
                        <div class="card-body">
                            <i class="bi bi-people fs-1"></i>
                            <h5 class="mt-2">Profissionais</h5>
                            <asp:Label ID="lblProfissionais" runat="server" 
                                CssClass="fw-bold fs-4 text-secondary"></asp:Label>
                        </div>
                    </div>
                </div>

            </div>

            <!-- =============================== -->
            <!-- GRÁFICO DE OCUPAÇÃO             -->
            <!-- =============================== -->
            <div class="mt-5 text-center">
                <h4>Ocupação Hospitalar</h4>

                <asp:Image ID="imgGraficoOcupacao" runat="server"
                    CssClass="img-fluid" Style="max-width: 450px;" />
            </div>

        </div>

        <!-- FOOTER -->
        <footer class="bg-primary text-white text-center py-3 mt-4">
            © 2025 - Sistema Hospitalar
        </footer>

        <!-- Bootstrap -->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

    </form>
</body>
</html>
