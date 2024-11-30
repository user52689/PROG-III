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

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("InicioSesion.aspx");
        }

        protected void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = DateTime.Parse(txtFechaInicio.Text);
                DateTime fechaFin = DateTime.Parse(txtFechaFin.Text);

                // Generar el informe detallado en el grid
                List<Informe> informes = negociosInforme.GenerarInformeAsistencias(fechaInicio, fechaFin);
                gvInforme.DataSource = informes;
                gvInforme.DataBind();

                // Generar el grafico de estados
                List<KeyValuePair<string, int>> resumenEstados = negociosInforme.ObtenerResumenEstadosTurnos(fechaInicio, fechaFin);
                Debug.WriteLine("Datos grafico pastel:");
                foreach (var item in resumenEstados)
                {
                    Debug.WriteLine($"resumenEstados: {item.Key}, Valor: {item.Value}");
                }


                //Especialidades con mas atenciones
                List<KeyValuePair<string, int>> especialidades = negociosInforme.ObtenerEspecialidadesMasAtendidas(fechaInicio, fechaFin);
                GenerarBarrasEspecialidades(especialidades);
                Debug.WriteLine("Datos para barras:");
                foreach (var item in especialidades)
                {
                    Debug.WriteLine($"Especialidad: {item.Key}, Valor: {item.Value}");
                }

                if (resumenEstados.Count > 0)
                {
                    chartEstadosTurnos.Series["Estados"].Points.DataBind(resumenEstados, "Key", "Value", null);
                    chartEstadosTurnos.Visible = true;
                    lblMensajeGrafico.Text = string.Empty;

                    // **Configuración adicional del grafico circular**
                    chartEstadosTurnos.Titles.Add("Distribución de Estados de Turnos");
                    chartEstadosTurnos.Series["Estados"].Label = "#PERCENT{P0}"; // Muestra porcentaje en el gráfico
                    chartEstadosTurnos.Series["Estados"].LegendText = "#VALX (#VAL)"; // Muestra valores en la leyenda
                    chartEstadosTurnos.Legends.Add("Legend1");
                    chartEstadosTurnos.Legends["Legend1"].Docking = System.Web.UI.DataVisualization.Charting.Docking.Bottom; // Posicion de la leyenda
                    chartEstadosTurnos.Series["Estados"].Palette = System.Web.UI.DataVisualization.Charting.ChartColorPalette.Pastel; // Colores pastel
                }
                else
                {
                    lblMensajeGrafico.Text = "No se encontraron datos para las fechas seleccionadas.";
                    chartEstadosTurnos.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al generar informe: {ex.Message}");
                lblMensaje.Text = "Ocurrio un error al generar el informe.";
                lblMensajeGrafico.Text = "Ocurrio un error al generar el grafico.";
            }
        }

        //genera las barras con una regla de tres
        private void GenerarBarrasEspecialidades(List<KeyValuePair<string, int>> especialidades)
        {
            try
            {
                if (especialidades.Count > 0)
                {
                    Debug.WriteLine("Datos crudos para las barras:");
                    foreach (var esp in especialidades)
                    {
                        Debug.WriteLine($"Especialidad: {esp.Key}, Total: {esp.Value}");
                    }

                    int total = especialidades.Sum(e => e.Value);

                    if (total > 0)
                    {
                        var especialidadesConPorcentaje = especialidades.Select(e => new
                        {
                            Especialidad = e.Key.Trim(),
                            Porcentaje = (e.Value * 100) / total
                        }).ToList();

                        Debug.WriteLine("Especialidades con porcentaje calculado:");
                        foreach (var esp in especialidadesConPorcentaje)
                        {
                            Debug.WriteLine($"Especialidad: {esp.Especialidad}, Porcentaje: {esp.Porcentaje}%");
                        }

                        rptEspecialidades.DataSource = especialidadesConPorcentaje;
                        rptEspecialidades.DataBind();
                    }
                    else
                    {
                        lblMensajeGraficos.Text = "No se encontraron atenciones para calcular porcentajes.";
                        rptEspecialidades.DataSource = null;
                        rptEspecialidades.DataBind();
                    }
                }
                else
                {
                    lblMensajeGraficos.Text = "No se encontraron especialidades en el rango seleccionado.";
                    rptEspecialidades.DataSource = null;
                    rptEspecialidades.DataBind();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en GenerarBarrasEspecialidades: {ex.Message}");
                lblMensaje.Text = "Error al procesar las barras de especialidades.";
            }
        }

        protected void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpiar los valores de los TextBox
                txtFechaInicio.Text = string.Empty;
                txtFechaFin.Text = string.Empty;

                // Opcional: limpiar mensajes o graficos generados
                lblMensaje.Text = string.Empty;
                lblMensajeGrafico.Text = string.Empty;
                gvInforme.DataSource = null;
                gvInforme.DataBind();
                chartEstadosTurnos.Visible = false;
                rptEspecialidades.DataSource = null;
                rptEspecialidades.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrio un error al limpiar los campos.";
                Debug.WriteLine($"Error en btnLimpiarCampos_Click: {ex.Message}");
            }
        }

    }
}