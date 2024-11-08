<%@ Page Title="Ingreso" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="expresssolution.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
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
                    <h5 class="card-title texto-pagina">Iniciar Sesion</h5>
                    <div class="mt-1">
                        <asp:Label Text="Correo: " runat="server" CssClass="form-label" />
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail"/>
                        <asp:Label Text="Contraseña: " runat="server" CssClass="form-label" />
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" type="password"/>
                    </div>
                    <p>¿No tienes cuenta? <a href="Registro.aspx" class="card-text">Registrate</a></p>
                    <div class="mt-3">
                        <asp:Button Text="Ingresar" runat="server" CssClass="btn btn-primary" ID="btnIngresar" OnClick="btnIngresar_Click" />
                        <asp:Button Text="Cancelar" runat="server" CssClass="btn btn-secondary" ID="btnCancelar" OnClick="btnCancelar_Click"/>
                    </div>
                  </div>
                </div>
              </div>
            </div>
        </div>
    </div>
</asp:Content>
