using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Negocios;
using Entidades;
using System.Data;
using System.Diagnostics;
namespace Vistas
{
    public partial class GestionarTurnos : System.Web.UI.Page
    {
        NegociosTurnos NegociosTurnos = new NegociosTurnos();

        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarAcceso();

            if (!IsPostBack)
            {
                grdTurnos.Visible = false;
                if (Session["UsuarioLogueado"] is Usuario usuarioLogueado && usuarioLogueado.EsMedico())
                {
                    int legajoMedico = usuarioLogueado.Id;
                    Session["LegajoMedico"] = legajoMedico;
                    CargarDatosMedico(legajoMedico);
                }
                else
                {
                    Response.Redirect("AccesoDenegado.aspx");
                }
            }
        }

        private void CargarDatosMedico(int legajoMedico)
        {
            try
            {
                var dtMedico = NegociosTurnos.ObtenerDatosMedico(legajoMedico);
                gvDatosMedico.DataSource = dtMedico;
                gvDatosMedico.DataBind();
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar los datos del médico: {ex.Message}", false);
            }
        }



        public static DataTable ConvertirListaATabla(List<Turno> lista)
        {
            DataTable dt = new DataTable();
            var propiedades = typeof(Turno).GetProperties();

            foreach (var propiedad in propiedades)
            {
                dt.Columns.Add(propiedad.Name);
            }

            foreach (var item in lista)
            {
                DataRow fila = dt.NewRow();
                foreach (var propiedad in propiedades)
                {
                    fila[propiedad.Name] = propiedad.GetValue(item) ?? DBNull.Value;
                }
                dt.Rows.Add(fila);
            }
            return dt;
        }

        protected void btnFiltrarRango_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio, fechaFin;
            string formatoFecha = "dd-MM-yyyy";

            if (DateTime.TryParseExact(txtFechaInicio.Text, formatoFecha, null, System.Globalization.DateTimeStyles.None, out fechaInicio) &&
                DateTime.TryParseExact(txtFechaFin.Text, formatoFecha, null, System.Globalization.DateTimeStyles.None, out fechaFin))
            {
                if (Session["LegajoMedico"] != null)
                {
                    int legajoMedico = (int)Session["LegajoMedico"];
                    var turnosFiltrados = NegociosTurnos.FiltrarTurnosPorFechas(legajoMedico, fechaInicio, fechaFin);

                    if (turnosFiltrados.Rows.Count > 0)
                    {
                        grdTurnos.DataSource = turnosFiltrados;
                        grdTurnos.DataBind();
                        MostrarMensaje("Filtro aplicado correctamente", true);
                        grdTurnos.Visible = true;
                    }
                    else
                    {
                        MostrarMensaje("No se encontraron turnos en el rango de fechas seleccionado.", false);
                        grdTurnos.DataSource = null;
                        grdTurnos.DataBind();
                    }
                }
                else
                {
                    MostrarMensaje("No se pudo determinar el legajo del médico.", false);
                }
            }
            else
            {
                MostrarMensaje("Por favor, ingrese un rango de fechas válido (formato dd-MM-yyyy).", false);
            }
        }
        protected void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtFechaInicio.Text = string.Empty;
            txtFechaFin.Text = string.Empty;
        }

        private void CargarTurnosPorMedico(int legajoMedico)
        {
            var listaTurnos = NegociosTurnos.ObtenerTurnosPorMedico(legajoMedico);
            if (listaTurnos == null || listaTurnos.Count == 0)
            {
                MostrarMensaje("No se encontraron turnos para el médico.", false);
                return;
            }
            grdTurnos.DataSource = ConvertirListaATabla(listaTurnos);
            grdTurnos.DataBind();
        }
        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            if (Session["LegajoMedico"] != null)
            {
                int legajoMedico = (int)Session["LegajoMedico"];
                CargarTurnosPorMedico(legajoMedico);
                grdTurnos.Visible = true;
            }
            else
            {
                MostrarMensaje("No se pudo determinar el legajo del médico.", false);
            }
        }

        private void MostrarMensaje(string mensaje, bool esExito)
        {
            lblFiltroMensajeRango.Text = mensaje;
            lblFiltroMensajeRango.ForeColor = esExito ? System.Drawing.Color.Green : System.Drawing.Color.Red;
        }
        protected void grdTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Guardar")
            {
                try
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdTurnos.Rows[rowIndex];


                    if (!int.TryParse(grdTurnos.DataKeys[row.RowIndex]?.Value.ToString(), out int idTurno))
                    {
                        lblMensaje.Text = "El identificador del turno no es válido.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }


                    var ddlAsistencia = (DropDownList)row.FindControl("ddlAsistencia");
                    var txtObservaciones = (TextBox)row.FindControl("txtObservaciones");

                    if (ddlAsistencia != null && txtObservaciones != null)
                    {

                        if (ddlAsistencia.SelectedValue == "1")
                        {
                            txtObservaciones.Enabled = true;

                            string observacion = txtObservaciones.Text.Trim();
                            if (string.IsNullOrWhiteSpace(observacion))
                            {
                                lblMensaje.Text = "Debe ingresar una observación si el estado es 'Asistió'.";
                                lblMensaje.ForeColor = System.Drawing.Color.Red;
                                return;
                            }


                            var negocio = new NegociosTurnos();
                            negocio.ActualizarTurno(idTurno, 1, observacion);

                            lblMensaje.Text = "Turno actualizado correctamente.";
                            lblMensaje.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            txtObservaciones.Enabled = false;
                            lblMensaje.Text = "Debe seleccionar 'Asistió' para ingresar observaciones.";
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                            return;
                        }


                        int legajoMedico = Convert.ToInt32(Session["LegajoMedico"]);
                        CargarTurnosPorMedico(legajoMedico);
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = $"Error al actualizar el turno: {ex.Message}";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void ddlAsistencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;

            var txtObservaciones = (TextBox)row.FindControl("txtObservaciones");
            if (ddl.SelectedValue == "1")
            {
                txtObservaciones.Enabled = true;
            }
            else
            {
                txtObservaciones.Enabled = false;
                txtObservaciones.Text = "";
            }
        }

        //------------------------------------------------------------Metodos Sistema de Acceso
        protected void VerificarAcceso()
        {
            Usuario usuarioLogueado = Session["UsuarioLogueado"] as Usuario;

            if (usuarioLogueado == null || !usuarioLogueado.EsMedico())
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