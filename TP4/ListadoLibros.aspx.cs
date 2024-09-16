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
                string idTema = Request.QueryString["IdTema"];

                if (!string.IsNullOrEmpty(idTema))
                {
                    SqlConnection cn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True");

                    try
                    {
                        cn.Open();

                        // Consulta para obtener los libros filtrados por el IdTema
                        string query = "SELECT IdLibro, IdTema, Titulo, Precio, Autor  FROM Libros WHERE IdTema = @IdTema";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@IdTema", idTema);

                        SqlDataReader dr = cmd.ExecuteReader();

                        gvLibros.DataSource = dr;
                        gvLibros.DataBind();

                        dr.Close();
                        cn.Close();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error al conectar con la base de datos: " + ex.ToString());
                    }
                }
            }
        }

        protected void lkbConsultarOtroTema_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio3.aspx");
        }
    }
}