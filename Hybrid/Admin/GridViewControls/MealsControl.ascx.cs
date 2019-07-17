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
    public partial class MealsControl : System.Web.UI.UserControl
    {
        private readonly static IRepository repo = RepoFactory.GetRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["firstTime"] == null)
            {
                DdlNoOfMeals.DataSource = repo.GetNumberOfMeals();
                DdlNoOfMeals.DataBind();
                BindMeals();
                ViewState["firstTime"] = false;
                BindCalories();
            }
        }

        private void BindCalories()
        {
            var noOfMeals = Convert.ToInt32(DdlNoOfMeals.SelectedValue);
            var npm = repo.GetNutrientsPerMeal(noOfMeals);

            DataTable dt = new DataTable();
            foreach (var meal in npm)
            {
                dt.Columns.Add(meal.MealName, typeof(string));
            }

            DataRow dr = dt.NewRow();

            foreach (var meal in npm)
            {
                dr[meal.MealName] = meal.PercentCalorie;
            }
            dt.Rows.Add(dr);

            DataRow drId = dt.NewRow();

            foreach (var meal in npm)
            {
                drId[meal.MealName] = meal.MealId;
            }
            dt.Rows.Add(drId);
            GW_EditCalories.DataSource = dt;

            GW_EditCalories.DataBind();

        }

        protected void DdlNoOfMeals_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMeals();
            BindCalories();
        }

        private void BindMeals()
        {
            var noOfMeals = Convert.ToInt32(DdlNoOfMeals.SelectedValue);
            GwMeals.DataSource = repo.GetNutrientsPerMeal(noOfMeals);
            GwMeals.DataBind();
            //GwMeals.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void GwMeals_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GwMeals.EditIndex = e.NewEditIndex;
            Page.Validate();
            BindMeals();
        }

        protected void GwMeals_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GwMeals.EditIndex = -1;
            BindMeals();
        }

        protected void GwMeals_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //int mealId = Convert.ToInt32(((HiddenField)GwMeals.Rows[e.RowIndex].FindControl("mealId")).Value);
            int mealId = Convert.ToInt32(GwMeals.DataKeys[e.RowIndex].Value.ToString());

            string mealName = ((TextBox)GwMeals.Rows[e.RowIndex].FindControl("tbMealName")).Text.Trim();
            string protein = ((TextBox)GwMeals.Rows[e.RowIndex].FindControl("tbProtein")).Text.Trim();
            string fat = ((TextBox)GwMeals.Rows[e.RowIndex].FindControl("tbFat")).Text.Trim();
            string carbs = ((TextBox)GwMeals.Rows[e.RowIndex].FindControl("tbCarbs")).Text.Trim();
            string calories = ((TextBox)GwMeals.Rows[e.RowIndex].FindControl("tbCalorie")).Text.Trim();

            repo.UpdateNutrients(new Models.NutrientsPerMeal
            {
                MealId = mealId,
                MealName = mealName,
                PercentCarbs = Convert.ToDouble(carbs),
                PercentFat = Convert.ToDouble(fat),
                PercentProtein = Convert.ToDouble(protein),
                PercentCalorie = Convert.ToDouble(calories)
            });

            GwMeals.EditIndex = -1;
            BindMeals();
        }

        protected void BtnEditCalories_Click(object sender, EventArgs e)
        {
        }

        protected void GW_EditCalories_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
        }

        protected void GW_EditCalories_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GW_EditCalories.EditIndex = -1;
            BindCalories();
        }

        protected void GW_EditCalories_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GW_EditCalories.EditIndex = e.NewEditIndex;
            BindCalories();

        }
    }
}
