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
    public partial class ListadoLibros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el tema seleccionado pasado desde la página anterior
                string temaSeleccionado = Request.QueryString["tema"];
                if (!string.IsNullOrEmpty(temaSeleccionado))
                {
                    lblTitulo.Text = "Listado de Libros para el Tema: " + temaSeleccionado;

                    // Conectar a la base de datos y llenar el GridView con los libros de este tema
                    using (SqlConnection cn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True"))
                    {
                        string query = "SELECT * FROM Libros WHERE Tema = @tema";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, cn);
                        adapter.SelectCommand.Parameters.AddWithValue("@tema", temaSeleccionado);

                        DataSet ds = new DataSet();
                        adapter.Fill(ds, "Libros");
                        gvLibros.DataSource = ds.Tables["Libros"];
                        gvLibros.DataBind();
                    }
                }
            }
        }
    }
}