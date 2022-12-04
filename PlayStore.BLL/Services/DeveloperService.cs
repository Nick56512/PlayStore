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
    public class DeveloperService
    {
        IRepository<Developers> repository;
        IMapper mapper;
        public DeveloperService(IRepository<Developers> repository)
        {
            this.repository = repository;
            MapperConfiguration configuration = new MapperConfiguration((x) => {


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
        public IEnumerable<DeveloperDTO> GetAll()
        {
            return repository.GetAll().Select(developer => mapper.Map<Developers,DeveloperDTO>(developer));
        }
    }
}
