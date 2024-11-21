<%@ Page Title="Pantalla Principal" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="expresssolution.Principal" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <%//EN ESTE APARTADO SE DEFINIRIA LAS ACCCIONES A REALIZAR POR EL TELEFONISTA %>
    <div class="row">
        <div class="col">
            <div class="card card-custom d-flex align-items-center">
              <asp:Image ImageUrl="~/images/agregar.png" runat="server" Width="300px" CssClass="card-img-top mt-2" AlternateText="Imagen Funcionalidad Lista Incidencias"/>
              <div class="card-body w-100 px-5">
                <h5 class="card-title">Cargar Incidencias</h5>
                <p class="card-text">Espacio para crear incidencias.</p>
                <a href="CargarIncidencia.aspx" class="btn btn-primary d-flex">Ingresar</a>
              </div>
            </div>
        </div>
        <div class="col">
            <div class="card card-custom d-flex align-items-center">
              <asp:Image ImageUrl="~/images/lista.png" runat="server" Width="300px" CssClass="card-img-top mt-2" AlternateText="Imagen Funcionalidad Lista Incidencias"/>
              <div class="card-body w-100 px-5">
                <h5 class="card-title">Lista de Incidencias</h5>
                <p class="card-text">Consultar lista de incidencias asignadas/cargadas.</p>
                <a href="ListadoIncidencias.aspx" class="btn btn-primary d-flex">Ir</a>
              </div>
            </div>
        </div>

         <%if (!(Seguridad.seguridad.EsCliente(Session["usuario"])) && (!(Seguridad.seguridad.EsSupervisor(Session["usuario"])))){ %>
        <div class="col">
            <div class="card card-custom d-flex align-items-center">
              <asp:Image ImageUrl="~/images/agregarUsuario.png" runat="server" Width="300px" CssClass="card-img-top mt-2" AlternateText="Imagen Funcionalidad Lista Incidencias"/>
              <div class="card-body w-100 px-5">
                <h5 class="card-title">Dar de Alta</h5>
                <p class="card-text">Crearle un usuario a un cliente que no este registrado en el sistema.</p>
                <a href="Registro.aspx" class="btn btn-primary d-flex">Crear Cliente</a> <%--/AGREGAR UNA PAGINA PUEDE SER LA MISMA DE REGISTRO PERO LA LOGICA DEBERIA REDIRECCIONAR A OTRA PANTALLA EN LUGAR DE HACER LO MISMO DEL LOGIN (PODRIA ARREGLARSE USANDO LA SESSION) /--%>
              </div>
            </div>
        </div>
        
        <%} %>

        <%if (!(Seguridad.seguridad.EsCliente(Session["usuario"]))){ %>
        <div class="col">
            <div class="card card-custom d-flex align-items-center">
              <asp:Image ImageUrl="~/images/usuarios.png" runat="server" Width="300px" CssClass="card-img-top mt-2" AlternateText="Imagen Funcionalidad Lista Usuarios"/>
              <div class="card-body w-100 px-5">
                <h5 class="card-title">Lista Usuarios</h5>
                <p class="card-text">Consultar lista de usuarios creados en el sitio.</p>
                <a href="ListadoUsuarios.aspx" class="btn btn-primary d-flex">VER USUARIOS</a>
              </div>
            </div>
        </div>
        <%} %>
    </div>
</asp:Content>
