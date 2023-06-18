using System.ComponentModel.DataAnnotations;

namespace TestingSolution.TestProject.Core.Contracts.Products.Commands.CreateProduct
{
    public class CreateProductCommand
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 1000)]
        public double Price { get; set; }
    }
}