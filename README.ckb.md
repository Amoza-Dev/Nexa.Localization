# Nexa.Localization

فریموێرکێکی مۆدێرن، خێرا و بەهێز بۆ بەڕێوەبردنی Localization لە .NET.

**Nexa.Localization** فریموێرکێکی سووک و Strongly Typed ـە کە بە JSON Resources و Roslyn Incremental Source Generator دروستکراوە. ئەم فریموێرکە کلیلەکانی Localization لە کاتی Compile دروست دەکات، گۆڕینی زمان لە Runtime، Dependency Injection، Startup Validation و دیزاینێکی پاک و سەربەخۆ لە UI Framework دابین دەکات.

---

# تایبەتمەندییەکان

## Localization

- پشتگیری لە JSON
- Strongly Typed Localization Keys
- گۆڕینی زمان لە Runtime
- پشتگیری لە چەند زمان
- Fallback Culture
- پشتگیری لە RTL

## Performance

- خێرایی زۆر بەرز
- Thread-safe Localization Cache
- Startup Validation
- کەمترین بەکارهێنانی Memory

## Developer Experience

- Roslyn Incremental Source Generator
- IntelliSense
- Compile-time Safety
- Refactoring Friendly
- بێ Magic Strings
- Dependency Injection Integration

## Architecture

- Clean Architecture
- Cross-platform
- UI Framework Independent
- Extensible Provider Architecture

---

# پلاتفۆرمە پشتگیریکراوەکان

- ASP.NET Core
- Blazor
- WinForms
- WPF
- .NET MAUI
- Console Applications
- Class Libraries

---

# دامەزراندن

دامەزراندنی پەکێجی سەرەکی:

```bash
dotnet add package Nexa.Localization
```

دامەزراندنی Source Generator:

```bash
dotnet add package Nexa.Localization.SourceGenerator
```

---

# دەستپێکردنی خێرا

## ١. تۆمارکردنی Localization

```csharp
builder.Services.AddNexaLocalization(options =>
{
    options.DefaultCulture = "ckb";
    options.FallbackCulture = "en";

    options.AddDefaultLanguages();
});
```

## ٢. دەستپێکردنی Localization

```csharp
var app = builder.Build();

await app.Services.InitializeNexaLocalizationAsync();

app.Run();
```

---

# پێکهاتەی Localization

```text
Shared/
└── Localization/
    ├── ckb/
    ├── en/
    └── ar/
```

نمونەی فایل:

```json
{
    "button.save": "پاشەکەوت",
    "button.cancel": "هەڵوەشاندنەوە"
}
```

---

# بەکارهێنانی Strongly Typed Keys

Source Generator بە شێوەی خۆکار هەموو Localization Key ـەکان دەگۆڕێت بۆ C# Properties.

```csharp
NexaKeys.Button.Save

NexaKeys.Button.Cancel

NexaKeys.Status.Active

NexaKeys.Dialog.Confirm
```

لە Razor:

```razor
<button>@NexaKeys.Button.Save</button>

<span>@NexaKeys.Status.Active</span>
```

سوودەکان:

- IntelliSense
- Compile-time Safety
- بێ Magic Strings
- Refactoring Friendly
- کارایی باشتر

---

# Resource Library

Nexa.Localization لەگەڵ کۆمەڵێک Localization Resource ـی ئامادە دێت.

### ئاماری ئێستا

| بابەت | ژمارە |
|-------|------:|
| زمان | 3 |
| JSON Files | 87 |
| Localization Keys | 2,469 |

زمانە پشتگیریکراوەکان:

- English (en)
- کوردی (ckb)
- العربية (ar)

بۆ بینینی تەواوی فایلەکان و Localization Key ـەکان، `ResourceLibrary.md` بخوێنەوە.

---

# ڕێکخستن

```csharp
builder.Services.AddNexaLocalization(options =>
{
    options.DefaultCulture = "ckb";
    options.FallbackCulture = "en";

    options.EnableCaching = true;
    options.ValidateOnStartup = true;

    options.AddDefaultLanguages();
});
```

---

# زیادکردنی زمان

```csharp
options.AddKurdish();

options.AddEnglish();

options.AddArabic();

options.AddDefaultLanguages();
```

یان زمانی خۆت زیاد بکە:

```csharp
options.AddLanguage(
    code: "fr",
    name: "French",
    nativeName: "Français");
```

---

# پەکێجەکان

| پەکێج | دۆخ | دەربارە |
|--------|:---:|----------|
| Nexa.Localization | ✅ | فریموێرکی سەرەکی |
| Nexa.Localization.SourceGenerator | ✅ | Strongly Typed Keys |
| Nexa.Localization.Blazor | 🚧 | بەزوویی |
| Nexa.Localization.WinForms | 📅 | لە پلاندانایە |
| Nexa.Localization.WPF | 📅 | لە پلاندانایە |
| Nexa.Localization.MAUI | 📅 | لە پلاندانایە |

---

# ڕێگای داهاتوو (Roadmap)

## Version 1.x

- Blazor Integration
- WinForms Integration
- WPF Integration
- .NET MAUI Integration
- Cookie Language Storage
- Browser LocalStorage
- Session Storage
- Database Storage
- Performance Benchmarks

## داهاتوو

- AI Translation
- AI Resource Suggestions
- AI Missing Key Detection
- Cloud Resource Synchronization
- Visual Studio Extension
- CLI Tools

---

# بەڵگەنامە

بەڵگەنامەکانی Nexa.Localization بریتین لە:

- دەستپێکردن
- دامەزراندن
- ڕێکخستن
- Source Generator
- Resource Library
- Runtime API
- باشترین شێوازەکانی بەکارهێنان
- نموونە پڕۆژەکان

بەڵگەنامەکان بە زمانی:

- English
- کوردی
- العربية

بڵاودەکرێنەوە.

---

# مۆڵەت

ئەم پڕۆژەیە بە **MIT License** بڵاودەکرێتەوە.

بۆ زانیاری زیاتر، فایلەکەی **LICENSE** بخوێنەوە.