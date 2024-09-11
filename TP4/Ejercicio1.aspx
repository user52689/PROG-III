<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 47px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <u>    DESTINO INICIO<br /> </u>
            <br />
            <b>PROVINCIA:&nbsp;</b>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="auto-style1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>-- Seleccione --</asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
