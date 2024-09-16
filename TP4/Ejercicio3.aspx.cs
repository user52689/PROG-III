using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;

namespace TP4
{
    public partial class Ejercicio3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = Libreria; Integrated Security = True");

            if (IsPostBack == false)
            {
                try
                {
                    cn.Open();

                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM Temas", cn);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds, "Temas");

                    foreach (DataRow dr in ds.Tables["Temas"].Rows)
                    {
                        ddlTemas.Items.Add(dr["Tema"].ToString());
                    }

                    cn.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("Error al conectar con la base de datos. Revise el nombre del Data Source en la conexion, debe coincidir con el nombre de su base de datos." + ex.Message);
                }
            }
        }

        protected void lkbVerLibros_Click(object sender, EventArgs e)
        {
            string temaSeleccionado = ddlTemas.SelectedValue;
            Response.Redirect($"ListadoLibros.aspx?tema={temaSeleccionado}");
        }
    }
}