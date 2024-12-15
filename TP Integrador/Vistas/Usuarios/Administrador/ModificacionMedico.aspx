<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificacionMedico.aspx.cs" Inherits="Vistas.ModificacionMedico" %>

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
            <h1><asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Modificacion Medico"></asp:Label></h1>
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
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn" OnClick="btnBuscar_Click" />
                    <asp:Button ID="btnResetear" runat="server" Text="Resetear" CssClass="btn" OnClick="btnResetear_Click" />
                </div>
            <table>
     
              <tr>
                  <td class="auto-style9" colspan="2">
                 <asp:GridView ID="grdModificacionMedico" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowCancelingEdit="grdModificacionMedico_RowCancelingEdit" OnRowEditing="grdModificacionMedico_RowEditing" OnRowUpdating="grdModificacionMedico_RowUpdating">
                    <Columns>
                        <asp:TemplateField HeaderText="Leg">
                               <ItemTemplate>
                                   <asp:Label ID="lblLegajoMedico" runat="server" Text='<%# Bind("Legajo_med") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>

                        <asp:TemplateField HeaderText="DNI">
                            <ItemTemplate>
                                <asp:Label ID="lblDniMedico" runat="server" Text='<%# Bind("DNI_med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
        
                        <asp:TemplateField HeaderText="Nombre">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_it_NombreMedico" runat="server" Text='<%# Bind("Nombre_med") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNombreMedico" runat="server" Text='<%# Bind("Nombre_med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
        
                        <asp:TemplateField HeaderText="Apellido">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_it_ApellidoMedico" runat="server" Text='<%# Bind("Apellido_med") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblApellidoMedico" runat="server" Text='<%# Bind("Apellido_med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
        
                        <asp:TemplateField HeaderText="Genero">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlGenero" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblGeneroMedico" runat="server" Text='<%# Bind("Descripcion_g") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
        
                        <asp:TemplateField HeaderText="Nacionalidad">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlNacionalidad" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNacionalidadMedico" runat="server" Text='<%# Bind("Nombre_pais") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
        
                        <asp:TemplateField HeaderText="Fecha Nacimiento">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_it_FHNacimientoMedico" runat="server" Text='<%# Bind("FechaNacimiento_med") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblFHNacimientoMedico" runat="server" Text='<%# Bind("FechaNacimiento_med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
        
                        <asp:TemplateField HeaderText="Direccion">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_it_DireccionMedico" runat="server" Text='<%# Bind("Direccion_med") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDireccionMedico" runat="server" Text='<%# Bind("Direccion_med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
        
                        <asp:TemplateField HeaderText="Provincia">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblProvinciaMedico" runat="server" Text='<%# Bind("Nombre_prov") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Localidad">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlLocalidad" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblLocalidadMedico" runat="server" Text='<%# Bind("Nombre_loc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="E-mail">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_it_EmailMedico" runat="server" Text='<%# Bind("CorreoElectronico_med") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEmailMedico" runat="server" Text='<%# Bind("CorreoElectronico_med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Telefono">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_it_TelefonoMedico" runat="server" Text='<%# Bind("Telefono_med") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTelefonoMedico" runat="server" Text='<%# Bind("Telefono_med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Especialidad">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlEspecialidad" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEspecialidadMedico" runat="server" Text='<%# Bind("Nombre_esp") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dias Laborales">
                            <EditItemTemplate>
                                <asp:CheckBoxList ID="cblDias" runat="server">
                                    <asp:ListItem Value="1">Lunes</asp:ListItem>
                                    <asp:ListItem Value="2">Martes</asp:ListItem>
                                    <asp:ListItem Value="3">Miercoles</asp:ListItem>
                                    <asp:ListItem Value="4">Jueves</asp:ListItem>
                                    <asp:ListItem Value="5">Viernes</asp:ListItem>
                                    <asp:ListItem Value="6">Sabado</asp:ListItem>
                                    <asp:ListItem Value="7">Domingo</asp:ListItem>
                                </asp:CheckBoxList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDias" runat="server" Text='<%# Bind("Dias") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Horario">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlHorarioAtencion" runat="server" Height="16px">
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
                                    <asp:ListItem Value="13">20:00</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblHorario" runat="server" Text='<%# Bind("Horario_h") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                 </asp:GridView>

                      <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                  </td>
                  <td>&nbsp;</td>
              </tr>
            </table>
        </div>
    </form>
</body>
</html>