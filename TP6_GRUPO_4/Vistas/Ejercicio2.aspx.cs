﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP6_GRUPO_4
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnEliminarProductosSeleccionados_Click(object sender, EventArgs e)
        {
            Session["ProductosSeleccionados"] = null;
        }
    }
}