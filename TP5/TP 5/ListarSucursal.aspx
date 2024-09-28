<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarSucursal.aspx.cs" Inherits="TP_5.ListarSucursal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            margin-left: 0px;
        }
        .auto-style3 {
            width: 289px;
        }
        .auto-style5 {
            width: 54px;
        }
        .auto-style6 {
            width: 190px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlAgregarSucursal" runat="server" NavigateUrl="~/AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlListarSucursal" runat="server" NavigateUrl="~/ListarSucursal.aspx">Listado de Sucursales</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlEliminarSucursal" runat="server" NavigateUrl="~/EliminarSucursal.aspx">Eliminar Sucursales</asp:HyperLink>
                    <br />
            <br />
            <br />
    &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblAgregarSucursal" runat="server" Text="Listado de Sucursales:" Font-Size="XX-Large"></asp:Label>
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblBusqueda" runat="server" Text="Buesqueda -&gt; Ingrese ID Sucursal:"></asp:Label>
                    </td>
                    <td class="auto-style6">&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtIdSucursal" runat="server" CssClass="auto-style2"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="btnFiltrar" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar" />
                    </td>
                    <td>
                        <asp:Button ID="btnMostrarTodo" runat="server" OnClick="btnMostrarTodo_Click" Text="Mostrar todo" />
&nbsp;&nbsp; </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            <asp:GridView ID="grdSucursales" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
