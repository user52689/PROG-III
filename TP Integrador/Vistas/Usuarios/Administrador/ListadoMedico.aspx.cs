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
            NegociosMedico negociosMedico = new NegociosMedico();
            var listaMedicos = negociosMedico.obtenerListaMedicos();
            grdListadoMedico.DataSource = listaMedicos;
            grdListadoMedico.DataBind();
        }

      

        void mostrarLegajoMedico()
        {
            string legajo = txtBuscarPorLegajo.Text;
            NegociosMedico negociosMedico = new NegociosMedico();          
            var listaMedicos = negociosMedico.ObtenerMedicosPorLegajo(legajo);
            grdListadoMedico.DataSource = listaMedicos;
            grdListadoMedico.DataBind();

        }

        protected void btnBuscarMedico_Click(object sender, EventArgs e)
        {
            mostrarLegajoMedico();
        }
    }
}
