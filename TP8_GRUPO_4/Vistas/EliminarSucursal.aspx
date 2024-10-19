<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 375px;
        }
        .auto-style3 {
            width: 156px;
        }
    </style>
</head>
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="hlAgregarSucursal" runat="server" NavigateUrl="~/AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
            <asp:HyperLink ID="hlListadoSucursal" runat="server" NavigateUrl="~/ListadoSucursal.aspx">Listado Sucursal</asp:HyperLink>
            <asp:HyperLink ID="hlEliminarSucursal" runat="server" NavigateUrl="~/EliminarSucursal.aspx">Eliminar Sucursal</asp:HyperLink>
            <br />
            <br />
            <asp:Label ID="lblEliminarSucursal" runat="server" Font-Size="XX-Large" Text="Eliminar Sucursal"></asp:Label>
            <br />
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblEliminarSucursalID" runat="server" Text="Eliminar Sucursal ID:"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtEliminarSucursalID" runat="server" Width="145px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnEliminarSucursal" runat="server" Text="Eliminar" OnClick="btnEliminarSucursal_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
</body>
</html>
