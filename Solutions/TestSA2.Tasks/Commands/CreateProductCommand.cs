namespace TestSA2.Tasks.Commands
{
  using System.ComponentModel.DataAnnotations;

  using SharpArch.Domain.Commands;

  public class CreateProductCommand : CommandBase
  {
    public CreateProductCommand(string name)
    {
      this.Name = name;
    }

    [Required]
    public string Name { get; set; }
  }
}