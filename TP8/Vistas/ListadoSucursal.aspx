<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursal.aspx.cs" Inherits="Vistas.ListadoSucursal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="StyleTP8.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 364px;
            height: 65px;
        }
        .auto-style4 {
            width: 66px;
            height: 65px;
        }
        .auto-style5 {
            width: 45px;
            height: 65px;
        }
        .auto-style6 {
            height: 65px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hlAgregarSucursal" runat="server" NavigateUrl="~/AgregarSucursal.aspx" CssClass="link">Agregar Sucursal</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hlListadoSucursal" runat="server" NavigateUrl="~/ListadoSucursal.aspx" CssClass="link">Listado Sucursal</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hlEliminarSucursal" runat="server" NavigateUrl="~/EliminarSucursal.aspx" CssClass="link">Eliminar Sucursal</asp:HyperLink>
            <br />
            <br />
            <asp:Label ID="lblListarSucursal" runat="server" Font-Size="XX-Large" Text="Listar Sucursal" CssClass="titulo"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblBusquedaSucursalID" runat="server" Text="Busqueda Sucursal ID:" CssClass="txt"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <br />
                        <asp:TextBox ID="txtBusquedaSucursalID" runat="server" Width="150px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">

                        

                        <br />

                        

            <asp:RegularExpressionValidator ID="RID" runat="server" ControlToValidate="txtBusquedaSucursalID" ErrorMessage="Debe ingresar números" ValidationExpression="^\d+$" ValidationGroup="Grupo1">*</asp:RegularExpressionValidator>
                          <asp:RequiredFieldValidator ID="RfvID" runat="server" ControlToValidate="txtBusquedaSucursalID" ErrorMessage="Ingrese un ID" ValidationGroup="Grupo1">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style4">&nbsp;&nbsp;
                        <asp:Button ID="btnFiltrarSucursal" runat="server" Text="Filtrar" OnClick="btnFiltrarSucursal_Click" CssClass="button" ValidationGroup="Grupo1" Height="42px" Width="85px" />
                    </td>
                    <td class="auto-style6">
                        <br />
                        <asp:Button ID="btnMostrarTodo" runat="server" Text="Mostrar todo" OnClick="btnMostrarTodo_Click" CssClass="button" />
                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <td>
                      <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Grupo1" />
                </td>
            </table>
            <br />
            <br />

            <asp:GridView ID="grdSucursales" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="Black" ForeColor="Black">
                <Columns>
                    <asp:TemplateField HeaderText="ID_Sucursal">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_IdSucursal" runat="server" Text='<%# Eval("Id_Sucursal") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_NombreSucursal" runat="server" Text='<%# Eval("NombreSucursal") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descripcion">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_DescripcionSucursal" runat="server" Text='<%# Eval("DescripcionSucursal") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Provincia">
                    <ItemTemplate>
                    <asp:Label ID="lbl_it_ProvinciaSucursal" runat="server" Text='<%# Eval("DescripcionProvincia") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Direccion">
                        <ItemTemplate>
                            <asp:Label ID="lblDireccionSucursal" runat="server" Text='<%# Eval("DireccionSucursal") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <p>
            &nbsp;</p>
      
    </form>
</body>
</html>
