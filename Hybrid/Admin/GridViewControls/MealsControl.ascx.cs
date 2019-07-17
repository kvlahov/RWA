using Hybrid.Models.DAL;
using System;
using System.Collections.Generic;
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
            DdlNoOfMeals.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                DdlNoOfMeals.Items.Add(new ListItem(i.ToString()));
            }
            BindMeals();
        }

        protected void DdlNoOfMeals_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMeals();
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
            BindMeals();
        }

        protected void GwMeals_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GwMeals.EditIndex = -1;
            BindMeals();
        }
    }
}
