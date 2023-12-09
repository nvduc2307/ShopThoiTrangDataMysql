using ShopThoiTrang.BackEnd.Entities;

namespace ShopThoiTrang.BackEnd.IRepositories;
public interface IUserRepository : IGenericRepository<UserEntity> {
    Task<UserEntity> Login(LogginInfo logginInfo);
    Task<List<UserEntity>> GetUsers();
}