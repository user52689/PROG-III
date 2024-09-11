<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TP_2._4._1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            Usuario:&nbsp;
            <asp:TextBox ID="TxtUsuario" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lbClave" runat="server" Text="Clave:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnValidar" runat="server" Text="Validar" OnClick="btnValidar_Click" />
        </p>
    </form>
</body>
</html>
