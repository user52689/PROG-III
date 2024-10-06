<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TP6_GRUPO_4.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br /> 
            <h1>Grupo N°4</h1>
            <p>&nbsp;</p>
            <p>
                <asp:HyperLink ID="hlEjercicio1" runat="server" NavigateUrl="~/Vistas/Ejercicio1.aspx">Ejercicio 1</asp:HyperLink>
            </p>
            <p>&nbsp;</p>
            <p>
                <asp:HyperLink ID="hlEjercicio2" runat="server" NavigateUrl="~/Vistas/Ejercicio2.aspx">Ejercicio 2</asp:HyperLink>
            </p>
        </div>
    </form>
</body>
</html>
