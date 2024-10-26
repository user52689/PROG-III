<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaPaciente.aspx.cs" Inherits="Vistas.AltaPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Alta Paciente</title>

   <link href="../../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            position: relative;
            margin-bottom: 20px;
            left: 0px;
            top: 0px;
        }
        .auto-style2 {
            width: 140px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <h1><asp:Label ID="lblTituloPaciente" runat="server" Font-Size="XX-Large" Text="Alta Paciente"></asp:Label></h1>
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario: "></asp:Label>
            <asp:Label ID="lblNombreUsuario" runat="server"></asp:Label>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblDniPaciente" runat="server" Text="DNI:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtDni" runat="server" CssClass="auto-style1" placeholder="DNI"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDni">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblNombrePaciente" runat="server" Text="Nombre:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="input-box" placeholder="Nombre"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre" ErrorMessage="RequiredFieldValidator">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblApellidoPaciente" runat="server" Text="Apellido:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="input-box" placeholder="Apellido"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtApellido" ErrorMessage="RequiredFieldValidator">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblGeneroPaciente" runat="server" Text="Genero:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                            <asp:ListItem Value="1">Masculino</asp:ListItem>
                            <asp:ListItem Value="2">Femenino</asp:ListItem>
                            <asp:ListItem Value="3">Prefiero no decirlo</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblNacionalidadPaciente" runat="server" Text="Nacionalidad:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="input-box">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownList1" ErrorMessage="RequiredFieldValidator">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblFechaNacimientoPaciente" runat="server" Text="Fecha Nacimiento:"></asp:Label>

                    </td>
                    <td class="auto-style7">
                            <input type="date"/></td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblDireccionPaciente" runat="server" Text="Direccion:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtDireccionPaciente" runat="server" placeholder="Direccion"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDireccionPaciente" ErrorMessage="RequiredFieldValidator">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblLocalidadPaciente" runat="server" Text="Localidad:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="input-box">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DropDownList2" ErrorMessage="RequiredFieldValidator">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblProvinciaPaciente" runat="server" Text="Provincia:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="input-box">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DropDownList3" ErrorMessage="RequiredFieldValidator">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblEmailPaciente" runat="server" Text="E-mail:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="input-box" placeholder="E-mail"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblTelefonoPaciente" runat="server" Text="Teléfono:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="input-box" placeholder="Telefono"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtTelefono" ErrorMessage="RequiredFieldValidator">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblEstadoPaciente" runat="server" Text="Estado:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="DropDownList4" runat="server" CssClass="input-box">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="DropDownList4" ErrorMessage="RequiredFieldValidator">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3"></td>
                    <td class="auto-style7">
                        <asp:Button ID="btnGuardarPaciente" runat="server" Text="Guardar" CssClass="btn" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
