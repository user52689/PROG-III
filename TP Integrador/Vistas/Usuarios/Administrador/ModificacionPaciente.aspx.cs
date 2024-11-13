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
    public partial class ModificacionPaciente : System.Web.UI.Page
    {
        NegociosPaciente negocioP = new NegociosPaciente();
        DataTable dt = new DataTable();
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void CargarGridPacientes() //Para vista del grid en el estado de edicion
        {
            dt = negocioP.FiltrarPacienteDNIModificacionNegocios(txtBuscarPorDNI.Text);
            CargarGridPacientes(dt)
;        }
        void CargarGridPacientes(DataTable dt) //Para la vista del grid
        {
            grdModificacionPacietne.DataSource = dt;
            grdModificacionPacietne.DataBind();
        }


        //----------------------------------------------------------------------------------------------------------------------Eventos de botones

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            dt = negocioP.FiltrarPacienteDNIModificacionNegocios(txtBuscarPorDNI.Text);

            if (dt != null)
            {
                CargarGridPacientes(dt);
                lblMensaje.Text = string.Empty;
                //txtBuscarPorDNI.Text = string.Empty; como ahce una variable global para almacenar
            }
            else
            {
                CargarGridPacientes(dt);
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

            DropDownList ddlGenero = (DropDownList)row.FindControl("ddlGeneroPaciente");
            DropDownList ddlNacionalidad = (DropDownList)row.FindControl("ddlNacionalidadPaciente");
            DropDownList ddlProvincia = (DropDownList)row.FindControl("ddlProvinciaPaciente");
            DropDownList ddlLocalidad = (DropDownList)row.FindControl("ddlLocalidadPaciente");

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
        }


        protected void grdModificacionPacietne_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string _DNI_pac = ((Label)grdModificacionPacietne.Rows[e.RowIndex].FindControl("lblDniPaciente")).Text;
            string _Nombre_pac = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_NombrePaciente")).Text;
            string _Apellido_pac = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_ApellidoPaciente")).Text;
            int _Genero_pac = int.Parse(((DropDownList)grdModificacionPacietne.Rows[e.RowIndex].FindControl("ddlGeneroPaciente")).SelectedValue);
            int _Nacionalidad_pac = int.Parse(((DropDownList)grdModificacionPacietne.Rows[e.RowIndex].FindControl("ddlNacionalidadPaciente")).SelectedValue);

            string fechaTexto = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_FHNacimientoPaciente")).Text;
            DateTime _FechaNacimiento_pac = DateTime.Parse(fechaTexto);


            string _Direccion_pac = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_DireccionPaciente")).Text;
            int _Provincia_pac = int.Parse(((DropDownList)grdModificacionPacietne.Rows[e.RowIndex].FindControl("ddlProvinciaPaciente")).SelectedValue);
            int _Localidad_pac = int.Parse(((DropDownList)grdModificacionPacietne.Rows[e.RowIndex].FindControl("ddlLocalidadPaciente")).SelectedValue);
            string _CorreoElectronico_pac = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_EmailPaciente")).Text;
            string _Telefono_pac = ((TextBox)grdModificacionPacietne.Rows[e.RowIndex].FindControl("txt_it_TelefonoPAciente")).Text;

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
                Telefono = _Telefono_pac
            };

            negocioP.ModificarPacienteNegocio(paciente);

            if (negocioP != null)
            {
                grdModificacionPacietne.EditIndex = -1;

                CargarGridPacientes();

                txtBuscarPorDNI.Text = string.Empty;
                lblMensaje.Text = "Paciente modificado con éxito.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                
            }
            else
            {
                txtBuscarPorDNI.Text = string.Empty;
                lblMensaje.Text = "No se pudo modificar el paciente";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

        }


        protected void grdModificacionPacietne_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdModificacionPacietne.EditIndex = -1;
            CargarGridPacientes();
        }
        //----------------------------------------------------------------------------------------------------------------------Cargas de los ddl 
        //-----------------------------------------------------------------------------Carga ddl de Generos


        private void CargarGeneros(DropDownList ddlGenero) 
        {
            ddlGenero.DataSource = negocioP.CargarGenerosNegocio();
            ddlGenero.DataTextField = "Descripcion_g";
            ddlGenero.DataValueField = "IdGenero_g";
            ddlGenero.DataBind();
            ddlGenero.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }


    //----------------------------------------------------------------------------Carga ddl de Nacionalidades
    private void CargarNacionalidades(DropDownList ddlNacionalidad)
        {
            ddlNacionalidad.DataSource = negocioP.CargarNacionalidadesNegocio();
            ddlNacionalidad.DataTextField = "Nombre_pais";
            ddlNacionalidad.DataValueField = "IdPais_p";
            ddlNacionalidad.DataBind();
            ddlNacionalidad.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        //----------------------------------------------------------------------------Carga ddl de Provincias
        private void CargarProvincias(DropDownList ddlProvincia)
        {
            ddlProvincia.DataSource = negocioP.CargarProvinciasNegocio();
            ddlProvincia.DataTextField = "Nombre_prov";
            ddlProvincia.DataValueField = "IdProvincia_prov";
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        //----------------------------------------------------------------------------Carga ddl de Localidades
        private void CargarLocalidades(DropDownList ddlLocalidad)
        {
            ddlLocalidad.DataSource = negocioP.CargarLocalidadesNegocio();
            ddlLocalidad.DataTextField = "Nombre_loc";
            ddlLocalidad.DataValueField = "IdLocalidad_loc";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        protected void ddlProvinciaPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlProvincia = (DropDownList)sender;

            GridViewRow row = (GridViewRow)ddlProvincia.NamingContainer;

            DropDownList ddlLocalidad = (DropDownList)row.FindControl("ddlLocalidadPaciente");

            if (ddlLocalidad != null)
            {
                int IdProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
                CargarLocalidadesPorProvincia(ddlLocalidad, IdProvincia);
            }
        }
        private void CargarLocalidadesPorProvincia(DropDownList ddlLocalidad, int IdProvincia)
        {
            dt = negocioP.CargarLocalidadesPorProvinciaNegocio(IdProvincia);

            ddlLocalidad.DataSource = dt;
            ddlLocalidad.DataTextField = "Nombre_loc";
            ddlLocalidad.DataValueField = "IdLocalidad_loc";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }
    }
}