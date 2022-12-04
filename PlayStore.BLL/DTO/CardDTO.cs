using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.BLL.DTO
{
    public class CardDTO
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string SecurityCode { get; set; }
        public decimal Balance { get; set; }
        public DateTime Date { get; set; }

        public int? UserId { get; set; }
        public UserDTO User { get; set; }

    }
}
