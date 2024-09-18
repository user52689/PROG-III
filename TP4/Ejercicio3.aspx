<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3.aspx.cs" Inherits="TP4.Ejercicio3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbSeleccionarTema" runat="server" Text="Seleccionar Tema: "> 
            </asp:Label>&nbsp;&nbsp;&nbsp;<asp:DropDownList runat="server" ID="ddlTemas"></asp:DropDownList>
        </div>
        <div>&nbsp;</div>
        <div>&nbsp;</div>
        <div>
            <asp:LinkButton runat="server" ID="lkbVerLibros" OnClick="lkbVerLibros_Click">Ver Libros</asp:LinkButton>&nbsp;</div>
    </form>
</body>
</html>
