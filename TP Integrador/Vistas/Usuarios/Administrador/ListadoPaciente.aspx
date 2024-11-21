<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoPaciente.aspx.cs" Inherits="Vistas.ListadoPaciente" %>

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado Pacientes</title>
    <link href="../../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <style>
        .contenedor-gridview {
            overflow-x: auto;
            padding: 10px;
            border: 1px solid #ddd;
            background-color: #ffffff;
            border-radius: 5px;
            max-width: 100%;
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
                        <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
                        <asp:Label ID="lblUsuarioEnSesion" runat="server" CssClass="auto-style1"></asp:Label>
                    </li>
                    <li>
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" CssClass="btn-cerrar-sesion" OnClick="btnCerrarSesion_Click" />
                    </li>
                </ul>
            </nav>
        </header>
        <div class="wrapper">
            <h1><asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Listado Pacientes"></asp:Label></h1>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblBuscarPorDNI" runat="server" Text="DNI Paciente:"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtBuscarPorDNI" runat="server" CssClass="auto-style8" placeholder="DNI" TextMode="Number" ValidationGroup="gp1"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtBuscarPorDNI" ValidationGroup="gp1">*CompletarCampo</asp:RequiredFieldValidator>
                        <asp:Label ID="lblMensajePaciente" runat="server"></asp:Label>
                        <br />
                    </td>
                </tr>
            </table>

            <div class="botones-container">
                <asp:Button ID="btnBuscarPaciente" runat="server" CssClass="btn" Text="Buscar" OnClick="btnBuscarPaciente_Click" ValidationGroup="gp1" />
                <asp:Button ID="btnMostrarTodos" runat="server" Text="Mostrar todo" CssClass="btn" OnClick="btnMostrarTodos_Click" />
            </div>

            <!-- Contenedor para el GridView de Pacientes -->
            <div class="contenedor-gridview">
                <asp:GridView ID="grdListadoPaciente" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="DNI" HeaderText="DNI" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Genero" HeaderText="Género" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                        <asp:BoundField DataField="Provincia" HeaderText="Provincia" />
                        <asp:BoundField DataField="Localidad" HeaderText="Localidad" />
                        <asp:BoundField DataField="CorreoElectronico" HeaderText="E-mail" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />       
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>

