<%@ Page Title="Ingreso" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="expresssolution.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col d-flex flex-column justify-content-center align-items-center">
                    <h5 class="seccion-bg mb-0 p-1">Inicio Sesion</h5>
                    <div class="card mb-3">
                        <div class="row no-gutters">
                            <div class="col-md-4 d-flex align-items-center">
                                <img src="https://gbce.es/wp-content/uploads/2023/08/verde-du-poligonos_07-v1_a.jpeg" class="card-img" alt="Herramientas">
                            </div>
                            <div class="col-md-8">
                                <div class="card-body">
                                    <div class="mt-1">
                                        <asp:Label Text="" runat="server" ID="txtObligatorio" /> <br />

                                        <asp:Label Text="Correo: " runat="server" CssClass="form-label" />
                                        <asp:Label Text="" runat="server" ID="txtFormatoCorreo" />
                                        <asp:Label Text="" runat="server" ID="txtCorreoObligatorio" />
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" AutoPostBack="true" />


                                        <asp:Label Text="Contraseña: " runat="server" CssClass="form-label" />
                                        <asp:Label Text="" runat="server" ID="txtPassObligatoria" />
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" type="password" AutoPostBack="true" />
                                    </div>
                                    <p>¿Olvidaste la contraseña? <a href="Recuperar.aspx" class="card-text">Recuperar Contraseña</a></p>
                                    <div class="mt-1">
                                        <asp:Button Text="Ingresar" runat="server" CssClass="btn btn-primary" ID="btnIngresar" OnClick="btnIngresar_Click" />
                                        <asp:Button Text="Cancelar" runat="server" CssClass="btn btn-secondary" ID="btnCancelar" OnClick="btnCancelar_Click" />
                                    </div>
                                    <p>¿No tienes cuenta? <a href="Registro.aspx" class="card-text">Registrate</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
