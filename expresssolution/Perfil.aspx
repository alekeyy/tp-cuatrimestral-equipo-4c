<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="expresssolution.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Mis datos / Configuracion Perfil (depende del analisis posterior de session)</h3>

    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Tipo Usuario: " runat="server" CssClass="form-label" />
                <asp:TextBox runat="server" CssClass="form-control" />
                <asp:Label Text="Nombre: " runat="server" CssClass="form-label" />
                <asp:TextBox runat="server" CssClass="form-control" />
                <asp:Label Text="Apellido: " runat="server" CssClass="form-label" />
                <asp:TextBox runat="server" CssClass="form-control" />
                <asp:Label Text="Email: " runat="server" CssClass="form-label" />
                <asp:TextBox runat="server" CssClass="form-control" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Aceptar" runat="server" CssClass="btn btn-primary" />
                <asp:Button Text="Cancelar" runat="server" CssClass="btn btn-secondary" />
            </div>
        </div>
    </div>

</asp:Content>
