using System;
using Negocios;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;


namespace Vistas.Inicio
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        //------------------------------------------------------------FUNCIONALIDAD LOGIN
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text;
            string contraseña = txtContraseña.Text;

            AutenticacionUsuario autenticacion = new AutenticacionUsuario();
            Usuario usuario = autenticacion.Login(nombreUsuario, contraseña);

            if (usuario != null)
            {
                Session["UsuarioLogueado"] = usuario;

                if (usuario.EsAdministrador())
                {
                    Response.Redirect("InicioAdministrador.aspx", true);
                }
                else if (usuario.EsMedico())
                {
                    Response.Redirect("InicioMedico.aspx", true);
                }
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
            }
        }
    }
}