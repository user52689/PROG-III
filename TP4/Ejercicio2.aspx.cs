using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection("Data Source=SKYNET\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {

                    cn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Productos", cn);

                    DataSet ds = new DataSet();

                    adapter.Fill(ds, "TablaProductos");

                    //Condiciones

                    gvGrilla.DataSource = ds.Tables["TablaProductos"];
                    gvGrilla.DataBind();



                    cn.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("Error al conectar con la base de datos: " + ex.ToString());
                }
            }
        }
    }
}