namespace ShopThoiTrang.BackEnd.IRepositories;
public interface IGenericRepository<T> where T : class {
    public Task<List<T>> FetchData();
    public Task<int> Create(T entity);
    public Task<int> Update(T entity);
    public Task<int> Delete(T entity);
}