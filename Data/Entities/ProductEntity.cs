﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Entities
{
    [Table("Products")]
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string Producer { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        public DateTime Created { get; set; }

        public int? OrganizationId { get; set; }
        public OrganizationEntity? Organization { get; set; }

        public ProductEntity()
        {
            Created = DateTime.Now;
        }

    }

}
