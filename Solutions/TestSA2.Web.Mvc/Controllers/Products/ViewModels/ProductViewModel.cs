namespace TestSA2.Web.Mvc.Controllers.Products.ViewModels
{
  using System.ComponentModel.DataAnnotations;

  public class ProductViewModel
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
  }
}