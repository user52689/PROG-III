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
        SqlConnection cn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {

                    cn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos", cn);


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

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try//en caso de fallo de conexion con la base de datos, Impide el fallo total de la aplicacion
            {
                cn.Open();

                string idProducto = txtBoxProducto.Text.Trim();
                string idCategoria = txtBoxCategoria.Text.Trim();

                string query = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos";
                List<string> condiciones = new List<string>();

                if (!string.IsNullOrEmpty(idProducto))
                {
                   
                    if (DDL1.SelectedValue=="1")
                    {
                        condiciones.Add("IdProducto > @IdProducto");
                    }
                    else if (DDL1.SelectedValue=="2") 
                    {
                        condiciones.Add("IdProducto < @IdProducto");
                    }
                    else
                    {
                        condiciones.Add("IdProducto = @IdProducto");
                    }
                }

                if (!string.IsNullOrEmpty(idCategoria))
                {
                   
                    if (DDL2.SelectedValue == "1")
                    {
                        condiciones.Add("IdCategoría > @IdCategoria");
                    }
                    else if (DDL2.SelectedValue == "2")
                    {
                        condiciones.Add("IdCategoría < @IdCategoria");
                    }
                    else
                    {
                        condiciones.Add("IdCategoría = @IdCategoria");
                    }

                }

                if (condiciones.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", condiciones);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(query, cn);

                if (!string.IsNullOrEmpty(idProducto))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@IdProducto", idProducto);
                }

                if (!string.IsNullOrEmpty(idCategoria))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@IdCategoria", idCategoria);
                }

                DataSet ds = new DataSet();
                adapter.Fill(ds, "TablaProductos");

                gvGrilla.DataSource = ds.Tables["TablaProductos"];
                gvGrilla.DataBind();

                cn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error al conectar con la base de datos: " + ex.ToString());
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            txtBoxCategoria.Text = "";
            txtBoxProducto.Text = "";
            DDL1.SelectedIndex = 0;
            DDL2.SelectedIndex = 0;
            try
            {

                cn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos", cn);


                DataSet ds = new DataSet();

                adapter.Fill(ds, "TablaProductos");

           

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
  