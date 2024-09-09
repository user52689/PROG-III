using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_3._1._0
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void cvLocalidadesDuplicadas_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string localidad = txtLocalidadIngresada.Text.Trim();
            string compararLocalidad = localidad.ToLower();

            bool localidadExiste = false;

            foreach (ListItem item in ddlLocalidades.Items)
            {
                if (item.Text.ToLower() == compararLocalidad)
                {
                    localidadExiste = true;
                    break;
                }
            }

            if (localidadExiste)
            {
                args.IsValid = false;
            }
            else
            {
                ddlLocalidades.Items.Add(new ListItem(localidad));
                args.IsValid = true;
                txtLocalidadIngresada.Text = string.Empty;
            }
        }



        protected void btnIrAInicio_Click(object sender, EventArgs e) => Response.Redirect("Inicio.aspx");

        protected void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            lblBienvenida.Text = $"Bienvenido {txtNombreUsuario.Text}";
            txtNombreUsuario.Text = string.Empty;
            txtBoxCorreo.Text = string.Empty;
            txtCP.Text = string.Empty;
            txtLocalidadIngresada.Text = string.Empty;
        }
    }
}