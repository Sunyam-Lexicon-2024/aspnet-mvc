using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Web.Models;

public class ProductListViewModel
{
  private int _id;
  private string? _name;
  private int? _price;
  private int? _count;
  private string? _category;
  private string? _shelf;
  private string? _description;
  private DateTime? _orderDate;
  private static SelectList? _categories;

  public ProductListViewModel(Product product, SelectList? categories = null)
  {
    _id = product.ID;
    _name = product.Name;
    _price = product.Price;
    _count = product.Count;
    _category = product.Category;
    _shelf = product.Shelf;
    _description = product?.Description;
    _orderDate = product?.OrderDate;
    _categories = categories;
  }

  public int ID => _id;
  public string? Name => _name;
  public int? Price => _price;
  public int? Count => _count;
  public string? Category => _category;
  public string? Shelf => _shelf;
  public string? Description => _description;
  [DisplayName("Order Date")]
  public DateTime? OrderDate => _orderDate;
  [DisplayName("Inventory Total Value")]
  public int? InventoryValue => Price * Count;

  public static string? SelectedCategory { get; set; }
  public static SelectList? Categories { get => _categories; set => _categories = value; }
}
