<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="expresssolution.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Bienvenido registrese con su usuario y contraseña</h3>
    <p>
        (en esta pantalla debera actuar de diferentes maneras dependiendo de quien sea el que accedio:
         <br /> - un usuario nuevo.
         <br /> - un telefonista registrando a un usuario)
    </p>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Nombre: " runat="server" CssClass="form-label" />
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre"/>
                <asp:Label Text="Apellido: " runat="server" CssClass="form-label" />
                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido"/>
                <asp:Label Text="Correo: " runat="server" CssClass="form-label" />
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail"/>
                <asp:Label Text="Contraseña: " runat="server" CssClass="form-label" />
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" type="password"/>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Registrarse" runat="server" CssClass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" />
                <asp:Button Text="Cancelar" runat="server" CssClass="btn btn-secondary" ID="btnCancelar" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
