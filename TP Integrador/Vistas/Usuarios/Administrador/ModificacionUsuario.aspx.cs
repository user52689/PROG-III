using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuarios.Administrador
{
    public partial class ModificacionUsuario : System.Web.UI.Page
    {
        private AutenticacionUsuario autenticacion = new AutenticacionUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarAcceso();

            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        private void CargarUsuarios()
        {
            List<Usuario> usuarios = autenticacion.ObtenerUsuarios();
            gvUsuarios.DataSource = usuarios;
            gvUsuarios.DataBind();
        }

        protected void gvUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsuarios.EditIndex = e.NewEditIndex;
            CargarUsuarios();
        }

        protected void gvUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsuarios.EditIndex = -1;
            CargarUsuarios();
        }

        protected void gvUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = gvUsuarios.Rows[e.RowIndex];

                if (gvUsuarios.DataKeys[e.RowIndex] != null)
                {
                    int id = Convert.ToInt32(gvUsuarios.DataKeys[e.RowIndex].Value);
                    string nombreUsuario = ((TextBox)row.Cells[1].Controls[0])?.Text ?? string.Empty;
                    string contraseña = ((TextBox)row.Cells[2].Controls[0])?.Text ?? string.Empty;
                    string rol = ((Label)row.FindControl("lblRol"))?.Text ?? string.Empty;

                    // Llamar a la capa de negocio para validar y actualizar
                    bool actualizado = autenticacion.ActualizarUsuarioConValidacion(id, nombreUsuario, contraseña, rol);

                    lblMensaje.Text = actualizado ? "Usuario actualizado correctamente." : "Error: El nombre de usuario ya está en uso o no se pudo actualizar.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMensaje.Text = "Error: no se encontró la clave de usuario.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Se produjo un error al actualizar el usuario.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                Debug.WriteLine($"Error en RowUpdating: {ex.Message}");
            }
            finally
            {
                gvUsuarios.EditIndex = -1;
                CargarUsuarios();
            }
        }

        //---------------------------------------------------------------------------------------------Metodo control acceso
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
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Inicio/InicioSesion.aspx");
        }

        protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuarios.PageIndex = e.NewPageIndex;
            CargarUsuarios(); // Recargar datos de la nueva página.
        }
    }
}