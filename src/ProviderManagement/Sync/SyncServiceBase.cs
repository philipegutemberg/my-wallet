using ProviderManagement.Sync.Context;
using ProviderManagement.Sync.Interfaces;

namespace ProviderManagement.Sync;

internal abstract class SyncServiceBase<TEntity> : ISyncService
    where TEntity : ISyncableEntity
{
    private readonly ISyncContext _syncContext;
    private readonly ISyncableEntityService<TEntity> _syncableEntityService;

    protected SyncServiceBase(ISyncContext syncContext, ISyncableEntityService<TEntity> syncableEntityService)
    {
        _syncContext = syncContext;
        _syncableEntityService = syncableEntityService;
    }

    public async Task Sync()
    {
        await BeforeSync();

        IEnumerable<TEntity> returnedEntities = await _syncableEntityService.Get();

        var saved = await GetAllSaved();
        var toBeInserted = GetEntitiesToBeInserted(returnedEntities, saved);

        var inserted = await Insert(toBeInserted);

        saved = saved.Union(inserted).DistinctBy(e => e.GetSyncId());

        AddToContext(saved);
    }

    protected virtual Task BeforeSync() => Task.CompletedTask;
    protected abstract Task<IEnumerable<TEntity>> GetAllSaved();
    protected abstract Task<TEntity> Insert(TEntity entity);
    protected abstract string GetContextKey();

    private void AddToContext(IEnumerable<TEntity> entities) => _syncContext.Add(GetContextKey(), entities);

    private IEnumerable<TEntity> GetEntitiesToBeInserted(IEnumerable<TEntity> candidates, IEnumerable<TEntity> saved) =>
        candidates.Where(candidate =>
            saved.All(save => save.GetSyncId() != candidate.GetSyncId()));

    private async Task<IEnumerable<TEntity>> Insert(IEnumerable<TEntity> toBeInserted) =>
        await Task.WhenAll(toBeInserted.Select(Insert));
}