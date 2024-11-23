using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Entidades;
using Negocios;
using Vistas.Helper;

namespace Vistas
{
    public partial class AltaMedico : System.Web.UI.Page
    {
        private readonly DropDownListService _dataService = new DropDownListService();

        readonly NegociosMedico NegocioMedico = new NegociosMedico();

        //---------------------------------------------------------------------------------Eventos
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                lblLegajoAutoincremental.Text = NegocioMedico.ObtenerMaximoLegajoNegocio().ToString();
                CargarGeneros(ddlGenero);
                CargarPaises(ddlNacionalidad);
                CargarProvincias(ddlProvincia);
                CargarLocalidadesPorProvincia(Convert.ToInt32(ddlProvincia.Text), ddlLocalidad);
                CargarEspecialidades(ddlEspecialidad);
            }
        }


        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
            CargarLocalidadesPorProvincia(idProvincia, ddlLocalidad);
        }



        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fechanacimiento = DateTime.Parse(txtFechaNacimiento.Value);

                Medico nuevoMedico = new Medico
                {
                    DNI = txtDni.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Genero = ddlGenero.SelectedIndex,
                    FechaNacimiento = fechanacimiento,
                    Nacionalidad = ddlNacionalidad.SelectedIndex,
                    Especialidad = int.Parse(ddlEspecialidad.SelectedValue),
                    Direccion = txtDireccion.Text,
                    Localidad = int.Parse(ddlLocalidad.SelectedValue),
                    Provincia = int.Parse(ddlProvincia.SelectedValue),
                    CorreoElectronico = txtEmail.Text,
                    Telefono = txtTelefono.Text,
                    Estado = true
                };

                bool resultado = NegocioMedico.AgregarMedico(nuevoMedico);

                if (resultado)
                {
                    lblMensaje.Text = "Medico agregado correctamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMensaje.Text = "El Medico ya existe.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar medico: {ex.Message}");
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("InicioSesion.aspx");
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
    }
}