using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BELibrary.Entity;

namespace BELibrary.Core.Entity.Repositories
{
    //this.Configuration.LazyLoadingEnabled = false;
    public interface IAccountRepository : IRepository<User>
    {
        User ValidBEAccount(string username, string password);
        User ValidFEAccount(string username, string password);

        User GetAccountByUsername(string email);
    }
}