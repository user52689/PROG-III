<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoMedico.aspx.cs" Inherits="Vistas.ListadoMedico" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado Medicos</title>
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
            <h1><asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Listado Médico"></asp:Label></h1>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblBuscarPorLegajo" runat="server" Text="Legajo medico:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtBuscarPorLegajo" runat="server" CssClass="auto-style8" placeholder="Legajo"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvLegajoMEdico" runat="server" ControlToValidate="txtBuscarPorLegajo">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>

            <div class="botones-container">
                <asp:Button ID="btnGuardar" runat="server" Text="Buscar" CssClass="btn" />
                <asp:Button ID="btnMostrarTodo" runat="server" Text="Mostrar todo" CssClass="btn" />
            </div>

            <table class="auto-style1">
               
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3" colspan="2">
                        <asp:GridView ID="grdListadoMedico" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True">
                         <Columns>
                             <asp:TemplateField HeaderText="Legajo">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label1" runat="server"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
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

