using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_v2._2._1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Nombre;
            string Apellido;
            string zona;

            CheckBoxList chkListTemas = (CheckBoxList)PreviousPage.FindControl("chkListTemas");
            Nombre = Request["txtNombre"].ToString();
            Apellido = Request["txtApellido"].ToString();
            zona = Request["DlLista"].ToString();

         

                List<string> temasSeleccionados = new List<string>();


                foreach (ListItem item in chkListTemas.Items)
                {
                    if (item.Selected)
                    {
                        temasSeleccionados.Add(item.Text);
                    }
                }


                LbResumen.Text = "Nombre:  " + "  " + "<strong>" + Nombre + "</strong>" + "<br />";
                LbResumen.Text += "Apellido:  " + "  " + "<strong>" + Apellido + "</strong>" + "<br />";
                LbResumen.Text += "Zona:  " + "  " + "<strong>" + zona + "</strong>" + "<br />";
                LbResumen.Text += "Los Temas elegidos son :" + "<br />";

         
                string Temas = string.Join("<br/>", temasSeleccionados);

            if (temasSeleccionados.Count > 0) {
                LbResumen.Text += "<strong>" + Temas + "</strong>";
            }
            else
            {
                LbResumen.Text += "<strong>" + "No hay temas seleccionados" + "</strong>" + "<br />";

            }


                


                


            
        }
    }
}