using Hybrid.Models;
using Hybrid.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hybrid.Admin
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        private readonly static IRepository repo = RepoFactory.GetRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindUsers();
            }
        }

        private void BindUsers()
        {
            UsersList.DataSource = repo.GetAllUsers();
            UsersList.DataTextField = "FullName";
            UsersList.DataValueField = "EntityID";
            UsersList.SelectedIndex = 0;
            UsersList.DataBind();
            BindDetails();
        }

        private void BindDetails()
        {
            User usr = repo.GetUser(UsersList.SelectedValue);
            var activity = repo.GetLvlsOfActivity().Where(a => a.Id == usr.LevelOfActivityID).First();
            phName.Controls.Add(new LiteralControl(usr.Name));
            phSurname.Controls.Add(new LiteralControl(usr.Surname));
            phHeight.Controls.Add(new LiteralControl(usr.Height.ToString()));
            phWeight.Controls.Add(new LiteralControl(usr.Weight.ToString()));
            phSex.Controls.Add(new LiteralControl(usr.Sex.ToString()));
            phDiabetesType.Controls.Add(new LiteralControl(usr.DiabetesType.ToString()));
            phLvlActivity.Controls.Add(new LiteralControl(activity.Type));
            phDateOfBirth.Controls.Add(new LiteralControl(usr.DateOFBirth.ToShortDateString()));
        }

        protected void UsersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDetails();
        }
    }
}