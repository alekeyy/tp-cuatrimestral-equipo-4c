<%@ Page Title="Incidencias" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoIncidencias.aspx.cs" Inherits="expresssolution.ListadoIncidencias" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <h3>Bienvenido a la seccion de vista de incidentes</h3>
            <br />
            <p><b>- en esta seccion en particular, supervisor solo puede darle a modificar, para asignar telefonista, nada mas</b></p>
            <p><b>- administrador puede darle a modificar y modificar todos los datos</b></p>
            <p><b>- telefonista ya filtra por sus incidencias asignadas </b></p>
            <p><b>- cliente ya filtra por sus incidencias cargadas</b></p>

            
            <asp:GridView ID="dgvListaIncidenciasAsignadas" runat="server" CssClass="table table-active table-bordered"
                AutoGenerateColumns="false" OnSelectedIndexChanged="dgvListaIncidenciasAsignadas_SelectedIndexChanged" DataKeyNames="IDIncidencia">
                <Columns>
                    <asp:BoundField HeaderText="IDIncidencia" DataField="IDIncidencia" Visible="false" />
                    <asp:BoundField HeaderText="Id" DataField="Id" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Telefonista Asignado" DataField="Telefonista" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText=" Ver Detalles" />
                    </Columns>
                </asp:GridView>

            <asp:Button Text="Agregar" runat="server" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-primary" />
        </div>
    </div>

</asp:Content>
