    <%@ Page Title="Express Solutions" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="expresssolution.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="row d-flex">
            <div class="col">
                <asp:Image ImageUrl="./images/portada.jpg" runat="server" Width="700px" />
            </div>

            <div class="col-4 align-content-center">
                <h1 class="page--title">EXPRESS SOLUTION</h1>
                <h2 class="page--subtitle">Tu callcenter por <span class="subtitulo">excelencia</span></h2>
                <p class="page--text">
                    Con años respaldando nuestro compromiso al cliente ofrecemos la mas completa y rapida respuesta a las incidencias de nuestros clientes 
                <%if (!(Seguridad.seguridad.SessionActiva(Session["usuario"])))
                  {%>
                        <span class="pregunta">¿Aun no sos parte?</span></p>                                   
                        <asp:Button runat="server" CssClass="btn btn-primary d-flex justify-content-center p-2" Text="UNETE" ID="btnUnete" OnClick="btnUnete_Click" />
                <%} 
                  else
                  { %>
                        </p> 
                  <%}%>
            </div>
        </div>
    </main>
</asp:Content>
