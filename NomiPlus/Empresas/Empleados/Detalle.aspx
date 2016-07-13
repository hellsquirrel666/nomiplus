<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="NomiPlus.Empresas.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron jumbotron-small">
        <h2>
            <asp:Label runat="server" ID="lblAccion" />
            empleado
        </h2>
    </div>
    <h1 class="page-header">Datos Personales</h1>
    
    <table style="width:100%">
        <tr>
            <td>
                <asp:HiddenField runat="server" ID="hfIdDireccion" Visible="true" />
                <asp:HiddenField runat="server" ID="hfIdEmpleado" Visible="true" />
            </td>
            <td />
        </tr>
        <tr>
            <td class="formulario-md">Nombre(s)
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" width="200px" />
                <asp:RequiredFieldValidator runat="server" ID="rfvNombre" ControlToValidate="txtNombre" Display="Dynamic" ErrorMessage="*" ForeColor="Red" />
                <asp:RegularExpressionValidator runat="server" ID="revNombre" ControlToValidate="txtNombre" Display="Dynamic" ErrorMessage="Formato incorrecto." ForeColor="Red"
                    ValidationExpression="[a-züñáéíóúA-ZÜÑÁÉÍÓÚ0-9.\s\-]{1,50}" />
            </td>
            <td class="formulario-md">Apellido Paterno
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPaterno" width="200px" />
                <asp:RequiredFieldValidator runat="server" ID="rfvPaterno" ControlToValidate="txtPaterno" Display="Dynamic" ErrorMessage="*" ForeColor="Red" />
                <asp:RegularExpressionValidator runat="server" ID="revPaterno" ControlToValidate="txtPaterno" Display="Dynamic" ErrorMessage="Formato incorrecto." ForeColor="Red"
                    ValidationExpression="[a-züñáéíóúA-ZÜÑÁÉÍÓÚ0-9.\s\-]{1,50}" />
            </td>
            <td class="formulario-md">Apellido Materno
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtMaterno" width="200px" />
                <asp:RegularExpressionValidator runat="server" ID="revMaterno" ControlToValidate="txtMaterno" Display="Dynamic" ErrorMessage="Formato incorrecto." ForeColor="Red"
                    ValidationExpression="[a-züñáéíóúA-ZÜÑÁÉÍÓÚ0-9.\s\-]{1,50}" />
            </td>
        </tr>
        <tr>
            <td>
                <span class="help" title="Este valor no se utiliza para cálculos.">Periodicidad de pago</span>
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlPeriodicidad" CssClass="form-control" width="200px" />
            </td>
        
            <td>RFC
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtRFC" MaxLength="13" width="200px" />
                <asp:RequiredFieldValidator runat="server" ID="rfvRFC" ControlToValidate="txtRFC" Display="Dynamic" ErrorMessage="*" ForeColor="Red"  ValidationGroup="RDIE" />
                <asp:RegularExpressionValidator runat="server" ID="revRFC" ControlToValidate="txtRFC" Display="Dynamic" ErrorMessage="Formato incorrecto." ForeColor="Red"
                    ValidationExpression="[A-Z,Ñ,&]{3,4}[0-9]{2}[0-1][0-9][0-3][0-9][A-Z,0-9]?[A-Z,0-9]?[0-9,A-Z]?" />
            </td>
            <td>CURP
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtCURP" MaxLength="18" width="200px" />
                <asp:RequiredFieldValidator runat="server" ID="rfvCURP" ControlToValidate="txtCURP" Display="Dynamic" ErrorMessage="*" ForeColor="Red" />
                <asp:RegularExpressionValidator runat="server" ID="revCURP" ControlToValidate="txtCURP" Display="Dynamic" ErrorMessage="Formato incorrecto." ForeColor="Red"
                    ValidationExpression="[A-Z][A,E,I,O,U,X][A-Z]{2}[0-9]{2}[0-1][0-9][0-3][0-9][M,H][A-Z]{2}[B,C,D,F,G,H,J,K,L,M,N,Ñ,P,Q,R,S,T,V,W,X,Y,Z]{3}[0-9,A-Z][0-9]" />
            </td>
        </tr>
        <tr>
            <td>Numero de Seguridad Social
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNumSeguro" width="200px" MaxLength="11" />
                <asp:RequiredFieldValidator runat="server" ID="rfvNSS" ControlToValidate="txtNumSeguro" Display="Dynamic" Text="*" ForeColor="Red" ValidationGroup="RDIE"/>
                <asp:RegularExpressionValidator runat="server" ID="revNSS" ControlToValidate="txtNumSeguro" Display="Dynamic" ErrorMessage="Formato incorrecto." ForeColor="Red"
                    ValidationExpression="[0-9]{11}" />
            </td>
            <td>Numero INFONAVIT
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtInfonavit" width="200px" MaxLength="11" />
                <asp:RequiredFieldValidator runat="server" ID="rfvInfonavit" ControlToValidate="txtNumSeguro" Display="Dynamic" Text="*" ForeColor="Red" ValidationGroup="RDIE"/>
                <asp:RegularExpressionValidator runat="server" ID="revInfornavit" ControlToValidate="txtNumSeguro" Display="Dynamic" ErrorMessage="Formato incorrecto." ForeColor="Red"
                    ValidationExpression="[0-9]{11}" />
            </td>
            <td>Fecha de registro</td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaRegistro" placeholder="dd/mm/aaaa" width="200px" />
                <asp:RequiredFieldValidator runat="server" ID="rfvFechaRegistro" ControlToValidate="txtFechaRegistro" Display="Dynamic" ErrorMessage="*" ForeColor="Red" />
                <asp:RegularExpressionValidator ID="revRechaRegistro" runat="server" ControlToValidate="txtFechaRegistro" Display="Dynamic" ErrorMessage="Formato incorrecto." ForeColor="Red"
                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/](19|20)\d\d" />

            </td>
        </tr>
        <tr>
            <td>Sexo
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlSexo" AppendDataBoundItems="true" CssClass="form-control" width="200px">
                    <asp:ListItem Text="Hombre" Value="H" />
                    <asp:ListItem Text="Mujer" Value="M" />
                </asp:DropDownList>
            </td>
            <td>Tipo de trabajador
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlTipoTrabajador" CssClass="form-control" width="200px" />
            </td>
            <td>Tipo de salario
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlTipoSalario" CssClass="form-control" width="200px" />
            </td>
        </tr>
        <tr>
            <td>Lugar de nacimiento
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlLugarDeNacimiento" CssClass="form-control" width="200px" />
            </td>
            <td>UMF
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtUMF" CssClass="form-control" width="200px" />
            </td>
            <td>Fecha de alta IMSS</td>
            <td>
                <asp:TextBox runat="server" ID="txtFechaAltaImss" CssClass="form-control" placeholder="dd/MM/aaaa" width="200px" />
            </td>
        </tr>
        <tr>
            <td>Codigo postal
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCodigoPostal" CssClass="form-control" MaxLength="5" width="200px" />
                <asp:RegularExpressionValidator ID="revCodigoPostal" runat="server" ControlToValidate="txtCodigoPostal" Display="Dynamic" ErrorMessage="Formato incorrecto." ForeColor="Red"
                    ValidationExpression="[0-9]{5}" />
            </td>
            <td>Salario diario
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtSalarioDiario" CssClass="form-control" width="200px" />
                <asp:RequiredFieldValidator runat="server" ID="rfvSalario" ControlToValidate="txtSalarioDiario" ErrorMessage="*" ForeColor="Red" Display="Dynamic" 
                    ValidationGroup="RDIE"/>
            </td>
            <td>SDI
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtSDI" CssClass="form-control" width="200px" />
                <asp:RequiredFieldValidator runat="server" ID="rfvSDI" ControlToValidate="txtSDI" ErrorMessage="*" ForeColor="Red" Display="Dynamic" 
                    ValidationGroup="RDIE"/>
            </td>
        </tr>
        <tr>
            <td>Fecha Baja
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFechaBaja" CssClass="form-control" placeholder="dd/mm/aaaa" width="200px" />

            </td>
            <td>Causa baja
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlClaveCausaBaja" CssClass="form-control" width="200px" />

            </td>
            <td>Fecha Reingreso
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtReingreso" CssClass="form-control" placeholder="dd/mm/aaaa" width="200px" />
            </td>
        </tr>
        <tr>
            <td>Ocupacion
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtClaveOcupacion" CssClass="form-control" width="200px" MaxLength="5" />
                <asp:RegularExpressionValidator ID="revClaveOcupacion" runat="server" ControlToValidate="txtClaveOcupacion" Display="Dynamic" ErrorMessage="Formato incorrecto." ForeColor="Red"
                    ValidationExpression="[0-9]{1,5}" />
            </td>                    
            <td>
                Sucursal:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlSucursal" width="200px" CssClass="form-control" />
            </td>
            <td>
                Departamento:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlDepartamento" width="200px" CssClass="form-control" />
            </td>
        </tr>
    </table>

    <table class="large-table">
        <tr>
            <td class="text-right">
                <asp:Button runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" Text="Guardar" CssClass="btn btn-primary"
                    OnClientClick="return Validate('¿Estás seguro que deseas guardar datos de la empresa?');" />
                <asp:Button runat="server" ID="btnCancelar" OnClick="btnCancelar_Click" Text="Cancelar" CssClass="btn btn-secondary" CausesValidation="False"
                    OnClientClick="return confirm('¿Estás seguro que deseas volver sin guardar los cambios?');" />
            </td>
        </tr>
    </table>
    <asp:Panel runat="server" ID="pnlFallos" CssClass="alert alert-danger" role="alert" Visible="false">
    	<asp:Label runat="server" ID="lblErrorMsg" />
    </asp:Panel>
</asp:Content>
