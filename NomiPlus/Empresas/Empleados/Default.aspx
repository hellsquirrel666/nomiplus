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
            <asp:GridView runat="server" ID="gvEmpleados" CssClass="table table-condensed table-bordered table-hover" ItemType="NomiPlus.Modelo.Sucursal" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:BoundField HeaderText="Departamento" DataField="sDepartamento" />
                    <asp:BoundField HeaderText="Encargado" DataField="sNombreEncargado" />
                    <asp:BoundField HeaderText="Telefono" DataField="sTelefono" />
                    <asp:BoundField HeaderText="E-mail" DataField="sEmailContacto" />
                    <asp:BoundField HeaderText="Fax" DataField="sFax" />
                    <asp:TemplateField ItemStyle-CssClass="gridview_menu">
                        <ItemTemplate>
                            <div class="dropdown" style="cursor: pointer;">
                                <a class="dropdown-toggle list-inline" id="ddmOpciones" data-toggle="dropdown">Opciones<span class="caret"></span></a>
                                <ul class="dropdown-menu" role="menu" aria-labelledby="ddmOpciones">
                                    <li role="presentation">
                                        <asp:LinkButton ID="lbtnEditar" runat="server" Text="Editar" 
                                            PostBackUrl='<%# string.Format("~/Empresas/Empleados/Detalle?Empresa={0}&Departamento{1}",Item.nIdEmpresa , Item.nIdSucursal) %>'/>
                                    </li>
                                </ul>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <!-- /widget-content --> 
        </div>
        <!-- /widget -->    

</asp:Content>
