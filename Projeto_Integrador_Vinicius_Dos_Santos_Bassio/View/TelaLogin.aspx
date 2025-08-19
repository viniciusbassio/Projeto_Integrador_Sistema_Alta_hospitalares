<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaLogin.aspx.cs" Inherits="Projeto_Integrador_Vinicius_Dos_Santos_Bassio.TelaLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="TelaLogin.css" rel="stylesheet" />
    <title>Bem-vindo à tela de login</title>

</head>
<body>
    <form id="form1" runat="server">
        <div class="Informacoes_Login">
            <h1>Seja bem-vindo ao sistema da Santa Casa de Misericordia de Adamantina</h1>

            <div class="Informacoes_usuario">
                <p>Adicione seu usuário:</p>
                <asp:TextBox runat="server" ID="TXTusuario" CssClass="input-text" />
            </div>

            <div class="div_senha">
                <p>Insira sua senha:</p>
                <asp:TextBox runat="server" ID="TXTSenha" TextMode="Password" CssClass="input-text" />
            </div>
            <div class="div_esqueci_senha">
                <asp:HyperLink runat="server" ID="HYPesqueciSenha" NavigateUrl="~/TelaEsqueciSenha.aspx" Text="Esqueci minha senha" CssClass="link-esqueci-senha" />
            </div>
            <br />
            <div class="Button">
                <asp:Button runat="server" ID="btnLogar" Text="Entrar" CssClass="btn-login" OnClick="BtnLogar_Click1" />
            </div>
            <div class="Mensagem_Erro">
                <asp:Label runat="server" ID="lblMensagemErro" CssClass="mensagem-erro" Text="" Visible="false"/>
            </div>
        </div>
    </form>
</body>
</html>
