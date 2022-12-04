using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.DAL.Context
{
    public class Games
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Cover { get; set; }
        public string Platforms { get; set; }
        public string Processors { get; set; }
        public string MinMemory { get; set; }
        public string VideoCard { get; set; }
        public string SoundCard { get; set; }
        public string HDDSpace { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; }

        public int? GenreId { get; set; }
        public virtual Genres Genre { get; set; }

        public int? DeveloperId { get; set; }
        public virtual Developers Developer { get; set; }

        public virtual ICollection<Photos> Photos { get; set; } = new HashSet<Photos>();
        public virtual ICollection<Users> Players { get; set; } = new HashSet<Users>();
        public virtual ICollection<Carts> Carts { get; set; } = new HashSet<Carts>();


        public string GameFile { get; set; }

    }
}
