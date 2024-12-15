<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificacionUsuario.aspx.cs" Inherits="Vistas.Usuarios.Administrador.ModificacionUsuario" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Modificar Usuarios</title>
    <link rel="stylesheet" href="../../Estilos/Estilos.css"/>
</head>
<body>
    <form runat="server">
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
            <h1>Modificar Usuarios</h1>
            <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" CssClass="grid-view" DataKeyNames="Id" OnRowEditing="gvUsuarios_RowEditing" OnRowCancelingEdit="gvUsuarios_RowCancelingEdit" OnRowUpdating="gvUsuarios_RowUpdating" 
                AllowPaging="True" PageSize="10" OnPageIndexChanging="gvUsuarios_PageIndexChanging">
                <PagerSettings Mode="NextPrevious" PreviousPageText="Anterior" NextPageText="Siguiente" />
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
        <asp:BoundField DataField="Contraseña" HeaderText="Contraseña" />
        <asp:TemplateField HeaderText="Rol">
            <ItemTemplate>
                <asp:Label ID="lblRol" runat="server" Text='<%# Bind("Rol") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:CommandField ShowEditButton="True" />
    </Columns>
</asp:GridView>
            <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje"></asp:Label>
        </div>
    </form>
</body>
</html>