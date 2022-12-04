using PlayStore.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.DAL.Repositories
{
    public class CartRepository:GenericRepository<Carts>
    {
        public CartRepository(DbContext context):base(context)
        {

        }
    }
}
