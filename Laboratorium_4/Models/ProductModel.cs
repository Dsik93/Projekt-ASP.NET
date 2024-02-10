using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_4.Models
{
    public class ProductModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [HiddenInput]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Display(Name = "Price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Producer is required.")]
        [Display(Name = "Producer")]
        public string Producer { get; set; }

        [Required(ErrorMessage = "Production date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Enter a valid production date.")]
        [Display(Name = "Production Date")]
        public DateTime ProductionDate { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 1000 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Priority is required.")]
        [Display(Name = "Priority")]
        public Priority Priority { get; set; }

    }
}
