using ResTIConnect.Domain.Interfaces;
using ResTIConnect.Persistence.Context;

namespace ResTIConnect.Persistence;

public class UnitOfWork : IUnitofWork
{
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task Commit(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
