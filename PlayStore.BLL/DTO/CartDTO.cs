using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.BLL.DTO
{
    public class CartDTO
    {
        public int Id { get; set; }
        public ICollection<GameDTO> Games { get; set; }

    }
}
