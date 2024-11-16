using Negocios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class AltaPaciente : System.Web.UI.Page
    {
           NegociosUbicacion _NegociosUbicacion = new NegociosUbicacion();
            NegociosPaciente _NegocioPaciente = new NegociosPaciente();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarProvincias();
            CargarPaises();
        }
    }

    void CargarProvincias()
    {
        ddlProvincia.DataSource = _NegociosUbicacion.ObtenerProvincias();
        ddlProvincia.DataTextField = "Nombre_prov";
        ddlProvincia.DataValueField = "IdProvincia_prov";
        ddlProvincia.DataBind();
        ddlProvincia.Items.Insert(0, new ListItem("--Seleccione Provincia--", ""));
    }




    protected void btnGuardarPaciente_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime fechaNacimiento = DateTime.Parse(txtFechaNacimiento.Value);
               

            // Validar si el DNI, email o teléfono ya existen
           

            if( _NegocioPaciente.ExistePaciente(txtDni.Text))
            {
                lblMensaje.Text = "El DNI ya está registrado en el sistema.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }
          

            // Crear un nuevo objeto Paciente con los datos ingresados
            Paciente nuevoPaciente = new Paciente
            {
                DNI = txtDni.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Genero = int.Parse(RadioButtonList1.SelectedValue),
                Nacionalidad = ddlNacionalidad.SelectedIndex,
                FechaNacimiento = fechaNacimiento,
                Direccion = txtDireccion.Text,
                Localidad = ddlLocalidad.SelectedIndex,
                Provincia = ddlProvincia.SelectedIndex,
                CorreoElectronico = txtEmail.Text,
                Telefono = txtTelefono.Text
            };

            // Intentar agregar el paciente
            bool resultado = _NegocioPaciente.agregarPaciente(nuevoPaciente);

            if (resultado)
            {
                lblMensaje.Text = "Paciente agregado correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "No se pudo agregar el paciente.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
           
        }
    }


    private void CargarPaises()
    {
        var dtNacionalidad = _NegociosUbicacion.ObtenerPaises();
        ddlNacionalidad.DataSource = dtNacionalidad;
        ddlNacionalidad.DataTextField = "nombre_pais";
        ddlNacionalidad.DataValueField = "IdPais_p";
        ddlNacionalidad.DataBind();
           
        ddlNacionalidad.Items.Insert(0, new ListItem("--SELECCIONAR PAIS--", "0"));
    }
        
    protected void provinciaSeleccionada(object sender, EventArgs e)
    {
        if (int.TryParse(ddlProvincia.SelectedValue, out int provinciaID) && provinciaID > 0)
        {
            ddlLocalidad.DataSource = _NegociosUbicacion.ObtenerLocalidadesPorProvincia(provinciaID);
            ddlLocalidad.DataTextField = "Nombre_loc";
            ddlLocalidad.DataValueField = "IdLocalidad_loc";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("--Seleccione Localidad--", ""));
        }
        else
        {
            ddlLocalidad.Items.Clear();
            ddlLocalidad.Items.Insert(0, new ListItem("--Seleccione Localidad--", ""));
        }




    }
}
    }
