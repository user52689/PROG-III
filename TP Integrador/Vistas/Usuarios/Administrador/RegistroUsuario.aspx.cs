using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuarios.Administrador
{
    public partial class RegistroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text;
            string contraseña = txtContraseña.Text;
            string confirmarContraseña = txtConfirmarContraseña.Text;
            string rol = ddlRol.SelectedValue;

            // Validación de confirmación de contraseña
            if (contraseña != confirmarContraseña)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Las contraseñas no coinciden.";
                return;
            }

            // Creación del objeto Usuario
            Usuario usuario = new Usuario
            {
                NombreUsuario = nombreUsuario,
                Contraseña = contraseña,
                Rol = rol
            };

            // Registro del usuario
            AutenticacionUsuario autenticacion = new AutenticacionUsuario();
            bool registrado = autenticacion.RegistrarUsuario(usuario);

            if (registrado)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Usuario registrado exitosamente.";
                Debug.WriteLine($"Usuario registrado: {usuario.NombreUsuario}, Rol: {usuario.Rol}");
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error al registrar el usuario. Intente de nuevo.";
                Debug.WriteLine("Error al intentar registrar el usuario.");
            }
        }
    }
}