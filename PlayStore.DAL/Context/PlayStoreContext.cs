using PlayStore.DAL.Initializer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.DAL.Context
{
    public class PlayStoreContext:DbContext
    {
        public DbSet<Games> Games { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Admins> Admins { get; set; }

        public DbSet<Histories> History { get; set; }
        public DbSet<Photos> Screenshots { get; set; }

        public DbSet<Genres> Genres { get; set; }
        public DbSet<Carts> Carts { get; set; }

        public DbSet<Cards> Cards { get; set; }

        public DbSet<Developers> Developers { get; set; }

        public PlayStoreContext():base("name=PlayStoreContext")
        {
            Database.SetInitializer<PlayStoreContext>(new PlayStoreInitializer());
        }
        
    }
}
