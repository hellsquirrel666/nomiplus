﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NomiPlus.Empresas.Sucursales.Departamentos.Default" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="Server">
    <title>Departamentos</title>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="jumbotron jumbotron-small">
        <h2>
            <asp:Label runat="server" ID="lblAccion" /> Ver departamentos
        </h2>
    </div>

    <div class="widget">
    <div class="widget-header"> 
        <i class="icon-list"></i>
            <h3><asp:Label runat="server" ID="lblNombre" /></h3>
        </div>
        <div class="widget-content">
            <asp:HiddenField runat="server" ID="hfIdSucursal" Visible="false" />
            <asp:HiddenField runat="server" ID="hfIdEmpresa" Visible="false" />
            <asp:GridView runat="server" ID="gvDepartamentos" CssClass="table table-condensed table-bordered table-hover" ItemType="NomiPlus.Modelo.Departamento" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:BoundField HeaderText="Departamento" DataField="sDepartamento" />
                    <asp:BoundField HeaderText="Encargado" DataField="sNombreEncargado" />
                    <asp:BoundField HeaderText="Telefono" DataField="sTelefono" />
                    <asp:BoundField HeaderText="E-mail" DataField="sEmail" />
                    <asp:BoundField HeaderText="Fax" DataField="sFax" />
                    <asp:TemplateField ItemStyle-CssClass="gridview_menu">
                        <ItemTemplate>
                            <div class="dropdown" style="cursor: pointer;">
                                <a class="dropdown-toggle list-inline" id="ddmOpciones" data-toggle="dropdown">Opciones<span class="caret"></span></a>
                                <ul class="dropdown-menu" role="menu" aria-labelledby="ddmOpciones">
                                    <li role="presentation">
                                        <asp:LinkButton ID="lbtnEditar" runat="server" Text="Editar" 
                                            PostBackUrl='<%# string.Format("~/Empresas/Sucursales/Departamentos/Detalle?Sucursal={0}&Departamento={1}",Item.nIdSucursal , Item.nIdDepartamento) %>'/>
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
                        <asp:Button runat="server" ID="btnNuevoDepartamento" OnClick="btnNuevaEmpresa_Click" 
                            CssClass="btn btn-primary" Text="Nuevo departamento" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" ID="btnCancelar" OnClick="btnCancelar_Click"
                            CssClass="btn btn-danger" Text="Regresar" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <!-- /widget-content --> 
        </div>
        <!-- /widget -->    

</asp:Content>
