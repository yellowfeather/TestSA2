namespace TestSA2.Tests
{
  using NUnit.Framework;

  using SharpArch.NHibernate;
  using SharpArch.Testing.NUnit.NHibernate;

  using TestSA2.Domain;

  [TestFixture]
  public class ProductRepositoryTests : RepositoryTestsBase
  {
    [Test]
    public void CanSaveProduct()
    {
      var repository = new NHibernateRepository<Product>();

      var product = new Product { ProductName = "Test" };
      repository.Save(product);
    }

    [SetUp]
    protected override void SetUp()
    {
      ServiceLocatorInitializer.Init();
      base.SetUp();
    }

    protected override void LoadTestData()
    {
      // do nothing
    }
  }
}