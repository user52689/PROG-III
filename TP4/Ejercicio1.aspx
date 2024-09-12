<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 47px;
            margin-top: 4px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <u>    DESTINO INICIO<br /> </u>
            <br />
            <b>PROVINCIA:</b>&nbsp;
            <asp:DropDownList ID="DropDownList5" runat="server" CssClass="auto-style1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" height="20px" width="161px">
                <asp:ListItem>-- Seleccione --</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblLocalidad" runat="server" Font-Bold="True" Text="LOCALIDAD:"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="auto-style1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" height="20px" width="161px">
                <asp:ListItem>-- Seleccione --</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
        <u>    DESTINO FINAL<br />
            <br />
            </u>
            <asp:Label ID="lblLocalidad1" runat="server" Font-Bold="True" Text="PROVINCIA:"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="auto-style1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" height="20px" width="161px">
                <asp:ListItem>-- Seleccione --</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblLocalidad0" runat="server" Font-Bold="True" Text="LOCALIDAD:"></asp:Label>
            &nbsp;<asp:DropDownList ID="DropDownList4" runat="server" CssClass="auto-style1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" height="20px" width="161px">
                <asp:ListItem>-- Seleccione --</asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
