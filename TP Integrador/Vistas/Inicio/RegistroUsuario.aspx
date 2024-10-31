<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="Vistas.Inicio.RegistroUsuario" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Formulario de Registro</title>
    <link rel="stylesheet" href="../Estilos/Estilos.css"/>
</head>
<body>
    <div class="wrapper">
        <h1>Registro de Usuario</h1>
        <form runat="server">
            <table>
                <!-- Usuario -->
                <tr>
                    <td><asp:Label ID="lblUsuario" runat="server" Text="Usuario:" AssociatedControlID="txtUsuario" /></td>
                    <td><asp:TextBox ID="txtUsuario" runat="server" CssClass="registro-input" Placeholder="Ingrese su usuario" /></td>
                    <td><asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="*Completar campo"  /></td>
                </tr>
                <!-- Nombre -->
                <tr>
                    <td><asp:Label ID="lblNombre" runat="server" Text="Nombre:" AssociatedControlID="txtNombre" /></td>
                    <td><asp:TextBox ID="txtNombre" runat="server" CssClass="registro-input" Placeholder="Ingrese su nombre" /></td>
                    <td><asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="*Completar campo"  /></td>
                </tr>
                <!-- Apellido -->
                <tr>
                    <td><asp:Label ID="lblApellido" runat="server" Text="Apellido:" AssociatedControlID="txtApellido" /></td>
                    <td><asp:TextBox ID="txtApellido" runat="server" CssClass="registro-input" Placeholder="Ingrese su apellido" /></td>
                    <td><asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="*Completar campo"  /></td>
                </tr>
                <!-- DNI -->
                <tr>
                    <td><asp:Label ID="lblDNI" runat="server" Text="DNI:" AssociatedControlID="txtDNI" /></td>
                    <td><asp:TextBox ID="txtDNI" runat="server" CssClass="registro-input" Placeholder="Ingrese su DNI" /></td>
                    <td><asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" ErrorMessage="*Completar campo"  /></td>
                </tr>
                <!-- Nacionalidad -->
                <tr>
                    <td><asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:" AssociatedControlID="txtNacionalidad" /></td>
                    <td><asp:TextBox ID="txtNacionalidad" runat="server" CssClass="registro-input" Placeholder="Ingrese su nacionalidad" /></td>
                    <td><asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="txtNacionalidad" ErrorMessage="*Completar campo"  /></td>
                </tr>
                <!-- Email -->
                <tr>
                    <td><asp:Label ID="lblEmail" runat="server" Text="Email:" AssociatedControlID="txtEmail" /></td>
                    <td><asp:TextBox ID="txtEmail" runat="server" CssClass="registro-input" Placeholder="Ingrese su correo electrónico" /></td>
                    <td><asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="*Completar campo"  /></td>
                </tr>
                <!-- Contraseña -->
                <tr>
                    <td><asp:Label ID="lblContraseña" runat="server" Text="Contraseña:" AssociatedControlID="txtContraseña" /></td>
                    <td><asp:TextBox ID="txtContraseña" runat="server" CssClass="registro-input" TextMode="Password" Placeholder="Ingrese su contraseña" /></td>
                    <td><asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="txtContraseña" ErrorMessage="*Completar campo"  /></td>
                </tr>
                <!-- Confirmar Contraseña -->
                <tr>
                    <td><asp:Label ID="lblConfirmarContraseña" runat="server" Text="Confirmar Contraseña:" AssociatedControlID="txtConfirmarContraseña" /></td>
                    <td><asp:TextBox ID="txtConfirmarContraseña" runat="server" CssClass="registro-input" TextMode="Password" Placeholder="Confirme su contraseña" /></td>
                    <td><asp:RequiredFieldValidator ID="rfvConfirmarContraseña" runat="server" ControlToValidate="txtConfirmarContraseña" ErrorMessage="*Completar campo"  /></td>
                </tr>
                <!-- Fecha de Nacimiento -->
                <tr>
                    <td><asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento:" /></td>
                    <td><input type="date" class="registro-input" /></td>
                    <td></td>
                </tr>
                <!-- Género -->
                <tr>
                    <td><asp:Label ID="lblGenero" runat="server" Text="Género:" /></td>
                    <td>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="registro-category" RepeatLayout="Flow">
                            <asp:ListItem Value="1">Masculino</asp:ListItem>
                            <asp:ListItem Value="2">Femenino</asp:ListItem>
                            <asp:ListItem Value="3">Prefiero no decirlo</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td></td>
                </tr>
                <!-- Botón Enviar -->
                <tr>
                    <td colspan="3" class="botones-container">
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn" Text="Registrarse" />
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>