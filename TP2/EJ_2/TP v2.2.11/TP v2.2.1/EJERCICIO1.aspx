<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EJERCICIO1.aspx.cs" Inherits="TP2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Ingreso de Datos -->
            <div>
                <br />
                Ingrese nombre del producto:&nbsp;&nbsp;
                <asp:TextBox ID="txtNombre1" runat="server" Width="160px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp; Cantidad:&nbsp;&nbsp;
                <asp:TextBox ID="txtCantidadProUno" runat="server"></asp:TextBox>
                <br />
                <br />
            </div>
            <div>
                Ingrese nombre del producto: <asp:TextBox ID="txtNombre2" runat="server" style="margin-left: 8px" Width="160px"></asp:TextBox> <!-- Nuevo TextBox -->
                &nbsp;&nbsp;&nbsp; Cantidad:&nbsp;&nbsp;
                <asp:TextBox ID="txtCantidadProDos" runat="server"></asp:TextBox>
            </div>
        </div>
        <p>
            <asp:Button ID="btnTabla" runat="server" Text="Generar Tabla" OnClick="btnTabla_Click" />
        </p>
        <asp:Label ID="lbTabla" runat="server"></asp:Label>
    </form>
</body>
</html>