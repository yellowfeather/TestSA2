namespace TestSA2.Web.Mvc.Controllers.Products.Queries
{
  using System;
  using System.Linq;

  using MvcContrib.Pagination;

  using NHibernate.Linq;
  using NHibernate.Transform;

  using SharpArch.NHibernate;

  using TestSA2.Domain;
  using TestSA2.Web.Mvc.Controllers.Products.Queries.Contracts;
  using TestSA2.Web.Mvc.Controllers.Products.ViewModels;

  public class ProductQueries : NHibernateQuery, IProductQueries
  {
    public IPagination<ProductListViewModel> GetPagedList(int pageIndex, int pageSize)
    {
      var query = Session.QueryOver<Product>()
        .OrderBy(product => product.ProductName).Asc;

      var countQuery = query.ToRowCountQuery();
      var totalCount = countQuery.FutureValue<int>();

      var firstResult = (pageIndex - 1) * pageSize;

      ProductListViewModel viewModel = null;
      var viewModels = query.SelectList(list => list
                              .Select(mission => mission.Id).WithAlias(() => viewModel.Id)
                              .Select(mission => mission.ProductName).WithAlias(() => viewModel.Name)
                              .Select(mission => mission.ProductName).WithAlias(() => viewModel.Name))
        .TransformUsing(Transformers.AliasToBean(typeof(ProductListViewModel)))
        .Skip(firstResult)
        .Take(pageSize)
        .Future<ProductListViewModel>();

      return new CustomPagination<ProductListViewModel>(viewModels, pageIndex, pageSize, totalCount.Value);
    }

    public ProductViewModel GetViewModel(int id)
    {
      return Session.Query<Product>()
          .Where(product => product.Id == id)
          .Select(product => new ProductViewModel
                                {
                                  Id = product.Id,
                                  Name = product.ProductName
                                })
          .SingleOrDefault();
    }
  }
}