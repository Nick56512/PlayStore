using PlayStore.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.DAL.Repositories
{
    public class GenreRepository:GenericRepository<Genres>
    {
        public GenreRepository(DbContext context) : base(context)
        {

        }
    }
   
}
