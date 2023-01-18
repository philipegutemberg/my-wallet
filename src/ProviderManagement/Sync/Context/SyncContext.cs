namespace ProviderManagement.Sync.Context;

internal class SyncContext : ISyncContext
{
    private readonly Dictionary<string, object> _dictionary;

    public SyncContext()
    {
        _dictionary = new Dictionary<string, object>();
    }

    public void Add<TValue>(string key, TValue value)
    {
        if (value == null) return;

        if (Exists(key))
            Remove(key);

        _dictionary.Add(key, value);
    }

    public void Remove(string key) => _dictionary.Remove(key);

    public TValue? Get<TValue>(string key)
    {
        if (_dictionary.ContainsKey(key))
        {
            var value = _dictionary[key];

            if (value.GetType().IsAssignableTo(typeof(TValue)))
                return (TValue)value;
        }

        return default;
    }

    public bool Exists(string key) => _dictionary.ContainsKey(key);

    public bool Exists<TValue>(string key) => Get<TValue>(key) != null;
}