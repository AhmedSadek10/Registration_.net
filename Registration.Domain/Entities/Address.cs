using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Might need imporvment
 * There are 2 approaches to implment this 
 * Approach 1 => use strings to store city and governate
 * Approach 2 => use City Entity and Governate Entity to represent the city and the governate
 * Approach 1 will be simpler and easier to maintain 
 * Approach 2 will promote data consistency
 * I decided to go with Approach 1 since the user will access the city and governate from a dropdown list coming from the lookup tables;
 */
namespace Registration.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string Governate { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public int FlatNumber { get; set; }
    }
}
