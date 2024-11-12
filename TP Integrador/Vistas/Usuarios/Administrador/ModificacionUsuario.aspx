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
        <div class="wrapper">
            <h1>Modificar Usuarios</h1>
            <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" CssClass="grid-view" 
    DataKeyNames="Id" OnRowEditing="gvUsuarios_RowEditing" 
    OnRowCancelingEdit="gvUsuarios_RowCancelingEdit" OnRowUpdating="gvUsuarios_RowUpdating">
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