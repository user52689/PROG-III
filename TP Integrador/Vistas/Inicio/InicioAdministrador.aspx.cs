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

            Usuario usuario = (Usuario)Session["UsuarioLogueado"];
            if (usuario == null || !usuario.EsAdministrador())
            {
                Response.Redirect("AccesoDenegado.aspx");
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("InicioSesion.aspx");
        }
    }
}