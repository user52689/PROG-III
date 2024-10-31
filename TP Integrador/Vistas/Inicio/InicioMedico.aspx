<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioMedico.aspx.cs" Inherits="Vistas.Inicio.InicioMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sesion Medico</title>
     <link href="../Estilos/Estilos.css" rel="stylesheet" />
     <style>
      </style>
</head>
<body>
    <form id="form1" runat="server">
          <header>
              <p>Clinica Pacheco</p>
              <nav>
                  <ul class="nav-bar">
                      <li>
                          <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                          <asp:Label ID="lblUsuarioEnSesion" runat="server" CssClass="auto-style1"></asp:Label>
                      </li>
                      <li>
                          <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" CssClass="btn-cerrar-sesion" />
                      </li>
                  </ul>
              </nav>
          </header>
        <div class="wrapper">
            <h1><asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Bienvenid@">
            <asp:Label ID="lblNombreMedico" runat="server"></asp:Label> "Nombre medico"</asp:Label></h1>
            <br />
            <table class="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="lblAcciones" runat="server" Text="Acciones:" Font-Size="X-Large"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hlGetionTurnos" runat="server" NavigateUrl="~/Usuarios/Medico/GestionarTurnos.aspx">Gestion de turnos</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
