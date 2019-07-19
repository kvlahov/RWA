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
<asp:GridView ID="GwMeals" runat="server"
    AutoGenerateColumns="false"
    DataKeyNames="MealId"
    CssClass="table table-striped"
    OnRowCancelingEdit="GwMeals_RowCancelingEdit"
    OnRowEditing="GwMeals_RowEditing"
    OnRowUpdating="GwMeals_RowUpdating">
    <HeaderStyle CssClass="thead-dark" />
    <Columns>
        <asp:BoundField DataField="MealId" Visible="false" />
        <asp:TemplateField HeaderText="Meal">
            <ItemTemplate><%# Eval("MealName") %></ItemTemplate>
            <EditItemTemplate>
                <%--<asp:HiddenField runat="server" ID="mealId" Value='<%#Eval("MealId")%>' />--%>
                <asp:TextBox runat="server" ID="tbMealName" CssClass="form-control" Text='<%# Eval("MealName") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbMealName" ErrorMessage="Meal name is required"></asp:RequiredFieldValidator>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="% Protein">
            <ItemTemplate><%# Eval("PercentProtein") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox runat="server" ID="tbProtein" CssClass="form-control" Text='<%# Eval("PercentProtein") %>'></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" ControlToValidate="tbProtein" runat="server" MinimumValue="0" MaximumValue="100" Type="Double" ErrorMessage="Must be in range 0 - 100"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbProtein" ErrorMessage="Required"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator1" runat="server" CssClass="text-danger" ErrorMessage="Percentage must add up to 100" ControlToValidate="tbProtein" ClientValidationFunction="validatePercents"></asp:CustomValidator>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="% Fat">
            <ItemTemplate><%# Eval("PercentFat") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox runat="server" ID="tbFat" CssClass="form-control" Text='<%# Eval("PercentFat") %>'></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator2" ControlToValidate="tbFat" runat="server" MinimumValue="0" MaximumValue="100" Type="Double" ErrorMessage="Must be in range 0 - 100"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbFat" ErrorMessage="Required"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator2" runat="server" CssClass="text-danger" ErrorMessage="Percentage must add up to 100" ControlToValidate="tbFat" ClientValidationFunction="validatePercents"></asp:CustomValidator>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="% Carbs">
            <ItemTemplate><%# Eval("PercentCarbs") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox runat="server" ID="tbCarbs" CssClass="form-control" Text='<%# Eval("PercentCarbs") %>'></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator3" ControlToValidate="tbCarbs" runat="server" MinimumValue="0" MaximumValue="100" Type="Double" ErrorMessage="Must be in range 0 - 100"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbCarbs" ErrorMessage="Required"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator3" runat="server" CssClass="text-danger" ErrorMessage="Percentage must add up to 100" ControlToValidate="tbCarbs" ClientValidationFunction="validatePercents"></asp:CustomValidator>

            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="% Calorie">
            <ItemTemplate>
                <asp:Label CssClass="cals" runat="server"><%# Eval("PercentCalorie") %></asp:Label>
            </ItemTemplate>
            <%--<EditItemTemplate>
                <asp:TextBox runat="server" ID="tbCalorie" CssClass="form-control" Text='<%# Eval("PercentCalorie") %>'></asp:TextBox>
                 <asp:RangeValidator ID="RangeValidator4" ControlToValidate="tbCalorie" runat="server" MinimumValue="0"  MaximumValue="100" Type="Double" ErrorMessage="Must be in range 0 - 100"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbCalorie" ErrorMessage="Required"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator4" runat="server" CssClass="text-danger" ErrorMessage="Percentage must add up to 100" ControlToValidate="tbCalorie" Display="Dynamic" ClientValidationFunction="validateCalories"></asp:CustomValidator>
            </EditItemTemplate>--%>
        </asp:TemplateField>
        <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
            ItemStyle-Width="150" />
    </Columns>
</asp:GridView>
<%--<asp:Button ID="BtnEditCalories" runat="server" Text="Button" OnClick="BtnEditCalories_Click" />
<div class="row">
    <div class="col-md-6">
        <asp:GridView ID="GW_EditCalories" runat="server" 
            AutoGenerateColumns="true" 
            CssClass="table" 
            OnRowCancelingEdit="GW_EditCalories_RowCancelingEdit" 
            OnRowEditing="GW_EditCalories_RowEditing" 
            OnRowUpdating="GW_EditCalories_RowUpdating" AutoGenerateEditButton="true">
        </asp:GridView>
    </div>
</div>--%>

<script>
    function validatePercents(source, args) {
        const protein = parseFloat($('[id*=Protein]').val());
        const fat = parseFloat($('[id*=Fat]').val());
        const carbs = parseFloat($('[id*=Carbs]').val());

        if (Math.round(protein + fat + carbs) === 100) {
            args.IsValid = true;
        }
        else {
            args.IsValid = false;
        }
    }

    function validateCalories(source, args) {
        const sum = $.map($('.cals'), (el, i) => $(el).text())
            .map(e => parseFloat(e))
            .reduce((acc, el) => acc + el, 0);

        if (args.Value + sum == 100) {
            args.IsValid = true;
        }
        else {
            args.IsValid = false;
        }
    }
</script>
