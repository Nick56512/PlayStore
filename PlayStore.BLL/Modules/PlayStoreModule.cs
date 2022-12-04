using Ninject.Modules;
using PlayStore.BLL.DTO;
using PlayStore.BLL.Services;
using PlayStore.DAL.Context;
using PlayStore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.BLL.Modules
{
    public class PlayStoreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<PlayStoreContext>();

            Bind<UserService>().To<UserService>();
            Bind<UserDTO>().To<UserDTO>();
            Bind<IRepository<Users>>().To<UserRepository>();

            Bind<IRepository<Carts>>().To<CartRepository>();
            Bind<CartService>().To<CartService>();

            Bind<IRepository<Admins>>().To<AdminRepository>();
            Bind<AdminService>().To<AdminService>();

            Bind<IRepository<Games>>().To<GameRepository>();
            Bind<GameService>().To<GameService>();

            Bind<IRepository<Genres>>().To<GenreRepository>();
            Bind<GenreService>().To<GenreService>();

            Bind<IRepository<Developers>>().To<DeveloperRepository>();
            Bind<DeveloperService>().To<DeveloperService>();

            Bind<IRepository<Histories>>().To<HistoryRepository>();
            Bind<HistoryService>().To<HistoryService>();

            Bind<IRepository<Cards>>().To<CardRepository>();
            Bind<CardService>().To<CardService>();
        }
    }
}
