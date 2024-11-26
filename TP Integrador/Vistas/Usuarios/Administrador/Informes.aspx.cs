using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace Vistas.Administrador
{
    public partial class Informes : System.Web.UI.Page
    {
        private readonly NegociosInforme negociosInforme = new NegociosInforme();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio, fechaFin;

            // Validar las fechas de entrada
            if (!DateTime.TryParse(txtFechaInicio.Text, out fechaInicio) || !DateTime.TryParse(txtFechaFin.Text, out fechaFin))
            {
                lblMensaje.Text = "Por favor, ingrese fechas válidas.";
                return;
            }

            try
            {
                // Llamar a la capa de negocio para obtener el informe
                List<Informe> informes = negociosInforme.GenerarInformeAsistencias(fechaInicio, fechaFin);

                if (informes.Count > 0)
                {
                    gvInforme.DataSource = informes;
                    gvInforme.DataBind();
                    lblMensaje.Text = $"Se generó el informe con {informes.Count} resultados.";
                }
                else
                {
                    lblMensaje.Text = "No se encontraron datos en el rango de fechas proporcionado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error al generar el informe.";
                Debug.WriteLine($"Error en btnGenerarInforme_Click: {ex.Message}");
            }
        }

    }
}