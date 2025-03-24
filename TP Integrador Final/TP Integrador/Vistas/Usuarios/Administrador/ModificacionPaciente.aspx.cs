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
            VerificarAcceso();
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
            //--Modo lectura
            grdModificacionPacietne.EditIndex = e.NewEditIndex;

            GridViewRow row = grdModificacionPacietne.Rows[e.NewEditIndex];

            string genero = ((Label)row.FindControl("lblGeneroPaciente"))?.Text;
            string nacionalidad = ((Label)row.FindControl("lblNacionalidadPaciente"))?.Text;
            string provincia = ((Label)row.FindControl("lblProvinciaPaciente"))?.Text;
            string localidad = ((Label)row.FindControl("lblLocalidadPaciente"))?.Text;

            CargarGridPacientes();

            //--Modo edicion
            row = grdModificacionPacietne.Rows[e.NewEditIndex];

            DropDownList ddlGenero = (DropDownList)row.FindControl("ddlGenero");
            DropDownList ddlNacionalidad = (DropDownList)row.FindControl("ddlNacionalidad");
            DropDownList ddlProvincia = (DropDownList)row.FindControl("ddlProvincia");
            DropDownList ddlLocalidad = (DropDownList)row.FindControl("ddlLocalidad");


            if (ddlGenero != null)
            {
                CargarGeneros(ddlGenero);
                if (!string.IsNullOrEmpty(genero))
                    ddlGenero.SelectedValue = ddlGenero.Items.FindByText(genero)?.Value;
            }

            if (ddlNacionalidad != null)
            {
                CargarPaises(ddlNacionalidad);
                if (!string.IsNullOrEmpty(nacionalidad))
                    ddlNacionalidad.SelectedValue = ddlNacionalidad.Items.FindByText(nacionalidad)?.Value;
            }

            if (ddlProvincia != null)
            {
                CargarProvincias(ddlProvincia);
                if (!string.IsNullOrEmpty(provincia))
                {
                    ddlProvincia.SelectedValue = ddlProvincia.Items.FindByText(provincia)?.Value;

                    if (ddlProvincia.SelectedIndex != -1 && ddlLocalidad != null)
                    {
                        int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
                        CargarLocalidadesPorProvincia(idProvincia, ddlLocalidad);

                        if (!string.IsNullOrEmpty(localidad))
                            ddlLocalidad.SelectedValue = ddlLocalidad.Items.FindByText(localidad)?.Value;
                    }
                }
            }
        }



        protected void grdModificacionPacietne_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                string _DNI_pac = ((Label)grdModificacionPacietne.Rows[e.RowIndex].FindControl("lblDniPaciente")).Text;
                string _Nombre_pac = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_NombrePaciente")).Text;
                string _Apellido_pac = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_ApellidoPaciente")).Text;

                int _Genero_pac = int.Parse(((DropDownList)grdModificacionPacietne.Rows[e.RowIndex].FindControl("ddlGenero")).SelectedValue);
                int _Nacionalidad_pac = int.Parse(((DropDownList)grdModificacionPacietne.Rows[e.RowIndex].FindControl("ddlNacionalidad")).SelectedValue);
                int _Provincia_pac = int.Parse(((DropDownList)grdModificacionPacietne.Rows[e.RowIndex].FindControl("ddlProvincia")).SelectedValue);
                int _Localidad_pac = int.Parse(((DropDownList)grdModificacionPacietne.Rows[e.RowIndex].FindControl("ddlLocalidad")).SelectedValue);

                string fechaTexto = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_FHNacimientoPaciente")).Text;
                DateTime _FechaNacimiento_pac = DateTime.Parse(fechaTexto);

                string _Direccion_pac = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_DireccionPaciente")).Text;
                string _CorreoElectronico_pac = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_EmailPaciente")).Text;
                string _Telefono_pac = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_TelefonoPaciente")).Text;

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

                int filasAfectadas = negocioP.ModificarPacienteNegocio(paciente);

                if (filasAfectadas > 0)
                {
                    grdModificacionPacietne.EditIndex = -1;
                    CargarGridPacientes();

                    lblMensaje.Text = "Paciente modificado con éxito.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMensaje.Text = "El paciente no se pudo modificar.";
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
            Response.Redirect("~/Inicio/InicioSesion.aspx");
        }

        // -------------------------------------------------------------------------------------------------Metodos
        void CargarGridPacientes() //Para vista del grid en el estado de edicion
        {
            dt = negocioP.FiltrarPacienteDNINegocios(txtBuscarPorDNI.Text);
            CargarGridPacientes(dt);
        }
        void CargarGridPacientes(DataTable dt) //Para la vista del grid
        {
            grdModificacionPacietne.DataSource = dt;
            grdModificacionPacietne.DataBind();
        }
        protected void btnResetear_Click(object sender, EventArgs e)
        {
            grdModificacionPacietne.DataSource = null;
            grdModificacionPacietne.DataBind();
            txtBuscarPorDNI.Text = string.Empty;
            lblMensaje.Text = string.Empty;
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

        //---------------------------------------------------------------------------------------------Metodo control acceso
        protected void VerificarAcceso()
        {
            Usuario usuarioLogueado = Session["UsuarioLogueado"] as Usuario;

            if (usuarioLogueado == null || !usuarioLogueado.EsAdministrador())
            {
                Response.Redirect("~/Inicio/AccesoDenegado.aspx");
                return;
            }

            // Mostrar el nombre de usuario en la barra de navegacion
            lblUsuarioEnSesion.Text = usuarioLogueado.NombreUsuario;
        }

    }
}