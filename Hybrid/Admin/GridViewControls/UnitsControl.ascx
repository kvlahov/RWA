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
<asp:GridView ID="GwUnits" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" OnRowCancelingEdit="GwUnits_RowCancelingEdit" OnRowEditing="GwUnits_RowEditing" OnRowDataBound="GwUnits_RowDataBound">
    <HeaderStyle CssClass="thead-dark" />
    <Columns>
        <asp:BoundField DataField="Kcal" HeaderText="Calories" />
        <asp:BoundField DataField="Value" HeaderText="Value" />

        <asp:TemplateField HeaderText="Unit" SortExpression="Unit">
            <ItemTemplate>
                <%# Eval("Unit.Type")%>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="DdlUnitType" runat="server" CssClass="form-control"></asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>
        <%--<asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit"/>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update" CssClass="btn btn-default"/>
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="btn btn-default"/>
            </EditItemTemplate>
        </asp:TemplateField>--%>
        <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                    ItemStyle-Width="150" />
    </Columns>
</asp:GridView>


