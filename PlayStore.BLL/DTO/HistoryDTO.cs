using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.BLL.DTO
{
    public class HistoryDTO
    {
        public GameDTO Game { get; set; }
        public UserDTO User { get; set; }

        public DateTime? Date { get; set; }
        
    }
}
