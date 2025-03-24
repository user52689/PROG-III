﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionarTurnos.aspx.cs" Inherits="Vistas.GestionarTurnos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestion de Turnos</title>
    <link href="../../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <style>

        .btn {
   
    display: flex;
    justify-content: left; /* Centra horizontalmente */
    align-items:center; /* Centra verticalmente */
    text-align: left;
    box-sizing: border-box; /* Asegura que el padding no desordene el diseño */
}
   
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <p>Clinica Pacheco</p>
                <nav>
                <ul class="nav-bar">
                    <!-- Link a la página de inicio -->
                    <li class="nav-item">
                        <a>
                            <asp:HyperLink ID="hlInicio" runat="server" NavigateUrl="~/Inicio/InicioAdministrador.aspx">Inicio</asp:HyperLink>
                        </a>
                    </li>

                    <!-- Información del usuario centrada -->
                    <li class="user-info">
                        <div class="user-container">
                            <span class="user-icon">👨‍⚕️</span> <!-- Ícono del usuario -->
                            <div class="user-details">
                                <asp:Label ID="lblUsuarioEnSesion" runat="server" CssClass="user-name"></asp:Label>
                                <asp:Label ID="lblRolUsuario" runat="server" CssClass="role-label" Text="Medico"></asp:Label>
                            </div>
                        </div>
                    </li>

                    <!-- Botón para cerrar sesión -->
                    <li class="nav-item">
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="btn-cerrar-sesion" OnClick="btnCerrarSesion_Click" CausesValidation="false" />
                    </li>
                </ul>
            </nav>
        </header>

        <div class="wrapper">
            <h1 id="gvDatosMedico">
                <asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Gestion Turnos"></asp:Label>
            </h1>

            <table class="auto-style1">
                <tr>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style6">
                        <br />
                        <asp:GridView ID="gvDatosMedico" runat="server">
                        </asp:GridView>
                        <br />
                        <h2>Indique un Intervalo de Fecha</h2>
                        <div class="input-box">
                            <!-- Fecha inicial -->
                            <label>Fecha Inicial</label>
                            <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="input" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <br />
                            <br />

                            <!-- Fecha final -->
                            <label>Fecha Final</label>
                            <asp:TextBox ID="txtFechaFin" runat="server" CssClass="input" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <br />
                            <br />

                            <!-- Botones -->
                           <div class="botones-container">
    <asp:Button ID="btnFiltrarRango" runat="server" CssClass="btn" Text="Filtrar por Rango" OnClick="btnFiltrarRango_Click" />
    <asp:Button ID="btnLimpiarCampos" runat="server" CssClass="btn" Text="Limpiar" OnClick="btnLimpiarCampos_Click" />
    <asp:Button ID="btnMostrarTodo" runat="server" CssClass="btn" Text="Mostrar Todo" OnClick="btnMostrarTodo_Click" />
</div>
                            <asp:Label ID="lblFiltroMensajeRango" runat="server" CssClass="mensaje"></asp:Label>
                        </div>
                        <br />
                    </td>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style6">
                    </td>
                </td>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="auto-style2">
                        <asp:GridView ID="grdTurnos" runat="server" AutoGenerateColumns="False" 
                            OnRowCommand="grdTurnos_RowCommand" DataKeyNames="IdTurno">
                            <Columns>
                                <asp:BoundField DataField="IdTurno" HeaderText="IdTurno" ReadOnly="True" />
                                <asp:BoundField DataField="PacienteNombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="PacienteApellido" HeaderText="Apellido" />
                                <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                                <asp:BoundField DataField="FechaTurno" HeaderText="Fecha Turno" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:TemplateField HeaderText="Asistencia">
                                    <ItemTemplate>
                                      <asp:DropDownList ID="ddlAsistencia" runat="server" OnSelectedIndexChanged="ddlAsistencia_SelectedIndexChanged" AutoPostBack="true">
    <asp:ListItem Value="0">No Asistió</asp:ListItem>
    <asp:ListItem Value="1">Asistió</asp:ListItem>
</asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Observación">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Rows="3" Columns="20" Enabled="false"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CommandName="Guardar" CommandArgument="<%# Container.DataItemIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="auto-style2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>