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
            }
        }

        protected void btnGuardarUsuario_Click(object sender, EventArgs e)
        {

            if (txtBoxContraseña1.Text != txtBoxContraseña2.Text)
            {
                lblCotraseña.Text = "Las contraseñas no coinciden";
                lblCotraseña.ForeColor = System.Drawing.Color.Red;

            }

            lblBienvenida.Text = $"Bienvenido {txtNombreUsuario.Text}";
        }
          

        protected void btnGuardarLocalidad_Click(object sender, EventArgs e)
        {
            txtLocalidadIngresada.Text = "";
        }

        protected void btnIrAInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void txtCP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}