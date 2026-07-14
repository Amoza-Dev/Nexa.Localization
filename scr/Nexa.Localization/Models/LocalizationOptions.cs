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

    public LocalizationOptions AddLanguage(
        string code,
        string name,
        string nativeName,
        bool rtl = false,
        string? flag = null)
    {
        SupportedLanguages.Add(new Language
        {
            Code = code,
            Name = name,
            NativeName = nativeName,
            IsRightToLeft = rtl,
            Flag = flag
        });

        return this;
    }

    public LocalizationOptions AddKurdish()
    {
        return AddLanguage(
            code: "ckb",
            name: "Kurdish",
            nativeName: "کوردی",
            rtl: true,
            flag: "🇮🇶");
    }

    public LocalizationOptions AddEnglish()
    {
        return AddLanguage(
            code: "en",
            name: "English",
            nativeName: "English",
            flag: "🇺🇸");
    }

    public LocalizationOptions AddArabic()
    {
        return AddLanguage(
            code: "ar",
            name: "Arabic",
            nativeName: "العربية",
            rtl: true,
            flag: "🇸🇦");
    }
    public LocalizationOptions AddDefaultLanguages()
    {
        return AddKurdish()
            .AddEnglish()
            .AddArabic();
    }
}