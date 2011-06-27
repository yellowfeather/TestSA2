namespace TestSA2.Domain
{
  using System.ComponentModel.DataAnnotations;

  using SharpArch.Domain.DomainModel;

    public class Product : Entity
    {
      [Required]
      public virtual string ProductName { get; set; }
    }
}