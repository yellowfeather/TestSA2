namespace TestSA2.Web.Mvc.Controllers.Products.Queries.Contracts
{
  using MvcContrib.Pagination;

  using TestSA2.Web.Mvc.Controllers.Products.ViewModels;

  public interface IProductQueries
  {
    IPagination<ProductListViewModel> GetPagedList(int pageIndex, int pageSize);

    ProductViewModel GetViewModel(int id);
  }
}