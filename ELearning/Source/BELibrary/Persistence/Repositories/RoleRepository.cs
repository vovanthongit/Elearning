using System;
using System.Linq;
using BELibrary.Core.Entity.Repositories;
using BELibrary.Entity;
using BELibrary.Utils;

namespace BELibrary.Persistence.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ELearningDBContext context)
            : base(context)
        {
        }

        public ELearningDBContext ELearningDBContext
        {
            get { return Context as ELearningDBContext; }
        }
    }
}