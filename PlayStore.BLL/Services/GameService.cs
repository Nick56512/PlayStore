using AutoMapper;
using PlayStore.BLL.DTO;
using PlayStore.DAL.Context;
using PlayStore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.BLL.Services
{
    public class GameService
    {
        IRepository<Games> repository;
        IMapper mapper;
        public GameService(IRepository<Games> repository)
        {
            this.repository = repository;
            MapperConfiguration configuration = new MapperConfiguration((x) => {


                x.CreateMap<GenreDTO,Genres>();
                x.CreateMap<Genres, GenreDTO>();

                x.CreateMap<DeveloperDTO, Developers>();
                x.CreateMap<Developers, DeveloperDTO>();

                x.CreateMap<PhotoDTO, Photos>();
                x.CreateMap<Photos, PhotoDTO>();

                x.CreateMap<Games, GameDTO>();
                x.CreateMap<GameDTO, Games>();

                x.CreateMap<CartDTO, Carts>();
                x.CreateMap<Carts, CartDTO>();
                 
                
            });
            mapper = new Mapper(configuration);
        }
        public IEnumerable<GameDTO> GetAll()
        {
           return repository.GetAll().Select(game => mapper.Map<Games, GameDTO>(game));
        }

        public void AddOrUpdateGame(GameDTO game)
        {
                Games addingGame = mapper.Map<GameDTO, Games>(game);
                repository.CreateOrUpdate(addingGame);
                repository.SaveChanges(); 
   
        }
        public void RemoveGame(GameDTO game)
        {
            Games removeGame = repository.Get(game.Id);
            repository.Delete(removeGame);
            repository.SaveChanges();
        }
        public IEnumerable<GameDTO> FindByName(string name)
        {
            var games= repository.GetAll().Select(game => mapper.Map<Games, GameDTO>(game));
            return games.Where((game) =>
            {
                if (game.Name != null)
                {
                    return game.Name.ToLower().Contains(name.ToLower());
                }
                else return false;
                
            });
        }
        public Games Get(GameDTO game)
        {
            return repository.Get(game.Id);
        }
        
      
        
    }

}
