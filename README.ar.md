# Nexa.Localization

إطار عمل سريع وعالي الأداء لإدارة الترجمة (Localization) لتطبيقات .NET.

**Nexa.Localization** هو إطار عمل خفيف، سريع وقابل للتوسع لإدارة اللغات المتعددة في تطبيقات .NET. يعتمد على ملفات JSON، ويولّد مفاتيح ترجمة **Strongly Typed** باستخدام **Source Generator**، ويدعم تغيير اللغة أثناء التشغيل، مع بنية نظيفة ومستقلة عن أي إطار عمل لواجهة المستخدم.

---

## ✨ المميزات

### 🌍 الترجمة

- الترجمة باستخدام ملفات JSON
- مفاتيح ترجمة Strongly Typed
- تغيير اللغة أثناء التشغيل (Runtime)
- Language Manager
- حفظ اللغة المختارة
- دعم اللغات من اليمين إلى اليسار (RTL)

### ⚡ الأداء

- أداء عالي
- ذاكرة تخزين مؤقت (Cache) آمنة للخيوط (Thread-safe)
- التحقق من صحة الملفات عند بدء التشغيل

### 🛠 تجربة المطور

- Incremental Source Generator
- التحقق أثناء وقت الترجمة (Compile-time Validation)
- دعم Dependency Injection
- دعم IntelliSense
- دعم إعادة هيكلة الكود (Refactoring)

### 🏗 البنية

- Clean Architecture
- مستقل عن أي إطار عمل لواجهة المستخدم
- بنية قابلة للتوسع باستخدام Provider Architecture

---

## 💻 المنصات المدعومة

- ASP.NET Core
- Blazor
- WinForms
- WPF
- .NET MAUI
- تطبيقات Console
- Class Libraries

---

## 📦 التثبيت

تثبيت المكتبة الأساسية:

```powershell
Install-Package Nexa.Localization
```

أو

```bash
dotnet add package Nexa.Localization
```

تثبيت Source Generator:

```powershell
Install-Package Nexa.Localization.SourceGenerator
```

أو

```bash
dotnet add package Nexa.Localization.SourceGenerator
```

---

## 🚀 البدء السريع

### 1. تسجيل خدمات Localization

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

### 2. تحميل ملفات الترجمة

```csharp
await localizationLoader.LoadAsync();

await languageManager.InitializeAsync();

validator.Validate();
```

---

## 📖 الاستخدام

قم بحقن خدمة Localization.

```csharp
@inject ILocalizationService L
```

ثم استخدم مفاتيح الترجمة Strongly Typed.

```csharp
<h1>@L[Nexa.Buttons.Save]</h1>

<button>@L[Nexa.Buttons.Cancel]</button>

<span>@L[Nexa.Menu.Dashboard]</span>
```

---

## 📂 بنية ملفات الترجمة

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

مثال:

```json
{
  "Buttons.Save": "حفظ",
  "Buttons.Cancel": "إلغاء",
  "Menu.Dashboard": "لوحة التحكم"
}
```

---

## ⚙️ Source Generator

يقوم **Nexa.Localization.SourceGenerator** تلقائياً بإنشاء مفاتيح الترجمة Strongly Typed أثناء عملية البناء (Build).

مثال:

```csharp
Nexa.Buttons.Save

Nexa.Buttons.Cancel

Nexa.Menu.Dashboard

Nexa.Errors.NotFound
```

### الفوائد

- IntelliSense
- الأمان أثناء الترجمة (Compile-time Safety)
- دعم إعادة هيكلة الكود
- التخلص من Magic Strings
- أداء أفضل
- تقليل أخطاء الكتابة

---

## 🏗 بنية المشروع

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

المكتبة الأساسية مستقلة تماماً عن أي إطار عمل لواجهة المستخدم.

أما التكامل مع المنصات المختلفة فيتم توفيره من خلال حزم مستقلة.

---

## 🗺 خارطة الطريق

### الإصدار 1.x

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

## 📚 التوثيق

سيتم توفير التوثيق الكامل داخل مجلد `docs`.

- البدء السريع
- الإعداد
- Source Generator
- بنية المشروع
- مرجع API
- أمثلة عملية

يتوفر التوثيق باللغات التالية:

- English
- کوردی
- العربية

---

## 📄 الترخيص

هذا المشروع مرخّص بموجب **MIT License**.

يرجى مراجعة ملف **LICENSE** لمزيد من التفاصيل.