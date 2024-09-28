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
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
        <u>    
            <br />
            DESTINO INICIO<br /> </u>
            <br />
            <b>PROVINCIA:</b>&nbsp;
            <asp:DropDownList ID="ddlProvinciaInicio" runat="server" CssClass="auto-style1" height="20px" width="161px" AutoPostBack="True" OnSelectedIndexChanged="ddlProvinciaInicio_SelectedIndexChanged">
    <asp:ListItem>-- Seleccione --</asp:ListItem>
</asp:DropDownList>
            <br />
            <asp:Label ID="lblLocalidad" runat="server" Font-Bold="True" Text="LOCALIDAD:"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlLocalidadInicio" runat="server" CssClass="auto-style1" height="20px" width="161px" AutoPostBack="True">
                <asp:ListItem>-- Seleccione --</asp:ListItem>
            </asp:DropDownList>

            <br />
            <br />
        <u>    DESTINO FINAL<br />
            <br />
            </u>
            <asp:Label ID="lblLocalidad1" runat="server" Font-Bold="True" Text="PROVINCIA:"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="ddlProvinciaFinal" runat="server" CssClass="auto-style1" height="20px" width="161px" AutoPostBack="True" OnSelectedIndexChanged="ddlProvinciaFinal_SelectedIndexChanged">
                <asp:ListItem>-- Seleccione --</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblLocalidad0" runat="server" Font-Bold="True" Text="LOCALIDAD:"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlLocalidadFinal" runat="server" CssClass="auto-style1" height="20px" width="161px" AutoPostBack="True">
                <asp:ListItem>-- Seleccione --</asp:ListItem>
            </asp:DropDownList>

        </div>
    </form>
</body>
</html>
