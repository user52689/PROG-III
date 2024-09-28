<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP4.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 75px;
            height: 158px;
        }
        .auto-style3 {
            width: 521px;
            height: 158px;
        }
        .auto-style4 {
            height: 158px;
        }
        .auto-style5 {
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom: 21px">
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Id producto:&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DDL1" runat="server">
                <asp:ListItem>Igual a:</asp:ListItem>
                <asp:ListItem Value="1">Mayor a:</asp:ListItem>
                <asp:ListItem Value="2">Menor a:</asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtBoxProducto" runat="server" Width="270px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Id Categorìa:&nbsp;&nbsp;
            <asp:DropDownList ID="DDL2" runat="server" style="margin-top: 6px">
                <asp:ListItem>Igual a:</asp:ListItem>
                <asp:ListItem Value="1">Mayor a:</asp:ListItem>
                <asp:ListItem Value="2">Menor a:</asp:ListItem>
            </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtBoxCategoria" runat="server" Width="270px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnFiltrar" runat="server" Height="29px" Text="Filtrar" OnClick="btnFiltrar_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnFiltro" runat="server" Height="29px" Text="Quitar filtro" OnClick="btnFiltro_Click" />
            <br />
&nbsp;
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style3">
                        <asp:GridView ID="gvGrilla" runat="server" CssClass="auto-style5" Width="480px">
                        </asp:GridView>
                    </td>
                    <td class="auto-style4"></td>
                </tr>
            </table>
&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
