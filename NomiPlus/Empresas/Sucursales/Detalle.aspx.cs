using NomiPlus.LogicObjects;
using NomiPlus.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NomiPlus.Empresas.Sucursales
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
            SucursalLogic sl = new SucursalLogic();
            sl.GuardarSucursal(ObtenerSucursal(dir.nIdDireccion));
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Empresas/Sucursales");
        }

        protected void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            IncializaDdlDirecciones();
        }

        #region Metodos
        private void InitializeControls()
        {
            var idSucursal = Request.QueryString["Sucursal"];
            var idEmpresa = Request.QueryString["Empresa"];
            if (!string.IsNullOrEmpty(idEmpresa))
            {
                int idEmp;
                if (int.TryParse(idEmpresa, out idEmp))
                {
                    hfIdSucursal.Value = idEmp.ToString();
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
            else
            {
                Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "No se encontró la sucursal." + "');</script>"
                    );
                Response.Redirect("~/Empresas/Sucursales");
            }
            if (!string.IsNullOrEmpty(idSucursal))
            {
                int idPac;
                if (int.TryParse(idSucursal, out idPac))
                {
                    SucursalLogic pl = new SucursalLogic();
                    Sucursal sucursal = pl.ObtenerSucursal(int.Parse(idSucursal));
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
                        DireccionLogic dl = new DireccionLogic();
                        Direccion dir = dl.ObtenerDireccion(sucursal.nIdDireccion);
                        if (dir == null)
                        {
                            Page.ClientScript.RegisterStartupScript(
                                Page.GetType(),
                                "MessageBox",
                                "<script language='javascript'>alert('" + "No se encontró la dirección del cliente." + "');</script>"
                             );
                            Response.Redirect("~/");
                        }
                        lblAccion.Text = "Editar";
                        LlenarSucursal(sucursal, dir);
                    }
                }
            }
            else
            {
                lblAccion.Text = "Nueva";
            }
        }

        public Sucursal ObtenerSucursal(int idDireccion)
        {
            Sucursal sucursal = new Sucursal()
            {
                nIdSucursal = string.IsNullOrEmpty(hfIdSucursal.Value) ? default(int) : int.Parse(hfIdSucursal.Value),
                nIdEmpresa = int.Parse(hfIdSucursal.Value),
                sNombreSucursal = txtSucursal.Text,
                sNombreEncargado = txtResponsable.Text,
                sTelefono = txtTelefono.Text,
                sFax = txtFax.Text,
                sEmail = txtEmail.Text,
                sFechaRegistro = DateTime.Parse(txtFechaRegistro.Text),
                bActivo = true,
                nIdDireccion = idDireccion
            };
            return sucursal;
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
                                  where c.sCP.Equals(txtCodigoPostal.Text) && c.nIdCiudad == (m.nIdCiudad) && e.nIdEstado == (ciu.nIdEstado)
                                  select new { m.nIdMunicipio, m.sMunicpio, ciu.nIdCiudad, ciu.sCiudad, e.nIdEstado, e.sEstado }
                             ).Distinct().ToList();

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


        public void LlenarSucursal(Sucursal sucursal, Direccion dir)
        {
            hfIdSucursal.Value = sucursal.nIdSucursal.ToString();
            hfIdEmpresa.Value = sucursal.nIdEmpresa.ToString();

            txtSucursal.Text = sucursal.nIdSucursal.ToString();
            txtResponsable.Text = sucursal.sNombreEncargado;
            txtTelefono.Text = sucursal.sTelefono;
            txtFax.Text = sucursal.sFax;
            txtEmail.Text = sucursal.sEmail;
            txtFechaRegistro.Text = sucursal.sFechaRegistro.ToString();

            hfIdDireccion.Value = sucursal.nIdDireccion.ToString();

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