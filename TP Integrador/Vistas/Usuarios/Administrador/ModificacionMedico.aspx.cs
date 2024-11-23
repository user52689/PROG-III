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
    public partial class ModificacionMedico : System.Web.UI.Page
    {
        public NegociosMedico negocioM = new NegociosMedico();
        public readonly DropDownListService _dataService = new DropDownListService();
        DataTable dt = new DataTable();

        //----------------------------------------------------------------------------------------------------------------------Eventos 
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            dt = negocioM.FiltrarMedicosPorLegajoNegocio(Convert.ToInt32(txtBuscarPorLegajo.Text));

            if (dt != null && dt.Rows.Count > 0)
            {
                CargarGridMedicos(dt);
                lblMensaje.Text = string.Empty;
            }
            else
            {
                CargarGridMedicos(new DataTable());
                txtBuscarPorLegajo.Text = string.Empty;
                lblMensaje.Text = "No se encontró el médico.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void grdModificacionMedico_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdModificacionMedico.EditIndex = e.NewEditIndex;
            CargarGridMedicos();

            GridViewRow row = grdModificacionMedico.Rows[e.NewEditIndex];

            DropDownList ddlGenero = (DropDownList)row.FindControl("ddlGenero");
            DropDownList ddlNacionalidad = (DropDownList)row.FindControl("ddlNacionalidad");
            DropDownList ddlProvincia = (DropDownList)row.FindControl("ddlProvincia");
            DropDownList ddlLocalidad = (DropDownList)row.FindControl("ddlLocalidad");
            DropDownList ddlEspecialidad = (DropDownList)row.FindControl("ddlEspecialidad");

            CargarGeneros(ddlGenero);
            CargarPaises(ddlNacionalidad);
            CargarProvincias(ddlProvincia);

            if (ddlProvincia.SelectedIndex != -1)
            {
                int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
                CargarLocalidadesPorProvincia(idProvincia, ddlLocalidad);
            }

            CargarEspecialidades(ddlEspecialidad);
        }


        protected void grdModificacionMedico_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int legajo = Convert.ToInt32(txtBuscarPorLegajo.Text);

                string _DNI_med = ((Label)grdModificacionMedico.Rows[e.RowIndex].FindControl("lblDniMedico"))?.Text ?? string.Empty;
                string _Nombre_med = ((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_NombreMedico"))?.Text ?? string.Empty;
                string _Apellido_med = ((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_ApellidoMedico"))?.Text ?? string.Empty;

                int _Genero_med = 0;
                int _Nacionalidad_med = 0;
                int _Provincia_med = 0;
                int _Localidad_med = 0;
                int _Especialidad_med = 0;

                if (int.TryParse(((DropDownList)grdModificacionMedico.Rows[e.RowIndex].FindControl("ddlGenero"))?.SelectedValue, out _Genero_med) &&
                    int.TryParse(((DropDownList)grdModificacionMedico.Rows[e.RowIndex].FindControl("ddlNacionalidad"))?.SelectedValue, out _Nacionalidad_med) &&
                    int.TryParse(((DropDownList)grdModificacionMedico.Rows[e.RowIndex].FindControl("ddlProvincia"))?.SelectedValue, out _Provincia_med) &&
                    int.TryParse(((DropDownList)grdModificacionMedico.Rows[e.RowIndex].FindControl("ddlLocalidad"))?.SelectedValue, out _Localidad_med) &&
                    int.TryParse(((DropDownList)grdModificacionMedico.Rows[e.RowIndex].FindControl("ddlEspecialidad"))?.SelectedValue, out _Especialidad_med))
                {
                    string fechaTexto = ((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_FHNacimientoMedico")).Text;
                    DateTime _FechaNacimiento_med = DateTime.Parse(fechaTexto);

                    string _Direccion_med = ((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_DireccionMedico"))?.Text ?? string.Empty;
                    string _CorreoElectronico_med = ((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_EmailMedico"))?.Text ?? string.Empty;
                    string _Telefono_med = ((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_TelefonoMedico"))?.Text ?? string.Empty;

                    Medico medico = new Medico
                    {
                        Legajo = legajo,
                        DNI = _DNI_med,
                        Nombre = _Nombre_med,
                        Apellido = _Apellido_med,
                        Genero = _Genero_med,
                        Nacionalidad = _Nacionalidad_med,
                        FechaNacimiento = _FechaNacimiento_med,
                        Direccion = _Direccion_med,
                        Provincia = _Provincia_med,
                        Localidad = _Localidad_med,
                        CorreoElectronico = _CorreoElectronico_med,
                        Telefono = _Telefono_med,
                        Especialidad = _Especialidad_med,
                        Estado = true
                    };

                    negocioM.ModificarMedicoNegocio(medico);

                    grdModificacionMedico.EditIndex = -1;
                    CargarGridMedicos();

                    lblMensaje.Text = "Médico modificado con éxito.";
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
                lblMensaje.Text = "Se produjo un error al intentar modificar el médico: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void grdModificacionMedico_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdModificacionMedico.EditIndex = -1;
            CargarGridMedicos();
        }     

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlProvincia = (DropDownList)sender;
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue); 
            DropDownList ddlLocalidad = (DropDownList)grdModificacionMedico.Rows[grdModificacionMedico.EditIndex].FindControl("ddlLocalidad");
            CargarLocalidadesPorProvincia(idProvincia, ddlLocalidad);
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("InicioSesion.aspx");
        }

        //--------------------------------------------------------------------------------------------------------------------Metodos
        void CargarGridMedicos()
        {
            dt = negocioM.FiltrarMedicoLegajoNegocios(Convert.ToInt32(txtBuscarPorLegajo.Text)); 
            CargarGridMedicos(dt);
        }

        void CargarGridMedicos(DataTable dt)
        {
            grdModificacionMedico.DataSource = dt;
            grdModificacionMedico.DataBind();
        }

        //-----------------------------------------------------------------------------------------------------------------Cargar ddl

        private void CargarGeneros(DropDownList ddlGenero)
        {
            List<Genero> generos = _dataService.ObtenerGeneros();
            DropDownListHelper.Cargar(ddlGenero, generos, "Descripcion", "IdGenero_g");
        }

        private void CargarPaises(DropDownList ddlNacionalidad)
        {
            List<Pais> paises = _dataService.ObtenerPaises();
            DropDownListHelper.Cargar(ddlNacionalidad, paises, "Descripcion", "IdPais_p");
        }

        private void CargarProvincias(DropDownList ddlProvincia)
        {
            List<Provincia> provincias = _dataService.ObtenerProvincias();
            DropDownListHelper.Cargar(ddlProvincia, provincias, "Descripcion", "IdProvincia_prov");
        }
        private void CargarLocalidadesPorProvincia(int idProvincia, DropDownList ddlLocalidad)
        {
            List<Localidad> localidades = _dataService.ObtenerLocalidadesPorProvincia(idProvincia);
            DropDownListHelper.Cargar(ddlLocalidad, localidades, "Descripcion", "IdLocalidad_loc");
        }

        private void CargarEspecialidades(DropDownList ddlEspecialidad)
        {
            List<Especialidad> especialidades = _dataService.ObtenerEspecialidades();
            DropDownListHelper.Cargar(ddlEspecialidad, especialidades, "Descripcion", "IdEspecialidad_esp");
        }

        //-----------------------------------------------------------------------------------------------------------------Carga ddls con datos de registros en modo edicion - NO BORRAR!
        //private void CargarGenerosEdicion(DropDownList ddlGenero)
        //{
        //    _dataService.ObtenerGeneros();
        //}

        //private void CargarPaisesEdicion(DropDownList ddlNacionalidad)
        //{
        //    List<Pais> paises = _dataService.ObtenerPaises();
        //    DropDownListHelper.Cargar(ddlNacionalidad, paises, "Descripcion", "IdPais_p");
        //}

        //private void CargarProvinciasEdicion(DropDownList ddlProvincia)
        //{
        //    List<Provincia> provincias = _dataService.ObtenerProvincias();
        //    DropDownListHelper.Cargar(ddlProvincia, provincias, "Descripcion", "IdProvincia_prov");
        //}
        //private void CargarLocalidadesPorProvinciaEdicion(int idProvincia, DropDownList ddlLocalidad)
        //{
        //    List<Localidad> localidades = _dataService.ObtenerLocalidadesPorProvincia(idProvincia);
        //    DropDownListHelper.Cargar(ddlLocalidad, localidades, "Descripcion", "IdLocalidad_loc");
        //}

        //private void CargarEspecialidadesEdicion(DropDownList ddlEspecialidad)
        //{
        //    List<Especialidad> especialidades = _dataService.ObtenerEspecialidades();
        //    DropDownListHelper.Cargar(ddlEspecialidad, especialidades, "Descripcion", "IdEspecialidad_esp");
        //}
    }
}
