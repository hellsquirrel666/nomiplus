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
            Response.Redirect("~/");
        }

        protected void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            IncializaDdlDirecciones();
        }

        #region Metodos
        private void InitializeControls()
        {
            var idEmpleado = Request.QueryString["Empleado"];
            if (!string.IsNullOrEmpty(idEmpleado))
            {
                int idPac;
                if (int.TryParse(idEmpleado, out idPac))
                {
                    EmpleadoLogic pl = new EmpleadoLogic();
                    Empleado empresa = pl.ObtenerEmpleado(int.Parse(idEmpleado));
                    if (empresa == null)
                    {
                        Page.ClientScript.RegisterStartupScript(
                            Page.GetType(),
                            "MessageBox",
                            "<script language='javascript'>alert('" + "No se encontró el empleado." + "');</script>"
                         );
                        Response.Redirect("~/");
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
                                "<script language='javascript'>alert('" + "No se encontró la dirección del empleado." + "');</script>"
                             );
                            Response.Redirect("~/");
                        }
                        lblAccion.Text = "Editar";
                        LlenarEmpleado(empresa, dir);
                    }
                }
            }
            else
            {
                lblAccion.Text = "Nuevo";
            }
        }

        public Empleado ObtenerEmpleado(int idDireccion)
        {
            Empleado empresa = new Empleado()
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
                dFechaAltaIMSS = DateTime.Parse(txtFechaAltaImss.Text),
                nSalarioDiario = int.Parse(txtSalarioDiario.Text), 
                nSDI = int.Parse(txtSDI.Text),
                dFechaBaja = DateTime.Parse(txtFechaBaja.Text),
                nIdCausaBaja = int.Parse(ddlClaveCausaBaja.SelectedValue),
                dFechaReingreso = DateTime.Parse(txtReingreso.Text),
                nIdOcupacion = int.Parse(txtClaveOcupacion.Text),
                nIdSucursal = int.Parse(ddlSucursal.SelectedValue),
                nIdDepartamento = int.Parse(ddlDepartamento.SelectedValue),
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
                                  where c.sCP.Equals(txtCodigoPostal.Text) && c.nIdCiudad == (m.nIdCiudad) && e.nIdEstado == (ciu.nIdEstado)
                                  select new { m.nIdMunicipio, m.sMunicpio, ciu.nIdCiudad, ciu.sCiudad, e.nIdEstado, e.sEstado }
                             ).Distinct().ToList();

                //llena ddlCiudad
                ddlCiudad.DataValueField = "nIdCuidad";
                ddlCiudad.DataTextField = "sCuidad";
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
            txtFechaRegistro.Text = empleado.sFecharegistro.ToString("yyyy-MM-dd");
            ddlSexo.SelectedValue = empleado.sSexo;
            ddlTipoTrabajador.SelectedValue = empleado.nIdTipoTrabajador.ToString();
            ddlTipoSalario.SelectedValue = empleado.nIdTipoSalario.ToString();
            ddlLugarDeNacimiento.SelectedValue = empleado.nIdEstadoNacimiento.ToString();
            txtUMF.Text = empleado.sUMF;
            txtFechaAltaImss.Text = empleado.dFechaAltaIMSS.ToString();
            txtSalarioDiario.Text = empleado.nSalarioDiario.ToString();
            txtSDI.Text = empleado.nSDI.ToString();
            txtFechaBaja.Text = empleado.dFechaBaja.ToString();
            ddlClaveCausaBaja.SelectedValue = empleado.nIdCausaBaja.ToString();
            txtFechaRegistro.Text = empleado.dFechaReingreso.ToString();
            txtClaveOcupacion.Text = empleado.nIdOcupacion.ToString();
            ddlSucursal.SelectedValue = empleado.nIdSucursal.ToString();
            ddlDepartamento.SelectedValue = empleado.nIdDepartamento.ToString();

            hfIdDireccion.Value = empleado.nIdDireccion.ToString();

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