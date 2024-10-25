<%@ Page Title="Login" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="expresssolution.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Bienvenido ingrese con su usuario y contraseña</h3>

    <div class="row">
        <div class="col">
            <div class="mb-3">
                <asp:Label Text="Usuario: " runat="server" CssClass="form-label" />
                <asp:TextBox runat="server" CssClass="form-control" />
                <asp:Label Text="Contraseña: " runat="server" CssClass="form-label" />
                <asp:TextBox runat="server" CssClass="form-control" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Ingresar" runat="server" CssClass="btn btn-primary" ID="btnIngresar" OnClick="btnIngresar_Click" />
                <asp:Button Text="Cancelar" runat="server" CssClass="btn btn-secondary" ID="btnCancelar" OnClick="btnCancelar_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
