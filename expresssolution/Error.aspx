<%@ Page Title="Error!" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="expresssolution.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <h2>hubo un error :(</h2>
            <asp:Label Text="" runat="server" ID="lblError"/>
            <asp:Button Text="Regresar" runat="server" ID="btnRegresar" OnClick="btnRegresar_Click" CssClass="btn btn-primary"/>
        </div>
    </div>
</asp:Content>
