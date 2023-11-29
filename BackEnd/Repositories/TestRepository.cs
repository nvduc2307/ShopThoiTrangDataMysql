using ShopThoiTrang.BackEnd.Databases;
using ShopThoiTrang.BackEnd.Entities;

namespace ShopThoiTrang.BackEnd.Repositories;
public class TestRepository : GenericRepository<ProductEntity>
{
    public TestRepository(MainDbContext dbContext) : base(dbContext)
    {
    }
}