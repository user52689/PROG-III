<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoMedico.aspx.cs" Inherits="Vistas.ListadoMedico" %>


<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado Medicos</title>
    <link href="../../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
     <style>
       
         .contenedor-gridview {
            overflow-x: auto; /* Activa el desplazamiento horizontal */
            padding: 10px;
            border: 1px solid #ddd;
            background-color: #ffffff;
            border-radius: 5px;
            max-width: 100%; /* Asegura que el contenedor no se desborde */
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
            <h1><asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Listado Médico"></asp:Label></h1>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblBuscarPorLegajo" runat="server" Text="Legajo medico:"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtBuscarPorLegajo" runat="server" CssClass="auto-style8" placeholder="Legajo" TextMode="Number" ValidationGroup="gp1"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvLegajoMedico" runat="server" ControlToValidate="txtBuscarPorLegajo" ValidationGroup="gp1">*CompletarCampo</asp:RequiredFieldValidator>
                        <asp:Label ID="lblMensajeMedico" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>

            <div class="botones-container">
                <asp:Button ID="btnBuscarMedico" runat="server" CssClass="btn" Text="Buscar" OnClick="btnBuscarMedico_Click" ValidationGroup="gp1" />
                <asp:Button ID="btnMostrarTodo" runat="server" Text="Mostrar todo" CssClass="btn" OnClick="btnMostrarTodo_Click" />
                <asp:Button ID="btnResetear" runat="server" Text="Resetear" CssClass="btn" OnClick="btnResetear_Click" />
            </div>

            <div class="contenedor-gridview">
                <asp:GridView ID="grdListadoMedico" runat="server" AutoGenerateColumns="False" AllowPaging="False" PageSize="10" OnPageIndexChanging="grdListadoMedico_PageIndexChanging">
                    <PagerSettings Mode="NextPrevious"  PreviousPageText="Anterior"  NextPageText="Siguiente" />
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
                               <ItemTemplate>
                                   <asp:Label ID="lblNombreMedico" runat="server" Text='<%# Bind("Nombre_med") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
        
                           <asp:TemplateField HeaderText="Apellido">
                               <ItemTemplate>
                                   <asp:Label ID="lblApellidoMedico" runat="server" Text='<%# Bind("Apellido_med") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
        
                           <asp:TemplateField HeaderText="Genero">
                               <ItemTemplate>
                                   <asp:Label ID="lblGeneroMedico" runat="server" Text='<%# Bind("Descripcion_g") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
        
                           <asp:TemplateField HeaderText="Nacionalidad">
                               <ItemTemplate>
                                   <asp:Label ID="lblNacionalidadMedico" runat="server" Text='<%# Bind("Nombre_pais") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
        
                           <asp:TemplateField HeaderText="Fecha Nacimiento">
                               <ItemTemplate>
                                   <asp:Label ID="lblFHNacimientoMedico" runat="server" Text='<%# Bind("FechaNacimiento_med") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
        
                           <asp:TemplateField HeaderText="Direccion">
                               <ItemTemplate>
                                   <asp:Label ID="lblDireccionMedico" runat="server" Text='<%# Bind("Direccion_med") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
        
                           <asp:TemplateField HeaderText="Provincia">
                               <ItemTemplate>
                                   <asp:Label ID="lblProvinciaMedico" runat="server" Text='<%# Bind("Nombre_prov") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
        
                           <asp:TemplateField HeaderText="Localidad">
                               <ItemTemplate>
                                   <asp:Label ID="lblLocalidadMedico" runat="server" Text='<%# Bind("Nombre_loc") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
        
                           <asp:TemplateField HeaderText="E-mail">
                               <ItemTemplate>
                                   <asp:Label ID="lblEmailMedico" runat="server" Text='<%# Bind("CorreoElectronico_med") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
        
                           <asp:TemplateField HeaderText="Telefono">
                               <ItemTemplate>
                                   <asp:Label ID="lblTelefonoMedico" runat="server" Text='<%# Bind("Telefono_med") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
        
                           <asp:TemplateField HeaderText="Especialidad">
                               <ItemTemplate>
                                   <asp:Label ID="lblEspecialidadMedico" runat="server" Text='<%# Bind("Nombre_esp") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
