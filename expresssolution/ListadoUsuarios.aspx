<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoUsuarios.aspx.cs" Inherits="expresssolution.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Lista Usuarios</h3>

    <asp:GridView ID="dgvListaUsuarios" runat="server" CssClass="table table-light"
    AutoGenerateColumns="false"
    >
    <Columns>
        <asp:BoundField HeaderText="ID" DataField="Id"/>
        <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
        <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
        <asp:BoundField HeaderText="Tipo Usuario" DataField="TipoUsuario"/>
        <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText=" Modificar " />
    </Columns>
    </asp:GridView>
</asp:Content>
