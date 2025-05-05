using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Core.Repositories
{
    // Burayı yazmanın amacı Entitylerimizi boş bırakmamak aynı zamanda hangi varlığın veri tabanında hangi işlemi ne zaman yaptığını görmektir.
    public abstract class Entity<TId>
    {
        public TId Id { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }

        protected Entity()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}
