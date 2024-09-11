<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Ejercicio_5.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 80px;
        }
        .auto-style2 {
            position: relative;
            top: 0px;
            left: -1px;
            width: 133px;
            height: 111px;
        }
        .auto-style3 {
            position: relative;
            top: 10px;
            left: -10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Elija su configuración:"></asp:Label>
            <br />
            <strong >
            <br />
            Seleccione cantidad de memoria :</strong> </div> 
        <div style="margin-left: 160px">
            <br />
            <asp:DropDownList ID="DDLRam" runat="server">
                <asp:ListItem Value="200"> 2GB </asp:ListItem>
                <asp:ListItem Value="375"> 4GB </asp:ListItem>
                <asp:ListItem Value="500"> 6GB </asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>
        <p>
            &nbsp;</p>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Selecciones accesorios:"></asp:Label>
        </p><asp:CheckBoxList ID="CheckBoxList1" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged" style="margin-left: 157px" CssClass="auto-style2">
                <asp:ListItem Value="2000,50">Monitor LCD</asp:ListItem>
                <asp:ListItem Value="550,50">HD 500GB</asp:ListItem>
                <asp:ListItem Value="1200">Grabador DVD</asp:ListItem>
            </asp:CheckBoxList>
        <asp:Button runat="server" Text="Calcular Precio" ID="btnCalcularPrecio" Width="150px" style="margin-left: 157px; " CssClass="auto-style3" OnClick="btnCalcularPrecio_Click1"></asp:Button>
        <p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbResultado" runat="server"></asp:Label>
    </form>
</body>
</html>
