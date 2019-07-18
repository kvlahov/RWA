<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UnitsControl.ascx.cs" Inherits="Hybrid.Admin.GridViewControls.UnitsControl" %>

<div class="form-horizontal">
    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <label class="col-sm-3 control-label">For Ingredient</label>
                <div class="col-sm-9">
                    <asp:DropDownList ID="DdlIngredients" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DdlIngredients_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </div>
</div>
<asp:GridView ID="GwUnits" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" CssClass="table table-striped" OnRowCancelingEdit="GwUnits_RowCancelingEdit" OnRowEditing="GwUnits_RowEditing" OnRowDataBound="GwUnits_RowDataBound" OnRowUpdating="GwUnits_RowUpdating">
    <HeaderStyle CssClass="thead-dark" />
    <Columns>
        <asp:BoundField Visible="false" DataField="Id" />

        <asp:TemplateField HeaderText="Calories">
            <ItemTemplate><%# Eval("Kcal") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="tbKcal" runat="server" CssClass="form-control" Text='<%#Eval("Kcal") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="tbKcal" ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="Required"></asp:RequiredFieldValidator>
                <asp:RangeValidator ControlToValidate="tbKcal" runat="server" CssClass="text-danger" ErrorMessage="Must be greater than 0" Display="Dynamic" MinimumValue="0" Type="Double"></asp:RangeValidator>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Value">
            <ItemTemplate><%# Eval("Value") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="tbValue" runat="server" CssClass="form-control" Text='<%#Eval("Value") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="tbValue" ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                <asp:RangeValidator ControlToValidate="tbValue" runat="server" CssClass="text-danger" ErrorMessage="Must be greater than 0" Display="Dynamic" MinimumValue="0" Type="Double"></asp:RangeValidator>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Unit" SortExpression="Unit">
            <ItemTemplate>
                <%# Eval("Unit.Type")%>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="DdlUnitType" runat="server" CssClass="form-control"></asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
            ItemStyle-Width="150" />
    </Columns>
</asp:GridView>


