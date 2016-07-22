<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="NomiPlus.Empresas.Sucursales.Detalle" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="Server">
    <title><%: Request.QueryString["Sucursal"] == null ? "Nueva Sucursal" : "Editar Sucursal" %>  </title>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron jumbotron-small">
        <h2>
            <asp:Label runat="server" ID="lblAccion" /> sucursal
        </h2>
    </div>
    <h1 class="page-header">Datos</h1>

    <asp:HiddenField runat="server" ID="hfIdEmpresa" Visible="false" />
    <asp:HiddenField runat="server" ID="hfIdSucursal" Visible="false" />
    <asp:HiddenField runat="server" ID="hfIdDireccion" Visible="false" />
    <table class="small-table">
        <tr>
            <td class="formulario-md" style="width: 150px">Nombre sucursal
            </td>
            <td style="width:210px">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtSucursal" Width="200px" />
            </td>
            <td style="width:30px">
                <asp:RequiredFieldValidator runat="server" ID="rfvSucursal" ControlToValidate="txtSucursal" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
                <asp:RegularExpressionValidator runat="server" ID="revSucursal" ControlToValidate="txtSucursal" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                    ValidationExpression="[a-züñáéíóúA-ZÜÑÁÉÍÓÚ0-9.#\s\-]{1,150}" />
            </td>
            <td class="formulario-md" style="width: 150px">Nombre responsable
            </td>
            <td style="width:210px">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtResponsable" Width="200px" />
            </td>
            <td style="width:30px">
                <asp:RequiredFieldValidator runat="server" ID="rfvResponsable" ControlToValidate="txtResponsable" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
                <asp:RegularExpressionValidator runat="server" ID="revResponsable" ControlToValidate="txtResponsable" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                    ValidationExpression="[a-züñáéíóúA-ZÜÑÁÉÍÓÚ9.s\-\ ]{1,150}" />
            </td>
        </tr>
        <tr>
            <td class="formulario-md" style="width: 210px">Telefono
            </td>
            <td style="width:210px">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtTelefono" Width="200px" />
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rfvTelefono" ControlToValidate="txtTelefono" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
                <asp:RegularExpressionValidator runat="server" ID="revTelefono" ControlToValidate="txtTelefono" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                    ValidationExpression="[0-9.#\s\-]{1,50}" />
            </td>
            <td class="formulario-md" style="width: 210px">Fax
            </td>
            <td style="width:210px">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtFax" Width="200px" />
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rfvFax" ControlToValidate="txtFax" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
                <asp:RegularExpressionValidator runat="server" ID="revFax" ControlToValidate="txtFax" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                    ValidationExpression="[a-züñáéíóúA-ZÜÑÁÉÍÓÚ0-9.#\s\-]{1,150}" />
            </td>
        </tr>
        <tr>
            <td class="formulario-md" style="width: 210px">E-mail
            </td>
            <td style="width:210px">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" Width="200px" />
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
                <asp:RegularExpressionValidator runat="server" ID="revEmail" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
            </td>
            <td>Calle
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtCalle" Width="200px" />
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rfvCalle" ControlToValidate="txtCalle" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
                <asp:RegularExpressionValidator runat="server" ID="revCalle" ControlToValidate="txtCalle" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                    ValidationExpression="[a-züñáéíóúA-ZÜÑÁÉÍÓÚ0-9.#\s\-]{1,100}" />
            </td>
        </tr>
        <tr>
            <td>Número exterior
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNumeroExterior" Width="200px" />
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rfvNumeroExterior" ControlToValidate="txtNumeroExterior" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
                <asp:RegularExpressionValidator runat="server" ID="revNumeroExterior" ControlToValidate="txtNumeroExterior" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                    ValidationExpression="[a-züñáéíóúA-ZÜÑÁÉÍÓÚ0-9.#\s\-]{1,100}" />
            </td>
            <td>Número interior
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNumeroInterior" Width="200px" />
            </td>
            <td>
                <asp:RegularExpressionValidator runat="server" ID="revNumeroInterior" ControlToValidate="txtNumeroInterior" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                    ValidationExpression="[a-züñáéíóúA-ZÜÑÁÉÍÓÚ0-9.#\s\-]{1,100}" />
            </td>
        </tr>
        <tr>
            <td>Código postal
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtCodigoPostal" Width="200px" OnTextChanged="txtCodigoPostal_TextChanged" AutoPostBack="true" />
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rfvCodigoPostal" ControlToValidate="txtCodigoPostal" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
                <asp:RegularExpressionValidator runat="server" ID="revCodigoPostal" ControlToValidate="txtCodigoPostal" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                    ValidationExpression="\d{5}" />
            </td>
            <td>Colonia
            </td>
            <td>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlColonia" Width="210px"></asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rfvColonia" ControlToValidate="ddlColonia" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
            </td>
        </tr>
        <tr>
            <td>
                Delegacion / Municipio:
            </td>
            <td>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlDelegacion" Width="210px" ></asp:DropDownList>
            </td>
            <td></td>
            <td>Ciudad
            </td>
            <td>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCiudad" Width="210px" />
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rfvCiudad" ControlToValidate="ddlCiudad" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
            </td>
        </tr>
        <tr>
            <td>Estado
            </td>
            <td>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEstado" Width="210px" />
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rfvEstado" ControlToValidate="ddlEstado" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
            </td>
            <td>Fecha de registro</td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaRegistro" Width="200px" placeholder="dd/mm/aaaa" />
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rfvFechaRegistro" ControlToValidate="txtFechaRegistro" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
                <asp:RegularExpressionValidator ID="revRechaRegistro" runat="server" ControlToValidate="txtFechaRegistro" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/](19|20)\d\d" />
            </td>
        </tr>
    </table>
    </br>
    </br>
    </br>
    <table class="large-table">
        <tr>
            <td class="text-right">
                <asp:Button runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" Text="Guardar" CssClass="btn btn-primary"
                    OnClientClick="return Validate('¿Estás seguro que deseas guardar datos de la empresa?');" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button runat="server" ID="btnCancelar" OnClick="btnCancelar_Click" Text="Cancelar" CssClass="btn btn-danger" CausesValidation="False"
                    OnClientClick="return confirm('¿Estás seguro que deseas volver sin guardar los cambios?');" />
            </td>
        </tr>
    </table>
    <asp:Panel runat="server" ID="pnlFallos" CssClass="alert alert-danger" role="alert" Visible="false">
    	<asp:Label runat="server" ID="lblErrorMsg" />
    </asp:Panel>
</asp:Content>
