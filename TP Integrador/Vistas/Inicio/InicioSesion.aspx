<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="Vistas.Inicio.InicioSesion" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Inicio de Sesión</title>
    <link rel="stylesheet" href="../Estilos/Estilos.css"/>
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <h1>Inicio de Sesion</h1>
            <div class="input-box">
                <!-- TextBox para el Nombre de Usuario (ASP.NET) -->
                <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="input" placeholder="Nombre de Usuario"></asp:TextBox>
                <i class='bx bxs-user'></i>
            </div>
            <div class="input-box">
                <!-- TextBox para la Contraseña (ASP.NET) -->
                <asp:TextBox ID="txtContraseña" runat="server" CssClass="input" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                <i class='bx bxs-lock-alt'></i>
            </div>
            <div class="remember-forgot">
                <label><input type="checkbox" />Recordarme</label>
                <a href="#">¿Olvidaste tu Contraseña?</a>
            </div>
            <div>
                <!-- Botón de Login (ASP.NET) -->
                <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn" />
            </div>
            <div class="register-link">
                <p>¿No tienes una cuenta? 
                    <asp:HyperLink ID="hlRegistroUsuario" runat="server">Registrarse</asp:HyperLink>
                </p>
            </div>
        </div>
    </form>
</body>
</html>
