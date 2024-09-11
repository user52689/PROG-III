<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TP_2._3._1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:LinkButton ID="lnkRojo" runat="server" OnClick="lnkRojo_Click">Rojo</asp:LinkButton>
        <br />
       
        <asp:LinkButton ID="lnkAzul" runat="server" OnClick="lnkAzul_Click">Azul</asp:LinkButton>
        <br />
        
        <asp:LinkButton ID="lnkVerde" runat="server" OnClick="lnkVerde_Click">Verde</asp:LinkButton>
        
        <p>
            <asp:Label ID="lbMensaje" runat="server" Text="Texto coloreado"></asp:Label>
        </p>
    </form>
</body>
</html>
