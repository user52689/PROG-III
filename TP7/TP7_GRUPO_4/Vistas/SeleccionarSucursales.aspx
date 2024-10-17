<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursalesSeleccionadas.aspx.cs" Inherits="TP7_GRUPO_4.Vistas.SeleccionarSucursales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 24px;
        }
        .auto-style4 {
            height: 24px;
            width: 681px;
        }
        .auto-style5 {
            height: 24px;
            width: 265px;
        }
        .auto-style6 {
            width: 265px;
        }
        .auto-style7 {
            width: 51px;
        }
        .auto-style9 {
            width: 330px;
        }
        .auto-style10 {
            width: 681px;
        }
        .auto-style11 {
            height: 23px;
        }
        .auto-style12 {
            width: 100%;
            height: 516px;
        }
        .auto-style13 {
            height: 108px;
        }
        .auto-style14 {
            width: 267px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;<br />

            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style4">
            <asp:HyperLink ID="hlSeleccionSucursales" runat="server" NavigateUrl="~/Vistas/SeleccionarSucursales.aspx">Seleccion de sucursales</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hlListadoSucursalesSeleccionadas" runat="server" NavigateUrl="~/Vistas/ListadoSucursalesSeleccionadas.aspx">Listado sucursales seleccionadas</asp:HyperLink>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style4">
            <asp:Label ID="lblListadoSucursales" runat="server" Font-Size="XX-Large" Text="Seleccionar de sucursales"></asp:Label>
                    </td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style10">
            <asp:Label ID="lblBusquePorNombreSucursal" runat="server" Text="Busqueda por nombre de sucursal"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtBusquedaPorNombreSucursal" runat="server" Width="135px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" ValidationGroup="Grupo1" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBusquedaPorNombreSucursal" ErrorMessage="Admite solo letras" ValidationExpression="^[A-Za-z\s]+$" ValidationGroup="Grupo1"></asp:RegularExpressionValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style7">
                        <table class="auto-style12">
                            <tr>
                                <td class="auto-style11">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2">
                                        <ItemTemplate>
                                            <asp:Button ID="Button1" runat="server" Text='<%# Eval("DescripcionProvincia") %>' CommandArgument='<%# Eval("Id_Provincia") %>' OnCommand="ComandoProvincia" CommandName="ComandoBoton" />
                                            <br />
<br />
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BDSucursalesConnectionString %>" SelectCommand="SELECT [DescripcionProvincia], [Id_Provincia] FROM [Provincia]"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td class="auto-style9">

            <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id_Sucursal" DataSourceID="SqlDataSource1" GroupItemCount="3">
                <AlternatingItemTemplate>
                    <td runat="server" style="background-color:#FFF8DC;">&nbsp;<asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' />
                        <br />
                        <asp:ImageButton ID="imSucursal" runat="server" Height="200px" ImageAlign="Middle" ImageUrl='<%# Eval("URL_Imagen_Sucursal") %>' Width="200px" />
                        <br />
                        <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>'></asp:Label>Id_ProvinciaSucursal
                        <br />
                       <asp:Button ID="btnSeleccionar" runat="server" CommandArgument='<%# Eval("Id_Sucursal")+","+Eval("NombreSucursal")+","+Eval("DescripcionSucursal") %>' CommandName="eventoSeleccionar"  OnCommand="btnSeleccionar_Command2" Text="Seleccionar" />
                    </td>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <td runat="server" style="background-color:#008A8C;color: #FFFFFF;">Id_Sucursal:
                        <asp:Label ID="Id_SucursalLabel1" runat="server" Text='<%# Eval("Id_Sucursal") %>' />
                        <br />NombreSucursal:
                        <asp:TextBox ID="NombreSucursalTextBox" runat="server" Text='<%# Bind("NombreSucursal") %>' />
                        <br />DescripcionSucursal:
                        <asp:TextBox ID="DescripcionSucursalTextBox" runat="server" Text='<%# Bind("DescripcionSucursal") %>' />
                        <br />URL_Imagen_Sucursal:
                        <asp:TextBox ID="URL_Imagen_SucursalTextBox" runat="server" Text='<%# Bind("URL_Imagen_Sucursal") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                        <br /></td>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                        <tr>
                            <td>No se han devuelto datos.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
<td runat="server" />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <InsertItemTemplate>
                    <td runat="server" style="">NombreSucursal:
                        <asp:TextBox ID="NombreSucursalTextBox" runat="server" Text='<%# Bind("NombreSucursal") %>' />
                        <br />DescripcionSucursal:
                        <asp:TextBox ID="DescripcionSucursalTextBox" runat="server" Text='<%# Bind("DescripcionSucursal") %>' />
                        <br />URL_Imagen_Sucursal:
                        <asp:TextBox ID="URL_Imagen_SucursalTextBox" runat="server" Text='<%# Bind("URL_Imagen_Sucursal") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                        <br /></td>
                </InsertItemTemplate>
                <ItemTemplate>
                    <td runat="server" style="background-color:#DCDCDC;color: #000000;">
                        <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' />
                        <br />&nbsp;<asp:ImageButton ID="imgSucursal" runat="server" Height="200px" ImageUrl='<%# Eval("URL_Imagen_Sucursal") %>' Width="200px" />
                        <br />
                        <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' Font-Size="10pt"></asp:Label>
                        <br />
                        <asp:Button ID="btnSeleccionar" runat="server" CommandArgument='<%# Eval("Id_Sucursal")+","+Eval("NombreSucursal")+","+Eval("DescripcionSucursal") %>' CommandName="eventoSeleccionar"  OnCommand="btnSeleccionar_Command1" Text="Seleccionar" />
                        <br />
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr id="groupPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                                <asp:DataPager ID="DataPager1" runat="server" PageSize="6">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                        <asp:NumericPagerField />
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
           <SelectedItemTemplate>
    <td runat="server" class="centered">
        Id_Sucursal:
        <asp:Label ID="Id_SucursalLabel" runat="server" Text='<%# Eval("Id_Sucursal") %>' />
        <br />NombreSucursal:
        <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' />
        <br />DescripcionSucursal:
        <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' />
        <br />URL_Imagen_Sucursal:
        <asp:Label ID="URL_Imagen_SucursalLabel" runat="server" Text='<%# Eval("URL_Imagen_Sucursal") %>' />
        <br />
    </td>
</SelectedItemTemplate>
            </asp:ListView>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BDSucursalesConnectionString %>" SelectCommand="SELECT [Id_Sucursal], [NombreSucursal], [DescripcionSucursal], [URL_Imagen_Sucursal],[Id_ProvinciaSucursal] FROM [Sucursal]"></asp:SqlDataSource>
            <br />
            <asp:Label ID="lblMostrarSucursalesSeleccionadas" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblCantidadSucursalesSeleccionadas" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>

