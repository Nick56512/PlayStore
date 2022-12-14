using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.DAL.Context
{
    public class Genres
    {
        public int Id { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Games> Games { get; set; } = new HashSet<Games>();
    }
}
