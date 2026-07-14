# Nexa.Localization

**Nexa.Localization** فریموێرکێکی خێرا، سووک و مۆدێرنە بۆ بەڕێوەبردنی زمان (Localization) لە .NET.

ئەم فریموێرکە پشتگیری دەکات لە JSON، کلیلە بەهێزەکان (Strongly Typed Keys) بە بەکارهێنانی Roslyn Incremental Source Generator، گۆڕینی زمان لە کاتی جێبەجێکردن (Runtime)، Dependency Injection، پشکنینی هەڵە لە کاتی دەستپێکردن و دیزاینێکی پاک کە سەربەخۆیە لە هەر UI Framework ـێک.

---

# تایبەتمەندییەکان

## Localization

- پشتگیری لە JSON
- Strongly Typed Localization Keys
- گۆڕینی زمان لە Runtime
- پشتگیری لە چەند زمان
- Fallback Culture
- پشتگیری لە RTL

---

## کارایی (Performance)

- خێرایی زۆر بەرز
- Thread-safe Localization Cache
- Startup Validation
- کەمترین بەکارهێنانی Memory

---

## Developer Experience

- Incremental Source Generator
- IntelliSense
- Compile-time Safety
- Refactoring Friendly
- بێ بەکارهێنانی Magic String
- Dependency Injection

---

## دیزاین

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

دامەزراندنی پەکێجی سەرەکی.

```bash
dotnet add package Nexa.Localization
```

دامەزراندنی Source Generator.

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

---

## ٢. دەستپێکردنی Localization

```csharp
var app = builder.Build();

await app.Services.InitializeNexaLocalizationAsync();

app.Run();
```

---

# ڕێکخستنی Localization

```
Shared/
└── Localization/
    ├── ckb/
    │   ├── button.json
    │   ├── status.json
    │   ├── invoice.json
    │   └── ...
    │
    ├── en/
    │   ├── button.json
    │   ├── status.json
    │   ├── invoice.json
    │   └── ...
    │
    └── ar/
        ├── button.json
        ├── status.json
        ├── invoice.json
        └── ...
```

نمونە:

```json
{
  "button.save": "پاشەکەوت",
  "button.cancel": "هەڵوەشاندنەوە"
}
```

---

# بەکارهێنانی Strongly Typed Keys

تەنها کلیلە دروستکراوەکان بەکاربهێنە.

```razor
<h3>@NexaKeys.Button.Save</h3>

<button>@NexaKeys.Button.Cancel</button>

<span>@NexaKeys.Status.Active</span>
```

پێویست ناکات `ILocalizationService` Inject بکەیت.

---

# Source Generator

Incremental Source Generator بە شێوەی خۆکار کلیلەکان دروست دەکات.

نمونە:

```csharp
NexaKeys.Button.Save

NexaKeys.Button.Cancel

NexaKeys.Status.Active

NexaKeys.Invoice.Create.Success
```

---

## سوودەکان

- IntelliSense
- Compile-time Safety
- Refactoring Friendly
- بێ Magic String
- کارایی باشتر

---

# ڕێکخستن

```csharp
builder.Services.AddNexaLocalization(options =>
{
    options.DefaultCulture = "ckb";

    options.FallbackCulture = "en";

    options.EnableCaching = true;

    options.ValidateOnStartup = true;

    options.ThrowIfKeyNotFound = false;

    options.ReloadOnChange = false;

    options.AddDefaultLanguages();
});
```

---

# زیادکردنی زمان

زمانە بنەڕەتییەکان:

```csharp
options.AddKurdish();

options.AddEnglish();

options.AddArabic();

options.AddDefaultLanguages();
```

یان زمانی خۆت زیاد بکە.

```csharp
options.AddLanguage(
    code: "fr",
    name: "French",
    nativeName: "Français");
```

---

# پێکهاتەی پڕۆژە

```
Nexa.Localization
│
├── Abstractions
├── Caching
├── Exceptions
├── Extensions
├── Helpers
├── Models
├── Providers
├── Runtime
├── Services
├── Storage
└── Validation
```

پەکێجە تایبەتەکانی هەر Platform ـێک بە جیاوازی بڵاودەکرێنەوە.

---

# پەکێجەکان

| پەکێج | دەربارە |
|--------|----------|
| Nexa.Localization | فریموێرکی سەرەکی |
| Nexa.Localization.SourceGenerator | دروستکردنی Strongly Typed Keys |
| Nexa.Localization.Blazor *(بەزوویی)* | یەکگرتن لەگەڵ Blazor |
| Nexa.Localization.WinForms *(لە پلاندانایە)* | پشتگیری WinForms |
| Nexa.Localization.WPF *(لە پلاندانایە)* | پشتگیری WPF |
| Nexa.Localization.MAUI *(لە پلاندانایە)* | پشتگیری .NET MAUI |

---

# پلانی داهاتوو

## Version 1.x

- Blazor Integration
- WinForms Integration
- WPF Integration
- MAUI Integration
- Cookie Language Storage
- Browser LocalStorage
- Session Storage
- Database Storage
- Embedded Resource Provider
- Resource Overriding
- Performance Benchmarks

---

# بەڵگەنامە

بەڵگەنامەکان لە داهاتوودا ئەمانە لەخۆ دەگرن:

- دەستپێکردن
- دامەزراندن
- ڕێکخستن
- Source Generator
- Runtime API
- Best Practices
- نموونە پڕۆژەکان

بەڵگەنامە بە سێ زمان ئامادە دەبێت:

- 🇬🇧 English
- 🇹🇯 کوردی
- 🇸🇦 العربية

---

# مۆڵەت

ئەم پڕۆژەیە بە **MIT License** بڵاودەکرێتەوە.

بۆ زانیاری زیاتر، فایلەکەی **LICENSE** بخوێنەوە.