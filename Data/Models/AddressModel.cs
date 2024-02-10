using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class AddressModel
    {
        //[Key]
        //public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
    }
}
