<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarSucursal.aspx.cs" Inherits="TP_5.EliminarSucursal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
&nbsp;&nbsp;<br />
            &nbsp;
            <asp:Label ID="lblAgregarSucursal" runat="server" Text="Eliminar Sucursal:" Font-Size="XX-Large"></asp:Label>
                        <br />
            <br />
                        <table class="auto-style1">
                <tr>
                    <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblBusqueda" runat="server" Text="Buesqueda -&gt; Ingrese ID Sucursal:"></asp:Label>
                    </td>
                    <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:TextBox ID="txtIdSucursal" runat="server" CssClass="auto-style2"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" Width="97px" />
                    </td>
                    <td class="auto-style6">
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Debe ingresar un ID de sucursal" ID="rfvIdSucursal" ControlToValidate="txtIdSucursal" ForeColor="Red" EnableClientScript="False"> Debe ingresar un ID de sucursal</asp:RequiredFieldValidator>
                    </td>

                </tr>
            </table>            
        </div>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMensajeEliminacion" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
