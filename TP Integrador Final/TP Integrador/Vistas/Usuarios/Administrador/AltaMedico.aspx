<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaMedico.aspx.cs" Inherits="Vistas.AltaMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Alta Medico</title>
    <link href="../../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
       
        .auto-style1 {
            height: 22px;
        }
       
     </style>
</head>
<body>
    <form id="form1" runat="server">
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
                            <span class="user-icon">👤</span> <!-- Ícono del usuario -->
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

        <div class="wrapper2">
           
            <h1><asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Alta Médico"></asp:Label></h1>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblLegajo" runat="server" Text="Legajo:"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:Label ID="lblLegajoAutoincremental" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <br />
                        <asp:Label ID="lblVacio" runat="server"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="lblDni" runat="server" Text="DNI:"></asp:Label>
                    </td>
                    <td class="auto-style14">
                        <asp:TextBox ID="txtDni" runat="server" CssClass="auto-style11" placeholder="DNI"></asp:TextBox>
                    </td>
                    <td class="auto-style15">
                        <asp:RequiredFieldValidator ID="rfvDni" runat="server" ControlToValidate="txtDni">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="auto-style9" placeholder="Nombre"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="auto-style10" placeholder="Apellido"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblSexo" runat="server" Text="Genero:"></asp:Label>
                    </td>
                    <td class="auto-style1">
                         <asp:DropDownList ID="ddlGenero" runat="server">
                         </asp:DropDownList>
                    </td>
                    <td class="auto-style1">
                        <asp:RequiredFieldValidator ID="rfvGenero" runat="server" ControlToValidate="ddlGenero" InitialValue="0">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="ddlNacionalidad" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="ddlNacionalidad" InitialValue="0">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha Nacimiento:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                            <input type="date" id="txtFechaNacimiento" runat="server"/>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblDireccion" runat="server" Text="Direccion:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="auto-style9" placeholder="Direccion"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblProvincia" runat="server" Text="Provincia:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                            </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" InitialValue="0">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="ddlLocalidad" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" InitialValue="0">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblEmail" runat="server" Text="E-mail:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="auto-style11" placeholder="E-mail"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="auto-style12" placeholder="Telefono"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblDiaAtencion" runat="server" Text="Dia Atencion:"></asp:Label>
                    </td>

                    <td class="auto-style7">
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                            <asp:ListItem Value="1">Lunes</asp:ListItem>
                            <asp:ListItem Value="2">Martes</asp:ListItem>
                            <asp:ListItem Value="3">Miercoles</asp:ListItem>
                            <asp:ListItem Value="4">Jueves</asp:ListItem>
                            <asp:ListItem Value="5">Viernes</asp:ListItem>
                            <asp:ListItem Value="6">Sabado</asp:ListItem>
                            <asp:ListItem Value="7">Domingo</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Text="Horario Atencion"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="ddlHorarioAtencion" runat="server" Height="16px">
                            <asp:ListItem>--Seleccionar--</asp:ListItem>
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
                    
                    
                    <td>
                        <asp:RequiredFieldValidator ID="rfvHorarioAtencion" runat="server" ControlToValidate="ddlHorarioAtencion" InitialValue="--Seleccionar--">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                         <td>
                         
                             Especialidad:</td>
                     <td>
                         
                            
                         <asp:DropDownList ID="ddlEspecialidad" runat="server">
                             <asp:ListItem>--Seleccionar Especialidad--</asp:ListItem>
                             <asp:ListItem Value="1">Pediatría</asp:ListItem>
                             <asp:ListItem Value="2">Cardiología</asp:ListItem>
                             <asp:ListItem Value="3">Dermatología</asp:ListItem>
                             <asp:ListItem Value="4">Traumatología</asp:ListItem>
                             <asp:ListItem Value="5">Medicina general</asp:ListItem>
                         </asp:DropDownList>
                         
                            
                   </td>
                         <td>

                        <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="ddlEspecialidad" InitialValue="0">*Completar campo</asp:RequiredFieldValidator>

                           </td>  

                    </tr>
                </table>
                <br />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn" OnClick="btnGuardar_Click" />
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>