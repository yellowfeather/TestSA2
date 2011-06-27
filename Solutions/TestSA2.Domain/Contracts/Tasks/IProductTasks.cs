namespace TestSA2.Domain.Contracts.Tasks
{
  public interface IProductTasks
  {
    Product Create(string name);

    void Update(int id, string name);

    void Delete(int id);
  }
}