<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="expresssolution.Exito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <div class="row">
    <div class="col d-flex flex-column justify-content-center align-items-center">
        <h5 class="seccion-bg mb-0 p-1">Iniciar Sesion</h5>
        <div class="card mb-3">
            <div class="row no-gutters">
                <div class="col-md-4 d-flex align-items-center">
                    <img src="https://cdn-icons-png.flaticon.com/512/5610/5610944.png" class="card-img" alt="Tilde Accion Correcta">
                </div>
                <div class="col-md-8">
                    <div class="card-body">
                        <div class="mt-1">
                            <asp:Label ID="AccionExitosa" runat="server" Text=""></asp:Label>
                        </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
