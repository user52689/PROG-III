using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static TP_5.Conexion;

namespace TP_5
{
    public partial class AgregarSucursal : System.Web.UI.Page
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        Conexion conexion = null;

        //Esta funcion carga las provincias en el dropdownlist
        public void CargarProvincias(DropDownList ddlProvincias)
        {
            try
            {
                conexion = new Conexion();
                using (cn = new SqlConnection(conexion.getRuta()))
                {
                    string consulta = "SELECT * FROM Provincia";
                    cn.Open();

                    using (cmd = new SqlCommand(consulta, cn))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            ddlProvincias.DataSource = dr;
                            ddlProvincias.DataTextField = "DescripcionProvincia";
                            ddlProvincias.DataValueField = "Id_Provincia";
                            ddlProvincias.DataBind();
                        }
                    }
                }

                ddlProvincias.Items.Insert(0, new ListItem("--Seleccione--", "0"));
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error en la conexión SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió algún error al cargar las provincias: " + ex.Message);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            {
                CargarProvincias(ddlProvincia);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) // Verifica si todos los validadores pasaron
            {
                string consulta = "INSERT INTO Sucursal (NombreSucursal, DescripcionSucursal, Id_ProvinciaSucursal, DireccionSucursal) " +
                                 "VALUES (@NombreSucursal, @Descripcionsucursal, @Id_Provinciasucursal, @DireccionSucursal)";

                conexion = new Conexion();
                

                using (cmd = new SqlCommand(consulta))
                {
                    cmd.Parameters.AddWithValue("@NombreSucursal", txtNombreSucursal.Text);
                    cmd.Parameters.AddWithValue("@Descripcionsucursal", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@Id_Provinciasucursal", ddlProvincia.SelectedValue);
                    cmd.Parameters.AddWithValue("@DireccionSucursal", txtDireccion.Text);

                    int mensaje = conexion.Transaccion(cmd);

                    if (mensaje == 1)
                    {
                        lblMensaje.Text = "Se agrego la sucursal de la BD";
                    }
                }
                limpiarCampos();
            }
        }

        protected void limpiarCampos()
        {
            txtDescripcion.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtNombreSucursal.Text = string.Empty;
            ddlProvincia.SelectedIndex = 0;
        }
    }
}