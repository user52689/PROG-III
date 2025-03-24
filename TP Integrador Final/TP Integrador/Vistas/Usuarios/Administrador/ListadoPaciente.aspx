<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoPaciente.aspx.cs" Inherits="Vistas.ListadoPaciente" %>

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado Pacientes</title>
    <link href="../../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <style>
        .contenedor-gridview {
            overflow-x: auto;
            padding: 10px;
            border: 1px solid #ddd;
            background-color: #ffffff;
            border-radius: 5px;
            max-width: 100%;
        }
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
            <h1><asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Listado Pacientes"></asp:Label></h1>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblBuscarPorDNI" runat="server" Text="DNI Paciente:"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtBuscarPorDNI" runat="server" CssClass="auto-style8" placeholder="DNI" TextMode="Number" ValidationGroup="gp1"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtBuscarPorDNI" ValidationGroup="gp1">*CompletarCampo</asp:RequiredFieldValidator>
                        <asp:Label ID="lblMensajePaciente" runat="server"></asp:Label>
                        <br />
                    </td>
                </tr>
            </table>

            <div class="botones-container">
                <asp:Button ID="btnBuscarPaciente" runat="server" CssClass="btn" Text="Buscar" OnClick="btnBuscarPaciente_Click" ValidationGroup="gp1" />
                <asp:Button ID="btnMostrarTodos" runat="server" Text="Mostrar todo" CssClass="btn" OnClick="btnMostrarTodos_Click" />
                <asp:Button ID="btnResetear" runat="server" Text="Resetear" CssClass="btn" OnClick="btnResetear_Click" />
            </div>

            <div class="contenedor-gridview">
                <asp:GridView ID="grdListadoPaciente" runat="server" AutoGenerateColumns="False" AllowPaging="False" PageSize="10" OnPageIndexChanging="grdListadoPaciente_PageIndexChanging">
                    <PagerSettings Mode="NextPrevious"  PreviousPageText="Anterior"  NextPageText="Siguiente" />
                    <Columns>
                         <asp:TemplateField HeaderText="DNI">
                              <ItemTemplate>
                                  <asp:Label ID="lblDniPaciente" runat="server" Text='<%# Bind("DNI_pac") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
        
                          <asp:TemplateField HeaderText="Nombre">
                              <ItemTemplate>
                                  <asp:Label ID="lblNombrePaciente" runat="server" Text='<%# Bind("Nombre_pac") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
        
                          <asp:TemplateField HeaderText="Apellido">
                              <ItemTemplate>
                                  <asp:Label ID="lblApellidoPaciente" runat="server" Text='<%# Bind("Apellido_pac") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
        
                          <asp:TemplateField HeaderText="Genero">
                              <ItemTemplate>
                                  <asp:Label ID="lblGeneroPaciente" runat="server" Text='<%# Bind("Descripcion_g") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
        
                          <asp:TemplateField HeaderText="Nacionalidad">
                              <ItemTemplate>
                                  <asp:Label ID="lblNacionalidadPaciente" runat="server" Text='<%# Bind("Nombre_pais") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
        
                          <asp:TemplateField HeaderText="Fecha Nacimiento">
                              <ItemTemplate>
                                  <asp:Label ID="lblFHNacimientoPaciente" runat="server" Text='<%# Bind("FechaNacimiento_pac") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
        
                          <asp:TemplateField HeaderText="Direccion">
                              <ItemTemplate>
                                  <asp:Label ID="lblDireccionPaciente" runat="server" Text='<%# Bind("Direccion_pac") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
        
                          <asp:TemplateField HeaderText="Provincia">
                              <ItemTemplate>
                                  <asp:Label ID="lblProvinciaPaciente" runat="server" Text='<%# Bind("Nombre_prov") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
        
                          <asp:TemplateField HeaderText="Localidad">
                              <ItemTemplate>
                                  <asp:Label ID="lblLocalidadPaciente" runat="server" Text='<%# Bind("Nombre_loc") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
        
                          <asp:TemplateField HeaderText="E-mail">
                              <ItemTemplate>
                                  <asp:Label ID="lblEmailPaciente" runat="server" Text='<%# Bind("CorreoElectronico_pac") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
        
                          <asp:TemplateField HeaderText="Telefono">
                              <ItemTemplate>
                                  <asp:Label ID="lblTelefonoPaciente" runat="server" Text='<%# Bind("Telefono_pac") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>

