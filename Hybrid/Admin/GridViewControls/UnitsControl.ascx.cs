using Hybrid.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hybrid.Admin.GridViewControls
{
    public partial class UnitsControl : System.Web.UI.UserControl
    {
        private readonly static IRepository repo = RepoFactory.GetRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DdlIngredients.DataSource = repo.GetAllIngredients();
                DdlIngredients.DataTextField = "Name";
                DdlIngredients.DataValueField = "Id";
                DdlIngredients.DataBind();

            }
            DdlIngredients.DataSource = repo.GetAllIngredients();
            DdlIngredients.DataTextField = "Name";
            DdlIngredients.DataValueField = "Id";
            DdlIngredients.DataBind();

            BindUnits();
        }

        protected void DdlIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindUnits();
        }

        protected void GwUnits_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GwUnits.EditIndex = e.NewEditIndex;
            BindUnits();
        }

        protected void GwUnits_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GwUnits.EditIndex = -1;;
            BindUnits();

        }

        private void BindUnits()
        {
            GwUnits.DataSource = repo.GetUnitsOfMesurement(Convert.ToInt32(DdlIngredients.SelectedValue));
            GwUnits.DataBind();
            GwUnits.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void GwUnits_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddList = (DropDownList)e.Row.FindControl("DdlUnitType");
                    //bind dropdown-list
                    ddList.DataSource = repo.GetUnitTypes();
                    ddList.DataTextField = "Type";
                    ddList.DataValueField = "Id";
                    ddList.DataBind();

                    var selection = DataBinder.Eval(e.Row.DataItem, "Unit.Type").ToString();
                    ddList.Items.FindByText(selection).Selected = true;

                }
            }
        }
    }
}