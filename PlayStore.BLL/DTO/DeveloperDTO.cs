using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.BLL.DTO
{
    public class DeveloperDTO
    {
        public int Id { get; set; }
        public string DeveloperName { get; set; }

        public ICollection<GameDTO> Games { get; set; } = new HashSet<GameDTO>();

        public override string ToString()
        {
            return DeveloperName;
        }
    }
}
