<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionTurno.aspx.cs" Inherits="Vistas.Administrador.AsignacionTurno" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Asignación de Turno</title>
    <link href="../../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Header -->
        <header>
            <p>Clinica Pacheco</p>
                <nav>
                <ul class="nav-bar">
                    <!-- Link a la pagina de inicio -->
                    <li class="nav-item">
                        <a>
                            <asp:HyperLink ID="hlInicio" runat="server" NavigateUrl="~/Inicio/InicioAdministrador.aspx">Inicio</asp:HyperLink>
                        </a>
                    </li>

                    <!-- Informacion del usuario centrada -->
                    <li class="user-info">
                        <div class="user-container">
                            <span class="user-icon">👤</span> <!-- icono del usuario -->
                            <div class="user-details">
                                <asp:Label ID="lblUsuarioEnSesion" runat="server" CssClass="user-name"></asp:Label>
                                <asp:Label ID="lblRolUsuario" runat="server" CssClass="role-label" Text="Administrador"></asp:Label>
                            </div>
                        </div>
                    </li>

                    <!-- Boton para cerrar sesion -->
                    <li class="nav-item">
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="btn-cerrar-sesion" OnClick="btnCerrarSesion_Click" CausesValidation="false" />
                    </li>
                </ul>
            </nav>
        </header>

        <!-- Main Content -->
        <div class="wrapper">
            <h1>
                <asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Asignar Turno"></asp:Label>
            </h1>

            <!-- Form Table -->
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblDniPaciente" runat="server" Text="PACIENTE:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtPaciente" runat="server" CssClass="auto-style9" placeholder="DNI Paciente"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPaciente" runat="server" ControlToValidate="txtPaciente" ErrorMessage="*Completar campo"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblMedico" runat="server" Text="MEDICO:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtMedico" runat="server" CssClass="auto-style9" placeholder="Legajo Medico"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvMedico" runat="server" ControlToValidate="txtMedico" ErrorMessage="*Completar campo"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblFechaTurno" runat="server" Text="FECHA:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <input type="date" />
                    </td>
                    <td >&nbsp;</td>
                </tr>

                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblHora" runat="server" Text="HORA:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="ddlHorarioAtencion" runat="server" Height="16px">
                            <asp:ListItem Value="1">08:00</asp:ListItem>
                            <asp:ListItem Value="2">09:00</asp:ListItem>
                            <asp:ListItem Value="3">10:00</asp:ListItem>
                            <asp:ListItem Value="4">11:00</asp:ListItem>
                            <asp:ListItem Value="5">12:00</asp:ListItem>
                            <asp:ListItem Value="6">13:00</asp:ListItem>
                            <asp:ListItem Value="7">14:00</asp:ListItem>
                            <asp:ListItem Value="8">15:00</asp:ListItem>
                            <asp:ListItem Value="9">16:00</asp:ListItem>
                            <asp:ListItem Value="10">17:00</asp:ListItem>
                            <asp:ListItem Value="11">18:00</asp:ListItem>
                            <asp:ListItem Value="12">19:00</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="auto-style12" placeholder="Teléfono"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="*Completar campo"></asp:RequiredFieldValidator>
                    </td>
                </tr>

            </table>
                 <asp:Button ID="Button1" runat="server" Text="Guardar" CssClass="btn" />
                 <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
