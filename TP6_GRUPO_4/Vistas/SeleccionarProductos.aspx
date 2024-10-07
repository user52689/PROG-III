<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarProductos.aspx.cs" Inherits="TP6_GRUPO_4.Vistas.SeleccionarProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
        .auto-style2 {
            width: 57%;
        }
        .auto-style3 {
            height: 29px;
        }
        .auto-style4 {
            width: 286px;
        }
        .auto-style5 {
            height: 29px;
            width: 286px;
        }
        .auto-style6 {
            width: 285px;
        }
        .auto-style7 {
            height: 29px;
            width: 285px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <table class="auto-style2">
                <tr>
                    <td class="auto-style4">
                        <asp:GridView ID="grdSeleccionarProductos" runat="server">
                        </asp:GridView>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style7"></td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblProductosAgregados" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Vistas/Ejercicio2.aspx">Volver al Inicio</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
