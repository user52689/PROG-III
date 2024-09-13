using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TP4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {
                try
                {
                    SqlConnection cn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True");
              
                    cn.Open();               

                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM Provincias", cn);



                    DataSet ds = new DataSet();
                
                    adapt.Fill(ds, "Provincias");
               
                    foreach(DataRow dr in ds.Tables["Provincias"].Rows)
                    {
                        ddlProvinciaInicio.Items.Add(dr["IdProvincia"] + "-" + dr["NombreProvincia"]);
                    }

                    SqlDataAdapter adaptLocalidades = new SqlDataAdapter("SELECT * FROM Localidades",cn);

                    DataSet dsLocalidades = new DataSet();
                    
                    adaptLocalidades.Fill(dsLocalidades, "Localidades");


                    foreach(DataRow dr in dsLocalidades.Tables["Localidades"].Rows)
                    {
                        ddlLocalidadInicio.Items.Add(dr["IdProvincia"] + "-" + dr["NombreLocalidad"]);
                    }


                    cn.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("Error al conectar con la base de datos. Revise el nombre del Data Source en la conexion, debe coincidir con el nombre de su base de datos." + ex.Message);  
                }

               
                






            }
        }

    }
}