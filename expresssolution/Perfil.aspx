<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="expresssolution.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Mis datos / Configuracion Perfil (depende del analisis posterior de session)</h3>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">

                        <asp:Label Text="Tipo Usuario: " runat="server" CssClass="form-label" />
                        <asp:DropDownList runat="server" ID="ddlTipoUsuario" CssClass="form-control" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:Label Text="Nombre: " runat="server" CssClass="form-label" />
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                        <asp:Label Text="Apellido: " runat="server" CssClass="form-label" />
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
                        <asp:Label Text="Email: " runat="server" CssClass="form-label" />
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />

                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="" runat="server" ID="lblTelefonistaOcupado"/>
                        <br />
                        <asp:Button Text="Aceptar" ID="btnAceptar" runat="server" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                        <asp:Button Text="Cancelar" ID="btnCancelar" runat="server" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
