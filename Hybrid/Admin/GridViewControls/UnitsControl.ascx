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
<button class="btn btn-primary" id="btnAdd">Add Unit</button>
<div class="row">
    <div class="col-md-8">
        <table class="table table-condensed" id="addNewUnitEnergy" style="display: none; vertical-align: middle !important;">
            <tbody>
                <tr>
                    <td>
                        <asp:TextBox ID="tbNewKcal" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbNewValue" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                        
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlNewUnit" runat="server" CssClass="form-control"></asp:DropDownList>

                    </td>
                    <td>
                        <asp:Button ID="btnCreate" Text="Create" CausesValidation="true" OnClick="btnCreate_Click" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbNewKcal" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="tbNewKcal" MinimumValue="0" Type="Double" ErrorMessage="Must be number greater than 0"></asp:RangeValidator></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tbNewValue" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="tbNewValue" MinimumValue="0" Type="Double" ErrorMessage="Must be number greater than 0"></asp:RangeValidator>
                    </td>
                </tr>
            </tbody>
        </table>

    </div>
</div>
<asp:GridView ID="GwUnits" runat="server"
    AutoGenerateColumns="false"
    DataKeyNames="Id"
    CssClass="table table-striped"
    OnRowCancelingEdit="GwUnits_RowCancelingEdit"
    OnRowEditing="GwUnits_RowEditing"
    OnRowDataBound="GwUnits_RowDataBound"
    OnRowUpdating="GwUnits_RowUpdating"
    OnRowDeleting="GwUnits_RowDeleting">
    <HeaderStyle CssClass="thead-dark" />
    <Columns>
        <asp:BoundField Visible="false" DataField="Id" />

        <asp:TemplateField HeaderText="Calories">
            <ItemTemplate><%# Eval("Kcal") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="tbKcal" runat="server" CssClass="form-control" Text='<%#Eval("Kcal") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="tbNewValue" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="tbNewValue" MinimumValue="0" Type="Double" ErrorMessage="Must be number greater than 0"></asp:RangeValidator>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Value">
            <ItemTemplate><%# Eval("Value") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="tbValue" runat="server" CssClass="form-control" Text='<%#Eval("Value") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="tbNewValue" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="tbNewValue" MinimumValue="0" Type="Double" ErrorMessage="Must be number greater than 0"></asp:RangeValidator>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Unit" SortExpression="Unit">
            <ItemTemplate>
                <asp:HiddenField ID="unitID" Value='<%# Eval("Unit.Id")%>' runat="server" />
                <%# Eval("Unit.Type")%>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="DdlUnitType" runat="server" CssClass="form-control"></asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:CommandField ButtonType="Link" ShowEditButton="true"
            ItemStyle-Width="150" />

        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:LinkButton ID="DeleteButton" runat="server"
                    CommandName="Delete" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Are you sure you want to delete this event?');"
                    Text="Delete" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


<script>
    $('#btnAdd').click(function (e) {
        e.preventDefault();
        $('#addNewUnitEnergy').toggle();
    });
</script>
