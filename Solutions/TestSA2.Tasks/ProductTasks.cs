namespace TestSA2.Tasks
{
  using SharpArch.NHibernate.Contracts.Repositories;

  using TestSA2.Domain;
  using TestSA2.Domain.Contracts.Tasks;

  public class ProductTasks : IProductTasks
  {
    private readonly INHibernateRepository<Product> productRepository;

    public ProductTasks(INHibernateRepository<Product> productRepository)
    {
      this.productRepository = productRepository;
    }

    public Product Create(string name)
    {
      var product = new Product { ProductName = name };
      this.productRepository.SaveOrUpdate(product);
      return product;
    }

    public void Update(int id, string name)
    {
      var product = this.productRepository.Get(id);
      product.ProductName = name;
    }

    public void Delete(int id)
    {
      var product = this.productRepository.Get(id);
      this.productRepository.Delete(product);
    }
  }
}