<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaPacientes_Alta.aspx.cs" Inherits="Projeto_Integrador_Vinicius_Dos_Santos_Bassio.View.ListaPacientes_Alta" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Pacientes sem Alta</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">

            <h2 class="mb-3">Pacientes sem Alta</h2>

            <!-- 🔍 Filtro de busca -->
            <div class="row mb-3">
                <div class="col-md-5">
                    <asp:TextBox ID="txtBusca" runat="server" CssClass="form-control" Placeholder="Buscar por nome ou CPF..."></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                    <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="btn btn-secondary ms-2" OnClick="btnLimpar_Click" />
                </div>
            </div>

            <!-- 🧾 Tabela de pacientes -->
            <asp:GridView ID="gvPacientesSemAlta" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" OnRowCommand="gvPacientesSemAlta_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ID_PACIENTE" HeaderText="ID" />
                    <asp:BoundField DataField="NOME" HeaderText="Nome" />
                    <asp:BoundField DataField="CPF" HeaderText="CPF" />
                    <asp:BoundField DataField="TELEFONE" HeaderText="Telefone" />
                    <asp:BoundField DataField="ESF" HeaderText="ESF" />
                    <asp:TemplateField HeaderText="Ações">
                        <ItemTemplate>
                            <asp:Button ID="btnDarAlta" runat="server" Text="Dar Alta" CssClass="btn btn-success btn-sm" CommandName="DarAlta" CommandArgument='<%# Eval("ID_PACIENTE") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <!-- 🔙 Botão Voltar -->
            <div class="mt-3">
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn btn-secondary" OnClick="btnVoltar_Click" />
            </div>
        </div>
    </form>
</body>
</html>
