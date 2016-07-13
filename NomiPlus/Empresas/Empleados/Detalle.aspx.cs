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
            DireccionLogic dl = new DireccionLogic();
            var dir = dl.ActualizarOGuardarDireccion(ObtenerDireccion());
            EmpleadoLogic el = new EmpleadoLogic();
            el.GuardarEmpleado(ObtenerEmpleado(dir.nIdDireccion));
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        protected void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {

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
                            "<script language='javascript'>alert('" + "No se encontró la empresa." + "');</script>"
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
                                "<script language='javascript'>alert('" + "No se encontró la dirección del cliente." + "');</script>"
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
                lblAccion.Text = "Nueva";
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
                
            };
            return direccion;
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