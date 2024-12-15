<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioAdministrador.aspx.cs" Inherits="Vistas.Inicio.InicioAdministrador" %>
<%@ Import Namespace="Entidades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sesion Administrador</title>
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
                <!-- Información del usuario centrada -->
                <li class="user-info">
                    <div class="user-container">
                        <span class="user-icon">👤</span> <!-- Ícono del usuario -->
                        <div class="user-details">
                            <asp:Label ID="lblUsuarioEnSesion" runat="server" CssClass="user-name"></asp:Label>
                            <asp:Label ID="lblRolUsuario" runat="server" CssClass="role-label" Text="Administrador"></asp:Label>
                        </div>
                    </div>
                </li>

                <!-- Botón para cerrar sesión -->
                <li class="nav-item">
                    <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="btn-cerrar-sesion" OnClick="btnCerrarSesion_Click" />
                </li>
            </ul>
        </nav>
          </header>
        <div class="wrapper">
              <h1><asp:Label ID="Label3" runat="server" Font-Size="XX-Large"></asp:Label></h1>
             <h1>Bienvenido <%= ((Usuario)Session["UsuarioLogueado"]).NombreUsuario %></h1>
              <table class="auto-style1">
              <tr>
                  <td>&nbsp;</td>
                  <td>
                      <asp:Label ID="lblAccionesMedicos" runat="server" Text="Acciones Medicos:" Font-Size="X-Large"></asp:Label>
                  </td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td>&nbsp;</td>
                  <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="hlAltaMedico" runat="server" NavigateUrl="~/Usuarios/Administrador/AltaMedico.aspx">Alta</asp:HyperLink>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  </td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td class="auto-style2"></td>
                  <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:HyperLink ID="hlBajaMedico" runat="server" NavigateUrl="~/Usuarios/Administrador/BajaMedico.aspx">Baja</asp:HyperLink>
                  </td>
                  <td class="auto-style2"></td>
              </tr>
              <tr>
                  <td>&nbsp;</td>
                  <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:HyperLink ID="hlModificacionMedico" runat="server" NavigateUrl="~/Usuarios/Administrador/ModificacionMedico.aspx">Modificacion</asp:HyperLink>
                  </td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td>&nbsp;</td>
                  <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:HyperLink ID="hlListadoMedico" runat="server" NavigateUrl="~/Usuarios/Administrador/ListadoMedico.aspx">Listado</asp:HyperLink>
                  </td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td>&nbsp;</td>
                  <td>
                      <asp:Label ID="lblAccionesPacientes" runat="server" Text="Acciones Pacientes:" Font-Size="X-Large"></asp:Label>
                  </td>
                  <td>&nbsp;</td>
              </tr>
                  <tr>
                      <td></td>
                      <td>    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:HyperLink ID="hlAsignacionTurno" runat="server" NavigateUrl="~/Usuarios/Administrador/AsignacionTurno.aspx">Asignacion Turno</asp:HyperLink>
                      </td>
                      <td></td>
                  </tr>
              <tr>
                  <td class="auto-style2"></td>
                  <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:HyperLink ID="hlAltaPAciente" runat="server" NavigateUrl="~/Usuarios/Administrador/AltaPaciente.aspx">Alta</asp:HyperLink>
                  </td>
                  <td class="auto-style2"></td>
              </tr>
              <tr>
                  <td>&nbsp;</td>
                  <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:HyperLink ID="hlBajaPaciente" runat="server" NavigateUrl="~/Usuarios/Administrador/BajaPaciente.aspx">Baja</asp:HyperLink>
                  </td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td>&nbsp;</td>
                  <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:HyperLink ID="hlModificacionPaciente" runat="server" NavigateUrl="~/Usuarios/Administrador/ModificacionPaciente.aspx">Modificacion</asp:HyperLink>
                  </td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td>&nbsp;</td>
                  <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:HyperLink ID="hlListadoPaciente" runat="server" NavigateUrl="~/Usuarios/Administrador/ListadoPaciente.aspx">Listado</asp:HyperLink>
                  </td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td>&nbsp;</td>
                  <td>
                      <asp:Label ID="Label4" runat="server" Font-Size="X-Large" Text="Acciones Usuarios:"></asp:Label>
                  </td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td>&nbsp;</td>
                  <td>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:HyperLink ID="hlRegistrarUsuario" runat="server" NavigateUrl="~/Usuarios/Administrador/RegistroUsuario.aspx">Registrar Usuario</asp:HyperLink>
                  </td>
                  <td>&nbsp;</td>
                  </tr>
                  <tr>
                   <td>&nbsp;</td>
                    <td>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlModificacionUsuario" runat="server" NavigateUrl="~/Usuarios/Administrador/ModificacionUsuario.aspx">Modificar</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
              <tr>
                  <td>&nbsp;</td>
                  <td>
                      <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="Informes:"></asp:Label>
                  </td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td>&nbsp;</td>
                  <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:HyperLink ID="hlInformes" runat="server" NavigateUrl="~/Usuarios/Administrador/Informes.aspx">Informes</asp:HyperLink>
                  </td>
                  <td>&nbsp;</td>
              </tr>

          </table>
        </div>
    </form>
</body>
</html>