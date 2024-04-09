using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Storage.Models;

public class ProductViewModel(IEnumerable<Product> products)
{

  private IEnumerable<Product> _products = products;


  public string? Name { get; set; }
  public int Price { get; set; }
  public int Count { get; set; }
  public string? Category { get; set; }
  public string? Description { get; set; }
  public string? Shelf { get; set; }
  public DateTime OrderDate { get; set; }
  [DisplayName("Inventory Value")]
  public int InventoryValue => Price * Count;


  public IEnumerable<Product>? Products => _products;
  public string? SelectedCategory { get; set; }
  public SelectList? Categories { get; set; }

}
