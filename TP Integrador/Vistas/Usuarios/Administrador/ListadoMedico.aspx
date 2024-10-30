<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoMedico.aspx.cs" Inherits="Vistas.ListadoMedico" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado Medicos</title>
    <link href="../../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
     <style>
         .btn-cerrar-sesion {
         background-color: #FF6347; /* Color de fondo rojo suave */
         color: white; /* Color de texto */
         padding: 8px 16px; /* Espaciado interno */
         border: none; /* Sin borde */
         border-radius: 5px; /* Borde redondeado */
         font-size: 16px; /* Tamaño de fuente */
         cursor: pointer; /* Icono de mano al pasar el mouse */
         transition: background-color 0.3s ease; /* Transición suave */
         }

         .btn-cerrar-sesion:hover {
             background-color: #FF4500; /* Color de fondo al pasar el mouse */
         }

     </style>
</head>
<body>
    <form id="form1" runat="server">
          <header>
              <p>Clinica Pacheco</p>
              <nav>
                  <ul class="nav-bar">
                      <li><a href="AltaMedico.aspx">Medicos</a></li>
                      <li><a href="AltaPaciente.aspx">Pacientes</a></li>
                      <li><a href="AsignacionTurno.aspx">Turnos</a></li>
                      <li><a href="Informes.aspx">Informes</a></li>
                      <li>
                          <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
                          <asp:Label ID="lblUsuarioEnSesion" runat="server" CssClass="auto-style1"></asp:Label>
                      </li>
                      <li>
                          <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" CssClass="btn-cerrar-sesion" />
                      </li>
                  </ul>
              </nav>
          </header>
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
                        <asp:GridView ID="grdListadoMEdico" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField HeaderText="Legajo" />
                                <asp:BoundField HeaderText="DNI" />
                                <asp:BoundField HeaderText="Nombre" />
                                <asp:BoundField HeaderText="Apellido" />
                                <asp:BoundField HeaderText="Genero" />
                                <asp:BoundField HeaderText="Nacionalidad" />
                                <asp:BoundField HeaderText="Fecha Nacimiento" />
                                <asp:BoundField HeaderText="Direccion" />
                                <asp:BoundField HeaderText="Provincia" />
                                <asp:BoundField HeaderText="Localidad" />
                                <asp:BoundField HeaderText="E-mail" />
                                <asp:BoundField HeaderText="Telefono" />
                                <asp:BoundField HeaderText="Especialidad" />
                                <asp:BoundField HeaderText="Dia Atencion" />
                                <asp:BoundField HeaderText="Horario Atencion" />
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>&nbsp;</td>
                </tr>
               
            </table>
        </div>
    </form>
</body>
</html>

