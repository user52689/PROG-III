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
        SqlConnection cn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    cn.Open();

                    /// cargar ddlProvinciaInicio
                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM Provincias", cn);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds, "Provincias");

                    foreach (DataRow dr in ds.Tables["Provincias"].Rows)
                    {
                        ddlProvinciaInicio.Items.Add(dr["IdProvincia"] + "-" + dr["NombreProvincia"]);
                    }

                    ///cargar ddlLocalidades
                    SqlDataAdapter adaptLocalidades = new SqlDataAdapter("SELECT * FROM Localidades", cn);
                    DataSet dsLocalidades = new DataSet();
                    adaptLocalidades.Fill(dsLocalidades, "Localidades");


                    foreach (DataRow dr in dsLocalidades.Tables["Localidades"].Rows)
                    {
                        ddlLocalidadInicio.Items.Add(dr["IdProvincia"] + "-" + dr["NombreLocalidad"]);
                    }

                    // cargar ddlProvinciaFinal
                    SqlDataAdapter adaptFinal = new SqlDataAdapter("SELECT * FROM Provincias", cn);
                    DataSet dsFinal = new DataSet();
                    adaptFinal.Fill(dsFinal, "Provincias");

                    foreach (DataRow dr in dsFinal.Tables["Provincias"].Rows)
                    {
                        ddlProvinciaFinal.Items.Add(dr["IdProvincia"] + "-" + dr["NombreProvincia"]);
                    }

                    cn.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("Error al conectar con la base de datos. Revise el nombre del Data Source en la conexion, debe coincidir con el nombre de su base de datos." + ex.Message);
                }
            }
        }
        void cargarDDLLocalidad(SqlConnection cn, DropDownList ddl, int IdProvincia)
        {
            cn.Open();
            SqlCommand sc = new SqlCommand("SELECT * FROM Localidades WHERE IdProvincia = '" + IdProvincia + "'", cn);
            SqlDataReader dr = sc.ExecuteReader();
            ddl.Items.Clear();
            ddl.Items.Add("--Seleccione una Localidad--");

            while (dr.Read())
            {
                ListItem lt = new ListItem(dr["NombreLocalidad"].ToString(), dr["IdLocalidad"].ToString());
                ddl.Items.Add(lt);
            }
            cn.Close();
        }

        protected void ddlProvinciaFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = ddlProvinciaFinal.SelectedIndex;
            cargarDDLLocalidad(cn, ddlLocalidadFinal, id);
            ddlLocalidadFinal.Enabled = true;

        }
        
        protected void ddlProvinciaInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ddlProvinciaInicio.SelectedValue;
            if (!string.IsNullOrEmpty(selectedValue) && selectedValue.Contains("-"))
            {
                int id = int.Parse(selectedValue.Split('-')[0]); 
                cargarDDLLocalidad(cn, ddlLocalidadInicio, id); 
                ddlLocalidadInicio.Enabled = true; 
            }
            else
            {
                ddlLocalidadInicio.Items.Clear();
                ddlLocalidadInicio.Items.Add("--Seleccione una Localidad--");
                ddlLocalidadInicio.Enabled = false;
            }

            foreach(ListItem items in ddlProvinciaFinal.Items)
            {
                if (items.Value.Equals(selectedValue))
                {
                    items.Enabled = false;
                }
                else
                {
                    items.Enabled = true;
                }
            }
        }      
    }
}