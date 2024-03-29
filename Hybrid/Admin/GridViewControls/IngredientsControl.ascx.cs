﻿using Hybrid.Models.DAL;
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
    public partial class IngredientsControl : System.Web.UI.UserControl
    {
        private readonly static IRepository repo = RepoFactory.GetRepository();
        //private void Page_Init(object sender, EventArgs e)
        //{
        //    if (ViewState["firstTime"] == null)
        //    {
        //        BindIngredinets();
        //        TbSearch.Text = string.Empty;
        //        ViewState["firstTime"] = false;
        //    }

        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["firstTime"] == null)
            {
                TbSearch.Text = string.Empty;
                BindIngredinets();
                ViewState["firstTime"] = false;
            }
        }

        protected void TbSearch_TextChanged(object sender, EventArgs e)
        {
            BindIngredinets();
        }

        protected void GwIngredients_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GwIngredients.EditIndex = e.NewEditIndex;
            BindIngredinets();
        }

        protected void GwIngredients_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GwIngredients.EditIndex = -1;
            BindIngredinets();
        }

        protected void GwIngredients_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GwIngredients.PageIndex = e.NewPageIndex;
            BindIngredinets();
        }

        private void BindIngredinets()
        {
            var source = repo.GetAllIngredients();
            var searchValue = TbSearch.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(searchValue))
            {
                source = source.Where(ing => ing.Name.ToLower().StartsWith(searchValue)).ToList();
            }
            GwIngredients.DataSource = source;
            GwIngredients.DataBind();

        }

        protected void GwIngredients_Sorting(object sender, GridViewSortEventArgs e)
        {
            //DataTable dtSortTable = GwIngredients.DataSource as DataTable;

            //if (dtSortTable != null)
            //{
            //    DataView dvSortedView = new DataView(dtSortTable);

            //    dvSortedView.Sort = e.SortExpression + GetSortDirectionString(e.SortDirection);
            //    GwIngredients.DataSource = dvSortedView;
            //    GwIngredients.DataBind();
            //}
        }

        private string GetSortDirectionString(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;
            if (sortDirection == SortDirection.Ascending)
            {
                newSortDirection = "ASC";
            }
            else
            {
                newSortDirection = "DESC";
            }
            return newSortDirection;
        }

        protected void GwIngredients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddList = (DropDownList)e.Row.FindControl("DdlIngredientType");
                    //bind dropdown-list
                    ddList.DataSource = repo.GetAllIngredientTypes();
                    ddList.DataTextField = "Key";
                    ddList.DataValueField = "Value";
                    ddList.DataBind();

                    var selection = DataBinder.Eval(e.Row.DataItem, "Type").ToString();
                    ddList.Items.FindByText(selection).Selected = true;

                    GwIngredients.EditIndex = -1;
                }
            }
        }

        protected void GwIngredients_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GwIngredients.DataKeys[e.RowIndex].Value.ToString());
            string name = ((TextBox)GwIngredients.Rows[e.RowIndex].FindControl("tbIngName")).Text.Trim();

            var ddl = (DropDownList)GwIngredients.Rows[e.RowIndex].FindControl("DdlIngredientType");
            int typeId = Convert.ToInt32(ddl.SelectedValue);

            repo.UpdateIngredient(new Models.Ingredient
            {
                Id = id,
                Name = name,
                TypeId = typeId
            });

            GwIngredients.EditIndex = -1;
            BindIngredinets();
        }
    }
}