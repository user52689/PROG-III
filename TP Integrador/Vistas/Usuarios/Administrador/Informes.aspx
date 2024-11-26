<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="Vistas.Administrador.Informes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Informes</title>
    <link rel="stylesheet" href="../../Estilos/Estilos.css" />
</head>
<body>
    <form runat="server">
        <div class="wrapper">
            <h1>Generar Informes</h1>
            <div>
                <label>Fecha Inicio:</label>
                <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="input-date"></asp:TextBox>
                <label>Fecha Fin:</label>
                <asp:TextBox ID="txtFechaFin" runat="server" CssClass="input-date"></asp:TextBox>
                <asp:Button ID="btnGenerarInforme" runat="server" CssClass="btn" Text="Generar Informe" OnClick="btnGenerarInforme_Click" />
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </div>
            <asp:GridView ID="gvInforme" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="IdTurno" HeaderText="ID Turno" />
                    <asp:BoundField DataField="NombrePaciente" HeaderText="Nombre" />
                    <asp:BoundField DataField="ApellidoPaciente" HeaderText="Apellido" />
                    <asp:BoundField DataField="EstadoTurno" HeaderText="Estado del Turno" />
                    <asp:BoundField DataField="FechaTurno" HeaderText="Fecha del Turno" DataFormatString="{0:dd/MM/yyyy}" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>