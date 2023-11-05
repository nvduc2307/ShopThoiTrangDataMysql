using System.ComponentModel.DataAnnotations;

namespace ShopThoiTrang.BackEnd.Entities;
public class ProductEntity {
    [Key]
    public int Id {get; set;}

    [Required]
    [StringLength(50)]
    public string? Name{get; set;}

    [Required]
    public double Price {get; set;}
}