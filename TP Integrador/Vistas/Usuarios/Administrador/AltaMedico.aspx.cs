using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;
namespace Vistas
{
    public partial class AltaMedico : System.Web.UI.Page
    {
        NegociosUbicacion _NegociosUbicacion = new NegociosUbicacion();
        NegociosMedico _NegocioMedico = new NegociosMedico();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                CargarPaises();
                CargarProvincias();
            }
        }

        private void CargarProvincias()
        {
            var dtProvincias = _NegociosUbicacion.ObtenerProvincias();
            ddlProvincia.DataSource = dtProvincias;
            ddlProvincia.DataTextField = "nombre_prov";
            ddlProvincia.DataValueField = "idProvincia_prov";
            ddlProvincia.DataBind();


            ddlProvincia.Items.Insert(0, new ListItem("--SELECCIONAR PROVINCIA--", "0"));
        }

        private void CargarPaises()
        {
            var dtNacionalidad = _NegociosUbicacion.ObtenerPaises();
            ddlNacionalidad.DataSource = dtNacionalidad;
            ddlNacionalidad.DataTextField = "nombre_pais";
            ddlNacionalidad.DataValueField = "idPais_p";
            ddlNacionalidad.DataBind();


            ddlNacionalidad.Items.Insert(0, new ListItem("--SELECCIONAR PAIS--", "0"));
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {


            CargarLocalidades();


        }

        private void CargarLocalidades()
        {
            int provinciaId = Convert.ToInt32(ddlProvincia.SelectedValue);
            var dtLocalidades = _NegociosUbicacion.ObtenerLocalidadesPorProvincia(provinciaId);

            ddlLocalidad.DataSource = dtLocalidades;
            ddlLocalidad.DataTextField = "Nombre_loc";
            ddlLocalidad.DataValueField = "IDLocalidad_loc";
            ddlLocalidad.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {


                DateTime fechanacimiento = DateTime.Parse(txtFechaNacimiento.Value);
               
                if (_NegocioMedico.ExisteMedico(txtDni.Text))
                {
                    lblMensaje.Text = "El DNI ya está registrado en el sistema.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }


                // Crear un nuevo objeto Paciente con los datos ingresados
                Medico nuevoMedico = new Medico
                {
                    DNI = txtDni.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Genero = int.Parse(rbGenero.SelectedValue),
                    FechaNacimiento = fechanacimiento,
                    Nacionalidad =ddlNacionalidad.SelectedIndex ,
                    Especialidad = int.Parse(ddlEspecialidad.SelectedValue),
                    Direccion = txtDireccion.Text,
                    Localidad = int.Parse(ddlLocalidad.SelectedValue), 
                    Provincia = int.Parse(ddlProvincia.SelectedValue),
                    CorreoElectronico = txtEmail.Text,
                    Telefono = txtTelefono.Text
                    
                };

                bool resultado = _NegocioMedico.agregarMedico(nuevoMedico);

                if (resultado)
                {
                    lblMensaje.Text = "Medico agregado correctamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMensaje.Text = "No se pudo agregar el Medico.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("InicioSesion.aspx");
        }
    }
    }