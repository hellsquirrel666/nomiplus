using NomiPlus.LogicObjects;
using NomiPlus.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NomiPlus.Empresas
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeControls();
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(
                Page.GetType(),
                "MessageBox",
                "<script language='javascript'>alert('" + "Ha ocurrido un error al cargar a pagina." + "');</script>"
                );
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        protected void btnNuevaEmpresa_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Empresas/Detalle");
        }

        public void InitializeControls()
        {
            EmpresaLogic pl = new EmpresaLogic();
            var lista = pl.ListaEmpresas();
            gvPacientes.DataSource = lista;
            gvPacientes.DataBind();
        }
    }
}