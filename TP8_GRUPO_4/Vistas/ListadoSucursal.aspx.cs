using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class ListadoSucursal : System.Web.UI.Page
    {
        NegocioSucursal ns = new NegocioSucursal();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = ns.getTabla();
                grdSucursales.DataSource = dt;
                grdSucursales.DataBind();
            }
        }
    }
}