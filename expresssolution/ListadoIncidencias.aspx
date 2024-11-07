<%@ Page Title="Incidencias" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoIncidencias.aspx.cs" Inherits="expresssolution.ListadoIncidencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h3>Bienvenido a la seccion de vista de incidentes</h3>
        <br />
       <%-- 
        <br />
        / asignados 
        <br />
        / personales 
        <br />
        / totales 
        <br />
        (depende el usuario que ingrese)</h3>
    <p>
        (por ahora se tiene precargada la lista de tipos de incidentes para que el dgv no quede vacio,
        <br />
        y tengamos una vista de como quedaria).

    </p>--%>

    <asp:GridView ID="dgvListaIncidenciasAsignadas" runat="server" CssClass="table table-active table-bordered"
        AutoGenerateColumns="false"
        >
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id"/>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
            <asp:BoundField HeaderText="Telefonista Asignado" DataField="Telefonista"/>
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText=" Modificar " />
        </Columns>
    </asp:GridView>

    <asp:Button Text="Agregar" runat="server" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-primary" />
</asp:Content>
