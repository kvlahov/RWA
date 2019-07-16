<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="ManageData.aspx.cs" Inherits="Hybrid.Admin.ManageData" %>

<%@ Register TagPrefix="units" TagName="UnitsControl" Src="GridViewControls/UnitsControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Data</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label class="col-sm-3 control-label">Data type</label>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="DdlData" AutoPostBack="True" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlData_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="Ingredients"> Ingredients </asp:ListItem>
                            <asp:ListItem Value="Units"> Units of Mesurement </asp:ListItem>
                            <asp:ListItem Value="Meals">Meals</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:GridView ID="DataGridView" runat="server" AllowSorting="true" AllowPaging="true" OnRowEditing="DataGridView_RowEditing" OnRowCancelingEdit="DataGridView_RowCancelingEdit" CssClass="table table-condensed">
        <%-- <Columns>
          <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="true"/>
          <asp:BoundField DataField="Name" HeaderText="Ime"/>
          <asp:BoundField DataField="TypeId" HeaderText="Tip"/>
        </Columns>--%>
    </asp:GridView>

    <units:UnitsControl runat="server" ID="MyControl"></units:UnitsControl>
</asp:Content>
