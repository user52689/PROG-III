<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificacionPaciente.aspx.cs" Inherits="Vistas.ModificacionPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Modificacion Paciente</title>
     <link href="../../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <style>

        .btn-cerrar-sesion {
        background-color: #FF6347; /* Color de fondo rojo suave */
        color: white; /* Color de texto */
        padding: 8px 16px; /* Espaciado interno */
        border: none; /* Sin borde */
        border-radius: 5px; /* Borde redondeado */
        font-size: 16px; /* Tamaño de fuente */
        cursor: pointer; /* Icono de mano al pasar el mouse */
        transition: background-color 0.3s ease; /* Transición suave */
        }

        .btn-cerrar-sesion:hover {
            background-color: #FF4500; /* Color de fondo al pasar el mouse */
        }

        .auto-style1 {
            position: relative;
            margin-bottom: 20px;
            left: 0px;
            top: 1px;
        }
        .auto-style2 {
            position: relative;
            margin-bottom: 20px;
            left: 0px;
            top: 2px;
        }
        .auto-style3 {
            position: relative;
            margin-bottom: 20px;
            left: 0px;
            top: 3px;
        }
        .auto-style4 {
            position: relative;
            margin-bottom: 20px;
            left: 0px;
            top: 4px;
        }
        .auto-style5 {
            position: relative;
            margin-bottom: 20px;
            left: 0px;
            top: 5px;
        }
        .auto-style6 {
            position: relative;
            margin-bottom: 20px;
            left: 0px;
            top: 6px;
        }
        .auto-style7 {
            position: relative;
            margin-bottom: 20px;
            left: 0px;
            top: 7px;
        }
        .auto-style8 {
            position: relative;
            margin-bottom: 20px;
            left: 0px;
            top: 8px;
        }

     </style>
</head>
<body>
    <form id="form1" runat="server">
         <header>
             <p>Clinica Pacheco</p>
             <nav>
                 <ul class="nav-bar">
                     <li><a href="AltaMedico.aspx">Medicos</a></li>
                     <li><a href="AltaPaciente.aspx">Pacientes</a></li>
                     <li><a href="AsignacionTurno.aspx">Turnos</a></li>
                     <li><a href="Informes.aspx">Informes</a></li>
                     <li>
                         <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                         <asp:Label ID="lblUsuarioEnSesion" runat="server" CssClass="auto-style1"></asp:Label>
                     </li>
                     <li>
                         <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" CssClass="btn-cerrar-sesion" />
                     </li>
                 </ul>
             </nav>
         </header>
        <div class="wrapper">
             <h1><asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Modificacion Paciente"></asp:Label></h1>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td class="auto-style2"></td>
                </tr>
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
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style7">
                        <asp:Button ID="btnGuardar" runat="server" Text="Buscar" CssClass="btn" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
     
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3" colspan="2">
                        <asp:GridView ID="grdModificacionPacietne" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True">
                            <Columns>
                                <asp:TemplateField HeaderText="DNI"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Apellido"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Genero"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Nacionalidad"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha Nacimiento"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Direccion"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Provincia"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Localidad"></asp:TemplateField>
                                <asp:TemplateField HeaderText="E-mail"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Telefono"></asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>&nbsp;</td>
                </tr>
     
            </table>
        </div>
    </form>
</body>
</html>
