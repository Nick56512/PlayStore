using AutoMapper;
using PlayStore.BLL.DTO;
using PlayStore.DAL.Context;
using PlayStore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.BLL.Services
{
    public class UserService
    {
        IRepository<Users> repository;
        IMapper mapper;
        public UserService(IRepository<Users>repository)
        {
            this.repository = repository;
            MapperConfiguration configuration = new MapperConfiguration((x)=> {

                x.CreateMap<Users, UserDTO>();
                x.CreateMap<UserDTO, Users>();

                x.CreateMap<Carts, CartDTO>();
                x.CreateMap<CartDTO, Carts>();

                x.CreateMap<Games, GameDTO>();
                x.CreateMap<GameDTO, Games>();

                x.CreateMap<GenreDTO, Genres>();
                x.CreateMap<Genres, GenreDTO>();

                x.CreateMap<DeveloperDTO, Developers>();
                x.CreateMap<Developers, DeveloperDTO>();

                x.CreateMap<PhotoDTO, Photos>();
                x.CreateMap<Photos, PhotoDTO>();

                x.CreateMap<Cards, CardDTO>();
                x.CreateMap<CardDTO, Cards>();

            });
            mapper = new Mapper(configuration);
        }
        public IEnumerable<UserDTO> GetAll()
        {
            return repository.GetAll().Select(user => mapper.Map<Users, UserDTO>(user));
        }
        public Task AddUser(UserDTO user)
        {
            return Task.Run(() =>
            {
               
                Users addingUser = mapper.Map<UserDTO, Users>(user);
                repository.CreateOrUpdate(addingUser);
                repository.SaveChanges();
            }
            );
        }
      

        public UserDTO CheckSameLogin(string Login)
        {
            return mapper.Map<Users,UserDTO>(repository.GetAll().FirstOrDefault((user)=> {

                return user.Login == Login;
            }));
        }
        public UserDTO Authorization(string login,string password)
        {
            UserDTO User=  mapper.Map<Users, UserDTO>(repository.GetAll().FirstOrDefault((user) => {

                return user.Login == login
                &&
                user.Password==password;

            }));
            return User;

            
        }
        public void AddGameToLibrary(UserDTO user,GameDTO game)
        {
            using (PlayStoreContext context = new PlayStoreContext())
            {
                
                Users User = context.Users.Find(user.Id);
                Games Game = context.Games.Find(game.Id);
                User.Games.Add(Game);
                Game.Players.Add(User);
                context.SaveChanges();
            }
        }

    }
}
