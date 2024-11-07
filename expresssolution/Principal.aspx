<%@ Page Title="Principal - Menu" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="expresssolution.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <%//EN ESTE APARTADO SE DEFINIRIA LAS ACCCIONES A REALIZAR POR EL TELEFONISTA %>
    <h3>En este apartado el TELEFONISTA podra elegir que acciones realizar</h3>

    <div class="row">
        <div class="col">
            <p>
                - revisar su lista de incidencias asignada
                <br />
                cargadas por el mismo, o asignadas a él por el supervisor.
                <br />
                y en base a esto realizar modificaciones / actualizaciones, etc...
                <br />
                <a href="ListadoIncidencias.aspx">
                    <asp:Image ImageUrl="~/images/lista.png" runat="server" Width="300px"/>
                </a>
            </p>
        </div>

        <div class="col">
            <p>
                - dar de alta un nuevo cliente, 
                <br />
                si es que el mismo no estaba ingresado en el sistema...
                <br />
                <br />
                <br />
                <a href="Registro.aspx"> <%--/AGREGAR UNA PAGINA PUEDE SER LA MISMA DE REGISTRO PERO LA LOGICA DEBERIA REDIRECCIONAR A OTRA PANTALLA EN LUGAR DE HACER LO MISMO DEL LOGIN (PODRIA ARREGLARSE USANDO LA SESSION) /--%>
                    <asp:Image ImageUrl="~/images/agregarUsuario.png" runat="server" Width="300px"/>
                </a>
            </p>
        </div>

        <div class="col">
            <p>
                - cargar una incidencia 
                <br />
                si es que el cliente no puede hacerlo por su cuenta
                <br />
                <br />
                <br />
                <a href="CargarIncidencia.aspx">
                    <asp:Image ImageUrl="~/images/agregar.png" runat="server" Width="300px"/>
                </a>
            </p>
        </div>
    </div>
    <br />
    <hr />
    <br />

    <%//EN ESTE APARTADO SE DEFINIRIA LAS ACCCIONES A REALIZAR POR EL CLIENTE %>
    
    <h3>En este apartado el CLIENTE podra elegir que acciones realizar</h3>

    <div class="row">
        <div class="col">
            <p>
                - revisar su lista de incidencias propias y su estado, 
                <br />
                pero ~no modificarlas~
                <br />
                <a href="ListadoIncidencias.aspx">
                    <asp:Image ImageUrl="~/images/lista.png" runat="server" Width="300px"/>
                </a>
            </p>
        </div>

        <div class="col">
            <p>
                - cargar una incidencia 
                <br />
                <br />
                <a href="CargarIncidencia.aspx">
                    <asp:Image ImageUrl="~/images/agregar.png" runat="server" Width="300px"/>
                </a>
            </p>
        </div>
    </div>
    <br />
    <hr />
    <br />


    <%//EN ESTE APARTADO SE DEFINIRIA LAS ACCCIONES A REALIZAR POR EL ADMINISTRADOR %>

    <h3>En este apartado el ADMINISTRADOR podra elegir que acciones realizar</h3>

    <div class="row">
        <div class="col">
            <p>
                - revisar su lista de incidencias GENERAL 
                <br />
                (PUEDE VER TODAS DE TODOS LOS USUARIOS/TELEFONISTAS)
                <br />
                y en base a esto realizar modificaciones / actualizaciones, etc...
                <br />
                <a href="ListadoIncidencias.aspx">
                    <asp:Image ImageUrl="~/images/lista.png" runat="server" Width="300px"/>
                </a>
            </p>
        </div>

        <div class="col">
            <p>
                - dar de alta un nuevo cliente 
                <br />
                <br />
                <br />
                <br />
                <a href="Registro.aspx">
                    <asp:Image ImageUrl="~/images/agregarUsuario.png" runat="server" Width="300px"/>
                </a>
            </p>
        </div>

        <div class="col">
            <p>
                - cargar una incidencia 
                <br />
                <br />
                <br />
                <br />
                <a href="CargarIncidencia.aspx">
                    <asp:Image ImageUrl="~/images/agregar.png" runat="server" Width="300px"/>
                </a>
            </p>
        </div>
        
        <div class="col">
            <p>
                - VERIFICAR LA LISTA DE USUARIOS 
                <br />
                Y EN BASE A ESTA MODIFICAR NIVELES DE ACCESO O DATOS
                <br />
                <a href="ListadoUsuarios.aspx">
                    <asp:Image ImageUrl="~/images/usuarios.png" runat="server" Width="300px"/>
                </a>
            </p>
        </div>
    </div>

    <br />
    <hr />
    <br />

    
    <%//EN ESTE APARTADO SE DEFINIRIA LAS ACCCIONES A REALIZAR POR EL SUPERVISOR %>
    
    <h3>En este apartado el SUPERVISOR podra elegir que acciones realizar</h3>

    <div class="row">
        <div class="col">
            <p>
                - revisar su lista de incidencias GENERAL 
                <br />
                (PUEDE VER TODAS DE TODOS LOS USUARIOS/TELEFONISTAS)
                <br />
                y en base a esto MODIFICAR SOLO EL TELEFONISTA ASIGNADO
                <br />
                <br />
                <a href="ListadoIncidencias.aspx">
                    <asp:Image ImageUrl="~/images/lista.png" runat="server" Width="300px"/>
                </a>
            </p>
        </div>
        
        <div class="col">
            <p>
                - VERIFICAR LA LISTA DE USUARIOS 
                <br />
                SOLO EN MODO LECTURA.
                <br />
                <br />
                <br />
                <a href="ListadoUsuarios.aspx">
                    <asp:Image ImageUrl="~/images/usuarios.png" runat="server" Width="300px"/>
                </a>
            </p>
        </div>
    </div>

    <br />
    <hr />
    <br />
</asp:Content>
