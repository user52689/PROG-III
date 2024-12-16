﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="Vistas.Usuarios.Administrador.RegistroUsuario" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Registro de Usuario</title>
    <link href="../../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
        <style>
        .wrapper {
            max-width: 800px; /* Ajusta el valor a tus necesidades */
            width: 100%; /* Asegura que ocupe el 100% hasta el máximo */
            margin: 0 auto; /* Centra la tabla */
        }
    </style>
</head>
<body>
        <!-- Formulario principal -->
    <form runat="server">
        <!-- Barra de navegación -->
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
                            <span class="user-icon">👤</span> <!-- Icono del usuario -->
                            <div class="user-details">
                                <asp:Label ID="lblUsuarioEnSesion" runat="server" CssClass="user-name"></asp:Label>
                                <asp:Label ID="lblRolUsuario" runat="server" CssClass="role-label" Text="Administrador"></asp:Label>
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

        <!-- Contenido principal -->

    <div class="wrapper">
            <h1>Registro de Usuario</h1>
                <table>
                    <!-- Usuario -->
                    <tr>
                        <td><asp:Label ID="lblUsuario" runat="server" Text="Usuario:" AssociatedControlID="txtNombreUsuario" /></td>
                        <td><asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="registro-input" Placeholder="Ingrese su usuario" /></td>
                        <td><asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="*Completar campo" /></td>
                    </tr>
                    <!-- Contraseña -->
                    <tr>
                        <td><asp:Label ID="lblContraseña" runat="server" Text="Contraseña:" AssociatedControlID="txtContraseña" /></td>
                        <td><asp:TextBox ID="txtContraseña" runat="server" CssClass="registro-input" TextMode="Password" Placeholder="Ingrese su contraseña" /></td>
                        <td><asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="txtContraseña" ErrorMessage="*Completar campo" /></td>
                    </tr>
                    <!-- Confirmar Contraseña -->
                    <tr>
                        <td><asp:Label ID="lblConfirmarContraseña" runat="server" Text="Confirmar Contraseña:" AssociatedControlID="txtConfirmarContraseña" /></td>
                        <td><asp:TextBox ID="txtConfirmarContraseña" runat="server" CssClass="registro-input" TextMode="Password" Placeholder="Confirme su contraseña" /></td>
                        <td><asp:RequiredFieldValidator ID="rfvConfirmarContraseña" runat="server" ControlToValidate="txtConfirmarContraseña" ErrorMessage="*Completar campo" /></td>
                    </tr>
                    <!-- Rol -->
                    <tr>
                        <td><asp:Label ID="lblRol" runat="server" Text="Rol:" AssociatedControlID="ddlRol" /></td>
                        <td>
                            <asp:DropDownList ID="ddlRol" runat="server" CssClass="registro-input">
                                <asp:ListItem Value="">-Seleccione un Rol-</asp:ListItem>
                                <asp:ListItem Value="Administrador">Administrador</asp:ListItem>
                                <asp:ListItem Value="Medico">Médico</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td><asp:RequiredFieldValidator ID="rfvRol" runat="server" ControlToValidate="ddlRol" InitialValue="" ErrorMessage="*Seleccione un rol" /></td>
                    </tr>
                    <!-- Mensaje -->
                    <!-- Botón Enviar -->
                    </table>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnRegistrar" runat="server" CssClass="btn" Text="Registrarse" OnClick="btnRegistrar_Click" />
                        &nbsp;&nbsp; <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje" />
    </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>