using PlayStore.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.DAL.Repositories
{
    public class CardRepository : GenericRepository<Cards>
    {
        public CardRepository(DbContext db) : base(db)
        {
        }
    }
}
