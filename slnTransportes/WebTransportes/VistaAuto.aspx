<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaAuto.aspx.cs" Inherits="WebTransportes.VistaAuto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblMarca" runat="server" Text="Marca"></asp:Label>
        <asp:DropDownList ID="ddlMarcas" runat="server" OnSelectedIndexChanged="ddlMarcas_SelectedIndexChanged">
        </asp:DropDownList>
        <p>
            <asp:Label ID="lblModelo" runat="server" Text="Modelo"></asp:Label>
            <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblMatricula" runat="server" Text="Matricula"></asp:Label>
            <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        </p>
        <p>
            <asp:Label ID="lblPrecio" runat="server" Text="Precio"></asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
        </p>
        <p>
            <asp:Label ID="lblID" runat="server" Text="ID"></asp:Label>
            <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        </p>
        <asp:Label ID="lblBuscarPorMarca" runat="server" Text="Buscar autos por Marca"></asp:Label>
        <asp:DropDownList ID="ddlAutosPorMarca" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAutosPorMarca_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:GridView ID="gridAutos" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
