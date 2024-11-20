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
namespace Vistas
{
    public partial class ModificacionMedico : System.Web.UI.Page
    {
        NegociosMedico negocioM = new NegociosMedico();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        void CargarGridMedicos()
        {
            dt = negocioM.FiltrarMedicoLegajoNegocios(Convert.ToInt32(txtBuscarPorLegajo.Text)); // Este método obtiene la tabla de médicos para cargarla en el grid
            CargarGridMedicos(dt);
        }

        void CargarGridMedicos(DataTable dt)
        {
            grdModificacionMedico.DataSource = dt;
            grdModificacionMedico.DataBind();
        }

        //----------------------------------------------------------------------------------------------------------------------Eventos de botones

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            dt = negocioM.FiltrarMedicoLegajoNegocios(Convert.ToInt32(txtBuscarPorLegajo.Text));

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

            DropDownList ddlGenero = (DropDownList)row.FindControl("ddlGeneroMedico");
            DropDownList ddlNacionalidad = (DropDownList)row.FindControl("ddlNacionalidadMedico");
            DropDownList ddlProvincia = (DropDownList)row.FindControl("ddlProvinciaMedico");
            DropDownList ddlLocalidad = (DropDownList)row.FindControl("ddlLocalidadMedico");
            DropDownList ddlEspecialidad = (DropDownList)row.FindControl("ddlEspecialidadMedico");

            if (ddlGenero != null)
            {
                CargarGeneros(ddlGenero);
            }
            if (ddlNacionalidad != null)
            {
                CargarNacionalidades(ddlNacionalidad);
            }
            if (ddlProvincia != null)
            {
                CargarProvincias(ddlProvincia);
            }
            if (ddlLocalidad != null)
            {
                CargarLocalidades(ddlLocalidad);
            }
            if(ddlEspecialidad != null)
            {
                CargarEspecialidades(ddlEspecialidad);
            }
        }

        protected void grdModificacionMedico_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int legajo = Convert.ToInt32(txtBuscarPorLegajo.Text);

            string _DNI_med = ((Label)grdModificacionMedico.Rows[e.RowIndex].FindControl("lblDniMedico")).Text;
            string _Nombre_med = ((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_NombreMedico")).Text;
            string _Apellido_med = ((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_ApellidoMedico")).Text;
            int _Genero_med = int.Parse(((DropDownList)grdModificacionMedico.Rows[e.RowIndex].FindControl("ddlGeneroMedico")).SelectedValue);
            int _Nacionalidad_med = int.Parse(((DropDownList)grdModificacionMedico.Rows[e.RowIndex].FindControl("ddlNacionalidadMedico")).SelectedValue);

            string fechaTexto = ((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_FHNacimientoMedico")).Text;
            DateTime _FechaNacimiento_med = DateTime.Parse(fechaTexto);

            string _Direccion_med = ((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_DireccionMedico")).Text;
            int _Provincia_med = int.Parse(((DropDownList)grdModificacionMedico.Rows[e.RowIndex].FindControl("ddlProvinciaMedico")).SelectedValue);
            int _Localidad_med = int.Parse(((DropDownList)grdModificacionMedico.Rows[e.RowIndex].FindControl("ddlLocalidadMedico")).SelectedValue);
            string _CorreoElectronico_med = ((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_EmailMedico")).Text;
            string _Telefono_med = ((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_TelefonoMedico")).Text;
            int _Especialidad_med = int.Parse(((DropDownList)grdModificacionMedico.Rows[e.RowIndex].FindControl("ddlEspecialidadMedico")).SelectedValue);

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
                Especialidad = _Especialidad_med
            };

            negocioM.ModificarMedicoNegocio(medico);

            grdModificacionMedico.EditIndex = -1;
            CargarGridMedicos();

            lblMensaje.Text = "Médico modificado con éxito.";
            lblMensaje.ForeColor = System.Drawing.Color.Green;
        }

        protected void grdModificacionMedico_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdModificacionMedico.EditIndex = -1;
            CargarGridMedicos();
        }

        //---------------------------------------------------------------------------------------------------------------------- Cargas de los dropdowns

        private void CargarGeneros(DropDownList ddlGenero)
        {
            ddlGenero.DataSource = negocioM.CargarGenerosNegocio();
            ddlGenero.DataTextField = "Descripcion_g";
            ddlGenero.DataValueField = "IdGenero_g";
            ddlGenero.DataBind();
            ddlGenero.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        private void CargarEspecialidades(DropDownList ddlEspecialidad)
        {
            ddlEspecialidad.DataSource = negocioM.CargarEspecialidadesNegocio();
            ddlEspecialidad.DataTextField = "Nombre_esp";
            ddlEspecialidad.DataValueField = "IdEspecialidad_esp";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        private void CargarNacionalidades(DropDownList ddlNacionalidad)
        {
            ddlNacionalidad.DataSource = negocioM.CargarNacionalidadesNegocio();
            ddlNacionalidad.DataTextField = "Nombre_pais";
            ddlNacionalidad.DataValueField = "IdPais_p";
            ddlNacionalidad.DataBind();
            ddlNacionalidad.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        private void CargarProvincias(DropDownList ddlProvincia)
        {
            ddlProvincia.DataSource = negocioM.CargarProvinciasNegocio();
            ddlProvincia.DataTextField = "Nombre_prov";
            ddlProvincia.DataValueField = "IdProvincia_prov";
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        private void CargarLocalidades(DropDownList ddlLocalidad)
        {
            ddlLocalidad.DataSource = negocioM.CargarLocalidadesNegocio();
            ddlLocalidad.DataTextField = "Nombre_loc";
            ddlLocalidad.DataValueField = "IdLocalidad_loc";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        protected void ddlProvinciaMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlProvincia = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlProvincia.NamingContainer;
            DropDownList ddlLocalidad = (DropDownList)row.FindControl("ddlLocalidadMedico");

            if (ddlLocalidad != null)
            {
                int IdProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
                CargarLocalidadesPorProvincia(ddlLocalidad, IdProvincia);
            }
        }

        private void CargarLocalidadesPorProvincia(DropDownList ddlLocalidad, int IdProvincia)
        {
            dt = negocioM.CargarLocalidadesPorProvinciaNegocio(IdProvincia);
            ddlLocalidad.DataSource = dt;
            ddlLocalidad.DataTextField = "Nombre_loc";
            ddlLocalidad.DataValueField = "IdLocalidad_loc";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("InicioSesion.aspx");
        }
    }
}
