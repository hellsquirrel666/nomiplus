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
            DireccionLogic dl = new DireccionLogic();
            var dir = dl.ActualizarOGuardarDireccion(ObtenerDireccion());
            EmpresaLogic el = new EmpresaLogic();
            el.GuardarEmpresa(ObtenerEmpresa(dir.nIdDireccion));
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Empresas/");
        }

        protected void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            IncializaDdlDirecciones();
        }

        #region Metodos
        private void InitializeControls()
        {
            var idEmpresa = Request.QueryString["Empresa"];
            if (!string.IsNullOrEmpty(idEmpresa))
            {
                int idPac;
                if (int.TryParse(idEmpresa, out idPac))
                {
                    EmpresaLogic pl = new EmpresaLogic();
                    Empresa empresa = pl.ObtenerEmpresa(int.Parse(idEmpresa));
                    if (empresa == null)
                    {
                        Page.ClientScript.RegisterStartupScript(
                            Page.GetType(),
                            "MessageBox",
                            "<script language='javascript'>alert('" + "No se encontró la empresa." + "');</script>"
                         );
                        Response.Redirect("~/Empresas/");
                    }
                    else
                    {
                        DireccionLogic dl = new DireccionLogic();
                        Direccion dir = dl.ObtenerDireccion(empresa.nIdDireccion);
                        if (dir == null)
                        {
                            Page.ClientScript.RegisterStartupScript(
                                Page.GetType(),
                                "MessageBox",
                                "<script language='javascript'>alert('" + "No se encontró la dirección del cliente." + "');</script>"
                             );
                            Response.Redirect("~/Empresas/");
                        }
                        lblAccion.Text = "Editar";
                        LlenarEmpresa(empresa, dir);
                    }
                }
            }
            else 
            {
                lblAccion.Text = "Nueva";
            }
        }

        public Empresa ObtenerEmpresa(int idDireccion)
        {
            Empresa empresa = new Empresa()
            {
                nIdEmpresa = string.IsNullOrEmpty(hdIdEmpresa.Value) ? default(int) : int.Parse(hdIdEmpresa.Value),
                sRazonSocial = txtRazonSocial.Text,
                sRFC = txtRFC.Text,
                sCURP = txtCURP.Text,
                sRegimenFiscal = ddlRegimenFiscal.SelectedValue,
                sRepresentanteLegal = txtRepresentante.Text,
                sTelefono = txtTelefono.Text,
                sFAx = txtFax.Text,
                sEmailContacto = txtEmailContacto.Text,
                sPaginaWeb = txtPaginaWeb.Text,
                sFechaRegistro = DateTime.Parse(txtFechaRegistro.Text),
                bActivo = true,
                nIdDireccion = idDireccion
            };
            return empresa;
        }

        public Direccion ObtenerDireccion()
        {
            Direccion direccion = new Direccion
            {
                nIdDireccion = string.IsNullOrEmpty(hfIdDireccion.Value) ? default(int) : int.Parse(hfIdDireccion.Value),
                nIdColonia = int.Parse(ddlColonia.SelectedValue),
                sCalle = txtCalle.Text,
                sNoExterno = txtNumeroExterior.Text,
                sNoInterno = txtNumeroInterior.Text
            };
            return direccion;
        }

        public void IncializaDdlDirecciones()
        {
            using (var _dataModel = new DB_A06759_NOMINASEntities())
            {
                //obtiene colonias que coinciden con CP
                var colonias = (from c in _dataModel.Colonia
                                where c.sCP.Equals(txtCodigoPostal.Text)
                                select new { c.nIdColonia, c.sColonia }
                              ).ToList();
                //llena ddlColonia
                ddlColonia.DataValueField = "nIdColonia";
                ddlColonia.DataTextField = "sColonia";
                ddlColonia.DataSource = colonias;
                ddlColonia.DataBind();

                //obtiene municipios, ciudades y estados que coinciden con CP
                var municipios = (from c in _dataModel.Colonia
                                  join m in _dataModel.Municipio on c.nIdMunicipio equals m.nIdMunicipio
                                  join ciu in _dataModel.Ciudad on m.nIdCiudad equals ciu.nIdCiudad
                                  join e in _dataModel.Estado on ciu.nIdEstado equals e.nIdEstado
                                  where c.sCP.Equals(txtCodigoPostal.Text) && c.nIdCiudad == (m.nIdCiudad) && m.nIdEstado == (ciu.nIdEstado) && c.nIdEstado == m.nIdEstado
                                  select new { m.nIdMunicipio, m.sMunicpio, ciu.nIdCiudad, ciu.sCiudad, e.nIdEstado, e.sEstado }
                             ).Distinct().ToList();

                //llena ddlDelegacion
                ddlDelegacion.DataValueField = "nIdMunicipio";
                ddlDelegacion.DataTextField = "sMunicpio";
                ddlDelegacion.DataSource = municipios;
                ddlDelegacion.DataBind();

                //llena ddlCiudad
                ddlCiudad.DataValueField = "nIdCiudad";
                ddlCiudad.DataTextField = "sCiudad";
                ddlCiudad.DataSource = municipios;
                ddlCiudad.DataBind();

                //llena ddlEstado
                ddlEstado.DataValueField = "nIdEstado";
                ddlEstado.DataTextField = "sEstado";
                ddlEstado.DataSource = municipios;
                ddlEstado.DataBind();
            }
        }

        public void LlenarEmpresa(Empresa empresa, Direccion dir)
        {
            hdIdEmpresa.Value = empresa.nIdEmpresa.ToString();

            txtRazonSocial.Text = empresa.sRazonSocial;
            txtRFC.Text = empresa.sRFC;
            txtCURP.Text = empresa.sCURP;
            ddlRegimenFiscal.SelectedValue = empresa.sRegimenFiscal;
            txtRepresentante.Text = empresa.sRepresentanteLegal;
            txtTelefono.Text = empresa.sTelefono;
            txtFax.Text = empresa.sFAx;
            txtEmailContacto.Text = empresa.sEmailContacto;
            txtPaginaWeb.Text = empresa.sPaginaWeb;
            txtFechaRegistro.Text = empresa.sFechaRegistro.ToString();

            hfIdDireccion.Value = empresa.nIdDireccion.ToString();

            ddlColonia.SelectedValue = dir.nIdColonia.ToString();
            txtCalle.Text = dir.sCalle;
            txtNumeroExterior.Text = dir.sNoExterno;
            txtNumeroInterior.Text = dir.sNoInterno;

            using (var db = new DB_A06759_NOMINASEntities())
            {
                var colonia = db.Colonia.Where(c => c.nIdColonia == dir.nIdColonia).FirstOrDefault();
                txtCodigoPostal.Text = colonia.sCP;
            }
            txtCodigoPostal_TextChanged(this, EventArgs.Empty);

        }
        #endregion
    }
}