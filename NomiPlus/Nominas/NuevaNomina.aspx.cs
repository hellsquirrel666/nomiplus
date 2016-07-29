using NomiPlus.LogicObjects;
using NomiPlus.Modelo;
using NomiPlus.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NomiPlus.Nominas
{
    public partial class NuevaNomina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeControls();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                NominaLogic nl = new NominaLogic();
                nl.GuardarNomina(ObtenerNomina());
                //Response.Redirect("~/Nomina/AsignarPagos");
                //Manda a siguiente proceso de la nomina
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + ex.Message + "');</script>"
                 );

            }
 
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Nominas");
        }

        #region Metodos

        private void InitializeControls()
        {
            EmpresaLogic el = new EmpresaLogic();
            ddlEmpresa.DataSource = el.ListaEmpresas();
            ddlEmpresa.DataTextField = "sRazonSocial";
            ddlEmpresa.DataValueField = "nIdEmpresa";
            ddlEmpresa.DataBind();

            PeriodicidadLogic pl = new PeriodicidadLogic();
            ddlesquema.DataSource = pl.ListaPeriodicidades();
            ddlesquema.DataTextField = "sPeriodicidad";
            ddlesquema.DataValueField = "nIdPeriodicidad";
            ddlesquema.DataBind();
        }

        public Nomina ObtenerNomina()
        {
            Nomina nomina = new Nomina()
            { 
                nIdNomina = default(int),
                nIdEmpresa = int.Parse(ddlEmpresa.SelectedValue),
                sNombre = txtNombreNomina.Text,
                dFechaRegistro = DateTime.Now,
                dFechaInicio = DateTime.Parse(txtFechaInicio.Text),
                dFechaFin = DateTime.Parse(txtFechaFin.Text),
                nEsquemaPago = int.Parse(ddlesquema.SelectedValue),
                sEstatus = "Nueva"
            };
            return nomina;
        }
        #endregion
    }
}