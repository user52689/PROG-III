using Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Inicio
{
    public partial class InicioAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ESTE CODIGO CONTROLA ES SISTEMA DE MANEJO DE ROLES EN CADA VISTA

            VerificarAcceso();

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("InicioSesion.aspx");
        }

        protected void VerificarAcceso()
        {
            Usuario usuarioLogueado = Session["UsuarioLogueado"] as Usuario;

            if (usuarioLogueado == null || !usuarioLogueado.EsAdministrador())
            {
                Response.Redirect("AccesoDenegado.aspx");
                return;
            }

            // Mostrar el nombre de usuario en la barra de navegación
            lblUsuarioEnSesion.Text = usuarioLogueado.NombreUsuario;
        }
    }
}