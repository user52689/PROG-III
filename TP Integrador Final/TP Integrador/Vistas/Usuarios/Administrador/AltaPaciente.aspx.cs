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
            VerificarAcceso();

            if (!IsPostBack)
            {
                CargarGeneros(ddlGenero);
                CargarPaises(ddlNacionalidad);
                CargarProvincias(ddlProvincia);
              
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

                    // Limpiar los campos del formulario
                    LimpiarCampos();
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

        //-----------------------------------------------------------------------------------------------------------------Metodos
        private void LimpiarCampos()
        {
            txtDni.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            ddlGenero.SelectedIndex = 0;
            ddlNacionalidad.SelectedIndex = 0;
            txtFechaNacimiento.Value = string.Empty;
            txtDireccion.Text = string.Empty;
            ddlProvincia.SelectedIndex = 0;
            CargarLocalidadesPorProvincia(Convert.ToInt32(ddlProvincia.SelectedValue), ddlLocalidad);
            txtEmail.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }

        protected void VerificarAcceso()
        {
            Usuario usuarioLogueado = Session["UsuarioLogueado"] as Usuario;

            if (usuarioLogueado == null || !usuarioLogueado.EsAdministrador())
            {
                Response.Redirect("~/Inicio/AccesoDenegado.aspx");
                return;
            }

            // Mostrar el nombre de usuario en la barra de navegación
            lblUsuarioEnSesion.Text = usuarioLogueado.NombreUsuario;
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Inicio/InicioSesion.aspx");
        }
    }
}
