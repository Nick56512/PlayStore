using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PlayStore.BLL.DTO
{
    public class GameDTO
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


       public GenreDTO Genre { get; set; }

       public DeveloperDTO Developer { get; set; }

       public ICollection<PhotoDTO> Photos { get; set; }

        
        

    }
}
