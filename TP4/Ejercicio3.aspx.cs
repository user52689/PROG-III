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
            if (!IsPostBack)
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True");

                try
                {
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT IdTema, Tema FROM Temas", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    ddlTemas.Items.Clear();

                    while (dr.Read())
                    {
                        ddlTemas.Items.Add(new ListItem(dr["Tema"].ToString(), dr["IdTema"].ToString()));
                    }

                    dr.Close();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("Error al conectar con la base de datos: " + ex.ToString());
                }
            }
        }

        protected void lkbVerLibros_Click(object sender, EventArgs e)
        {
            string idTemaSeleccionado = ddlTemas.SelectedValue;

            Response.Redirect("ListadoLibros.aspx?IdTema=" + idTemaSeleccionado);
        }
    }
}