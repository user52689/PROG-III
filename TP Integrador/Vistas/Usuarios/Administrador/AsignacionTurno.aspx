<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionTurno.aspx.cs" Inherits="Vistas.Administrador.AsignacionTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link href="../../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .auto-style1 {
        position: relative;
        margin-bottom: 20px;
        left: 0px;
        top: 0px;
    }

    .auto-style2 {
        width: 162px;
    }

    .auto-style3 {
        position: relative;
        margin-bottom: 20px;
        left: 0px;
        top: 0px;
        width: 454px;
    }

    .auto-style4 {
        position: relative;
        margin-bottom: 20px;
        left: 0px;
        top: 0px;
        width: 156px;
    }

    .auto-style5 {
        position: relative;
        margin-bottom: 20px;
        left: -1px;
        top: 8px;
    }

    .auto-style6 {
        position: relative;
        margin-bottom: 20px;
        left: 0px;
        top: 10px;
    }

    .auto-style7 {
        position: relative;
        margin-bottom: 20px;
        left: 0px;
        top: 1px;
    }

    .auto-style8 {
        position: relative;
        margin-bottom: 20px;
        left: 0px;
        top: 9px;
    }

    .auto-style9 {
        position: relative;
        margin-bottom: 20px;
        left: 0px;
        top: 8px;
    }

    .auto-style10 {
        position: relative;
        margin-bottom: 20px;
        left: 0px;
        top: 7px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
       <header>
       <p>Clinica Pacheco</p>
       <nav>
           <ul class="nav-bar">
                <li>
                    <a>
                       <asp:HyperLink ID="hlInicio" runat="server" NavigateUrl="~/Inicio/InicioAdministrador.aspx">Inicio</asp:HyperLink>
                    </a>
                </li>
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
            <h1><asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Asignar Turno"></asp:Label></h1>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblDniPaciente" runat="server" Text="PACIENTE:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtPaciente" runat="server" CssClass="auto-style9" placeholder="DNI Paciente"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPaciente" runat="server" ControlToValidate="txtPaciente" ErrorMessage="*Completar campo"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblMedico" runat="server" Text="MEDICO:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtMedico" runat="server" CssClass="auto-style9" placeholder="Legajo Medico"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvMedico" runat="server" ControlToValidate="txtMedico" ErrorMessage="*Completar campo"></asp:RequiredFieldValidator>
                    </td>
                </tr>
             <tr>
                 <td class="auto-style4">
                     <asp:Label ID="lblFechaTurno" runat="server" Text="FECHA:"></asp:Label>

                 </td>
                 <td class="auto-style7">
                     <input type="date" /></td>
                 <td class="auto-style2">&nbsp;</td>
             </tr>
             <tr>
                 <td class="auto-style4">
                     <asp:Label ID="lblHora" runat="server" Text="HORA:"></asp:Label>

                 </td>
                <td class="auto-style7">
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
    </asp:DropDownList>
</td>
             </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="auto-style12" placeholder="Teléfono"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="*Completar campo"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style7">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>