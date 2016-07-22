<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="NomiPlus.Empresas.Detalle" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="Server">
    <title><%: Request.QueryString["Empresa"] == null ? "Nueva Empresa" : "Editar Empresa" %>  </title>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron jumbotron-small">
        <h2>
            <asp:Label runat="server" ID="lblAccion" /> empresa
        </h2>
    </div>
    <div class="widget">
    <div class="widget-header"> 
        <i class="icon-pencil"></i>
              <h3>Datos</h3>
            </div>
            <div class="widget-content">

            <asp:HiddenField runat="server" ID="hdIdEmpresa" Visible="false" />
            <asp:HiddenField runat="server" ID="hfIdDireccion" Visible="false" />
            <table class="large-table">
                <tr>
                    <td class="formulario-md" style="width: 140px">Razón social
                    </td>
                    <td style="width:210px">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtRazonSocial" Width="200px" />
                    </td>
                    <td style="width:30px">
                        <asp:RequiredFieldValidator runat="server" ID="rfvRazonSocial" ControlToValidate="txtRazonSocial" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
                        <asp:RegularExpressionValidator runat="server" ID="revDireccion" ControlToValidate="txtRazonSocial" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                            ValidationExpression="[a-züñáéíóúA-ZÜÑÁÉÍÓÚ0-9.#\s\-]{1,150}" />
                    </td>
                    <td class="formulario-md" style="width: 140px">RFC
                    </td>
                    <td style="width:210px">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtRFC" Width="200px" MaxLength="13" />
                    </td>
                    <td style="width:30px">
                        <asp:RequiredFieldValidator runat="server" ID="frvRFC" ControlToValidate="txtRFC" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
                        <asp:RegularExpressionValidator runat="server" ID="revRFC" ControlToValidate="txtRFC" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                            ValidationExpression="[A-Z,Ñ,&]{3,4}[0-9]{2}[0-1][0-9][0-3][0-9][A-Z,0-9]?[A-Z,0-9]?[0-9,A-Z]?" />
                    </td>
                    <td class="formulario-md" style="width: 140px">CURP
                    </td>
                    <td style="width:210px">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtCURP" Width="200px" MaxLength="18" />
                    </td>
                    <td style="width:30px">
                        <%--<asp:RequiredFieldValidator runat="server" ID="rfvCURP" ControlToValidate="txtCURP" Display="Dynamic" ErrorMessage="*" ForeColor="Red"  />--%>
                        <asp:RegularExpressionValidator runat="server" ID="revCURP" ControlToValidate="txtCURP" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                            ValidationExpression="[A-Z][A,E,I,O,U,X][A-Z]{2}[0-9]{2}[0-1][0-9][0-3][0-9][M,H][A-Z]{2}[B,C,D,F,G,H,J,K,L,M,N,Ñ,P,Q,R,S,T,V,W,X,Y,Z]{3}[0-9,A-Z][0-9]" />
                    </td>
                </tr>
                <tr>
                    <td>Régimen Fiscal
                    </td>
                    <td>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlRegimenFiscal" Width="210px">
                            <asp:ListItem Value="Régimen General de Ley Personas Morales" Text="Régimen General de Ley Personas Morales" runat="server" />
                            <asp:ListItem Value="Personas Morales con Fines no Lucrativos" Text="Personas Morales con Fines no Lucrativos" runat="server" />
                            <asp:ListItem Value="Régimen de las Personas Físicas con Actividades Empresariales y Profesionales" Text="Régimen de las Personas Físicas con Actividades Empresariales y Profesionales" runat="server" />
                            <asp:ListItem Value="Régimen Intermedio de las Personas Físicas con Actividades Empresariales" Text="Régimen Intermedio de las Personas Físicas con Actividades Empresariales" runat="server" />
                            <asp:ListItem Value="Régimen de Arrendamiento" Text="Régimen de Arrendamiento" runat="server" />
                            <asp:ListItem Value="Otro" Text="Otro" runat="server" />
                        </asp:DropDownList>
                    </td>
                    <td>
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
                </tr>
                <tr>
                    <td>Número interior
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtNumeroInterior" Width="200px" />
                    </td>
                    <td>
                        <asp:RegularExpressionValidator runat="server" ID="revNumeroInterior" ControlToValidate="txtNumeroInterior" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                            ValidationExpression="[a-züñáéíóúA-ZÜÑÁÉÍÓÚ0-9.#\s\-]{1,100}" />
                    </td>
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
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlDelegacion" Width="210px"></asp:DropDownList>
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
                    <td>Estado
                    </td>
                    <td>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEstado" Width="210px" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ID="rfvEstado" ControlToValidate="ddlEstado" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
                    </td>
                </tr>
                <tr>
                    <td>Representante legal
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtRepresentante" Width="200px" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ID="rfvNombreContacto" ControlToValidate="txtRepresentante" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
                        <asp:RegularExpressionValidator runat="server" ID="revNombreContacto" ControlToValidate="txtRepresentante" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                            ValidationExpression="[a-züñáéíóúA-ZÜÑÁÉÍÓÚ0-9.#\s\-]{1,150}" />
                    </td>
                    <td>Email contacto
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEmailContacto" Width="200px" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ID="rfvEmailContacto" ControlToValidate="txtEmailContacto" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" />
                        <asp:RegularExpressionValidator runat="server" ID="revEmailContacto" ControlToValidate="txtEmailContacto" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                    </td>
                    <td>Teléfono
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtTelefono" Width="200px" />
                    </td>
                    <td>
                        <asp:RegularExpressionValidator runat="server" ID="revTelefono" ControlToValidate="txtTelefono" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                            ValidationExpression="[a-zA-Z0-9\+\(\)\s\-]{1,50}" />
                    </td>
                </tr>
                <tr>
                    <td>Fax
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtFax" Width="200px" />
                    </td>
                    <td>
                        <asp:RegularExpressionValidator runat="server" ID="revFax" ControlToValidate="txtFax" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                            ValidationExpression="[a-zA-Z0-9\+\(\)\s\-]{1,255}" />
                    </td>
                    <td>Página web
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPaginaWeb" Width="200px" />
                    </td>
                    <td>
                        <asp:RegularExpressionValidator runat="server" ID="revPaginaWeb" ControlToValidate="txtPaginaWeb" Display="Dynamic" ErrorMessage="Formato incorrecto" ForeColor="Red"
                            ValidationExpression="[a-züñáéíóúA-ZÜÑÁÉÍÓÚ0-9.#\s\-]{1,150}" />
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
            <table style="width:100%">
                <tr>
                       <td style="text-align:right;">
                         <asp:Button runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" Text="Guardar" CssClass="btn btn-primary"
                            OnClientClick="return Validate('¿Estás seguro que deseas guardar datos de la empresa?');" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnCancelar" OnClick="btnCancelar_Click" Text="Cancelar" CssClass="btn btn-danger" CausesValidation="False"
                            OnClientClick="return confirm('¿Estás seguro que deseas volver sin guardar los cambios?');" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
            <asp:Panel runat="server" ID="pnlFallos" CssClass="alert alert-danger" role="alert" Visible="false">
    	        <asp:Label runat="server" ID="lblErrorMsg" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
