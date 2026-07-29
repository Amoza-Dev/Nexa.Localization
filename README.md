# Nexa.Localization

A modern, strongly typed localization framework for .NET powered by JSON resources and Roslyn Incremental Source Generators.

## Why Nexa.Localization?

Nexa.Localization is designed for modern .NET applications that require a fast, maintainable, and scalable localization system.

It combines JSON-based resources with compile-time generated localization keys to eliminate magic strings, improve developer productivity, and provide excellent runtime performance.

### Features

- JSON-based localization
- Strongly typed localization keys
- Roslyn Incremental Source Generator
- Runtime language switching
- Multiple language support
- Fallback culture support
- Right-to-left (RTL) support
- Dependency Injection integration
- Startup validation
- Thread-safe caching
- High-performance lookup
- Cross-platform
- Framework independent

---

# Supported Platforms

- ✅ ASP.NET Core
- ✅ Blazor
- ✅ WinForms
- ✅ WPF
- ✅ .NET MAUI
- ✅ Console Applications
- ✅ Class Libraries

---

# Installation

Install the runtime package.

```bash
dotnet add package Nexa.Localization
```

Install the Source Generator.

```bash
dotnet add package Nexa.Localization.SourceGenerator
```

---

# Quick Start

## Register Localization

```csharp
builder.Services.AddNexaLocalization(options =>
{
    options.DefaultCulture = "ckb";
    options.FallbackCulture = "en";

    options.AddDefaultLanguages();
});
```

---

## Initialize Localization

```csharp
var app = builder.Build();

await app.Services.InitializeNexaLocalizationAsync();

app.Run();
```

---

## Folder Structure

```
Shared/
└── Localization/
    ├── ckb/
    ├── en/
    └── ar/
```

Example:

```json
{
    "button.save": "Save",
    "button.cancel": "Cancel"
}
```

---

# Using Generated Keys

The Source Generator automatically generates strongly typed localization keys.

```csharp
NexaKeys.Button.Save

NexaKeys.Button.Cancel

NexaKeys.Dialog.Confirm

NexaKeys.Validation.Required
```

Example in Razor:

```razor
<button>@NexaKeys.Button.Save</button>

<span>@NexaKeys.Status.Active</span>
```

### Benefits

- IntelliSense support
- Compile-time safety
- No magic strings
- Refactoring friendly
- Better performance

---

# Built-in Resource Library

Nexa.Localization ships with a production-ready localization resource library.

Current library includes:

| Item | Count |
|------|------:|
| Languages | 3 |
| JSON Files | 87 |
| Localization Keys | 2,469 |

Supported languages:

- English (en)
- Kurdish (ckb)
- Arabic (ar)

See **ResourceLibrary.md** for the complete resource reference.

---

# Configuration

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

# Supported Language Helpers

```csharp
options.AddKurdish();

options.AddEnglish();

options.AddArabic();

options.AddDefaultLanguages();
```

Register your own language:

```csharp
options.AddLanguage(
    code: "fr",
    name: "French",
    nativeName: "Français");
```

---

# Packages

| Package | Status | Description |
|---------|:------:|-------------|
| Nexa.Localization | ✅ | Core localization framework |
| Nexa.Localization.SourceGenerator | ✅ | Strongly typed localization keys |
| Nexa.Localization.Blazor | 🚧 | Blazor integration |
| Nexa.Localization.WinForms | 📅 | Planned |
| Nexa.Localization.WPF | 📅 | Planned |
| Nexa.Localization.MAUI | 📅 | Planned |

---

# Documentation

Documentation is organized into dedicated guides.

- Getting Started
- Installation
- Configuration
- Source Generator
- Resource Library
- Runtime API
- Best Practices
- Samples
- AI Translation *(Planned)*

---

# Roadmap

## Version 1.x

- Blazor integration
- WinForms integration
- WPF integration
- .NET MAUI integration
- Cookie language storage
- Browser LocalStorage
- Session storage
- Database language storage
- Performance benchmarks

## Future

- AI Translation
- AI Resource Suggestions
- AI Missing Key Detection
- Cloud Resource Synchronization
- Visual Studio Extension
- CLI Tools

---

# License

Licensed under the MIT License.

See the `LICENSE` file for more information.