using ShopThoiTrang.BackEnd.Databases;
using ShopThoiTrang.BackEnd.IRepositories;

namespace ShopThoiTrang.BackEnd.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private MainDbContext _dbContext;
    private async Task<List<T>> GetAllData() {
        return _dbContext.Set<T>().ToList();
    }
    public GenericRepository(MainDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> Create(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        return _dbContext.SaveChanges();
    }

    public async Task<int> Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        return _dbContext.SaveChanges();
    }

    public async Task<List<T>> FetchData()
    {
        return await GetAllData();
    }

    public async Task<int> Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        return _dbContext.SaveChanges();
    }
}