using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Storage.Models;

public class Product
{
  public int ID { get; set; }

  [DataType(DataType.Text)]
  [Required(ErrorMessage = "A product name is required")]
  [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
  public string? Name { get; set; }

  [Required(ErrorMessage = "A product price is required")]
  [Range(0, 10000000, ErrorMessage = "Product price must be bewtween 0-1000000")]
  public int Price { get; set; }

  [DataType(DataType.Date)]
  [DisplayName("Order Date")]
  [Required(ErrorMessage = "An order date is required")]
  public DateTime OrderDate { get; set; }

  [DataType(DataType.Text)]
  [StringLength(100, ErrorMessage = "Category cannot exceed 100 characters")]
  public string? Category { get; set; }

  [DataType(DataType.Text)]
  [DisplayName("Shelf")]
  [Required(ErrorMessage = "A shelf is required")]
  [RegularExpression("^Shelf-[0-9]*$", ErrorMessage = "Naming scheme 'Shelf-#' required")]
  public string? Shelf { get; set; }

  [Required(ErrorMessage = "A product count is required")]
  [DisplayName("Current Stock")]
  public int Count { get; set; }

  [DataType(DataType.Text)]
  [StringLength(300, ErrorMessage = "Category cannot exceed 300 characters")]
  public string? Description { get; set; }

  public int InventoryValue => Price * Count;

}
