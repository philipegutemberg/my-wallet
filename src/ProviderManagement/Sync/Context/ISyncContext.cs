namespace ProviderManagement.Sync.Context;

internal interface ISyncContext
{
    void Add<TValue>(string key, TValue value);

    void Remove(string key);

    TValue? Get<TValue>(string key);

    bool Exists(string key);

    bool Exists<TValue>(string key);
}