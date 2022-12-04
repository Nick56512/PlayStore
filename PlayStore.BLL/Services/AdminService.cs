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
    public class AdminService
    {
        IRepository<Admins> repository;
        IMapper mapper;
        public AdminService(IRepository<Admins>repository)
        {
            this.repository = repository;
            MapperConfiguration configuration = new MapperConfiguration((x) => {

                x.CreateMap<Admins, AdminDTO>();
                x.CreateMap<AdminDTO, Admins>();
            });
            mapper = new Mapper(configuration);
        }
        public AdminDTO Authorization(string login, string password)
        {
            AdminDTO admin = mapper.Map<Admins,AdminDTO>(repository.GetAll()
                .FirstOrDefault((user) => 
                {

                   return user.Login == login
                   &&
                   user.Password == password;

                }));

            return admin;
        }

        public AdminDTO CheckSameLogin(string Login)
        {
            return mapper.Map<Admins, AdminDTO>(repository.GetAll().FirstOrDefault((admin) => {

                return admin.Login == Login;
            }));
        }
    }
}
