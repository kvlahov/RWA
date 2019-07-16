using Hybrid.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hybrid.Admin
{
    public partial class ManageData : System.Web.UI.Page
    {
        private readonly static IRepository repo = RepoFactory.GetRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateIngredientColumns();
        }

        protected void DdlData_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DdlData.SelectedValue)
            {
                case "Ingredients":
                    GenerateIngredientColumns();
                    break;
                case "Units":
                    DataGridView.DataSource = repo.GetUnitsOfMesurement(1);
                    break;
                case "Meals":
                    DataGridView.DataSource = repo.GetNutrientsPerMeal(3);
                    break;
            }
            DataGridView.DataBind();
        }

        protected void DataGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataGridView.EditIndex = e.NewEditIndex;
            GenerateIngredientColumns();
        }

        protected void DataGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DataGridView.EditIndex = -1;
            GenerateIngredientColumns();
        }

        private void GenerateIngredientColumns()
        {
            DataGridView.DataSource = repo.GetAllIngredients();
            DataGridView.AutoGenerateColumns = false;
            DataGridView.DataKeyNames = new string[] { "Id" };
            DataGridView.AllowPaging = true;
            DataGridView.AllowSorting = true;
            DataGridView.PageSize = 5;

            BoundField bf1 = new BoundField();
            BoundField bf2 = new BoundField();
            BoundField bf3 = new BoundField();

            bf1.HeaderText = "ID";
            bf1.DataField = "Id";
            bf1.ReadOnly = true;
            bf1.SortExpression = "Id";

            bf2.HeaderText = "Ingredient";
            bf2.DataField = "Name";
            bf2.SortExpression = "Name";

            bf3.HeaderText = "Type";
            bf3.DataField = "TypeId";
            bf3.SortExpression = "TypeId";

            CommandField cf = new CommandField();
            cf.ButtonType = ButtonType.Button;
            cf.ShowCancelButton = true;
            cf.ShowEditButton = true;

            DataGridView.Columns.Clear();
            DataGridView.Columns.Add(bf1);
            DataGridView.Columns.Add(bf2);
            DataGridView.Columns.Add(bf3);
            DataGridView.Columns.Add(cf);

            DataGridView.DataBind();
        }

        private void GenerateMealsColumns()
        {
            DataGridView.DataSource = repo.GetNutrientsPerMeal(3);
            DataGridView.AutoGenerateColumns = false;
            DataGridView.DataKeyNames = new string[] { "Id" };
            DataGridView.AllowPaging = true;
            DataGridView.AllowSorting = true;
            DataGridView.PageSize = 5;

            BoundField bf1 = new BoundField();
            BoundField bf2 = new BoundField();
            BoundField bf3 = new BoundField();

            bf1.HeaderText = "ID";
            bf1.DataField = "Id";
            bf1.ReadOnly = true;
            bf1.SortExpression = "Id";

            bf2.HeaderText = "Ingredient";
            bf2.DataField = "Name";
            bf2.SortExpression = "Name";

            bf3.HeaderText = "Type";
            bf3.DataField = "TypeId";
            bf3.SortExpression = "TypeId";

            CommandField cf = new CommandField();
            cf.ButtonType = ButtonType.Button;
            cf.ShowCancelButton = true;
            cf.ShowEditButton = true;

            DataGridView.Columns.Clear();
            DataGridView.Columns.Add(bf1);
            DataGridView.Columns.Add(bf2);
            DataGridView.Columns.Add(bf3);
            DataGridView.Columns.Add(cf);

            DataGridView.DataBind();
        }

        private void GenerateUnitsColumns()
        {
            DataGridView.DataSource = repo.GetAllIngredients();
            DataGridView.AutoGenerateColumns = false;
            DataGridView.DataKeyNames = new string[] { "Id" };
            DataGridView.AllowPaging = true;
            DataGridView.AllowSorting = true;
            DataGridView.PageSize = 5;

            BoundField bf1 = new BoundField();
            BoundField bf2 = new BoundField();
            BoundField bf3 = new BoundField();

            bf1.HeaderText = "ID";
            bf1.DataField = "Id";
            bf1.ReadOnly = true;
            bf1.SortExpression = "Id";

            bf2.HeaderText = "Ingredient";
            bf2.DataField = "Name";
            bf2.SortExpression = "Name";

            bf3.HeaderText = "Type";
            bf3.DataField = "TypeId";
            bf3.SortExpression = "TypeId";

            CommandField cf = new CommandField();
            cf.ButtonType = ButtonType.Button;
            cf.ShowCancelButton = true;
            cf.ShowEditButton = true;

            DataGridView.Columns.Clear();
            DataGridView.Columns.Add(bf1);
            DataGridView.Columns.Add(bf2);
            DataGridView.Columns.Add(bf3);
            DataGridView.Columns.Add(cf);

            DataGridView.DataBind();
        }

    }
}