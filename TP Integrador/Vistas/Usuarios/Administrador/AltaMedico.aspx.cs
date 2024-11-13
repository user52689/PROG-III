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
            ddlLocalidad.DataTextField = "nombre_loc";
            ddlLocalidad.DataValueField = "idLocalidad_loc";
            ddlLocalidad.DataBind();
        }
    }
}