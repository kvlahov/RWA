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
            BindUsers();
        }

        private void BindUsers()
        {
            UsersList.DataSource = repo.GetAllUsers();
            UsersList.DataBind();
        }
    }
}