using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_2._4._1
{
    public partial class WebFormError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensajeError.Text = "USUARIO INVALIDO, INGRESO NO PERMITIDO!";
        }
    }
}