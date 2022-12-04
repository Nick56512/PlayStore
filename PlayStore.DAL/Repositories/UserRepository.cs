using PlayStore.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.DAL.Repositories
{
    public class UserRepository:GenericRepository<Users>
    {
        public UserRepository(DbContext context):base(context)
        {

        }
    }
}
