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
        private bool IsUnitsControlSet {
            get {
                if(ViewState["UnitsAdded"] == null)
                {
                    ViewState["UnitsAdded"] = false;
                }
                return (bool)ViewState["UnitsAdded"];
            }
            set {
                ViewState["UnitsAdded"] = value;
            }
        }
        private bool IsIngredientsControlSet {
            get {
                if (ViewState["IngredientAdded"] == null)
                {
                    ViewState["IngredientAdded"] = false;
                }
                return (bool)ViewState["IngredientAdded"];
            }
            set {
                ViewState["IngredientAdded"] = value;
            }
        }
        private bool IsMealsControlSet {
            get {
                if (ViewState["MealsAdded"] == null)
                {
                    ViewState["MealsAdded"] = false;
                }
                return (bool)ViewState["MealsAdded"];
            }
            set {
                ViewState["MealsAdded"] = value;
            }
        }        

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    Control control = LoadControl("./GridViewControls/IngredientsControl.ascx");
            //    //control.ID = "ingredients";
            //    phUserControls.Controls.Add(control);
            //}

            if (IsUnitsControlSet)
            {
                AddUnitsControl();
            }
            if(IsIngredientsControlSet)
            {
                AddIngredientControl();
            }
            if(IsMealsControlSet)
            {
                AddMealsControl();
            }
        }

        private void AddMealsControl()
        {
            Control control = LoadControl("./GridViewControls/MealsControl.ascx");
            control.ID = "meals";
            phUserControls.Controls.Add(control);
            IsMealsControlSet = true;
        }

        private void AddIngredientControl()
        {
            Control control = LoadControl("./GridViewControls/IngredientsControl.ascx");
            //control.ID = "ingredients";
            phUserControls.Controls.Add(control);
            IsIngredientsControlSet = true;
        }

        private void AddUnitsControl()
        {
            Control control = LoadControl("./GridViewControls/UnitsControl.ascx");
            control.ID = "units";
            phUserControls.Controls.Add(control);
            IsUnitsControlSet = true;
        }

        protected void DdlData_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DdlData.SelectedValue)
            {
                case "Ingredients":
                    ClearControls();
                    AddIngredientControl();
                    break;
                case "Units":
                    ClearControls();
                    AddUnitsControl();
                    break;
                case "Meals":
                    ClearControls();
                    AddMealsControl();
                    break;
            }
        }

        private void ClearControls()
        {
            phUserControls.Controls.Clear();
            IsIngredientsControlSet = false;
            IsMealsControlSet = false;
            IsUnitsControlSet = false;
        }

    }
}