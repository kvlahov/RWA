using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hybrid.Models.DAL
{
    public static class RepoFactory
    {
        public static IRepository GetRepository() => new SQLRepo();
        
    }
}