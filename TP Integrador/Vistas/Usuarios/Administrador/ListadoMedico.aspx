<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoMedico.aspx.cs" Inherits="Vistas.ListadoMedico" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado Medicos</title>
    <link href="../../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <h1><asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Listado Médico"></asp:Label></h1>
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario: "></asp:Label>
            <asp:Label ID="lblNombreUsuario" runat="server"></asp:Label>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblBuscarPorLegajo" runat="server" Text="Legajo medico:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtBuscarPorLegajo" runat="server" CssClass="input-box" placeholder="Legajo"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style7">
                        <asp:Button ID="btnGuardar" runat="server" Text="Buscar" CssClass="btn" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
               
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3" colspan="2">
                        <asp:ListView ID="ListView1" runat="server">
                        </asp:ListView>
                    </td>
                    <td>&nbsp;</td>
                </tr>
               
            </table>
        </div>
    </form>
</body>
</html>

