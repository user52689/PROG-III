﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificacionMedico.aspx.cs" Inherits="Vistas.ModificacionMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Modificacion Medico</title>
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
                            <asp:HyperLink ID="hlInicio" runat="server" NavigateUrl="~/Inicio/InicioAdministrador.aspx">Inicio</asp:HyperLink>
                         </a>
                     </li>
                     <li>
                         <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                         <asp:Label ID="lblUsuarioEnSesion" runat="server" CssClass="auto-style1"></asp:Label>
                     </li>
                     <li>
                         <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" CssClass="btn-cerrar-sesion" />
                     </li>
                 </ul>
             </nav>
         </header>
        <div class="wrapper">
            <h1><asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Modificacion Paciente"></asp:Label></h1>
          <table class="auto-style1">
              <tr>
                  <td class="auto-style3">
                      <asp:Label ID="lblBuscarPorLegajo" runat="server" Text="Legajo medico:"></asp:Label>
                  </td>
                  <td class="auto-style7">
                      <asp:TextBox ID="txtBuscarPorLegajo" runat="server" CssClass="auto-style8" placeholder="Legajo"></asp:TextBox>
                  </td>
                  <td>
                      <asp:RequiredFieldValidator ID="rfvLegajoMedico" runat="server" ControlToValidate="txtBuscarPorLegajo">*Completar campo</asp:RequiredFieldValidator>
                  </td>
              </tr>
               </table>
                    <div class="botones-container">
                        <asp:Button ID="btnGuardar" runat="server" Text="Buscar" CssClass="btn" />
                        <asp:Button ID="btnMostrarTodo" runat="server" Text="Mostrar todo" CssClass="btn" />
                    </div>
               <table>
     
              <tr>
                  <td class="auto-style9" colspan="2">
                      <asp:GridView ID="grdModificacionMedico" runat="server" >
                          <Columns>
                              <asp:TemplateField HeaderText="DNI"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Nombre"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Apellido"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Genero"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Nacionalidad"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Fecha Nacimiento"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Direccion"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Provincia"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Localidad"></asp:TemplateField>
                              <asp:TemplateField HeaderText="E-mail"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Telefono"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Especialidad"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Dias Atencion"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Horario Atencion"></asp:TemplateField>
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
