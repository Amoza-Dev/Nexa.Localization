namespace Nexa.Localization.Models;

public sealed class LocalizationOptions
{
    public string DefaultCulture { get; set; } = "ckb";

    public string FallbackCulture { get; set; } = "ckb";

    public bool EnableCaching { get; set; } = true;

    public bool ThrowIfKeyNotFound { get; set; } = false;

    public bool IgnoreKeyCase { get; set; } = true;

    public bool ValidateOnStartup { get; set; } = true;

    public bool ReloadOnChange { get; set; } = false;

    public IList<Language> SupportedLanguages { get; }
        = new List<Language>();
}