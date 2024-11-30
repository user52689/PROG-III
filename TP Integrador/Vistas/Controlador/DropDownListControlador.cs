using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Vistas.Helper
{
    public class DropDownListControlador
    {
        public static void CargarDDL(DropDownList ddl, IEnumerable lista, string Descripcion, string valor)
        {
            ddl.DataSource = lista;
            ddl.DataTextField = Descripcion;
            ddl.DataValueField = valor;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }
    }
}