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
            VerificarAcceso();
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

                LimpiarCampos();
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error al registrar el usuario. Intente de nuevo.";
                Debug.WriteLine("Error al intentar registrar el usuario.");
            }

        }

        //---------------------------------------------------------------------------------------------Metodos
        protected void VerificarAcceso()
        {
            Usuario usuarioLogueado = Session["UsuarioLogueado"] as Usuario;

            if (usuarioLogueado == null || !usuarioLogueado.EsAdministrador())
            {
                Response.Redirect("~/Inicio/AccesoDenegado.aspx");
                return;
            }

            // Mostrar el nombre de usuario en la barra de navegacion
            lblUsuarioEnSesion.Text = usuarioLogueado.NombreUsuario;
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Inicio/InicioSesion.aspx");
        }

        private void LimpiarCampos()
        {
            txtNombreUsuario.Text = string.Empty;
            txtContraseña.Text = string.Empty;
            txtConfirmarContraseña.Text = string.Empty;
            ddlRol.SelectedIndex = 0; // Seleccionar el valor por defecto del DropDownList
        }
    }
}