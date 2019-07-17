<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MealsControl.ascx.cs" Inherits="Hybrid.Admin.GridViewControls.MealsControl" %>

<div class="form-horizontal">
    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <label class="col-sm-3 control-label">For Ingredient</label>
                <div class="col-sm-9">
                    <asp:DropDownList ID="DdlNoOfMeals" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DdlNoOfMeals_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </div>
</div>
<asp:GridView ID="GwMeals" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" OnRowCancelingEdit="GwMeals_RowCancelingEdit" OnRowEditing="GwMeals_RowEditing">
    <HeaderStyle CssClass="thead-dark" />
    <Columns>
        <asp:BoundField DataField="MealName" HeaderText="Calories" />
        <asp:BoundField DataField="PercentProtein" HeaderText="% Protein" />
        <asp:BoundField DataField="PercentFat" HeaderText="% Fat" />
        <asp:BoundField DataField="PercentCarbs" HeaderText="% Carbs" />
        <asp:BoundField DataField="PercentCalorie" HeaderText="% Calorie" />

        <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                    ItemStyle-Width="150" />
    </Columns>
</asp:GridView>