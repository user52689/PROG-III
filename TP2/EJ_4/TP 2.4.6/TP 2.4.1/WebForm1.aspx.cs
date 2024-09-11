using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_2._4._1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            string usuario = TxtUsuario.Text;
            string clave = txtClave.Text;

            // Verificar los datos ingresados
            if (usuario == "claudio" && clave == "casas")
            {
                // Redirigir al form de bienvenida
                Response.Redirect("WebFormBienvenida.aspx");
                
            }
            else
            {
                // Redirigir al form de error
                Response.Redirect("WebFormError.aspx");
            }
        }
    }
}