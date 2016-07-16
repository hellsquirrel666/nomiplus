<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NomiPlus.Empresas.Default" %>
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
