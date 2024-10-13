<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarSucursales.aspx.cs" Inherits="TP7_GRUPO_4.Vistas.SeleccionarSucursales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .links-container {
            position:absolute;
            left: 275px;
            top: 5px; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="links-container">
        <div style="text-align: left; padding: 10px;">
            <asp:HyperLink ID="hlSeleccionarSucursales" runat="server" NavigateUrl="~/SeleccionarSucursales.aspx">
                Listado de Sucursales
            </asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hlListadoSucursalesSeleccionadas" runat="server" NavigateUrl="~/ListadoSucursalesSeleccionadas.aspx">
                Mostrar sucursales seleccionadas
            </asp:HyperLink>
        </div>
        <div>
            <h2>Listado de Sucursales</h2>
        </div>
        <div>
            <asp:Label runat="server" Text="Busqueda por nombre de sucursal" ID="lblBusquedaNomSucursal"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox runat="server" ID="txtBuscarSucursales" Width="275"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button runat="server" Text="Buscar" ID="btnBuscar"></asp:Button>
        </div>
        <div>
            <asp:Button runat="server" Text="Buenos Aires" ID="btnBA" Width="250" 
                style="position: relative; left: -250px; top: 80px;" /><asp:ListView runat="server"></asp:ListView>
             <br />
             <br />
             <br />
            <asp:Button runat="server" Text="Entre Ríos" ID="btnER" Width="250" 
                style="position: relative; left: -250px; top: 90px;" />
             <br />
             <br />
             <br />
            <asp:Button runat="server" Text="Santa Fé" ID="btnSF" Width="250" 
                style="position: relative; left: -250px; top: 100px;" />
             <br />
             <br />
             <br />
            <asp:Button runat="server" Text="La Pampa" ID="btnLP" Width="250" 
                style="position: relative; left: -250px; top: 110px;" />
            <br />
            <br />
            <br />
            <asp:Button runat="server" Text="Córdoba" ID="btnCba" Width="250" 
                style="position: relative; left: -250px; top: 120px;" />
            <br />
            <br />
            <br />
            <asp:Button runat="server" Text="Misiones" ID="btnMs" Width="250" 
                style="position: relative; left: -250px; top: 130px;" />
            <br />
            <br />
            <br />
            <asp:Button runat="server" Text="Chaco" ID="btnCho" Width="250" 
                style="position: relative; left: -250px; top: 140px;" />
        </div>
    </form>
</body>
</html>