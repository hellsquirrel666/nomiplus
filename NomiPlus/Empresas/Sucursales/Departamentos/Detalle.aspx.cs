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
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InitializeControls();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            DepartamentoLogic dl = new DepartamentoLogic();
            var dir = dl.GuardarDepartamento(ObtenerDepartamento());
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Empresas/Sucursales/Departamentos/?Sucursal="+ hfIdSucursal.Value);

        }

        #region Metodos
        
        private void InitializeControls()
        {
            var idDepartamento = Request.QueryString["Departamento"];
            var idSucursal = Request.QueryString["Sucursal"];
            if (!string.IsNullOrEmpty(idSucursal))
            {
                int idSuc;
                if (int.TryParse(idSucursal, out idSuc))
                {
                    hfIdSucursal.Value = idSuc.ToString();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(
                        Page.GetType(),
                        "MessageBox",
                        "<script language='javascript'>alert('" + "No se encontró la sucursal." + "');</script>"
                     );
                    Response.Redirect("~/Empresas/Sucursales");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "No se encontró la sucursal." + "');</script>"
                    );
                Response.Redirect("~/Empresas/Sucursales");
            }
            if (!string.IsNullOrEmpty(idDepartamento))
            {
                int idDepto;
                if (int.TryParse(idDepartamento, out idDepto))
                {
                    DepartamentoLogic pl = new DepartamentoLogic();
                    Departamento departamento = pl.ObtenerDepartamento(int.Parse(idDepartamento));
                    if (departamento == null)
                    {
                        Page.ClientScript.RegisterStartupScript(
                            Page.GetType(),
                            "MessageBox",
                            "<script language='javascript'>alert('" + "No se encontró la departamento." + "');</script>"
                         );
                        Response.Redirect("~/Empresas/Sucursales?Sucursal="+ hfIdSucursal.Value);
                    }
                    lblAccion.Text = "Editar";
                    LlenarDepartamento(departamento);
                }
            }
            else
            {
                lblAccion.Text = "Nuevo";
            }
        }

        public Departamento ObtenerDepartamento()
        {
            Departamento departamento = new Departamento()
            {
                nIdDepartamento = string.IsNullOrEmpty(hfIdDepto.Value) ? default(int) : int.Parse(hfIdDepto.Value),
                sDepartamento = txtDepartamento.Text,
                sNombreEncargado = txtResponsable.Text,
                sEmail = txtEmail.Text,
                sFax = txtFax.Text,
                sTelefono = txtTelefono.Text,
                nIdSucursal = int.Parse(hfIdSucursal.Value),
                bActivo = true
            };
            return departamento;
        }

        public void LlenarDepartamento(Departamento empresa)
        {
            hfIdDepto.Value = empresa.nIdDepartamento.ToString();

            txtDepartamento.Text = empresa.sDepartamento;
            txtResponsable.Text = empresa.sNombreEncargado;
            txtEmail.Text = empresa.sEmail;
            txtFax.Text = empresa.sFax;
            txtTelefono.Text = empresa.sTelefono;
        }
        #endregion
    }
}