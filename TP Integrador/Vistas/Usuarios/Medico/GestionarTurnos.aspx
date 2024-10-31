<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionarTurnos.aspx.cs" Inherits="Vistas.GestionarTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestion de Turnos</title>
    <link href="../../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <style>
     </style>
</head>
<body>
    <form id="form1" runat="server">
         <header>
             <p>Clinica Pacheco</p>
             <nav>
                 <ul class="nav-bar">
                     <li>
                         <a>
                            <asp:HyperLink ID="hlInicio" runat="server" NavigateUrl="~/Inicio/InicioMedico.aspx">Inicio</asp:HyperLink>
                         </a>
                     </li>
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
            <h1><asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Gestion Turnos"></asp:Label></h1>
            <table>
                <tr>
                    <td >&nbsp;</td>
                    <td colspan="2">
                        <asp:GridView ID="grdListadoPacietne" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True">
                            <Columns>
                                <asp:TemplateField HeaderText="DNI"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Apellido"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha Nacimiento"></asp:TemplateField>
                                <asp:TemplateField HeaderText="E-mail"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Telefono"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado"></asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
