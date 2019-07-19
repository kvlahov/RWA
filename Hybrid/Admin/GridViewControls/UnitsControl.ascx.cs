using Hybrid.Models;
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

            //ddlNewUnit.DataSource = repo.GetUnitTypes();
            //ddlNewUnit.DataTextField = "Type";
            //ddlNewUnit.DataValueField = "Id";
            //ddlNewUnit.DataBind();

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

        protected void GwUnits_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GwUnits.DataKeys[e.RowIndex].Value.ToString());
            string kcal = ((TextBox)GwUnits.Rows[e.RowIndex].FindControl("tbKcal")).Text.Trim();
            string value = ((TextBox)GwUnits.Rows[e.RowIndex].FindControl("tbValue")).Text.Trim();

            var ddl = (DropDownList)GwUnits.Rows[e.RowIndex].FindControl("DdlUnitType");
            int unitId = Convert.ToInt32(ddl.SelectedValue);

            repo.UpdateUnits(new Models.UnitEnergy
            {
                Id = id,
                Kcal = Convert.ToDouble(kcal),
                Value = Convert.ToDouble(value),
                Unit = new Models.UnitOfMesurement
                {
                    Id = unitId
                }
            });

            GwUnits.EditIndex = -1;
            BindUnits();
        }

        protected void GwUnits_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GwUnits.DataKeys[e.RowIndex].Value.ToString());
            repo.DeleteUnitEnergy(id);
            BindUnits();
        }

        protected void GwUnits_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                repo.DeleteUnitEnergy(id);
            }
        }

        //protected void btnCreate_Click(object sender, EventArgs e)
        //{
        //    int ingId = Convert.ToInt32(DdlIngredients.SelectedValue);
        //    var unit = new UnitEnergy
        //    {
        //        Kcal = Convert.ToDouble(tbNewKcal.Text),
        //        Value = Convert.ToDouble(tbNewValue.Text),
        //        Unit = new UnitOfMesurement
        //        {
        //            Id = Convert.ToInt32(ddlNewUnit.SelectedValue),
        //            Type = ddlNewUnit.SelectedItem.Text
        //        }
        //    };
        //    repo.InsertUnitEnergy(unit, ingId);
        //    BindUnits();
        //}
    }
}