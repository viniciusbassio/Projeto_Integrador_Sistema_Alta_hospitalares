<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PTA_ServicoSocial.aspx.cs" Inherits="Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View.PTA_ServicoSocial" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <title>PTA Serviço Social</title>
</head>
<body>
    <form id="form1" runat="server">
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
                                <li><h6 class="dropdown-header">Administrativo</h6></li>
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
            <h2 class="mb-4 text-center">PLANO TERAPÊUTICO PARA ALTA RESPONSÁVEL - SERVIÇO SOCIAL</h2>

            <!-- Dados Sociais -->
            <div class="card mb-4">
                <div class="card-header bg-primary text-white">Dados Sociais</div>
                <div class="card-body row g-3">
                    <div class="col-md-6">
                        <label for="txtRenda" class="form-label">Renda Familiar</label>
                        <asp:TextBox ID="txtRenda" runat="server" CssClass="form-control" placeholder="Informe a renda familiar"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label for="txtResponsavel" class="form-label">Familiar Responsável</label>
                        <asp:TextBox ID="txtResponsavel" runat="server" CssClass="form-control" placeholder="Informe o nome do responsável"></asp:TextBox>
                    </div>
                </div>
            </div>

            <!-- Benefícios e Rede de Apoio -->
            <div class="card mb-4">
                <div class="card-header bg-primary text-white">Benefícios e Rede de Apoio</div>
                <div class="card-body row g-3">
                    <div class="col-md-6">
                        <label for="txtBeneficios" class="form-label">Benefícios Sociais</label>
                        <asp:TextBox ID="txtBeneficios" runat="server" CssClass="form-control" placeholder="Ex: Bolsa Família, BPC, etc."></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label for="txtApoio" class="form-label">Rede de Apoio</label>
                        <asp:TextBox ID="txtApoio" runat="server" CssClass="form-control" placeholder="Descreva a rede de apoio familiar ou comunitária"></asp:TextBox>
                    </div>
                </div>
            </div>

            <!-- Ações Desenvolvidas -->
            <div class="card mb-4">
                <div class="card-header bg-primary text-white">Ações Desenvolvidas</div>
                <div class="card-body">
                    <asp:TextBox ID="txtAcoes" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Descreva as ações realizadas no acompanhamento do paciente"></asp:TextBox>
                </div>
            </div>

            <!-- Observações -->
            <div class="card mb-4">
                <div class="card-header bg-primary text-white">Observações</div>
                <div class="card-body">
                    <asp:TextBox ID="txtObservacoes" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" placeholder="Inclua observações relevantes sobre o caso"></asp:TextBox>
                </div>
            </div>

            <!-- Botão Salvar (alinhado à direita) - mantido verde -->
            <div class="row mb-4">
                <div class="col-md-12 text-end">
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar PTA" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>