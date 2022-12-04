using PlayStore.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.DAL.Repositories
{
    class PhotosRepository:GenericRepository<Photos>
    {
        public PhotosRepository(DbContext context):base(context)
        {

        }
    }
}
