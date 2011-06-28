namespace TestSA2.Tests
{
  using NUnit.Framework;

  using SharpArch.Domain.PersistenceSupport;
  using SharpArch.NHibernate;
  using SharpArch.Testing.NUnit.NHibernate;

  using TestSA2.Domain;

  [TestFixture]
  public class ProductRepositoryTests : RepositoryTestsBase
  {
    private IRepository<Product> productRepository;

    [Test]
    public void CanGetProduct()
    {
      this.productRepository.Get(1);
    }

    [Test]
    public void CanSaveProduct()
    {
      var product = new Product { ProductName = "Test" };
      this.productRepository.SaveOrUpdate(product);
    }

    [SetUp]
    protected override void SetUp()
    {
      ServiceLocatorInitializer.Init();
      this.productRepository = new NHibernateRepository<Product>();

      base.SetUp();
    }

    protected override void LoadTestData()
    {
      var product = new Product { ProductName = "Test" };
      this.productRepository.SaveOrUpdate(product);
    }
  }
}