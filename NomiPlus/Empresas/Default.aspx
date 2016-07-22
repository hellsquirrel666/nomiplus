<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NomiPlus.Empresas.Default" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="Server">
    <title>Sucursales</title>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron jumbotron-small">
        <h2>
            <asp:Label runat="server" ID="lblAccion" /> Ver empresas
        </h2>
    </div>

    <div class="widget">
    <div class="widget-header"> 
        <i class="icon-list"></i>
              <h3>Datos</h3>
            </div>
            <div class="widget-content">
                <asp:GridView runat="server" ID="gvPacientes" CssClass="table table-condensed table-bordered table-hover" ItemType="NomiPlus.Modelo.Empresa" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:BoundField HeaderText="Empresa" DataField="sRazonSocial" />
                        <asp:BoundField HeaderText="RFC" DataField="sRFC" />
                        <asp:BoundField HeaderText="Representante" DataField="sRepresentanteLegal" />
                        <asp:BoundField HeaderText="E-mail" DataField="sEmailContacto" />
                        <asp:BoundField HeaderText="Telefono" DataField="sTelefono" />
                        <asp:TemplateField ItemStyle-CssClass="gridview_menu">
                            <ItemTemplate>
                                <div class="dropdown" style="cursor: pointer;">
                                    <a class="dropdown-toggle list-inline" id="ddmOpciones" data-toggle="dropdown">Opciones<span class="caret"></span></a>
                                    <ul class="dropdown-menu" role="menu" aria-labelledby="ddmOpciones">
                                        <li role="presentation">
                                            <asp:LinkButton ID="lbtnEditar" runat="server" Text="Editar" 
                                                PostBackUrl='<%# string.Format("~/Empresas/Detalle?Empresa={0}", Item.nIdEmpresa) %>'/>
                                        </li>
                                        <li role="presentation">
                                            <asp:LinkButton ID="lbtnSucursales" runat="server" Text="Ver sucursales" 
                                                PostBackUrl='<%# string.Format("~/Empresas/Sucursales/?Empresa={0}", Item.nIdEmpresa) %>'/>
                                        </li>
                                        <li role="presentation">
                                            <asp:LinkButton ID="lbtnEmpleados" runat="server" Text="Ver empleados" 
                                                PostBackUrl='<%# string.Format("~/Empresas/Empleados/?Empresa={0}", Item.nIdEmpresa) %>'/>
                                        </li>
                                        <li role="presentation">
                                            <asp:LinkButton ID="lbtnNominas" runat="server" Text="Ver Nominas" 
                                                PostBackUrl='<%# string.Format("~/Nominas?Empresa={0}", Item.nIdEmpresa) %>'/>
                                        </li>
                                    </ul>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </br>
                <br />
                    <table style="width:100%;">
                    <tr>
                        <td style="text-align:right;">
                            <asp:Button runat="server" ID="btnNuevaEmpresa" OnClick="btnNuevaEmpresa_Click" 
                                CssClass="btn btn-primary" Text="Nueva Empresa" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button runat="server" ID="btnCancelar" OnClick="btnCancelar_Click"
                                CssClass="btn btn-danger" Text="Regresar" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
                <br /> 
            <!-- /widget-content -->
            </div> 
          </div>
          <!-- /widget -->    
</asp:Content>
