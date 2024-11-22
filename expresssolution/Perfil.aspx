<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="expresssolution.Perfil" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row"> 
        <div class="col">
            <h3>Mis datos / Configuracion Perfil (depende del analisis posterior de session)</h3>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col">
                            <div class="card p-5">
                                <asp:Label Text="Tipo Usuario: " runat="server" CssClass="form-label" />
                                <asp:DropDownList runat="server" ID="ddlTipoUsuario" CssClass="form-control btn bg-pagina dropdown-toggle" AutoPostBack="true" >
                                </asp:DropDownList>
                                <asp:Label Text="Nombre: " runat="server" CssClass="form-label" />
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                                <asp:Label Text="Apellido: " runat="server" CssClass="form-label" />
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
                                <asp:Label Text="Email: " runat="server" CssClass="form-label" />
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                                
                                <asp:Label Text="Contraseña: " runat="server" CssClass="form-label" />
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtContra" type="password" />
                                <asp:Label Text="Contraseña Nueva: " runat="server" CssClass="form-label" />
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtContraNueva" type="password" />
                                <div>
                                    <asp:Label Text="" runat="server" ID="lblTelefonistaOcupado"/>
                                    <br />
                                    <asp:Button Text="Aceptar" ID="btnAceptar" runat="server" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                                    <asp:Button Text="Cancelar" ID="btnCancelar" runat="server" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
