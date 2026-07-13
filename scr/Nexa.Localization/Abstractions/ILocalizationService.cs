public interface ILocalizationService
{
    string this[string key] { get; }

    string Get(string key);

    string Get(string key, params object[] arguments);

    bool TryGet(string key, out string value);

    bool ContainsKey(string key);
}