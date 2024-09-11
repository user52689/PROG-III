using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_v2._2._1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = DlLista.SelectedValue;
        }

        protected void btnVerResumen_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebForm2.aspx");
        }

        protected void chkListTemas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}