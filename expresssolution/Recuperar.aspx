<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Recuperar.aspx.cs" Inherits="expresssolution.Recuperar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col d-flex flex-column justify-content-center align-items-center">
                    <h5 class="seccion-bg mb-0 p-1">Recuperar Contraseña</h5>
                    <div class="card mb-3">
                        <div class="row no-gutters">
                            <div class="col-md-4 d-flex align-items-center">
                                <img src="https://gbce.es/wp-content/uploads/2023/08/verde-du-poligonos_07-v1_a.jpeg" class="card-img" alt="Herramientas">
                            </div>
                            <div class="col-md-8">
                                <div class="card-body">
                                    <div class="mt-1">
                                        <p>A continuacion, se te enviara un correo con los datos necesarios para restablecer tu contraseña. Ingresa tu correo para buscar tu cuenta.</p>

                                        
                                        <asp:Label Text="" runat="server" ID="txtCamposObligatorios"/>
                                        <br />

                                        <asp:Label Text="Correo: " runat="server" CssClass="form-label" />
                                        <asp:Label Text="" runat="server" ID="txtValidacionCorreo"/>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" AutoPostBack="true" />


                                    </div>
                                    <div class="mt-3">
                                        <asp:Button Text="Enviar correo" runat="server" CssClass="btn btn-primary" ID="btnRecuperar" OnClick="btnRecuperar_Click" />
                                        <asp:Button Text="Cancelar" runat="server" CssClass="btn btn-secondary" ID="btnCancelar" OnClick="btnCancelar_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
