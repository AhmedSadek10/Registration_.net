using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain.Entities
{
    public class CityEntity
    {
        public int Id { get; set; }
        public string City { get; set; }

        public int GovernateId { get; set; }

        public GovernateEntity Governate { get; set; }
    }
}
