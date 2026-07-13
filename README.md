# Nexa.Localization

A high-performance, enterprise-ready localization framework for modern .NET applications.

**Nexa.Localization** is a lightweight, fast, and extensible localization framework for .NET. It provides JSON-based localization, strongly typed localization keys powered by Source Generators, runtime language switching, startup validation, dependency injection, and a clean architecture independent of any UI framework.

---

## Features

### Localization

- JSON-based localization
- Strongly typed localization keys
- Runtime language switching
- Language Manager
- Culture persistence
- Right-to-left (RTL) support

### Performance

- High performance
- Thread-safe localization cache
- Startup validation

### Developer Experience

- Incremental Source Generator
- Compile-time validation
- Dependency Injection support
- IntelliSense support
- Refactoring friendly

### Architecture

- Clean Architecture
- UI framework independent
- Extensible provider architecture

---

## Supported Platforms

- ASP.NET Core
- Blazor
- WinForms
- WPF
- .NET MAUI
- Console Applications
- Class Libraries

---

## Installation

Install the NuGet package.

```powershell
Install-Package Nexa.Localization
```

or

```bash
dotnet add package Nexa.Localization
```

For strongly typed localization keys, install the Source Generator package.

```powershell
Install-Package Nexa.Localization.SourceGenerator
```

or

```bash
dotnet add package Nexa.Localization.SourceGenerator
```

---

## Quick Start

### Register localization

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

Load localization resources during application startup.

```csharp
await localizationLoader.LoadAsync();

await languageManager.InitializeAsync();

validator.Validate();
```

---

## Usage

Inject the localization service.

```csharp
@inject ILocalizationService L
```

Use strongly typed localization keys.

```csharp
<h1>@L[Nexa.Buttons.Save]</h1>

<button>@L[Nexa.Buttons.Cancel]</button>

<span>@L[Nexa.Menu.Dashboard]</span>
```

---

## Localization Structure

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

Example:

```json
{
  "Buttons.Save": "Save",
  "Buttons.Cancel": "Cancel",
  "Menu.Dashboard": "Dashboard"
}
```

---

## Source Generator

Nexa.Localization.SourceGenerator automatically generates strongly typed localization keys during compilation.

Example:

```csharp
Nexa.Buttons.Save

Nexa.Buttons.Cancel

Nexa.Menu.Dashboard

Nexa.Errors.NotFound
```

### Benefits

- IntelliSense
- Compile-time safety
- Refactoring support
- No magic strings
- Better performance
- Reduced typing errors

---

## Architecture

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

The runtime is completely independent of any UI framework.

Platform-specific integrations are provided through separate packages.

---

## Roadmap

### Version 1.x

- Nexa.Localization.Blazor
- Nexa.Localization.AspNetCore
- Nexa.Localization.WinForms
- Nexa.Localization.WPF
- Nexa.Localization.MAUI
- Cookie language storage
- LocalStorage language storage
- Database language storage
- Embedded resource localization
- Project localization overriding
- Performance benchmarks

---

## Documentation

Documentation will be available in the `docs` directory.

- Getting Started
- Configuration
- Source Generator
- Architecture
- API Reference
- Samples

Documentation will be provided in:

- English
- Kurdish
- Arabic

---

## License

Licensed under the MIT License.

See the `LICENSE` file for more information.