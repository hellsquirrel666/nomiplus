<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="NomiPlus.Empresas.Sucursales.Departamentos.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron jumbotron-small">
        <h2>
            <asp:Label runat="server" ID="lblAccion" /> departamento
        </h2>
    </div>
    <h1 class="page-header">Datos</h1>

    <asp:HiddenField runat="server" ID="hfIdDepto" Visible="false" />
    <asp:HiddenField runat="server" ID="hfIdSucursal" Visible="false" />
    <table class="small-table">
        <tr>
            <td class="formulario-md" style="width: 210px">Departamento
            </td>
            <td style="width:210px">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtDepartamento" Width="200px" />
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rfvDepto" ControlToValidate="txtDepartamento" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
                <asp:RegularExpressionValidator runat="server" ID="revDepto" ControlToValidate="txtDepartamento" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                    ValidationExpression="[a-züñáéíóúA-ZÜÑÁÉÍÓÚ0-9.#\s\-\ ]{1,150}" />
            </td>
        </tr>
        <tr>
            <td class="formulario-md" style="width: 210px">Nombre responsable
            </td>
            <td style="width:210px">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtResponsable" Width="200px" />
            </td>
            <td>
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
        </tr>
        <tr>
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
