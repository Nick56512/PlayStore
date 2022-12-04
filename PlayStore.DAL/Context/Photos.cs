using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.DAL.Context
{
    public class Photos
    {
        public int Id { get; set; }
        public string Photo { get; set; }

        public int? GameId { get; set; }
        public virtual Games Game { get; set; }

    }
}
