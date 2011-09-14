namespace TestSA2.Tasks.CommandHandlers
{
  using SharpArch.Domain.Commands;
  using SharpArch.NHibernate.Contracts.Repositories;

  using TestSA2.Domain;
  using TestSA2.Tasks.Commands;

  public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
  {
    private readonly INHibernateRepository<Product> productRepository;

    public CreateProductCommandHandler(INHibernateRepository<Product> productRepository)
    {
      this.productRepository = productRepository;
    }

    public void Handle(CreateProductCommand command)
    {
      var product = new Product { ProductName = command.Name };
      this.productRepository.SaveOrUpdate(product);
    }
  }
}