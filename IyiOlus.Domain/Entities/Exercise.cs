using IyiOlus.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Domain.Entities
{
    public class Exercise : Entity<Guid>
    {
        public string Name { get; set; } = default!;
        public string Detail { get; set; } = default!;
        public int Progress { get; set; }
        public virtual User User { get; set; } = default!;
        public Guid UserId { get; set; }  // Burada id kullanmak işe yarayacak ancak veritabanı normalizasyonu açısından sıkıntılı bir durum oluşturabilir. Ancak eğer her kullanıcı için farklı egzersiz olacaksa mantıklı bir kullanım
    }
}
