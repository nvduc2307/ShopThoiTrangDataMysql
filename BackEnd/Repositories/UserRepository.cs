using Microsoft.EntityFrameworkCore;
using ShopThoiTrang.BackEnd.Databases;
using ShopThoiTrang.BackEnd.Entities;
using ShopThoiTrang.BackEnd.IRepositories;

namespace ShopThoiTrang.BackEnd.Repositories;
public class UserRepository : GenericRepository<UserEntity>, IUserRepository
{
    private MainDbContext _dbContext;

    public UserRepository(MainDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<UserEntity>> GetUsers()
    {
        var users = _dbContext.users.ToList();
        return users;
    }

    public async Task<UserEntity> Login(LogginInfo logginInfo)
    {
        UserEntity result = null;
        var users = _dbContext.users.ToList();
        var isExisted = users.Any(x=>x.UserName == logginInfo.UserName);
        if (isExisted)
        {
            var user = users.First(x=>x.UserName == logginInfo.UserName);
            if (user.Password == logginInfo.Password)
            {
                result = user;
            }
        }
        return result;
    }
}