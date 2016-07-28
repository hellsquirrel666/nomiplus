<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaNomina.aspx.cs" Inherits="NomiPlus.Nominas.NuevaNomina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Nueva Nómina</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="jumbotron jumbotron-small">
        <h2>
            <asp:Label runat="server" ID="lblAccion" /> Menú nóminas
        </h2>
    </div>
    <div class="widget">
        <div class="widget-header">
            <i class="icon-book"></i>
            <h3>Datos de la nómina</h3>
        </div>
        <!-- /widget-header -->
        <div class="widget-content">
            <table class="small-table">
                <tr>
                    <td>Empresa: </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlEmpresa" CssClass="form-control" AppendDataBoundItems="true">
                            <asp:ListItem Text="--Seleccione una empresa" />
                        </asp:DropDownList>
                    </td>

                </tr>
                <tr>
                    <td>Esquema de pago: </td>
                    <td>                        
                        <asp:DropDownList runat="server" ID="ddlesquema" CssClass="form-control" AppendDataBoundItems="true">
                            <asp:ListItem Text="--Seleccione un esquema de pago" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Nombre de la nòmina:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNombreNomina" CssClass="form-control" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ID="rfvnombreNomina" Display="Dynamic" 
                            ControlToValidate="txtNombreNomina" ForeColor="Red" ErrorMessage="* Requerido" 
                            ValidationGroup="Validators" />
                    </td>
                </tr>
                <tr>
                    <td>Fecha de inicio:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFechaInicio" CssClass="icon-calendar" TextMode="Date" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ID="rfvFechaInicio" Display="Dynamic" 
                            ControlToValidate="txtFechaInicio" ForeColor="Red" ErrorMessage="* Requerido" 
                            ValidationGroup="Validators" />
                    </td>
                </tr>
                <tr>
                    <td>Fecha de fin:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFechaFin" CssClass="icon-calendar" TextMode="Date" 
                            Enabled="false"/>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ID="rfvFechaFin" Display="Dynamic" 
                            ControlToValidate="txtFechaFin" ForeColor="Red" ErrorMessage="* Requerido" 
                            ValidationGroup="Validators" />
                    </td>
                </tr>
            </table>
                <br />
                <br />
                <table class="large-table">
                    <tr>
                        <td class="text-right">
                            <asp:Button runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" Text="Guardar" CssClass="btn btn-primary"
                                OnClientClick="return Validate('¿Estás seguro que deseas guardar datos de la empresa?');" ValidationGroup="Validators" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button runat="server" ID="btnCancelar" OnClick="btnCancelar_Click" Text="Cancelar" CssClass="btn btn-danger" CausesValidation="False"
                                OnClientClick="return confirm('¿Estás seguro que deseas volver sin guardar los cambios?');" />
                        </td>
                    </tr>
                </table>
                <asp:Panel runat="server" ID="pnlFallos" CssClass="alert alert-danger" role="alert" Visible="false">
    	            <asp:Label runat="server" ID="lblErrorMsg" />
                </asp:Panel>
        </div>
        <!-- /widget-content --> 
    </div>
</asp:Content>
