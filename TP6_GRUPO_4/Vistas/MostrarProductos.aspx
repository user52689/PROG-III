﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarProductos.aspx.cs" Inherits="TP6_GRUPO_4.Vistas.MostrarProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblProductosSeleccionados" runat="server" Font-Bold="True" Font-Size="20pt" Text="Productos seleccionados por el Usuario:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hlSeleccionarProductos" runat="server" NavigateUrl="~/Vistas/Ejercicio2.aspx">Atras</asp:HyperLink>
        </div>
       <asp:GridView ID="grdProductosSeleccionados" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="14" Width="766px">
    <Columns>
        <asp:TemplateField HeaderText="ID Producto">
            <ItemTemplate>
                <asp:Label ID="lbl_it_IDProducto" runat="server" Text='<%# Bind("IdProducto") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Nombre Producto">
            <ItemTemplate>
                <asp:Label ID="lbl_it_NombreProducto" runat="server" Text='<%# Bind("NombreProducto") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cantidad por Unidad">
            <EditItemTemplate>
                <asp:TextBox ID="txt_edit_CantidadPorUnidad" runat="server" Text='<%# Bind("CantidadPorUnidad") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl_it_CantidadPorUnidad" runat="server" Text='<%# Bind("CantidadPorUnidad") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Precio Unitario">
            <ItemTemplate>
                <asp:Label ID="lbl_it_PrecioUnidad" runat="server" Text='<%# Bind("PrecioUnidad") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        <br />
        <br />
    </form>
</body>
</html>