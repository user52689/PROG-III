<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoLibros.aspx.cs" Inherits="TP4.ListadoLibros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Text="Listado de Libros:"></asp:Label>
            <br />
            <asp:GridView ID="gvLibros" runat="server" AutoGenerateColumns="True"></asp:GridView>
            <br />
            <asp:LinkButton ID="lkbConsultarOtroTema" runat="server" OnClick="lkbConsultarOtroTema_Click">Consultar Otro Tema</asp:LinkButton>
        </div>
    </form>
</body>
</html>
