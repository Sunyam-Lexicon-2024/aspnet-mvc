using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Storage.Models;

public class ProductCreateViewModel(Product product)
{
  private string? _name = product.Name;
  private int _price = product.Price;
  private int _count = product.Count;
  private string? _category = product.Category;
  private string? _shelf = product.Shelf;
  private string? _description = product?.Description;
  private DateTime _orderDate = product!.OrderDate;

  [DataType(DataType.Text)]
  [Required(ErrorMessage = "A product name is required")]
  [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
  public string? Name { get => _name; set => _name = value; }

  [Required(ErrorMessage = "A product price is required")]
  [Range(0, 10000000, ErrorMessage = "Product price must be bewtween 0-1000000")]
  public int Price { get => _price; set => _price = value; }

  [DisplayName("Current Stock")]
  [Required(ErrorMessage = "A product count is required")]
  public int Count { get => _count; set => _count = value; }

  [DataType(DataType.Text)]
  [StringLength(100, ErrorMessage = "Category cannot exceed 100 characters")]
  public string? Category { get => _category; set => _category = value; }

  [DataType(DataType.Text)]
  [StringLength(300, ErrorMessage = "Category cannot exceed 300 characters")]
  public string? Description { get => _description; set => _description = value; }

  [DataType(DataType.Text)]
  [DisplayName("Shelf")]
  [Required(ErrorMessage = "A shelf is required")]
  [RegularExpression("^Shelf-[0-9]*$", ErrorMessage = "Naming scheme 'Shelf-#' required")]
  public string? Shelf { get => _shelf; set => _shelf = value; }

  [DataType(DataType.Date)]
  [Required(ErrorMessage = "An order date is required")]
  [DisplayName("Order Date")]
  public DateTime OrderDate { get => _orderDate; set => _orderDate = value; }

}
