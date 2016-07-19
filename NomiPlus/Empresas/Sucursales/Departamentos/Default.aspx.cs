using NomiPlus.LogicObjects;
using NomiPlus.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NomiPlus.Empresas.Sucursales.Departamentos
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

        protected void btnNuevaEmpresa_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Empresas/Sucursales/Departamentos/Detalle?Sucursal=" + hfIdSucursal.Value);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Empresas/Sucursales/?Empresa=" + hfIdEmpresa.Value);
        }

        public void InitializeControls()
        {
            var idSucursal = Request.QueryString["Sucursal"];
            if (!string.IsNullOrEmpty(idSucursal))
            {
                int idSuc;
                if (int.TryParse(idSucursal, out idSuc))
                {
                    SucursalLogic sl = new SucursalLogic();
                    Sucursal sucursal = sl.ObtenerSucursal(idSuc);
                    if (sucursal == null)
                    {
                        Page.ClientScript.RegisterStartupScript(
                            Page.GetType(),
                            "MessageBox",
                            "<script language='javascript'>alert('" + "No se encontró la sucursal." + "');</script>"
                         );
                        Response.Redirect("~/");
                    }
                    else
                    {
                        hfIdSucursal.Value = idSuc.ToString();
                        EmpresaLogic el = new EmpresaLogic();
                        Empresa empresa = el.ObtenerEmpresa(sucursal.nIdEmpresa);
                        hfIdEmpresa.Value = empresa.nIdEmpresa.ToString();
                        lblNombre.Text = "Sucursal " + sucursal.sNombreSucursal +" de la empresa "+ empresa.sRazonSocial;

                        DepartamentoLogic dl = new DepartamentoLogic();
                        var lista = dl.ListaDepartamentos();
                        gvDepartamentos.DataSource = lista;
                        gvDepartamentos.DataBind();
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "No se encontró la sucursal." + "');</script>"
                 );
                Response.Redirect("~/Empresas");
            }
        }
    }
}