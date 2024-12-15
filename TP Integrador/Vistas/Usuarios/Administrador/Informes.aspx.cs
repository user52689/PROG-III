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
        private readonly NegociosInforme _negociosInforme = new NegociosInforme();

        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarAcceso();
        }

        //-----------------------------------------------------------------------------------EVENTO
        protected void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarMensajes();

                DateTime fechaInicio = DateTime.Parse(txtFechaInicio.Text);
                DateTime fechaFin = DateTime.Parse(txtFechaFin.Text);

                GenerarInformeAsistencias(fechaInicio, fechaFin);
                GenerarGraficoEstados(fechaInicio, fechaFin);
                GenerarGraficoEspecialidades(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                ManejarError("Ocurrio un error al generar el informe.", ex);
            }
        }

        //-------------------------------------------------------------------------------------------------METODOS PARA GENERAR EL EVENTO
        private void GenerarInformeAsistencias(DateTime fechaInicio, DateTime fechaFin)
        {
            var informes = _negociosInforme.GenerarInformeAsistencias(fechaInicio, fechaFin);
            gvInforme.DataSource = informes;
            gvInforme.DataBind();
        }

        private void GenerarGraficoEstados(DateTime fechaInicio, DateTime fechaFin)
        {
            var resumenEstados = _negociosInforme.ObtenerResumenEstadosTurnos(fechaInicio, fechaFin);

            if (resumenEstados.Any())
            {
                ConfigurarGraficoCircular(chartEstadosTurnos, resumenEstados, "Distribucion de Estados de Turnos");
                lblMensajeGrafico.Text = string.Empty;
            }
            else
            {
                lblMensajeGrafico.Text = "No se encontraron datos para las fechas seleccionadas.";
                chartEstadosTurnos.Visible = false;
            }
        }

        private void GenerarGraficoEspecialidades(DateTime fechaInicio, DateTime fechaFin)
        {
            var especialidades = _negociosInforme.ObtenerEspecialidadesMasAtendidas(fechaInicio, fechaFin);

            if (especialidades.Any())
            {
                int total = especialidades.Sum(e => e.Value);
                var especialidadesConPorcentaje = especialidades.Select(e => new
                {
                    Especialidad = e.Key.Trim(),
                    Porcentaje = (e.Value * 100) / total
                }).ToList();

                rptEspecialidades.DataSource = especialidadesConPorcentaje;
                rptEspecialidades.DataBind();
            }
            else
            {
                lblMensajeGraficos.Text = "No se encontraron especialidades en el rango seleccionado.";
                rptEspecialidades.DataSource = null;
                rptEspecialidades.DataBind();
            }
        }

        //---------------------------------------------------------------------------------------------METODOS
        //----------CONFIGURA LAS PROPIEDADES VISUALES
        private void ConfigurarGraficoCircular(System.Web.UI.DataVisualization.Charting.Chart chart, List<KeyValuePair<string, int>> datos, string titulo)
        {
            chart.Series["Estados"].Points.DataBind(datos, "Key", "Value", null);
            chart.Titles.Clear();
            chart.Titles.Add(titulo);
            chart.Series["Estados"].Label = "#PERCENT{P0}";
            chart.Series["Estados"].LegendText = "#VALX (#VAL)";
            chart.Legends.Clear();
            chart.Legends.Add("Legend1");
            chart.Legends["Legend1"].Docking = System.Web.UI.DataVisualization.Charting.Docking.Bottom;
            chart.Series["Estados"].Palette = System.Web.UI.DataVisualization.Charting.ChartColorPalette.Pastel;
            chart.Visible = true;
        }

        protected void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtFechaInicio.Text = string.Empty;
            txtFechaFin.Text = string.Empty;
            LimpiarMensajes();
            gvInforme.DataSource = null;
            gvInforme.DataBind();
            chartEstadosTurnos.Visible = false;
            rptEspecialidades.DataSource = null;
            rptEspecialidades.DataBind();
        }

        private void LimpiarMensajes()
        {
            lblMensaje.Text = string.Empty;
            lblMensajeGrafico.Text = string.Empty;
            lblMensajeGraficos.Text = string.Empty;
        }

        private void ManejarError(string mensajeUsuario, Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
            lblMensaje.Text = mensajeUsuario;
        }

        //-------------------METODOS CONTROL RBAC
        protected void VerificarAcceso()
        {
            Usuario usuarioLogueado = Session["UsuarioLogueado"] as Usuario;

            if (usuarioLogueado == null || !usuarioLogueado.EsAdministrador())
            {
                Response.Redirect("~/Inicio/AccesoDenegado.aspx");
                return;
            }

            lblUsuarioEnSesion.Text = usuarioLogueado.NombreUsuario;
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Inicio/InicioSesion.aspx");
        }

        //--------------METODO PAGINACION
        protected void gvInforme_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInforme.PageIndex = e.NewPageIndex;

            DateTime fechaInicio = DateTime.Parse(txtFechaInicio.Text);
            DateTime fechaFin = DateTime.Parse(txtFechaFin.Text);

            GenerarInformeAsistencias(fechaInicio, fechaFin);
            GenerarGraficoEstados(fechaInicio, fechaFin);
        }
    }
}
