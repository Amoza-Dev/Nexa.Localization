# Nexa.Localization

فریم‌وەرکێکی Localization ی خێرا، Enterprise و گەشەپێدراو بۆ ئەپلیکەیشنەکانی .NET.

**Nexa.Localization** فریم‌وەرکێکی سووک، خێرا و فراوانکراوەیە بۆ بەڕێوەبردنی زمانە جیاوازەکان لە ئەپلیکەیشنەکانی .NET. پشت بە فایلەکانی JSON دەبەستێت، کلیلی Localization بە شێوەی **Strongly Typed** بەکارهێنانی **Source Generator** دروست دەکات، گۆڕینی زمان لە کاتی کارکردندا پشتگیری دەکات و بە هیچ UI Framework ـێک پابەند نییە.

---

## ✨ تایبەتمەندییەکان

### 🌍 Localization

- Localization بە بنەمای JSON
- کلیلی Strongly Typed
- گۆڕینی زمان لە کاتی Runtime
- Language Manager
- پاراستنی زمانی هەڵبژێردراو
- پشتگیری RTL

### ⚡ کارایی

- کارایی بەرز
- Cache ـی Thread-safe
- Validation لە Startup

### 🛠 گەشەپێدان

- Incremental Source Generator
- Compile-time Validation
- پشتگیری Dependency Injection
- IntelliSense
- Refactoring Friendly

### 🏗 تەلارماری فریم‌وەرک

- Clean Architecture
- سەربەخۆ لە UI Framework
- تەلارماری Provider ـی فراوانکراو

---

## 💻 پلاتفۆرمە پشتگیریکراوەکان

- ASP.NET Core
- Blazor
- WinForms
- WPF
- .NET MAUI
- Console Applications
- Class Libraries

---

## 📦 دامەزراندن

دامەزراندنی Runtime:

```powershell
Install-Package Nexa.Localization
```

یان

```bash
dotnet add package Nexa.Localization
```

دامەزراندنی Source Generator:

```powershell
Install-Package Nexa.Localization.SourceGenerator
```

یان

```bash
dotnet add package Nexa.Localization.SourceGenerator
```

---

## 🚀 دەستپێکردنی خێرا

### ١. تۆمارکردنی Localization

```csharp
builder.Services.AddNexaLocalization(options =>
{
    options.DefaultCulture = "en";
    options.FallbackCulture = "en";

    options.SupportedLanguages.Add(new Language
    {
        Code = "en",
        Name = "English",
        NativeName = "English"
    });

    options.SupportedLanguages.Add(new Language
    {
        Code = "ku",
        Name = "Kurdish",
        NativeName = "کوردی",
        IsRightToLeft = false
    });

    options.SupportedLanguages.Add(new Language
    {
        Code = "ar",
        Name = "Arabic",
        NativeName = "العربية",
        IsRightToLeft = true
    });
});
```

### ٢. بارکردنی فایلەکانی Localization

```csharp
await localizationLoader.LoadAsync();

await languageManager.InitializeAsync();

validator.Validate();
```

---

## 📖 بەکارهێنان

Localization Service ـەکە Inject بکە.

```csharp
@inject ILocalizationService L
```

پاشان کلیلە Strongly Typed ـەکان بەکاربهێنە.

```csharp
<h1>@L[Nexa.Buttons.Save]</h1>

<button>@L[Nexa.Buttons.Cancel]</button>

<span>@L[Nexa.Menu.Dashboard]</span>
```

---

## 📂 ڕێکخستنی فایلەکان

```
Shared/
└── Localization/
    ├── en/
    │   ├── buttons.json
    │   ├── menu.json
    │   └── errors.json
    │
    ├── ku/
    │   ├── buttons.json
    │   ├── menu.json
    │   └── errors.json
    │
    └── ar/
        ├── buttons.json
        ├── menu.json
        └── errors.json
```

نمونەی فایل:

```json
{
  "Buttons.Save": "پاشەکەوت",
  "Buttons.Cancel": "هەڵوەشاندنەوە",
  "Menu.Dashboard": "داشبۆرد"
}
```

---

## ⚙️ Source Generator

لە کاتی Build، **Nexa.Localization.SourceGenerator** بە شێوەی خۆکار کلیلە Localization ـەکان دروست دەکات.

نمونە:

```csharp
Nexa.Buttons.Save

Nexa.Buttons.Cancel

Nexa.Menu.Dashboard

Nexa.Errors.NotFound
```

### سوودەکان

- IntelliSense
- Compile-time Safety
- Refactoring Support
- No Magic Strings
- کارایی بەرز
- کەمکردنەوەی هەڵەی نووسین

---

## 🏗 تەلارماری فریم‌وەرک

```
Nexa.Localization
│
├── Abstractions
├── Caching
├── Components
├── Exceptions
├── Extensions
├── Helpers
├── Models
├── Providers
├── Services
└── Validation
```

Core ـی فریم‌وەرک تەواو سەربەخۆیە و هیچ UI Framework ـێک ناسێت.

هەموو Integration ـەکان لە Package ـی جیاواز دابین دەکرێن.

---

## 🗺 پلانی داهاتوو

### Version 1.x

- Nexa.Localization.Blazor
- Nexa.Localization.AspNetCore
- Nexa.Localization.WinForms
- Nexa.Localization.WPF
- Nexa.Localization.MAUI
- Cookie Language Storage
- LocalStorage Language Storage
- Database Language Storage
- Embedded Resource Localization
- Project Localization Override
- Performance Benchmarks

---

## 📚 بەڵگەنامەکان

بەڵگەنامەکانی تەواو لە فۆڵدەری `docs` دابین دەکرێن.

- دەستپێکردن
- ڕێکخستن
- Source Generator
- تەلارماری فریم‌وەرک
- API Reference
- نمونەکان

بەڵگەنامەکان بە سێ زمان دابین دەکرێن:

- English
- کوردی
- العربية

---

## 📄 مۆڵەت

ئەم پرۆژەیە بە **MIT License** بڵاوکراوەتەوە.

بۆ زانیاری زیاتر، فایلەکەی **LICENSE** بخوێنەوە.