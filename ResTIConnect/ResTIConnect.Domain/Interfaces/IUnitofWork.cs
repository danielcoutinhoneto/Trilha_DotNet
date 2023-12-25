namespace ResTIConnect.Domain.Interfaces;

public interface IUnitofWork
{
    Task Commit(CancellationToken cancellationToken);
}
