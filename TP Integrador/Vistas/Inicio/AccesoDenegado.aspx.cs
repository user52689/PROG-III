using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Vistas.Inicio
{
    public partial class AccesoDenegado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //obtener el usuario de la sesion
            Usuario usuarioLogueado = Session["UsuarioLogueado"] as Usuario;

            if (usuarioLogueado == null)
            {
                // Si no hay usuario en la sesion, usar el nombre "Intruso"
                lblErrorMessage.Text = "Intruso, no tienes permiso para acceder a esta página.";
            }
            else
            {
                // Si el usuario este en la sesion, mostrar su nombre
                lblErrorMessage.Text = $"{usuarioLogueado.NombreUsuario}, no tienes permiso para acceder a esta página.";
            }
        }
    }
}