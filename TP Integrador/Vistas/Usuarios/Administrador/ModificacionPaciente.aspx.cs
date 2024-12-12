using Datos;
using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vistas.Helper;

namespace Vistas
{
    public partial class ModificacionPaciente : System.Web.UI.Page
    {
        public readonly DropDownListService _dataService = new DropDownListService();
        NegociosPaciente negocioP = new NegociosPaciente();
        DataTable dt = new DataTable();
        
        //----------------------------------------------------------------------------------------------------------------------Eventos

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string DNIstring = txtBuscarPorDNI.Text;  

            dt = negocioP.FiltrarPacienteDNINegocios(DNIstring);

            if (dt != null && dt.Rows.Count > 0)
            { 
                CargarGridPacientes(dt);
                lblMensaje.Text = string.Empty;  
            }
            else
            {

                CargarGridPacientes(null);
                txtBuscarPorDNI.Text = string.Empty; 
                lblMensaje.Text = "No se encontró el paciente.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }



        protected void grdModificacionPacietne_RowEditing(object sender, GridViewEditEventArgs e) 
        {
            grdModificacionPacietne.EditIndex = e.NewEditIndex;
            CargarGridPacientes();

            GridViewRow row = grdModificacionPacietne.Rows[e.NewEditIndex];

            CargarGeneros((DropDownList)row.FindControl("ddlGenero"));
            CargarPaises((DropDownList)row.FindControl("ddlNacionalidad"));
            CargarProvincias((DropDownList)row.FindControl("ddlProvincia"));

            var ddlProvincia = (DropDownList)row.FindControl("ddlProvincia");
            var ddlLocalidad = (DropDownList)row.FindControl("ddlLocalidad");
            if (ddlProvincia != null && ddlProvincia.SelectedIndex != -1)
            {
                int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
                CargarLocalidadesPorProvincia(idProvincia, ddlLocalidad);
            }
        }
        protected void grdModificacionPacietne_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                string legajo = txtBuscarPorDNI.Text;

                string _DNI_pac = ((Label)grdModificacionPacietne.Rows[e.RowIndex].FindControl("lblDniPaciente"))?.Text ?? string.Empty;
                string _Nombre_pac = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_NombrePaciente"))?.Text ?? string.Empty;
                string _Apellido_pac = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_ApellidoPaciente"))?.Text ?? string.Empty;

                if (int.TryParse(((DropDownList)grdModificacionPacietne.Rows[e.RowIndex].FindControl("ddlGenero"))?.SelectedValue, out int _Genero_pac) &&
                    int.TryParse(((DropDownList)grdModificacionPacietne.Rows[e.RowIndex].FindControl("ddlNacionalidad"))?.SelectedValue, out int _Nacionalidad_pac) &&
                    int.TryParse(((DropDownList)grdModificacionPacietne.Rows[e.RowIndex].FindControl("ddlProvincia"))?.SelectedValue, out int _Provincia_pac) &&
                    int.TryParse(((DropDownList)grdModificacionPacietne.Rows[e.RowIndex].FindControl("ddlLocalidad"))?.SelectedValue, out int _Localidad_pac))
                {
                    string fechaTexto = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_FHNacimientoPaciente")).Text;
                    DateTime _FechaNacimiento_pac = DateTime.Parse(fechaTexto);

                    string _Direccion_pac = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_DireccionPaciente"))?.Text ?? string.Empty;
                    string _CorreoElectronico_pac = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_EmailPaciente"))?.Text ?? string.Empty;
                    string _Telefono_pac = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_TelefonoPaciente"))?.Text ?? string.Empty;

                    Paciente paciente = new Paciente
                    {
                        DNI = _DNI_pac,
                        Nombre = _Nombre_pac,
                        Apellido = _Apellido_pac,
                        Genero = _Genero_pac,
                        Nacionalidad = _Nacionalidad_pac,
                        FechaNacimiento = _FechaNacimiento_pac,
                        Direccion = _Direccion_pac,
                        Provincia = _Provincia_pac,
                        Localidad = _Localidad_pac,
                        CorreoElectronico = _CorreoElectronico_pac,
                        Telefono = _Telefono_pac,
                        Estado = true
                    };

                    negocioP.ModificarPacienteNegocio(paciente);

                    grdModificacionPacietne.EditIndex = -1;
                    CargarGridPacientes();

                    lblMensaje.Text = "Paciente modificado con éxito.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMensaje.Text = "Por favor, seleccione valores válidos para todos los campos.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Se produjo un error al intentar modificar el paciente: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

        }
        protected void grdModificacionPacietne_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdModificacionPacietne.EditIndex = -1;
            CargarGridPacientes();
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlProvincia = (DropDownList)sender;
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
            DropDownList ddlLocalidad = (DropDownList)grdModificacionPacietne.Rows[grdModificacionPacietne.EditIndex].FindControl("ddlLocalidad");
            CargarLocalidadesPorProvincia(idProvincia, ddlLocalidad);
        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("InicioSesion.aspx");
        }

        // -------------------------------------------------------------------------------------------------Metodos
        void CargarGridPacientes() //Para vista del grid en el estado de edicion
        {
            dt = negocioP.FiltrarPacienteDNINegocios(txtBuscarPorDNI.Text);
            CargarGridPacientes(dt);        }
        void CargarGridPacientes(DataTable dt) //Para la vista del grid
        {
            grdModificacionPacietne.DataSource = dt;
            grdModificacionPacietne.DataBind();
        }

        //-----------------------------------------------------------------------------------------------------------------Cargar ddl

        private void CargarGeneros(DropDownList ddlGenero)
        {
            List<Genero> generos = _dataService.ObtenerGeneros();
            DropDownListControlador.CargarDDL(ddlGenero, generos, "Descripcion", "IdGenero_g");
        }

        private void CargarPaises(DropDownList ddlNacionalidad)
        {
            List<Pais> paises = _dataService.ObtenerPaises();
            DropDownListControlador.CargarDDL(ddlNacionalidad, paises, "Descripcion", "IdPais_p");
        }

        private void CargarProvincias(DropDownList ddlProvincia)
        {
            List<Provincia> provincias = _dataService.ObtenerProvincias();
            DropDownListControlador.CargarDDL(ddlProvincia, provincias, "Descripcion", "IdProvincia_prov");
        }
        private void CargarLocalidadesPorProvincia(int idProvincia, DropDownList ddlLocalidad)
        {
            List<Localidad> localidades = _dataService.ObtenerLocalidadesPorProvincia(idProvincia);
            DropDownListControlador.CargarDDL(ddlLocalidad, localidades, "Descripcion", "IdLocalidad_loc");
        }
    }
}