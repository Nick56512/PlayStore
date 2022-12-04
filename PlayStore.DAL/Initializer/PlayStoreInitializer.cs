using PlayStore.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.DAL.Initializer
{
    class PlayStoreInitializer: DropCreateDatabaseIfModelChanges<PlayStoreContext>
    {
        protected override void Seed(PlayStoreContext context)
        {

            base.Seed(context);
        }
    }
}
