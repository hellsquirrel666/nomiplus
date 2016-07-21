using NomiPlus.LogicObjects;
using NomiPlus.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NomiPlus.Empresas.Empleados
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

        protected void btnNuevoEmpreado_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Empresas/Empleados/Detalle?Empresa="+hfIdEmpresa.Value);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Empresas");
        }

        public void InitializeControls()
        {
            var idEmpresa = Request.QueryString["Empresa"];
            if (!string.IsNullOrEmpty(idEmpresa))
            {
                int idEmp;
                if (int.TryParse(idEmpresa, out idEmp))
                {
                    EmpresaLogic el = new EmpresaLogic();
                    Empresa empresa = el.ObtenerEmpresa(idEmp);
                    if (empresa == null)
                    {
                        Page.ClientScript.RegisterStartupScript(
                            Page.GetType(),
                            "MessageBox",
                            "<script language='javascript'>alert('" + "No se encontró la empresa." + "');</script>"
                         );
                        Response.Redirect("~/");
                    }
                    else
                    {
                        hfIdEmpresa.Value = idEmp.ToString();
                        lblNombre.Text = empresa.sRazonSocial;

                        EmpleadoLogic eml = new EmpleadoLogic();
                        var lista = eml.ListaEmpleados();
                        gvEmpleados.DataSource = lista;
                        gvEmpleados.DataBind();
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "No se encontró la empresa." + "');</script>"
                 );
                Response.Redirect("~/Empresas");
            }
        }

        public string ObtenerSucursal(int idSucursal)
        {
            SucursalLogic sl = new SucursalLogic();
            Sucursal sucursal = sl.ObtenerSucursal(idSucursal);
            return sucursal.sNombreSucursal;
        }

        public string ObtenerDepartamento(int idDepartamento)
        {
            DepartamentoLogic dl = new DepartamentoLogic();
            Departamento departamento = dl.ObtenerDepartamento(idDepartamento);
            return departamento.sDepartamento;
        }

    }
}