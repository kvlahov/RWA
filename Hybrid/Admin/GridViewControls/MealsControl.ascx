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
<asp:GridView ID="GwMeals" runat="server" AutoGenerateColumns="false" DataKeyNames="MealId" CssClass="table table-striped" OnRowCancelingEdit="GwMeals_RowCancelingEdit" OnRowEditing="GwMeals_RowEditing" OnRowUpdating="GwMeals_RowUpdating">
    <HeaderStyle CssClass="thead-dark" />
    <Columns>
        <asp:BoundField DataField="MealId" Visible="false" />
        <asp:TemplateField  HeaderText="Meal" >
            <ItemTemplate><%# Eval("MealName") %></ItemTemplate>
            <EditItemTemplate>
                <%--<asp:HiddenField runat="server" ID="mealId" Value='<%#Eval("MealId")%>' />--%>
                <asp:TextBox runat="server" ID="tbMealName" CssClass="form-control" Text='<%# Eval("MealName") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="% Protein" >
            <ItemTemplate><%# Eval("PercentProtein") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox runat="server" ID="tbProtein" CssClass="form-control" Text='<%# Eval("PercentProtein") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="% Fat" >
            <ItemTemplate><%# Eval("PercentFat") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox runat="server" ID="tbFat" CssClass="form-control" Text='<%# Eval("PercentFat") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="% Carbs" >
            <ItemTemplate><%# Eval("PercentCarbs") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox runat="server" ID="tbCarbs" CssClass="form-control" Text='<%# Eval("PercentCarbs") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="% Calorie" >
            <ItemTemplate><%# Eval("PercentCalorie") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox runat="server" ID="tbCalorie" CssClass="form-control" Text='<%# Eval("PercentCalorie") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                    ItemStyle-Width="150" />
    </Columns>
</asp:GridView>