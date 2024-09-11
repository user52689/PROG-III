using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTabla_Click(object sender, EventArgs e)
        {
            int cantProducto1 = int.Parse(txtCantidadProUno.Text);
            int cantProducto2 = int.Parse(txtCantidadProDos.Text);
            int total = cantProducto1 + cantProducto2;

            String tabla = "<table border='1'>";
            tabla += "<tr><th>Producto</th><th>Cantidad</th></tr>";
            tabla+="<tr> <td>" + txtNombre1.Text + "</td> <td>" + txtCantidadProUno.Text + "</td> </tr>";
            tabla += "<tr> <td> " + txtNombre2.Text + "</td> <td>" + txtCantidadProDos.Text + "</td> </tr>";
            tabla += "<tr> <td> TOTAL </td> <td>" + total + "</td> </tr>";
            tabla +="</table>";
           
            lbTabla.Text = tabla;
        }
    }
}