using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmail(string email, CancellationToken cancellationToken);
}
