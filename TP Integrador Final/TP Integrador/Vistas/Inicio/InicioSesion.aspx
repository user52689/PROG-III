<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="Vistas.Inicio.InicioSesion" %>
<%@ Import Namespace="Entidades" %>

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
         <header>
             <p>Clinica Pacheco</p>
             <nav>
                 <ul class="nav-bar">
                 </ul>
             </nav>
         </header>
        <div class="wrapper">
            <h1>Inicio de Sesion</h1>
            <div class="input-box">
                <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="input" placeholder="Nombre de Usuario"></asp:TextBox>
                <i class='bx bxs-user'></i>
            </div>
            <div class="input-box">
                <asp:TextBox ID="txtContraseña" runat="server" CssClass="input" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
               <i class='bx bxs-lock-alt'></i>
            </div>   
        
            <div class="mensaje-box">
                <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje" Text=""></asp:Label>
            </div>
            <br>
            <div>
                <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn" OnClick="btnLogin_Click" />
            </div>
      </div>
    </form>
</body>
</html>