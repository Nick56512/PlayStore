using AutoMapper;
using PlayStore.BLL.DTO;
using PlayStore.DAL.Context;
using PlayStore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.BLL.Services
{
    public class CartService
    {
        IRepository<Carts> repository;
        IMapper mapper;
        public CartService(IRepository<Carts> repository)
        {
            this.repository = repository;
            MapperConfiguration configuration = new MapperConfiguration((x) => {

                x.CreateMap<Carts, CartDTO>();
                x.CreateMap<CartDTO, Carts>();

                x.CreateMap<GenreDTO, Genres>();
                x.CreateMap<Genres, GenreDTO>();

                x.CreateMap<DeveloperDTO, Developers>();
                x.CreateMap<Developers, DeveloperDTO>();

                x.CreateMap<PhotoDTO, Photos>();
                x.CreateMap<Photos, PhotoDTO>();

                x.CreateMap<Games, GameDTO>();
                x.CreateMap<GameDTO, Games>();

            });
            mapper = new Mapper(configuration);
        }
       
        //public CartDTO AddCorn(CartDTO cart)
       // {
       //     Carts addingCorn = mapper.Map<CartDTO, Carts>(cart);

      //      repository.CreateOrUpdate(addingCorn);
     //       repository.SaveChanges();
     //       return cart;
     //   }


        public void AddGameToCart(CartDTO cart,GameDTO game)
        {
            using (PlayStoreContext context=new PlayStoreContext())
            {
               // if (cart is null)
                   // cart.Games = new List<GameDTO>();
                cart.Games.Add(game);
                Carts Cart = context.Carts.Find(cart.Id);
                Games Game = context.Games.Find(game.Id);
                Cart.Games.Add(Game);
                Game.Carts.Add(Cart);
                context.SaveChanges();
            }
        }
        public void DeleteGameInCart(CartDTO cart,GameDTO game)
        {
            using (PlayStoreContext context = new PlayStoreContext())
            {
                cart.Games.Remove(game);
                Carts Cart = context.Carts.Find(cart.Id);
                Games Game = context.Games.Find(game.Id);
                Cart.Games.Remove(Game);
                Game.Carts.Remove(Cart);
                context.SaveChanges();
            }
        }
        public decimal GetAllPrice(CartDTO cart)
        {
            decimal price = 0;
            foreach(var item in cart.Games)
            {
                price += item.Price;
            }
            return price;
        }


       
    }
}
