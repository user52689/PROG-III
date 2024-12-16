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
        public DataTable dt = new DataTable();

        //----------------------------------------------------------------------------------------------------------------------Eventos 
        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarAcceso();
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBuscarPorLegajo.Text, out int _Legajo))
            {
                lblMensaje.Text = "Ingrese un legajo válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            dt = negocioM.FiltrarMedicosPorLegajoNegocio(_Legajo);

            if (dt != null && dt.Rows.Count > 0)
            {
                CargarGridMedico(dt);
                lblMensaje.Text = string.Empty;
            }
            else
            {
                CargarGridMedico(new DataTable());
                lblMensaje.Text = "No se encontró el médico.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void grdModificacionMedico_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdModificacionMedico.EditIndex = e.NewEditIndex;
            CargarGridMedico();

            GridViewRow row = grdModificacionMedico.Rows[e.NewEditIndex];

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
            CargarEspecialidades(((DropDownList)row.FindControl("ddlEspecialidad")));
        }



        protected void grdModificacionMedico_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int _Legajo = Convert.ToInt32(txtBuscarPorLegajo.Text);
                string _DNI_med = ((Label)grdModificacionMedico.Rows[e.RowIndex].FindControl("lblDniMedico"))?.Text ?? string.Empty;
                string _Nombre_med = ((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_NombreMedico"))?.Text ?? string.Empty;
                string _Apellido_med = ((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_ApellidoMedico"))?.Text ?? string.Empty;

                if (int.TryParse(((DropDownList)grdModificacionMedico.Rows[e.RowIndex].FindControl("ddlGenero"))?.SelectedValue, out int _Genero_med) &&
                    int.TryParse(((DropDownList)grdModificacionMedico.Rows[e.RowIndex].FindControl("ddlNacionalidad"))?.SelectedValue, out int _Nacionalidad_med) &&
                    int.TryParse(((DropDownList)grdModificacionMedico.Rows[e.RowIndex].FindControl("ddlProvincia"))?.SelectedValue, out int _Provincia_med) &&
                    int.TryParse(((DropDownList)grdModificacionMedico.Rows[e.RowIndex].FindControl("ddlLocalidad"))?.SelectedValue, out int _Localidad_med) &&
                    int.TryParse(((DropDownList)grdModificacionMedico.Rows[e.RowIndex].FindControl("ddlEspecialidad"))?.SelectedValue, out int _Especialidad_med))
                {

                    if (!DateTime.TryParse(((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_FHNacimientoMedico"))?.Text, out DateTime _FechaNacimiento_med))
                    {
                        lblMensaje.Text = "Ingrese una fecha válida.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    string _Direccion_med = ((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_DireccionMedico"))?.Text ?? string.Empty;
                    string _CorreoElectronico_med = ((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_EmailMedico"))?.Text ?? string.Empty;
                    string _Telefono_med = ((TextBox)grdModificacionMedico.Rows[e.RowIndex].FindControl("txt_it_TelefonoMedico"))?.Text ?? string.Empty;


                    List<(int dia, int hora)> diaxhora = new List<(int dia, int hora)>();
                    CheckBoxList cblDias = (CheckBoxList)grdModificacionMedico.Rows[e.RowIndex].FindControl("cblDias");
                    DropDownList ddlHorarioAtencion = (DropDownList)grdModificacionMedico.Rows[e.RowIndex].FindControl("ddlHorarioAtencion");

                    foreach (ListItem item in cblDias.Items)
                    {
                        if (item.Selected)
                        {
                            diaxhora.Add((int.Parse(item.Value), int.Parse(ddlHorarioAtencion.SelectedValue)));
                        }
                    }

                    Medico medico = new Medico
                    {
                        Legajo = _Legajo,
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
                        Diaxhora = diaxhora,
                        Estado = true
                    };

                    negocioM.ModificarMedicoNegocio(medico);

                    grdModificacionMedico.EditIndex = -1;
                    CargarGridMedico();

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
            CargarGridMedico();
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
            Response.Redirect("~/Inicio/InicioSesion.aspx");
        }
        protected void btnResetear_Click(object sender, EventArgs e)
        {
            grdModificacionMedico.DataSource = null;
            grdModificacionMedico.DataBind();
            txtBuscarPorLegajo.Text = string.Empty;
            lblMensaje.Text = string.Empty;
        }

        //--------------------------------------------------------------------------------------------------------------------Metodos
        void CargarGridMedico()
        {
            dt = negocioM.FiltrarMedicosPorLegajoNegocio(Convert.ToInt32(txtBuscarPorLegajo.Text));
            CargarGridMedico(dt);
        }

        void CargarGridMedico(DataTable dt)
        {
            grdModificacionMedico.DataSource = dt;
            grdModificacionMedico.DataBind();
        }

        //-----------------------------------------------------------------------------------------------------------------Cargar ddl - 

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

        private void CargarEspecialidades(DropDownList ddlEspecialidad)
        {
            List<Especialidad> especialidades = _dataService.ObtenerEspecialidades();
            DropDownListControlador.CargarDDL(ddlEspecialidad, especialidades, "Descripcion", "IdEspecialidad_esp");
        }
       
        //---------------------------------------------------------------------------------------------Metodos control acceso
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