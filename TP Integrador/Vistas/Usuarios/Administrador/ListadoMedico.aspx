<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoMedico.aspx.cs" Inherits="Vistas.ListadoMedico" %>


<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado Medicos</title>
    <link href="../../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
     <style>
       
         .contenedor-gridview {
    overflow-x: auto; /* Activa el desplazamiento horizontal */
    padding: 10px;
    border: 1px solid #ddd;
    background-color: #ffffff;
    border-radius: 5px;
    max-width: 100%; /* Asegura que el contenedor no se desborde */
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
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" CssClass="btn-cerrar-sesion" />
                    </li>
                </ul>
            </nav>
        </header>
        <div class="wrapper">
            <h1><asp:Label ID="lblTitulo" runat="server" Font-Size="XX-Large" Text="Listado Médico"></asp:Label></h1>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblBuscarPorLegajo" runat="server" Text="Legajo medico:"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtBuscarPorLegajo" runat="server" CssClass="auto-style8" placeholder="Legajo" TextMode="Number" ValidationGroup="gp1"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvLegajoMedico" runat="server" ControlToValidate="txtBuscarPorLegajo" ValidationGroup="gp1">*CompletarCampo</asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>

            <div class="botones-container">
                <asp:Button ID="btnBuscarMedico" runat="server" CssClass="btn" Text="Buscar" OnClick="btnBuscarMedico_Click" ValidationGroup="gp1" />
                <asp:Button ID="btnMostrarTodo" runat="server" Text="Mostrar todo" CssClass="btn" OnClick="btnMostrarTodo_Click" />
            </div>

            <!-- Contenedor para el GridView -->
            <div class="contenedor-gridview">
                <asp:GridView ID="grdListadoMedico" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
                        <asp:BoundField DataField="DNI" HeaderText="DNI" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Genero" HeaderText="Genero" />
                        <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                        <asp:BoundField DataField="Provincia" HeaderText="Provincia" />
                        <asp:BoundField DataField="Localidad" HeaderText="Localidad" />
                        <asp:BoundField DataField="CorreoElectronico" HeaderText="E-mail" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                        <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
