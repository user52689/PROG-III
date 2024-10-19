using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class AgregarSucursal : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        NegocioProvincia np = new NegocioProvincia();

        private void CargarProvincias(DropDownList ddlProvincias)
        {
            ddlProvincias.DataSource =np.CargarProvincias();
            ddlProvincias.DataTextField = "DescripcionProvincia"; 
            ddlProvincias.DataValueField = "Id_Provincia"; 
            ddlProvincias.DataBind();
            ddlProvincias.Items.Insert(0, new ListItem("--Seleccione--", "0")); 
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                CargarProvincias(ddlProvincias);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) 
            {
                string consulta = "INSERT INTO Sucursal (NombreSucursal, DescripcionSucursal, Id_ProvinciaSucursal, DireccionSucursal) " +
                                 "VALUES (@NombreSucursal, @Descripcionsucursal, @Id_Provinciasucursal, @DireccionSucursal)";
                

                //conexion = new Conexion();


                using (cmd = new SqlCommand(consulta))
                {
                    cmd.Parameters.AddWithValue("@NombreSucursal", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Descripcionsucursal", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@Id_Provinciasucursal", ddlProvincias.SelectedValue);
                    cmd.Parameters.AddWithValue("@DireccionSucursal", txtDireccion.Text);

                  //  int mensaje = conexion.Transaccion(cmd);

                    //if (mensaje == 1)
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
            txtNombre.Text = string.Empty;
            ddlProvincias.SelectedIndex = 0;
        }
    }

}