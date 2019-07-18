<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IngredientsControl.ascx.cs" Inherits="Hybrid.Admin.GridViewControls.IngredientsControl" %>

<style>
    /*gridview*/
    .table table tbody tr td a,
    .table table tbody tr td span {
        position: relative;
        float: left;
        padding: 6px 12px;
        margin-left: -1px;
        line-height: 1.42857143;
        color: #337ab7;
        text-decoration: none;
        background-color: #fff;
        border: 1px solid #ddd;
    }

    .table table > tbody > tr > td > span {
        z-index: 3;
        color: #fff;
        cursor: default;
        background-color: #337ab7;
        border-color: #337ab7;
    }

    .table table > tbody > tr > td:first-child > a,
    .table table > tbody > tr > td:first-child > span {
        margin-left: 0;
        border-top-left-radius: 4px;
        border-bottom-left-radius: 4px;
    }

    .table table > tbody > tr > td:last-child > a,
    .table table > tbody > tr > td:last-child > span {
        border-top-right-radius: 4px;
        border-bottom-right-radius: 4px;
    }

    .table table > tbody > tr > td > a:hover,
    .table table > tbody > tr > td > span:hover,
    .table table > tbody > tr > td > a:focus,
    .table table > tbody > tr > td > span:focus {
        z-index: 2;
        color: #23527c;
        background-color: #eee;
        border-color: #ddd;
    }
    /*end gridview */
</style>

<div class="form-horizontal">
    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <label class="col-sm-3 control-label">Search</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TbSearch" AutoPostBack="true" 
                        runat="server" CssClass="form-control" 
                        OnTextChanged="TbSearch_TextChanged"
                        onFocus="this.select()"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
</div>
<asp:GridView ID="GwIngredients" runat="server" AutoGenerateColumns="false" 
    AllowSorting="true" CssClass="table table-striped" AllowPaging="true"
    PageSize="20" OnPageIndexChanging="GwIngredients_PageIndexChanging"
    OnRowCancelingEdit="GwIngredients_RowCancelingEdit" 
    OnRowEditing="GwIngredients_RowEditing" OnSorting="GwIngredients_Sorting" DataKeyNames="Id" OnRowDataBound="GwIngredients_RowDataBound" OnRowUpdating="GwIngredients_RowUpdating">
    <HeaderStyle CssClass="thead-dark" />
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="true" SortExpression="Id"/>

        <asp:TemplateField HeaderText="Ingredient" SortExpression="Ingredient">
            <ItemTemplate><%# Eval("Name") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="tbIngName" runat="server" CssClass="form-control" Text='<%#Eval("Name") %>'></asp:TextBox>  
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Type" SortExpression="Type" >
            <ItemTemplate><%# Eval("Type") %></ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="DdlIngredientType" runat="server" CssClass="form-control"></asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
            ItemStyle-Width="150">
<ItemStyle Width="150px"></ItemStyle>
        </asp:CommandField>
    </Columns>
    <PagerSettings Position="Top" />
</asp:GridView>
