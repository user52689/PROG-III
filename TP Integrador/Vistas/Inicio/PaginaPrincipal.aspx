<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.cs" Inherits="Vistas.Inicio.PaginaPrincipal" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Bienvenido a Clínica Pacheco</title>
    <link rel="stylesheet" href="../Estilos/Estilos.css"/>
    <link rel="stylesheet" href="../Estilos/PaginaPrincipal.css"/> 
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>
</head>
<body>
    <form id="form1" runat="server">
         <header>
             <div class="logo">
                 <h1>Clínica Pacheco</h1>
             </div>
             <nav>
                 <ul class="nav-bar">
                     <li><asp:HyperLink ID="Inicio" runat="server" NavigateUrl="~/Inicio/InicioSesion.aspx">Inicio sesion</asp:HyperLink></li>
                 </ul>
             </nav>
         </header>

         <div class="container">
             <div class="wrapper1">
                 <section id="inicio" class="welcome-section">
                     <div class="content">
                         <h2>Bienvenidos a la Clínica Pacheco</h2>
                         <p>En Clínica Pacheco nos dedicamos a ofrecer atención médica de calidad, con un equipo de profesionales altamente capacitados y tecnología de punta. Estamos comprometidos con la salud y el bienestar de nuestros pacientes.</p>
                     </div>
                 </section>
             </div>
         </div>

         <div class="container">
             <div class="wrapper2">
                 <section id="acerca" class="about-section">
                     <h2>¿Quiénes Somos?</h2>
                     <p>Clínica Pacheco cuenta con años de experiencia en el cuidado de la salud. Ofrecemos una amplia gama de servicios médicos, incluyendo consultas generales, especialidades y procedimientos médicos avanzados. Nuestra misión es brindar atención personalizada con un enfoque humano.</p>
                 </section>
             </div>
         </div>

         <div class="container">
             <div class="wrapper3">
                 <section id="contacto" class="contact-section">
                     <h2>Contáctanos</h2>
                     <p>Si necesitas más información o deseas agendar una cita, no dudes en ponerte en contacto con nosotros. Estaremos encantados de ayudarte.</p>
                     <div class="social-media">
                         <a href="https://facebook.com" target="_blank"><i class="bx bxl-facebook"></i></a>
                         <a href="https://twitter.com" target="_blank"><i class="bx bxl-twitter"></i></a>
                         <a href="https://instagram.com" target="_blank"><i class="bx bxl-instagram"></i></a>
                         <a href="https://whastapp.com" target="_blank"><i class="bx bxl-whatsapp"></i></a>
                     </div>
                 </section>
             </div>
         </div>

         <footer>
             <p>&copy; 2024 Clínica Pacheco. Todos los derechos reservados, Grupo 4 de Programacion III.</p>
         </footer>
    </form>
</body>
</html>
