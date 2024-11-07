<%@ Page Title="Cargar Incidencia" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CargarIncidencia.aspx.cs" Inherits="expresssolution.CargarIncidencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Bienvenido a la seccion de carga de incidencias</h3>
    <p>
        (en este caso dependiendo el usuario que acceda hay que validarlo 
        <br />
        y en base a esto seran las opciones / acciones que se le permitiran).
    </p>
    <div class="row">
        <div class="col">
            <asp:Label Text="Nombre: " runat="server" CssClass="form-label"/>
            <asp:TextBox runat="server" ID="txtNombreIncidencia" CssClass="form-control"/>
        </div>
        <div class="col">
            <asp:Label Text="Cliente: " runat="server" CssClass="form-label"/>
            <asp:DropDownList runat="server" ID="ddlCliente" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="col">
            <asp:Label Text="Descripcion de problematica: " runat="server" CssClass="form-label"/>
            <asp:TextBox runat="server" ID="txtDescripcionIncidencia" CssClass="form-control"/>
        </div>
    </div>

    <div class="row">
        <div class="col">
            <asp:Label Text="Estado: " runat="server" CssClass="form-label"/>
            <asp:DropDownList runat="server" ID="ddlEstadoIncidencia" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="col">
            <asp:Label Text="Tipo: " runat="server" CssClass="form-label"/>
            <asp:DropDownList runat="server" ID="ddlTipoIncidencia" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="col">
            <asp:Label Text="Prioridad: " runat="server" CssClass="form-label"/>
            <asp:DropDownList runat="server" ID="ddlPrioridadIncidencia" CssClass="form-control">
            </asp:DropDownList>
        </div>
    </div>

    <div class="row">
        <div class="col">
            <asp:Label Text="Telefonista: " runat="server" CssClass="form-label"/>
            <asp:DropDownList runat="server" ID="ddlTelefonista" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="col">
            <asp:Label Text="Comentario: " runat="server" CssClass="form-label"/>
            <asp:TextBox runat="server" ID="txtComentarioIncidencia" CssClass="form-control"/>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-success" OnClick="btnAgregar_Click"/>
        </div>
    </div>
</asp:Content>
