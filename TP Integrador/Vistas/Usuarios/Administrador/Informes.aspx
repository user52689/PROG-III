<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="Vistas.Administrador.Informes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Informes</title>
    <link rel="stylesheet" href="../../Estilos/Estilos.css" />
     <style>
         .wrapper {
            background-color: transparent; 
            padding: 20px;
         }
         .columna-contenedor h2 {
            text-align: center; 
            margin: 0 auto 20px auto; 
            font-size: 18px; 
            color: #333; 
         }
     </style>
</head>
<body>
    <form runat="server">
        <header>
            <p>Clinica Pacheco</p>
            <nav>
                <ul class="nav-bar">
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
            <h1>Informes</h1>

            <!-- Contenedor de tres columnas -->
            <div class="contenedor-tres-columnas">
                <!-- Primera columna -->
                <div class="columna-contenedor">
                    <h2>Indique un Intervalo de Fecha</h2>
                    <div class="input-box">
                        <label>Fecha Inicial</label>
                        <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="input" placeholder="dd-mm-aaaa"></asp:TextBox>
                        <br />
                        <br />
                        <label>Fecha Final</label>
                        <asp:TextBox ID="txtFechaFin" runat="server" CssClass="input" placeholder="dd-mm-aaaa"></asp:TextBox>
                        <br />
                        <div class="botones-container">
                            <asp:Button ID="btnGenerarInforme" runat="server" CssClass="btn" Text="Generar" OnClick="btnGenerarInforme_Click" />
                            <asp:Button ID="btnLimpiarCampos" runat="server" CssClass="btn" Text="Limpiar" OnClick="btnLimpiarCampos_Click" />
                        </div>
                        <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje"></asp:Label>
                    </div>
                </div>

                <!-- Segunda columna -->
                <div class="columna-contenedor">
                    <h2>Informe de Asistencias Pacientes</h2>
                    <asp:GridView ID="gvInforme" runat="server" AutoGenerateColumns="False" CssClass="wrapper">
                        <Columns>
                            <asp:BoundField DataField="IdTurno" HeaderText="ID Turno" />
                            <asp:BoundField DataField="NombrePaciente" HeaderText="Nombre" />
                            <asp:BoundField DataField="ApellidoPaciente" HeaderText="Apellido" />
                            <asp:BoundField DataField="EstadoTurno" HeaderText="Estado del Turno" />
                            <asp:BoundField DataField="FechaTurno" HeaderText="Fecha del Turno" DataFormatString="{0:dd/MM/yyyy}" />
                        </Columns>
                    </asp:GridView>
                    <h2>Grafico de Estados Turnos</h2>
                    <asp:Chart ID="chartEstadosTurnos" runat="server" Width="400px" Height="300px" Visible="false">
                        <Series>
                            <asp:Series Name="Estados" ChartType="Pie" XValueMember="Key" YValueMembers="Value">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                    <asp:Label ID="lblMensajeGrafico" runat="server" CssClass="mensaje"></asp:Label>
                </div>

                <!-- Tercera columna -->
                <div class="columna-contenedor">
                    <h2>Especialidades con Mas Atenciones</h2>
                    <div class="especialidades-panel">
                        <asp:Repeater ID="rptEspecialidades" runat="server">
                            <ItemTemplate>
                                <div class="especialidad-barra">
                                    <span><%# Eval("Especialidad") %></span>
                                </div>
                                <div class="barra">
                                    <div class="barra-progreso" style='<%# "width:" + Eval("Porcentaje") + "%;" %>'></div>
                                    <span><%# Eval("Porcentaje") %>%</span>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Label ID="lblMensajeGraficos" runat="server" CssClass="mensaje"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>