<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NomiPlus.Empresas.Empleados.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="jumbotron jumbotron-small">
        <h2>
            <asp:Label runat="server" ID="lblAccion" /> Ver empleados
        </h2>
    </div>

    <div class="widget">
    <div class="widget-header"> 
        <i class="icon-list"></i>
            <h3><asp:Label runat="server" ID="lblNombre" /></h3>
        </div>
        <div class="widget-content">
            <asp:HiddenField runat="server" ID="hfIdEmpresa" Visible="false" />
            <asp:GridView runat="server" ID="gvEmpleados" CssClass="table table-condensed table-bordered table-hover" 
                ItemType="NomiPlus.Modelo.Empleado" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:TemplateField HeaderText="Nombre completo">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Item.sPrimerApellido + " " +
                            (string.IsNullOrEmpty(Item.sSegundoApellido)? "": Item.sSegundoApellido) + " " +
                            Item.sNombre %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="RFC" DataField="sRFC" />
                    <asp:BoundField HeaderText="CURP" DataField="sCURP" />
                    <asp:BoundField HeaderText="NSS" DataField="nNSS" />
                    <asp:TemplateField ItemStyle-CssClass="gridview_menu">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSucursal" Text='<%# ObtenerSucursal(Item.nIdSucursal) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="gridview_menu">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDepartamento" Text='<%# ObtenerDepartamento(Item.nIdDepartamento)%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="gridview_menu">
                        <ItemTemplate>
                            <div class="dropdown" style="cursor: pointer;">
                                <a class="dropdown-toggle list-inline" id="ddmOpciones" data-toggle="dropdown">Opciones<span class="caret"></span></a>
                                <ul class="dropdown-menu" role="menu" aria-labelledby="ddmOpciones">
                                    <li role="presentation">
                                        <asp:LinkButton ID="lbtnEditar" runat="server" Text="Editar" 
                                            PostBackUrl='<%# string.Format("~/Empresas/Empleados/Detalle?Empleado={0}",Item.nIdEmpleado) %>'/>
                                    </li>
                                </ul>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </br>
            <table style="width:100%;">
            <tr>
                <td style="text-align:right;">
                    <asp:Button runat="server" ID="btnNuevoEmpreado" OnClick="btnNuevoEmpreado_Click"
                        CssClass="btn btn-primary" Text="Nuevo empleado" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnCancelar" OnClick="btnCancelar_Click"
                        CssClass="btn btn-danger" Text="Regresar" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
        </table>
        </div>
        <!-- /widget-content --> 
        </div>
        <!-- /widget -->    

</asp:Content>
