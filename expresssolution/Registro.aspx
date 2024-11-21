<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="expresssolution.Registro" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col d-flex justify-content-center align-items-center">
            <div class="card mb-3">
              <div class="row no-gutters">
                <div class="col-md-4 d-flex align-items-center">
                  <img src="https://gbce.es/wp-content/uploads/2023/08/verde-du-poligonos_07-v1_a.jpeg" class="card-img" alt="Herramientas">
                </div>
                <div class="col-md-8">
                  <div class="card-body">
                    <h5 class="card-title texto-pagina">Registrate</h5>
                    <div class="mt-1">
                        <asp:Label Text="Nombre: " runat="server" CssClass="form-label" />
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre"/>
                        <asp:Label Text="Apellido: " runat="server" CssClass="form-label" />
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido"/>
                        <asp:Label Text="Correo: " runat="server" CssClass="form-label" />
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail"/>
                        <asp:Label Text="Contraseña: " runat="server" CssClass="form-label" />
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" type="password"/>
                    </div>
                    <p>¿Ya tenes una cuenta existente? <a href="Login.aspx" class="card-text">Ingresa</a></p>
                    <div class="mt-3">
                        <asp:Button 
                            Text="Registrarse" runat="server" CssClass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" />
                        <asp:Button Text="Cancelar" runat="server" CssClass="btn btn-secondary" ID="Button2" OnClick="btnCancelar_Click" />
                    </div>
                  </div>
                </div>
              </div>
            </div>
        </div>
    </div>
</asp:Content>
