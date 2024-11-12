<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="Vistas.Usuarios.Administrador.RegistroUsuario" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Registro de Usuario</title>
    <link href="../../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="wrapper">
        <h1>Registro de Usuario</h1>
        <form runat="server">
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
                <tr>
                    <td colspan="3"><asp:Label ID="lblMensaje" runat="server" CssClass="mensaje" /></td>
                </tr>
                <!-- Botón Enviar -->
                <tr>
                    <td colspan="3" class="botones-container">
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn" Text="Registrarse" OnClick="btnRegistrar_Click" />
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>