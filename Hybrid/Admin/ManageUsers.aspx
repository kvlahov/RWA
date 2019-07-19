<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="Hybrid.Admin.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Users</title>
    <style>
        .list {
            width: 100%;
            min-height: 300px;
            padding: 10px 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-5">
            <asp:ListBox ID="UsersList" CssClass="list" AutoPostBack="true" OnSelectedIndexChanged="UsersList_SelectedIndexChanged" runat="server"></asp:ListBox>
        </div>
        <div class="col-md-7">
             <div>
                <dl class="dl-horizontal">
                    <dt>Name
                    </dt>

                    <dd>
                        <asp:PlaceHolder ID="phName" runat="server"></asp:PlaceHolder>
                    </dd>

                    <dt>Surname
                    </dt>

                    <dd>
                        <asp:PlaceHolder ID="phSurname" runat="server"></asp:PlaceHolder>
                    </dd>

                    <dt>Height
                    </dt>

                    <dd>
                        <asp:PlaceHolder ID="phHeight" runat="server"></asp:PlaceHolder>
                    </dd>

                    <dt>Weight
                    </dt>

                    <dd>
                        <asp:PlaceHolder ID="phWeight" runat="server"></asp:PlaceHolder>
                    </dd>

                    <dt>Sex
                    </dt>

                    <dd>
                        <asp:PlaceHolder ID="phSex" runat="server"></asp:PlaceHolder>
                    </dd>

                    <dt>Date Of Birth
                    </dt>

                    <dd>
                        <asp:PlaceHolder ID="phDateOfBirth" runat="server"></asp:PlaceHolder>
                    </dd>

                    <dt>Level Of Activity
                    </dt>

                    <dd>
                        <asp:PlaceHolder ID="phLvlActivity" runat="server"></asp:PlaceHolder>
                    </dd>

                    <dt>Diabetes Type
                    </dt>

                    <dd>
                        <asp:PlaceHolder ID="phDiabetesType" runat="server"></asp:PlaceHolder>
                    </dd>

                </dl>
            </div>
        </div>
    </div>

</asp:Content>
