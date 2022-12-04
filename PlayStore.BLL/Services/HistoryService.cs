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
    public class HistoryService
    {
        IRepository<Histories> repository;
        IMapper mapper;

        public HistoryService(IRepository<Histories> repository)
        {
            this.repository = repository;
            MapperConfiguration configuration = new MapperConfiguration((x) =>
            {
                x.CreateMap<Histories, HistoryDTO>();
                x.CreateMap<Users, UserDTO>();
                //x.CreateMap<UserDTO, UserDTO>();
                x.CreateMap<Games, GameDTO>();
            });
            mapper = new Mapper(configuration);
        }
        public IEnumerable<HistoryDTO> GetAll()
        {
            return repository.GetAll().Select(item => mapper.Map<Histories, HistoryDTO>(item));
        }
    }
}
