using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.DAL.Context
{
    public class Developers
    {
        public int Id { get; set; }
        public string DeveloperName { get; set; }

        public ICollection<Games> Games { get; set; } = new HashSet<Games>();
    }
}
