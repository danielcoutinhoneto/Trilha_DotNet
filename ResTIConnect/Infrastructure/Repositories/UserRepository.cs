using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Domain.Interfaces;
using ResTIConnect.Persistence.Context;

namespace ResTIConnect.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    { }

    public async Task<User> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return await Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

}
