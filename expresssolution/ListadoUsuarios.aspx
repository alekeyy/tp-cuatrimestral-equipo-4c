<%@ Page Title="Lista de usuarios" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoUsuarios.aspx.cs" Inherits="expresssolution.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" ID="updatePanel">
    <ContentTemplate>
        <div class="row">
            <div class="col">
                <h3>Lista Usuarios</h3>
                 <ul class="nav nav-pills d-flex justify-content-center" id="pills-tab" role="tablist">
                    <li class="nav-item" role="presentation">
                      <a class="nav-link active" id="pills-clients-tab" data-bs-toggle="pill" href="#pills-clients" role="tab" aria-controls="pills-clients" aria-selected="true">Clientes</a>
                    </li>
                    <li class="nav-item" role="presentation">
                      <a class="nav-link" id="pills-users-tab" data-bs-toggle="pill" href="#pills-users" role="tab" aria-controls="pills-users" aria-selected="false">Usuarios</a>
                    </li>
                  </ul>

                 <!-- Contenido de las pestañas -->
                  <div class="tab-content mt-2" id="pills-tabContent">
                    <div class="tab-pane fade show active" id="pills-clients" role="tabpanel" aria-labelledby="pills-clients-tab">

                        <!-- CLIENTES -->
                        <asp:GridView ID="dgvListaClientes" runat="server" CssClass="table table-light" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvListaClientes_SelectedIndexChanged" DataKeyNames="Id" AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvListaClientes_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="ID" DataField="Id" />
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:BoundField HeaderText="Tipo Usuario" DataField="tipoUsuario.Descripcion" />
                                <asp:BoundField HeaderText="Correo" DataField="Email" />
                                <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText=" Modificar " />
                            </Columns>
                        </asp:GridView>

                    </div>
                    <div class="tab-pane fade" id="pills-users" role="tabpanel" aria-labelledby="pills-users-tab">

                        <!-- USUARIOS -->
                        <asp:GridView ID="dgvListaUsuarios" runat="server" CssClass="table table-light" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvListaUsuarios_SelectedIndexChanged" DataKeyNames="Id" AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvListaUsuarios_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="ID" DataField="Id" />
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:BoundField HeaderText="Tipo Usuario" DataField="tipoUsuario.Descripcion" />
                                <asp:BoundField HeaderText="Correo" DataField="Email" />
                                <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText=" Modificar " />
                            </Columns>
                        </asp:GridView>

                    </div>
                  </div>  
            </div>
        </div>
    </ContentTemplate>
    </asp:UpdatePanel>  
</asp:Content>
