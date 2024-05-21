using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain.Entities
{
    public class GovernateEntity
    {
        public int Id { get; set; }
        public string Governate { get; set; }

        public List<CityEntity> Cities { get; set; }
    }
}
