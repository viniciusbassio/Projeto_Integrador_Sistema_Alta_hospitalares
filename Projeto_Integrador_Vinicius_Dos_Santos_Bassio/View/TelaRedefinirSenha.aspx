<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaRedefinirSenha.aspx.cs" Inherits="Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View.TelaRedefinirSenha" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Redefinir Senha</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server" class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6 col-lg-5">
                <div class="card shadow-lg border-0 rounded-3">
                    <div class="card-body p-4">
                        <h3 class="text-center text-primary mb-4">
                            <i class="bi bi-shield-lock"></i> Redefinir Senha
                        </h3>

                        <div class="mb-3">
                            <asp:Label runat="server" ID="lblSenha" AssociatedControlID="txtSenha" 
                                       Text="Nova Senha:" CssClass="form-label fw-bold"></asp:Label>
                            <div class="input-group">
                                <span class="input-group-text bg-white"><i class="bi bi-key"></i></span>
                                <asp:TextBox runat="server" ID="txtSenha" CssClass="form-control" TextMode="Password" 
                                             placeholder="Digite a nova senha"></asp:TextBox>
                            </div>
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" ID="lblConfirmar" AssociatedControlID="txtConfirmar" 
                                       Text="Confirmar Senha:" CssClass="form-label fw-bold"></asp:Label>
                            <div class="input-group">
                                <span class="input-group-text bg-white"><i class="bi bi-key-fill"></i></span>
                                <asp:TextBox runat="server" ID="txtConfirmar" CssClass="form-control" TextMode="Password" 
                                             placeholder="Confirme a nova senha"></asp:TextBox>
                            </div>
                        </div>

                        <asp:Button runat="server" ID="btnRedefinir" Text="Redefinir Senha" 
                                    CssClass="btn btn-primary w-100 mb-2" OnClick="btnRedefinir_Click" />

                        <a href="TelaLogin.aspx" class="btn btn-outline-secondary w-100">
                            <i class="bi bi-arrow-left"></i> Voltar ao Login
                        </a>

                        <div class="mt-3 text-center">
                            <asp:Label runat="server" ID="lblMensagem" CssClass="fw-bold"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
