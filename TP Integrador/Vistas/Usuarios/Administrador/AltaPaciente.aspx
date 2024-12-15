<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaPaciente.aspx.cs" Inherits="Vistas.AltaPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Alta Paciente</title>

   <link href="../../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
        <header>
            <p>Clinica Pacheco</p>
                <nav>
                <ul class="nav-bar">
                    <!-- Link a la pagina de inicio -->
                    <li class="nav-item">
                        <a>
                            <asp:HyperLink ID="hlInicio" runat="server" NavigateUrl="~/Inicio/InicioAdministrador.aspx">Inicio</asp:HyperLink>
                        </a>
                    </li>

                    <!-- Informacion del usuario centrada -->
                    <li class="user-info">
                        <div class="user-container">
                            <span class="user-icon">👤</span> <!-- icono del usuario -->
                            <div class="user-details">
                                <asp:Label ID="lblUsuarioEnSesion" runat="server" CssClass="user-name"></asp:Label>
                                <asp:Label ID="lblRolUsuario" runat="server" CssClass="role-label" Text="Administrador"></asp:Label>
                            </div>
                        </div>
                    </li>

                    <!-- Boton para cerrar sesion -->
                    <li class="nav-item">
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="btn-cerrar-sesion" OnClick="btnCerrarSesion_Click" CausesValidation="false" />
                    </li>
                </ul>
            </nav>
        </header>
        <div class="wrapper">
            <h1><asp:Label ID="lblTituloPaciente" runat="server" Font-Size="XX-Large" Text="Alta Paciente"></asp:Label></h1>
            <table class="auto-style3">
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblDniPaciente" runat="server" Text="DNI:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtDni" runat="server" CssClass="auto-style5" placeholder="DNI"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="rfvDni" runat="server" ControlToValidate="txtDni">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblNombrePaciente" runat="server" Text="Nombre:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="auto-style9" placeholder="Nombre"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="RequiredFieldValidator">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblApellidoPaciente" runat="server" Text="Apellido:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="auto-style8" placeholder="Apellido"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="RequiredFieldValidator">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblGeneroPaciente" runat="server" Text="Genero:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="ddlGenero" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlGenero" InitialValue="0">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblNacionalidadPaciente" runat="server" Text="Nacionalidad:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="ddlNacionalidad" runat="server" CssClass="input-box">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="ddlNacionalidad" ErrorMessage="RequiredFieldValidator" InitialValue="0">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblFechaNacimientoPaciente" runat="server" Text="Fecha Nacimiento:"></asp:Label>

                    </td>
                    <td class="auto-style7">
                            <input type="date" id="txtFechaNacimiento" runat="server"/></td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="RequiredFieldValidator">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblDireccionPaciente" runat="server" Text="Direccion:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtDireccion" runat="server" placeholder="Direccion"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="RequiredFieldValidator">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblProvinciaPaciente" runat="server" Text="Provincia:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                       <asp:DropDownList ID="ddlProvincia"  AutoPostBack="true" runat="server"  OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                    </asp:DropDownList>

                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" ErrorMessage="RequiredFieldValidator" InitialValue="0">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblLocalidadPaciente" runat="server" Text="Localidad:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="auto-style6">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlProvincia" ErrorMessage="RequiredFieldValidator" InitialValue="0">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblEmailPaciente" runat="server" Text="E-mail:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="auto-style9" placeholder="E-mail"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblTelefonoPaciente" runat="server" Text="Teléfono:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="auto-style10" placeholder="Telefono"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="RequiredFieldValidator">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                </table>
                <br />
            

                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                <asp:Button ID="btnGuardarPaciente" runat="server" Text="Guardar" CssClass="btn" OnClick="btnGuardarPaciente_Click" />
        </div>
    </form>
</body>
</html>

