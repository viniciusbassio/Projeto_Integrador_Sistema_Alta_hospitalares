<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaEsqueciSenha.aspx.cs" Inherits="Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View.TelaEsqueciSenha" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <title>Esqueci Minha Senha</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet"/>
</head>
<body class="bg-light">
    <form id="form1" runat="server" class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6 col-lg-5">
                <div class="card shadow-lg border-0 rounded-3">
                    <div class="card-body p-4">
                        <h3 class="text-center text-primary mb-4">
                            <i class="bi bi-shield-lock"></i> Recuperar Senha
                        </h3>

                        <div class="mb-3">
                            <asp:Label runat="server" ID="lblEmail" AssociatedControlID="txtEmail" 
                                       Text="Digite seu e-mail:" CssClass="form-label fw-bold"></asp:Label>
                            <div class="input-group">
                                <span class="input-group-text bg-white"><i class="bi bi-envelope"></i></span>
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" 
                                             placeholder="exemplo@email.com"></asp:TextBox>
                            </div>
                        </div>

                        <asp:Button runat="server" ID="btnEnviar" Text="Enviar Link de Redefinição" 
                                    CssClass="btn btn-primary w-100 mb-2" OnClick="btnEnviar_Click"/>
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
