using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TP4
{
    public partial class Ejercicio3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lkbVerLibros_Click(object sender, EventArgs e)
        {
            string temaSeleccionado = ddlTemas.SelectedValue;
            Response.Redirect($"ListadoLibros.aspx?tema={temaSeleccionado}");
        }
    }
}