<%@ Page Title="Home Page" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdminSite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="row">
            <div class="col-sm-6 admin-menu-item">
                <asp:HyperLink ID="mngData" NavigateUrl="./ManageData.aspx" runat="server">
                        <span class="glyphicon glyphicon-edit"></span>
                </asp:HyperLink>
                <div class="row">
                    <label>Manage Data</label>
                </div>

            </div>
            <div class="col-sm-6 admin-menu-item">
                <asp:HyperLink ID="mngUsers" NavigateUrl="./ManageUsers.aspx" runat="server">
                    <span class="glyphicon glyphicon-user"></span>
                </asp:HyperLink>
                <div class="row">
                    <label>Manage Users</label>
                </div>
            </div>
        </div>
    </div>
    <asp:PlaceHolder ID="output" runat="server"></asp:PlaceHolder>

</asp:Content>
