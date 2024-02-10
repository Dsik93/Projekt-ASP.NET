using Microsoft.AspNetCore.Mvc;
using System;

namespace Laboratorium_6.Models
{
    public class AddressModel
    {
        public string City { get; set; }
        public string Streeet { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
    }
}
