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
    public class CardService
    {
        IRepository<Cards> repository;
        IMapper mapper;

        public CardService(IRepository<Cards>repository)
        {
            this.repository = repository;
            MapperConfiguration configuration = new MapperConfiguration((conf) => {

                conf.CreateMap<Cards, CardDTO>();
                conf.CreateMap<CardDTO, Cards>();

                conf.CreateMap<Users, UserDTO>();
                conf.CreateMap<UserDTO, Users>();

                conf.CreateMap<Carts, CartDTO>();
                conf.CreateMap<CartDTO, Carts>();

                conf.CreateMap<Games, GameDTO>();
                conf.CreateMap<GameDTO, Games>();

                conf.CreateMap<GenreDTO, Genres>();
                conf.CreateMap<Genres, GenreDTO>();

                conf.CreateMap<DeveloperDTO, Developers>();
                conf.CreateMap<Developers, DeveloperDTO>();

                conf.CreateMap<PhotoDTO, Photos>();
                conf.CreateMap<Photos, PhotoDTO>();


            });
            mapper = new Mapper(configuration);
        }

        public IEnumerable<CardDTO> GetAll()
        {
            return repository.GetAll().Select(card => mapper.Map<Cards, CardDTO>(card));
        }

        public void AddOrUpdateCard(CardDTO cardDTO)
        {
            Cards card = mapper.Map<CardDTO, Cards>(cardDTO);
            repository.CreateOrUpdate(card);
            repository.SaveChanges();
        }
        public CardDTO GetCardByUserId(UserDTO user)
        {
            return GetAll().FirstOrDefault((card) =>
            {
                try
                {
                    return card.UserId == user.Id;
                }
                catch { return false; }

            });
        }
    }
}
