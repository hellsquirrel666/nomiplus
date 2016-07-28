using NomiPlus.LogicObjects;
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
            ddlEmpresa.DataValueField = "IdEmpresa";
            ddlEmpresa.DataBind();

            PeriodicidadLogic pl = new PeriodicidadLogic();
            ddlesquema.DataSource = pl.ListaPeriodicidades();
            ddlesquema.DataTextField = "sPeriodicidad";
            ddlesquema.DataValueField = "sPeriodicidad";
            ddlesquema.DataBind();
        }

        #endregion
    }
}