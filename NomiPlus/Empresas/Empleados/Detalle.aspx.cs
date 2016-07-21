using NomiPlus.LogicObjects;
using NomiPlus.Modelo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NomiPlus.Empresas.Empleados
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
            try
            {
                DireccionLogic dl = new DireccionLogic();
                var dir = dl.ActualizarOGuardarDireccion(ObtenerDireccion());
                EmpleadoLogic el = new EmpleadoLogic();
                el.GuardarEmpleado(ObtenerEmpleado(dir.nIdDireccion));
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
            Response.Redirect(string.Format("~/Empresas/Empleados?Empresa={0}",hfIdEmpresa.Value));
        }

        protected void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            IncializaDdlDirecciones();
        }

        protected void ddlSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaDdlDepartamentos();
        }

        #region Metodos
        private void InitializeControls()
        {
            var idEmpresa = Request.QueryString["Empresa"];
            var idEmpleado = Request.QueryString["Empleado"];
            if (!string.IsNullOrEmpty(idEmpresa))
            {
                int idEmpr;
                if (int.TryParse(idEmpresa, out idEmpr))
                {
                    EmpresaLogic eml = new EmpresaLogic();
                    var empresa = eml.ObtenerEmpresa(idEmpr);
                    hfIdEmpresa.Value = empresa.nIdEmpresa.ToString();
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
                    "<script language='javascript'>alert('" + "No se encontró la empresa." + "');</script>"
                 );
                Response.Redirect("~/Empresas");

            }
            if (!string.IsNullOrEmpty(idEmpleado))
            {
                int idPac;
                if (int.TryParse(idEmpleado, out idPac))
                {
                    EmpleadoLogic pl = new EmpleadoLogic();
                    Empleado empleado = pl.ObtenerEmpleado(int.Parse(idEmpleado));
                    if (empleado == null)
                    {
                        Page.ClientScript.RegisterStartupScript(
                            Page.GetType(),
                            "MessageBox",
                            "<script language='javascript'>alert('" + "No se encontró el empleado." + "');</script>"
                         );
                        Response.Redirect("~/Empresas");
                    }
                    else
                    {
                        DireccionLogic dl = new DireccionLogic();
                        Direccion dir = dl.ObtenerDireccion(empleado.nIdDireccion);
                        if (dir == null)
                        {
                            Page.ClientScript.RegisterStartupScript(
                                Page.GetType(),
                                "MessageBox",
                                "<script language='javascript'>alert('" + "No se encontró la dirección del empleado." + "');</script>"
                             );
                            Response.Redirect("~/Empresas");
                        }
                        lblAccion.Text = "Editar";
                        IncializaDdls();
                        LlenarEmpleado(empleado, dir);
                    }
                }
            }
            else
            {
                IncializaDdls();
                lblAccion.Text = "Nuevo";
            }
        }

        public Empleado ObtenerEmpleado(int idDireccion)
        {
            
            Empleado empleado = new Empleado()
            {
                nIdEmpleado = string.IsNullOrEmpty(hfIdEmpleado.Value) ? default(int) : int.Parse(hfIdEmpleado.Value),
                sPrimerApellido = txtPaterno.Text,
                sSegundoApellido = txtMaterno.Text,
                sNombre = txtNombre.Text,
                nIdPeriodicidad = int.Parse(ddlPeriodicidad.SelectedValue),
                sRFC = txtRFC.Text,
                sCURP = txtCURP.Text,
                nNSS = txtNumSeguro.Text,
                nNoInfonavit = txtInfonavit.Text,
                sFecharegistro = DateTime.Parse(txtFechaRegistro.Text),
                sSexo = ddlSexo.SelectedValue,
                nIdTipoTrabajador = int.Parse(ddlTipoTrabajador.SelectedValue),
                nIdTipoSalario = int.Parse(ddlTipoSalario.SelectedValue),
                nIdEstadoNacimiento = int.Parse(ddlLugarDeNacimiento.SelectedValue),
                sUMF = txtUMF.Text,
                dFechaAltaIMSS = string.IsNullOrEmpty(txtFechaAltaImss.Text) ? (DateTime?)null : DateTime.Parse(txtFechaAltaImss.Text),
                nSalarioDiario = decimal.Parse(txtSalarioDiario.Text), 
                nSDI = decimal.Parse(txtSDI.Text),
                dFechaBaja = string.IsNullOrEmpty(txtFechaBaja.Text) ? (DateTime?)null : DateTime.Parse(txtFechaBaja.Text),
                nIdCausaBaja = int.Parse(ddlClaveCausaBaja.SelectedValue),
                dFechaReingreso = string.IsNullOrEmpty(txtReingreso.Text) ? (DateTime?)null : DateTime.Parse(txtReingreso.Text),
                nIdOcupacion = int.Parse(ddlClaveOcupacion.Text),
                nIdSucursal = int.Parse(ddlSucursal.SelectedValue),
                nIdDepartamento = int.Parse(ddlDepartamento.SelectedValue),
                bActivo = true,
                nIdDireccion = idDireccion
            };
            return empleado;
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

        public void LlenarEmpleado(Empleado empleado, Direccion dir)
        {
            hfIdEmpleado.Value = empleado.nIdEmpleado.ToString();
            txtPaterno.Text = empleado.sPrimerApellido;
            txtMaterno.Text = empleado.sSegundoApellido;
            txtNombre.Text = empleado.sNombre;
            ddlPeriodicidad.SelectedValue = empleado.nIdPeriodicidad.ToString();
            txtRFC.Text = empleado.sRFC;
            txtCURP.Text = empleado.sCURP;
            txtNumSeguro.Text = empleado.nNSS;
            txtInfonavit.Text = empleado.nNoInfonavit;
            txtFechaRegistro.Text = empleado.sFecharegistro.ToString("dd/MM/yyyy");
            ddlSexo.SelectedValue = empleado.sSexo;
            ddlTipoTrabajador.SelectedValue = empleado.nIdTipoTrabajador.ToString();
            ddlTipoSalario.SelectedValue = empleado.nIdTipoSalario.ToString();
            ddlLugarDeNacimiento.SelectedValue = empleado.nIdEstadoNacimiento.ToString();
            txtUMF.Text = empleado.sUMF;
            txtFechaAltaImss.Text = string.IsNullOrEmpty(empleado.dFechaAltaIMSS.ToString()) ? "" : empleado.dFechaAltaIMSS.Value.ToString("dd/MM/yyyy");
            txtSalarioDiario.Text = string.Format("{0:F2}", empleado.nSalarioDiario);
            txtSDI.Text = string.Format("{0:F2}", empleado.nSDI);
            txtFechaBaja.Text = string.IsNullOrEmpty(empleado.dFechaBaja.ToString()) ? "" : empleado.dFechaBaja.Value.ToString("dd/MM/yyyy");
            ddlClaveCausaBaja.SelectedValue = empleado.nIdCausaBaja.ToString();
            txtReingreso.Text = string.IsNullOrEmpty(empleado.dFechaReingreso.ToString()) ? "" : empleado.dFechaReingreso.Value.ToString("dd/MM/yyyy");
            ddlClaveOcupacion.SelectedValue = empleado.nIdOcupacion.ToString();
            ddlSucursal.SelectedValue = empleado.nIdSucursal.ToString();
            ddlDepartamento.SelectedValue = empleado.nIdDepartamento.ToString();

            hfIdDireccion.Value = empleado.nIdDireccion.ToString();

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

        public void IncializaDdls()
        {
            PeriodicidadLogic pl = new PeriodicidadLogic();
            ddlPeriodicidad.DataTextField = "sPeriodicidad";
            ddlPeriodicidad.DataValueField = "nIdPeriodicidad";
            ddlPeriodicidad.DataSource = pl.ListaPeriodicidades();
            ddlPeriodicidad.DataBind();
            
            TipoTrabajadorLogic ttl = new TipoTrabajadorLogic();
            ddlTipoTrabajador.DataTextField = "sTipoTrabajador";
            ddlTipoTrabajador.DataValueField = "nIdTipoTrabajador";
            ddlTipoTrabajador.DataSource = ttl.ListaTipoTrabajadores();
            ddlTipoTrabajador.DataBind();
            
            TipoSalarioLogic tsl = new TipoSalarioLogic();
            ddlTipoSalario.DataTextField = "sTipoSalario";
            ddlTipoSalario.DataValueField = "nIdTipoSalario";
            ddlTipoSalario.DataSource = tsl.ListaTipoSalarioes();
            ddlTipoSalario.DataBind();
            
            EstadoLogic edol = new EstadoLogic();
            ddlLugarDeNacimiento.DataTextField = "sEstado";
            ddlLugarDeNacimiento.DataValueField = "nIdEstado";
            ddlLugarDeNacimiento.DataSource = edol.ListaEstados();
            ddlLugarDeNacimiento.DataBind();
            
            SucursalLogic sl = new SucursalLogic();
            ddlSucursal.DataTextField = "sNombreSucursal";
            ddlSucursal.DataValueField = "nIdSucursal";
            ddlSucursal.DataSource = sl.ListaSucursales().Where(x => x.nIdEmpresa == int.Parse(hfIdEmpresa.Value));
            ddlSucursal.DataBind();

            CausaBajaLogic cbl = new CausaBajaLogic();
            ddlClaveCausaBaja.DataTextField = "sCausaBaja";
            ddlClaveCausaBaja.DataValueField = "nIdCausaBaja";
            ddlClaveCausaBaja.DataSource = cbl.ListaCausaBaja();
            ddlClaveCausaBaja.DataBind();

            OcupacionesLogic ol = new OcupacionesLogic();
            ddlClaveOcupacion.DataTextField = "sOcupacion";
            ddlClaveOcupacion.DataValueField = "nIdOcupacion";
            ddlClaveOcupacion.DataSource = ol.ListaOcupaciones();
            ddlClaveOcupacion.DataBind();

            ddlSucursal_SelectedIndexChanged(this, null);
        }

        public void CargaDdlDepartamentos()
        {
            DepartamentoLogic dl = new DepartamentoLogic();
            ddlDepartamento.DataTextField = "sDepartamento";
            ddlDepartamento.DataValueField = "nIdDepartamento";
            ddlDepartamento.DataSource = dl.ListaDepartamentos().Where(x=>x.nIdSucursal == int.Parse(ddlSucursal.SelectedValue));
            ddlDepartamento.DataBind();
        }
        #endregion
    }
}