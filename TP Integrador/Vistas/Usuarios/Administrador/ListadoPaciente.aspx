<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoPaciente.aspx.cs" Inherits="Vistas.ListadoPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado Paciente</title>
    <link href="../../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <style>
      
  
        .wrapper {
            max-width: 1200px;
            margin: auto;
            padding: 20px;
        }

        .tabla-pacientes {
            width: 100%;
            max-width: 100%; /* Limita el ancho al contenedor */
            border-collapse: collapse;
            overflow-x: auto; /* Para desplazar horizontalmente si es necesario */
        }

        .tabla-pacientes th, .tabla-pacientes td {
            padding: 8px;
            text-align: left;
            border: 1px solid #ddd;
        }

        .tabla-pacientes th {
            background-color: #f2f2f2;
        }

        #grvPacientes {
            width: 100%;
            max-width: 100%;
            overflow: hidden;
            margin: 20px 0; /* Espacio entre la tabla y otros elementos */
            background-color: white; /* Fondo blanco para la tabla */
            border-radius: 8px; /* Bordes redondeados */
        }

        /* Opcional: estilos para mejorar la visualización */
        #grvPacientes th, #grvPacientes td {
            padding: 10px;
            font-size: 14px;
        }
        .auto-style1 {
            margin-left: 294;
        }
        .auto-style2 {
            margin-left: 316px;
        }
        .auto-style4 {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            max-width: 120px; /* Ajusta este valor según tus necesidades */;
            padding: 10px;
            margin: 10px;
            background-color: #007BFF;
            color: white;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            display: block; /* Asegúrate de que el botón sea un bloque para que el max-width funcione */
        }
        .auto-style5 {
            margin-left: 294;
            width: 83px;
        }
        .auto-style6 {
            margin-left: 294;
            width: 91px;
        }
        .auto-style7 {
            margin-left: 294;
            width: 96px;
        }
        .auto-style8 {
            margin-left: 294;
            width: 102px;
        }
        .auto-style9 {
            margin-left: 294;
            width: 108px;
        }
        .auto-style10 {
            margin-left: 294;
            width: 495px;
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
                      <li>
                          <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
                          <asp:Label ID="lblUsuarioEnSesion" runat="server" CssClass="auto-style1"></asp:Label>
                      </li>
                      <li>
                          <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" CssClass="btn-cerrar-sesion" />
                      </li>
                  </ul>
              </nav>
          </header>
        <div class="wrapper">
            <h1><asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Listado Paciente"></asp:Label></h1>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style9">
                        &nbsp;</td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style9">
                        <asp:Label ID="lblBuscarPorDNI" runat="server" Text="DNI paciente:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtBuscarPorDNI" runat="server" placeholder="DNI" Width="218px" ValidationGroup="gp1" OnTextChanged="btnDni_Click"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDniPaciente" runat="server" ControlToValidate="txtBuscarPorDNI" ValidationGroup="gp1" OnDataBinding="btnDni_Click">*Completar campo</asp:RequiredFieldValidator>
                    </td>
                </tr>
                </table>

                <div class="botones-container">

                </div>

                <table>
               
                <tr>
                    <td class="auto-style10">

                        <asp:Button ID="btnDni" runat="server" CssClass="auto-style4" OnClick="btnDni_Click" Text="Buscar" ViewStateMode="Enabled" Width="335px" />

                    </td>
                    <td colspan="2">

                    <asp:Button ID="btnMostrarTodo" runat="server" Text="Mostrar todo" CssClass="auto-style4" OnClick="btnMostrarTodo_Click" Width="331px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
               
            </table>
    <asp:GridView ID="grvPacientes" runat="server" AutoGenerateColumns="False" Width="100%" 
    DataKeyNames="DNI" Enabled="False" Visible="False">
    <Columns>
        <asp:BoundField DataField="DNI" HeaderText="DNI" ReadOnly="True" SortExpression="DNI" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
        <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
        <asp:BoundField DataField="Genero" HeaderText="Genero" SortExpression="Genero" />
        <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" SortExpression="Nacionalidad" />
        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" SortExpression="FechaNacimiento" />
        <asp:BoundField DataField="Direccion" HeaderText="Dirección" SortExpression="Direccion" />
        <asp:BoundField DataField="Localidad" HeaderText="Localidad" SortExpression="Localidad" />
        <asp:BoundField DataField="Provincia" HeaderText="Provincia" SortExpression="Provincia" />
        <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electrónico" SortExpression="CorreoElectronico" />
        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
    </Columns>
</asp:GridView>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ClinicaConnectionString %>" 
                   ProviderName="<%$ ConnectionStrings:ClinicaConnectionString.ProviderName %>" 
                   SelectCommand="SELECT * FROM [Pacientes]">
</asp:SqlDataSource>
    </form>
</body>
</html>
