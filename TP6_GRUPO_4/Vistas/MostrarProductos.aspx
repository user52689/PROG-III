<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarProductos.aspx.cs" Inherits="TP6_GRUPO_4.Vistas.MostrarProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblP" runat="server" Font-Bold="True" Font-Size="20pt" Text="Productos seleccionados por el Usuario:"></asp:Label>
        </div>
        <asp:GridView ID="grdpProductosSeleccionados" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
