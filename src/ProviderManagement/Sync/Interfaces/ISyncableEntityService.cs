namespace ProviderManagement.Sync.Interfaces;

internal interface ISyncableEntityService<TEntity>
{
    Task<IEnumerable<TEntity>> Get();
}