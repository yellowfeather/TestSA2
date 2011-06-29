namespace TestSA2.Tests
{
  using System.Collections.Generic;

  using NUnit.Framework;

  using SharpArch.NHibernate;
  using SharpArch.Testing.NUnit.NHibernate;

  using TestSA2.Domain;
  using TestSA2.Web.Mvc.Controllers.Products.Queries;
  using TestSA2.Web.Mvc.Controllers.Products.Queries.Contracts;
  using TestSA2.Web.Mvc.Controllers.Products.ViewModels;

  [TestFixture]
  public class ProductQueryTests : RepositoryTestsBase
  {
    private IProductQueries productQueries;

    [Test]
    public void CanGetPagedList()
    {
      var pagedList = this.productQueries.GetPagedList(0, 10);
      Assert.AreEqual(100, pagedList.TotalItems);

      var list = new List<ProductListViewModel>(pagedList);
      Assert.AreEqual(10, list.Count);

      Assert.AreEqual(1, list[0].Id);
      Assert.AreEqual("Product 001", list[0].Name);

      Assert.AreEqual(10, list[9].Id);
      Assert.AreEqual("Product 010", list[9].Name);
    }

    [Test]
    public void CanGetViewModel()
    {
      var viewModel = this.productQueries.GetViewModel(1);
      Assert.AreEqual(1, viewModel.Id);
      Assert.AreEqual("Product 001", viewModel.Name);
    }

    [SetUp]
    protected override void SetUp()
    {
      ServiceLocatorInitializer.Init();
      this.productQueries = new ProductQueries();

      base.SetUp();
    }

    protected override void LoadTestData()
    {
      var repository = new NHibernateRepository<Product>();

      for (var id = 1; id <= 100; ++id) {
        var name = string.Format("Product {0:d3}", id);
        var product = new Product { ProductName = name };
        repository.Save(product);
      }
    }
  }
}