<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TP_v2._2._1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Nombre:&nbsp;&nbsp;
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
             &nbsp;&nbsp;
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lbCiudad" runat="server" Text="Ciudad: "></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DlLista" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Value="Norte">Gral. Pacheco</asp:ListItem>
                <asp:ListItem Value="Oeste">San Miguel</asp:ListItem>
                <asp:ListItem Value="Sur">Boedo</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Temas:<br />
            <asp:CheckBoxList ID="chkListTemas" runat="server" OnSelectedIndexChanged="chkListTemas_SelectedIndexChanged" style="margin-left: 0px">
                <asp:ListItem>Ciencias</asp:ListItem>
                <asp:ListItem>Literatura</asp:ListItem>
                <asp:ListItem>Historia</asp:ListItem>
            </asp:CheckBoxList>
            <br />
&nbsp;<asp:Button ID="btnVerResumen" runat="server" OnClick="btnVerResumen_Click" Text="Ver resumen" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>