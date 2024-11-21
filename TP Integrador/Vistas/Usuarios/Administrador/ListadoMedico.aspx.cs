using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class ListadoMedico : System.Web.UI.Page
    {
        NegociosMedico negociosMedico = new NegociosMedico();

       
        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            mostrarTodos();
        }

       
        void mostrarTodos()
        {
            var listaMedicos = negociosMedico.obtenerListaMedicos();
            grdListadoMedico.DataSource = listaMedicos;
            grdListadoMedico.DataBind();

            
            lblMensajeMedico.Visible = false;
            grdListadoMedico.Visible = true;
        }

        
        void mostrarLegajoMedico()
        {
            string legajoInput = txtBuscarPorLegajo.Text.Trim();

           
            if (string.IsNullOrEmpty(legajoInput))
            {
                lblMensajeMedico.Text = "Por favor, ingrese un legajo.";
                lblMensajeMedico.ForeColor = System.Drawing.Color.Red;
                lblMensajeMedico.Visible = true;
                grdListadoMedico.Visible = false; 
                return;
            }

            
            if (!int.TryParse(legajoInput, out int legajo))
            {
                lblMensajeMedico.Text = "Legajo no válido.";
                lblMensajeMedico.ForeColor = System.Drawing.Color.Red;
                lblMensajeMedico.Visible = true;
                grdListadoMedico.Visible = false; 
                return;
            }

          
            if (legajo <= 0)
            {
                lblMensajeMedico.Text = "El legajo debe ser un número positivo.";
                lblMensajeMedico.ForeColor = System.Drawing.Color.Red;
                lblMensajeMedico.Visible = true;
                grdListadoMedico.Visible = false;
                return;
            }

          
            var listaMedicos = negociosMedico.ObtenerMedicosPorLegajo(legajo);

            if (listaMedicos.Count == 0)
            {
                lblMensajeMedico.Text = "No se encontró un médico con el legajo especificado.";
                lblMensajeMedico.ForeColor = System.Drawing.Color.Red;
                lblMensajeMedico.Visible = true; 
                grdListadoMedico.Visible = false; 
            }
            else
            {
                grdListadoMedico.DataSource = listaMedicos;
                grdListadoMedico.DataBind();
                lblMensajeMedico.Visible = false;
                grdListadoMedico.Visible = true; 

            }
        }

      
        protected void btnBuscarMedico_Click(object sender, EventArgs e)
        {
            mostrarLegajoMedico();
        }

     
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("InicioSesion.aspx");
        }
    }
}

