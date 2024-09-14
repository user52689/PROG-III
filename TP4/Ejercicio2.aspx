<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP4.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom: 21px">
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Id producto:&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Igual a:</asp:ListItem>
                <asp:ListItem>Mayor a:</asp:ListItem>
                <asp:ListItem>Menor a:</asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbIdProducto" runat="server" Width="209px"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Id Categorìa:&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList2" runat="server" style="margin-top: 6px">
                <asp:ListItem>Igual a:</asp:ListItem>
                <asp:ListItem>Mayor a:</asp:ListItem>
                <asp:ListItem>Menor a:</asp:ListItem>
            </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbIdCategoria" runat="server" Width="208px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
