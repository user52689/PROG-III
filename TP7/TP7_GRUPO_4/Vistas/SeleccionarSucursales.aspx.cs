using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP7_GRUPO_4.Controladores;

namespace TP7_GRUPO_4.Vistas
{
    public partial class SeleccionarSucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        
        protected void btnSeleccionar_Command1(object sender, CommandEventArgs e)
        {
            //ItemTemplate
            if (e.CommandName == "eventoSeleccionar")
            {
                GestionSucursales gs = new GestionSucursales();
                gs.VariableSessionSucursalesSeleccionadas(sender, e, lblMostrarSucursalesSeleccionadas, lblCantidadSucursalesSeleccionadas);
            }
        }

        protected void btnSeleccionar_Command2(object sender, CommandEventArgs e)
        {
            //AlternatinItemTemplate
            if (e.CommandName == "eventoSeleccionar")
            {
                GestionSucursales gs = new GestionSucursales();
                gs.VariableSessionSucursalesSeleccionadas(sender, e, lblMostrarSucursalesSeleccionadas, lblCantidadSucursalesSeleccionadas);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreSucursal = txtBusquedaPorNombreSucursal.Text.Trim();
            GestionSucursales gs = new GestionSucursales();

            // Llamada al metodo para filtrar las sucursales por nombre
            DataTable resultadoBusqueda = gs.BuscarSucursalPorNombre(nombreSucursal);

            SqlDataSource1.SelectCommand = "SELECT * FROM Sucursal WHERE NombreSucursal LIKE '%" + nombreSucursal + "%'";
        }

        protected void ComandoProvincia(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ComandoBoton")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                SqlDataSource1.SelectCommand = $"select id_sucursal,nombreSucursal,DescripcionSucursal,URL_Imagen_Sucursal from Sucursal where  Id_ProvinciaSucursal = {id}";
            }
         
        }
    }
}   