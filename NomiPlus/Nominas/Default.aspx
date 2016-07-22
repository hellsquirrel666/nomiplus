<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NomiPlus.Nominas.Default" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="Server">
    <title>Nóminas</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron jumbotron-small">
        <h2>
            <asp:Label runat="server" ID="lblAccion" /> Menú nóminas
        </h2>
    </div>
    <div class="widget">
        <div class="widget-header">
            <i class="icon-bar-chart"></i>
            <h3>Menú</h3>
        </div>
        <!-- /widget-header -->
        <div class="widget-content">
            <div class="shortcuts"> 
                <a href="javascript:;" class="shortcut">
                    <i class="shortcut-icon icon-list-alt"></i>
                    <span class="shortcut-label">Apps</span> 
                </a>
                <a href="javascript:;" class="shortcut">
                    <i class="shortcut-icon icon-bookmark"></i>
                    <span class="shortcut-label">Bookmarks</span> 
                </a>
                <a href="javascript:;" class="shortcut">
                    <i class="shortcut-icon icon-signal"></i> 
                    <span class="shortcut-label">Reports</span> 
                </a>
                <a href="javascript:;" class="shortcut"> 
                    <i class="shortcut-icon icon-comment"></i>
                    <span class="shortcut-label">Comments</span> 
                </a>
                <a href="javascript:;" class="shortcut">
                    <i class="shortcut-icon icon-user"></i>
                    <span class="shortcut-label">Users</span> 
                </a>
                <a href="javascript:;" class="shortcut">
                    <i class="shortcut-icon icon-file"></i>
                    <span class="shortcut-label">Notes</span> 
                </a>
                <a href="javascript:;" class="shortcut">
                    <i class="shortcut-icon icon-picture"></i> 
                    <span class="shortcut-label">Photos</span> 
                </a>
                <a href="javascript:;" class="shortcut"> 
                    <i class="shortcut-icon icon-tag"></i>
                    <span class="shortcut-label">Tags</span> 
                </a> 
            </div>

            <!-- /shortcuts --> 
        </div>
        <!-- /widget-content --> 
        </div>


</asp:Content>
