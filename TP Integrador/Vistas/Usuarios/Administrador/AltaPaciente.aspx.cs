using Negocios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vistas.Helper;
using Datos;

namespace Vistas
{
    public partial class AltaPaciente : System.Web.UI.Page
    {
        readonly NegociosPaciente NegocioPaciente = new NegociosPaciente();
        private readonly DropDownListService _dataService = new DropDownListService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGeneros(ddlGenero);
                CargarPaises(ddlNacionalidad);
                CargarProvincias(ddlProvincia);
                CargarLocalidadesPorProvincia(Convert.ToInt32(ddlProvincia.Text), ddlLocalidad);
            }
        }
        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
            CargarLocalidadesPorProvincia(idProvincia, ddlLocalidad);
        }

        protected void btnGuardarPaciente_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaNacimiento = DateTime.Parse(txtFechaNacimiento.Value);         

                Paciente nuevoPaciente = new Paciente
                {
                    DNI = txtDni.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Genero = ddlGenero.SelectedIndex,
                    Nacionalidad = ddlNacionalidad.SelectedIndex,
                    FechaNacimiento = fechaNacimiento,
                    Direccion = txtDireccion.Text,
                    Localidad = ddlLocalidad.SelectedIndex,
                    Provincia = ddlProvincia.SelectedIndex,
                    CorreoElectronico = txtEmail.Text,
                    Telefono = txtTelefono.Text,
                    Estado = true
                };

                bool resultado = NegocioPaciente.AgregarPaciente(nuevoPaciente);

                if (resultado)
                {
                    lblMensaje.Text = "Paciente agregado correctamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMensaje.Text = "El paciente ya existe.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                 Console.WriteLine($"Error al guardar paciente: {ex.Message}");
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
    }
}
