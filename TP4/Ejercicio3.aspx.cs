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
                // Crear la conexión con la base de datos "Librería"
                SqlConnection cn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True");

                try
                {
                    cn.Open();

                    // Crear el comando SQL para seleccionar los temas
                    SqlCommand cmd = new SqlCommand("SELECT IdTema, Tema FROM Temas", cn);

                    // Ejecutar el comando y leer los datos
                    SqlDataReader dr = cmd.ExecuteReader();

                    // Limpiar el DropDownList antes de cargarlo
                    ddlTemas.Items.Clear();

                    // Recorrer los resultados y agregarlos al DropDownList
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
            // Obtener el IdTema seleccionado
            string idTemaSeleccionado = ddlTemas.SelectedValue;

            // Redirigir a ListadoLibros.aspx con el IdTema como parámetro
            Response.Redirect("ListadoLibros.aspx?IdTema=" + idTemaSeleccionado);
        }
    }
}