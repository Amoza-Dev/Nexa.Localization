# Nexa.Localization

A modern, high-performance localization framework for .NET.

**Nexa.Localization** is a lightweight, strongly typed localization framework powered by JSON resources and Roslyn Incremental Source Generators. It provides compile-time localization keys, runtime language switching, dependency injection, startup validation, and a clean architecture that works across multiple .NET platforms.

---

## Features

### Localization

- JSON-based localization
- Strongly typed localization keys
- Runtime language switching
- Multiple language support
- Fallback culture support
- Right-to-left (RTL) support

### Performance

- High-performance localization lookup
- Thread-safe localization cache
- Startup validation
- Minimal allocations

### Developer Experience

- Incremental Source Generator
- IntelliSense support
- Compile-time safety
- Refactoring friendly
- No magic strings
- Dependency Injection integration

### Architecture

- Clean Architecture
- Cross-platform
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

## 1. Register Services

```csharp
builder.Services.AddNexaLocalization(options =>
{
    options.DefaultCulture = "ckb";
    options.FallbackCulture = "en";

    options.AddDefaultLanguages();
});
```

---

## 2. Initialize Localization

```csharp
var app = builder.Build();

await app.Services.InitializeNexaLocalizationAsync();

app.Run();
```

---

# Localization Structure

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

Example:

```json
{
  "button.save": "Save",
  "button.cancel": "Cancel"
}
```

---

# Using Generated Keys

Simply use the generated localization keys.

```razor
<h3>@NexaKeys.Button.Save</h3>

<button>@NexaKeys.Button.Cancel</button>

<span>@NexaKeys.Status.Active</span>
```

No service injection is required.

---

# Source Generator

The Incremental Source Generator automatically generates strongly typed localization keys.

Generated example:

```csharp
NexaKeys.Button.Save

NexaKeys.Button.Cancel

NexaKeys.Status.Active

NexaKeys.Invoice.Create.Success
```

## Benefits

- IntelliSense
- Compile-time safety
- No magic strings
- Refactoring friendly
- Better performance

---

# Configuration

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

# Supported Language Helpers

```csharp
options.AddKurdish();

options.AddEnglish();

options.AddArabic();

options.AddDefaultLanguages();
```

Or register your own language.

```csharp
options.AddLanguage(
    code: "fr",
    name: "French",
    nativeName: "Français");
```

---

# Project Structure

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

Platform-specific integrations are distributed as separate packages.

---

# Packages

| Package | Description |
|---------|-------------|
| Nexa.Localization | Core localization framework |
| Nexa.Localization.SourceGenerator | Strongly typed localization keys |
| Nexa.Localization.Blazor *(Coming Soon)* | Blazor integration |
| Nexa.Localization.WinForms *(Planned)* | WinForms integration |
| Nexa.Localization.WPF *(Planned)* | WPF integration |
| Nexa.Localization.MAUI *(Planned)* | .NET MAUI integration |

---

# Roadmap

### Version 1.x

- Blazor integration
- WinForms integration
- WPF integration
- MAUI integration
- Cookie language storage
- Browser LocalStorage
- Session storage
- Database language storage
- Embedded resource provider
- Project resource overriding
- Performance benchmarks

---

# Documentation

Documentation includes:

- Getting Started
- Installation
- Configuration
- Source Generator
- Runtime API
- Best Practices
- Samples

Documentation will be available in:

- English
- Kurdish
- Arabic

---

# License

Licensed under the MIT License.

See the `LICENSE` file for more information.