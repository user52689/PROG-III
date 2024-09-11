using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejercicio_5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnCalcularPrecio_Click1(object sender, EventArgs e)
        {

            string valoresRam = DDLRam.SelectedValue;
            float ram = float.Parse(valoresRam);


            float valorBox = 0;
            foreach (ListItem item in CheckBoxList1.Items)
            {
               
                if (item.Selected)
                {
                   
                    valorBox += float.Parse(item.Value);


                }
            }

            
            float resultadoTotal = ram + valorBox;

            lbResultado.Text = $"<strong>El Precio final es: {resultadoTotal.ToString("N2")} $</strong>";
        }
    }
}