<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificacionPaciente.aspx.cs" Inherits="Vistas.ModificacionPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Modificacion Paciente</title>
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
             <h1><asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Modificacion Paciente"></asp:Label></h1>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblBuscarPorDNI" runat="server" Text="DNI paciente:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtBuscarPorDNI" runat="server" CssClass="auto-style7" placeholder="DNI"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDniPaciente" runat="server" ControlToValidate="txtBuscarPorDNI">*Completar Campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
              </table>
            <div class="botones-container">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn" OnClick="btnBuscar_Click" />
                <asp:Button ID="btnResetearGrid" runat="server" Text="Resetear" CssClass="btn" OnClick="btnResetear_Click" />
            </div>
            <table>
     
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3" colspan="2">
                        <asp:GridView ID="grdModificacionPacietne"  runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowCancelingEdit="grdModificacionPacietne_RowCancelingEdit" OnRowEditing="grdModificacionPacietne_RowEditing" OnRowUpdating="grdModificacionPacietne_RowUpdating">
                            <Columns>
                                <asp:TemplateField HeaderText="DNI">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDniPaciente" runat="server" Text='<%# Bind("DNI_pac") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_it_NombrePaciente" runat="server" Text='<%# Bind("Nombre_pac") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombrePaciente" runat="server" Text='<%# Bind("Nombre_pac") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Apellido">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_it_ApellidoPaciente" runat="server" Text='<%# Bind("Apellido_pac") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblApellidoPaciente" runat="server" Text='<%# Bind("Apellido_pac") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Genero">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlGenero" runat="server">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGeneroPaciente" runat="server" Text='<%# Bind("Descripcion_g") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nacionalidad">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlNacionalidad" runat="server">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblNacionalidadPaciente" runat="server" Text='<%# Bind("Nombre_pais") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha Nacimiento">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_it_FHNacimientoPaciente" runat="server" Text='<%# Bind("FechaNacimiento_pac") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblFXNacimiento" runat="server" Text='<%# Bind("FechaNacimiento_pac") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Direccion">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_it_DireccionPaciente" runat="server" Text='<%# Bind("Direccion_pac") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDireccionPaciente" runat="server" Text='<%# Bind("Direccion_pac") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Provincia">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblProvinciaPaciente" runat="server" Text='<%# Bind("Nombre_prov") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Localidad">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlLocalidad" runat="server">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocalidadPaciente" runat="server" Text='<%# Bind("Nombre_loc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="E-mail">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_it_EmailPaciente" runat="server" Text='<%# Bind("CorreoElectronico_pac") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmailPaciente" runat="server" Text='<%# Bind("CorreoElectronico_pac") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Telefono">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_it_TelefonoPAciente" runat="server" Text='<%# Bind("Telefono_pac") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTelefonoPaciente" runat="server" Text='<%# Bind("Telefono_pac") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>

                    </td>
                </tr>
     
            </table>
        </div>
    </form>
</body>
</html>
