<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursal.aspx.cs" Inherits="Vistas.ListadoSucursal" %>

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
            width: 364px;
        }
        .auto-style3 {
            width: 95px;
        }
        .auto-style4 {
            width: 66px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="hlAgregarSucursal" runat="server" NavigateUrl="~/AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
            <asp:HyperLink ID="hlListadoSucursal" runat="server" NavigateUrl="~/ListadoSucursal.aspx">Listado Sucursal</asp:HyperLink>
            <asp:HyperLink ID="hlEliminarSucursal" runat="server" NavigateUrl="~/EliminarSucursal.aspx">Eliminar Sucursal</asp:HyperLink>
            <br />
            <br />
            <asp:Label ID="lblListarSucursal" runat="server" Font-Size="XX-Large" Text="Listar Sucursal"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblBusquedaSucursalID" runat="server" Text="Busqueda Sucursal ID:"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtBusquedaSucursalID" runat="server" Width="150px"></asp:TextBox>
                    </td>
                    <td class="auto-style4">&nbsp;&nbsp;
                        <asp:Button ID="btnFiltrarSucursal" runat="server" Text="Filtrar" />
                    </td>
                    <td>
                        <asp:Button ID="btnMostrarTodo" runat="server" Text="Mostrar todo" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:GridView ID="grdSucursales" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="ID_Sucursal"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Descripcion"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Provincia"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Direccion"></asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
