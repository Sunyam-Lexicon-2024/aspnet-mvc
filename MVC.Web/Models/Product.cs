namespace MVC.Web.Models;

public class Product
{
  public int ID { get; set; }

  public required string Name { get; set; }

  public required int Price { get; set; }

  public required DateTime OrderDate { get; set; }

  public string? Category { get; set; }

  public required string Shelf { get; set; }
  
  public required int Count { get; set; }

  public string? Description { get; set; }

}
