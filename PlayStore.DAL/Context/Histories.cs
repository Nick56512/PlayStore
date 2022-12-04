using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.DAL.Context
{
    public class Histories
    {
        public int Id { get; set; }

        public int? GameId { get; set; }
        public virtual Games Game { get; set; }

        public DateTime? Date { get; set; }

        public int? UserId { get; set; }
        public virtual Users User { get; set; }
    }
}
