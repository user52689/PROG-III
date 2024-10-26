<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="Vistas.Inicio.RegistroUsuario" %>

<!DOCTYPE html>
<html lang="en" dir="ltr">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Formulario de Registro</title>
    <link rel="stylesheet" href="../Estilos/Estilos.css"/>
</head>
<body>
    <div class="container">
        <div class="content">
            <form runat="server">
              <div class="wrapper">
                <div class="title">Registro</div>

                <div class="form-row">
                    <!-- Campo Usuario -->
                    <div class="input-box">
                        <label for="txtUsuario">Usuario</label>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="input" placeholder="Usuario"></asp:TextBox>
                    </div>
                    <!-- Campo Nombre -->
                    <div class="input-box">
                        <label for="txtNombre">Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="input" placeholder="Nombre"></asp:TextBox>
                    </div>
                    <!-- Campo Apellido -->
                    <div class="input-box">
                        <label for="txtApellido">Apellido</label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="input" placeholder="Apellido"></asp:TextBox>
                    </div>
                    <!-- Campo DNI -->
                    <div class="input-box">
                        <label for="txtDNI">DNI</label>
                        <asp:TextBox ID="txtDNI" runat="server" CssClass="input" placeholder="DNI"></asp:TextBox>
                    </div>
                    <!-- Campo Nacionalidad -->
                    <div class="input-box">
                        <label for="txtNacionalidad">Nacionalidad</label>
                        <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="input" placeholder="Nacionalidad"></asp:TextBox>
                    </div>
                    <!-- Campo Direccion -->
                    <div class="input-box">
                        <label for="txtDireccion">Dirección</label>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="input" placeholder="Dirección"></asp:TextBox>
                    </div>
                    <!-- Campo Email -->
                    <div class="input-box">
                        <label for="txtEmail">Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="input" placeholder="Email"></asp:TextBox>
                    </div>
                    <!-- Campo Teléfono -->
                    <div class="input-box">
                        <label for="txtTelefono">Teléfono</label>
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="input" placeholder="Teléfono"></asp:TextBox>
                    </div>
                    <!-- Campo Contraseña -->
                    <div class="input-box">
                        <label for="txtContraseña">Contraseña</label>
                        <asp:TextBox ID="txtContraseña" runat="server" CssClass="input" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                    </div>
                    <!-- Campo Confirmar Contraseña -->
                    <div class="input-box">
                        <label for="txtConfirmarContraseña">Confirmar Contraseña</label>
                        <asp:TextBox ID="txtConfirmarContraseña" runat="server" CssClass="input" TextMode="Password" placeholder="Confirmar Contraseña"></asp:TextBox>
                    </div>
                    <!-- Campo Fecha de Nacimiento -->
                    <div class="input-box">
                        <label for="txtFechaNacimiento">Fecha de Nacimiento</label>
                        <input type="date">
                    </div>

                    </div>
                    <!-- Seleccion de Genero -->
                    <div class="gender-details">
                        <span class="gender-title">Género</span>
                              <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                  <asp:ListItem Value="1">Masculino</asp:ListItem>
                                  <asp:ListItem Value="2">Femenino</asp:ListItem>
                                  <asp:ListItem Value="3">Prefiero no decirlo</asp:ListItem>
                              </asp:RadioButtonList>
                    </div>
                    <!-- Boton Enviar -->
                    <div class="button">
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="input" Text="Registrarse" />
                    </div>
                </div>
              </div>
            </form>
        </div>
    </div>
</body>
</html>