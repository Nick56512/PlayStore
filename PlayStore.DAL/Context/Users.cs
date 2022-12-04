using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.DAL.Context
{
    public class Users
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
    
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string NumberPhone { get; set; }

        public virtual ICollection<Games> Games { get; set; } = new HashSet<Games>();

        public int? CartId { get; set; }
        public virtual Carts Cart { get; set; }
       
    }
}
