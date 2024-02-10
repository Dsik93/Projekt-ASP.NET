using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3.Models
{
    public class ProductModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Producer is required.")]
        public string Producer { get; set; }

        [Required(ErrorMessage = "Production date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Enter a valid production date.")]
        public DateTime ProductionDate { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 1000 characters.")]
        public string Description { get; set; }
    }
}
