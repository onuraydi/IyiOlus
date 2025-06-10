using IyiOlus.Core.Repositories;
using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Domain.Entities
{
    public class Question:Entity<Guid>
    {
        public string ProfileQuestion { get; set; } = default!;
        public QuestionTypes QuestionType { get; set; }
        public Guid ProfileTypeId { get; set; }
        public ProfileType ProfileType { get; set; } = default!; 
    }
}
