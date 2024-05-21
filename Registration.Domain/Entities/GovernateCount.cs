using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain.Entities
{
    public class GovernateCount
    {
        public string Governate { get; set; } = string.Empty;
        public int UserCount { get; set; }
    }
}
