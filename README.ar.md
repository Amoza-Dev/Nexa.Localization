# Nexa.Localization

**Nexa.Localization** هو إطار عمل حديث وسريع لإدارة الترجمة (Localization) في تطبيقات .NET.

يوفر الإطار نظام ترجمة يعتمد على ملفات JSON، ومفاتيح ترجمة قوية (Strongly Typed Localization Keys) يتم إنشاؤها تلقائياً باستخدام Roslyn Incremental Source Generator، بالإضافة إلى تغيير اللغة أثناء التشغيل (Runtime)، ودعم Dependency Injection، والتحقق من صحة الإعدادات عند بدء التشغيل، مع بنية نظيفة ومستقلة عن أي إطار عمل للواجهات.

---

# المميزات

## الترجمة (Localization)

- الترجمة باستخدام ملفات JSON
- مفاتيح ترجمة قوية (Strongly Typed Keys)
- تغيير اللغة أثناء التشغيل
- دعم تعدد اللغات
- دعم لغة احتياطية (Fallback Culture)
- دعم اللغات من اليمين إلى اليسار (RTL)

---

## الأداء

- أداء عالي
- Thread-safe Localization Cache
- التحقق من صحة الإعدادات عند بدء التشغيل
- أقل استهلاك ممكن للذاكرة

---

## تجربة المطور

- Incremental Source Generator
- دعم IntelliSense
- أمان وقت الترجمة (Compile-time Safety)
- سهل إعادة الهيكلة (Refactoring Friendly)
- بدون Magic Strings
- تكامل كامل مع Dependency Injection

---

## البنية

- Clean Architecture
- Cross-platform
- مستقل عن أي UI Framework
- بنية قابلة للتوسعة (Extensible Provider Architecture)

---

# المنصات المدعومة

- ASP.NET Core
- Blazor
- WinForms
- WPF
- .NET MAUI
- Console Applications
- Class Libraries

---

# التثبيت

تثبيت الحزمة الأساسية:

```bash
dotnet add package Nexa.Localization
```

تثبيت Source Generator:

```bash
dotnet add package Nexa.Localization.SourceGenerator
```

---

# البدء السريع

## 1. تسجيل الخدمات

```csharp
builder.Services.AddNexaLocalization(options =>
{
    options.DefaultCulture = "ckb";
    options.FallbackCulture = "en";

    options.AddDefaultLanguages();
});
```

---

## 2. تهيئة نظام الترجمة

```csharp
var app = builder.Build();

await app.Services.InitializeNexaLocalizationAsync();

app.Run();
```

---

# هيكل ملفات الترجمة

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

مثال:

```json
{
  "button.save": "حفظ",
  "button.cancel": "إلغاء"
}
```

---

# استخدام المفاتيح المولدة

يكفي استخدام المفاتيح التي يتم توليدها تلقائياً.

```razor
<h3>@NexaKeys.Button.Save</h3>

<button>@NexaKeys.Button.Cancel</button>

<span>@NexaKeys.Status.Active</span>
```

لا حاجة لحقن (`Inject`) خدمة `ILocalizationService`.

---

# Source Generator

يقوم Incremental Source Generator بإنشاء مفاتيح الترجمة تلقائياً أثناء عملية البناء.

مثال:

```csharp
NexaKeys.Button.Save

NexaKeys.Button.Cancel

NexaKeys.Status.Active

NexaKeys.Invoice.Create.Success
```

---

## الفوائد

- IntelliSense
- Compile-time Safety
- Refactoring Friendly
- بدون Magic Strings
- أداء أفضل

---

# الإعدادات

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

# إضافة اللغات

إضافة اللغات الافتراضية:

```csharp
options.AddKurdish();

options.AddEnglish();

options.AddArabic();

options.AddDefaultLanguages();
```

أو إضافة لغة مخصصة:

```csharp
options.AddLanguage(
    code: "fr",
    name: "French",
    nativeName: "Français");
```

---

# هيكل المشروع

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

يتم توفير تكامل كل منصة من خلال حزم مستقلة.

---

# الحزم

| الحزمة | الوصف |
|---------|--------|
| Nexa.Localization | إطار العمل الأساسي |
| Nexa.Localization.SourceGenerator | إنشاء مفاتيح ترجمة قوية |
| Nexa.Localization.Blazor *(قريباً)* | تكامل مع Blazor |
| Nexa.Localization.WinForms *(مخطط له)* | دعم WinForms |
| Nexa.Localization.WPF *(مخطط له)* | دعم WPF |
| Nexa.Localization.MAUI *(مخطط له)* | دعم .NET MAUI |

---

# خارطة الطريق

## الإصدار 1.x

- دعم Blazor
- دعم WinForms
- دعم WPF
- دعم MAUI
- Cookie Language Storage
- Browser LocalStorage
- Session Storage
- Database Storage
- Embedded Resource Provider
- Resource Overriding
- Performance Benchmarks

---

# التوثيق

سيتضمن التوثيق:

- البدء السريع
- التثبيت
- الإعدادات
- Source Generator
- Runtime API
- أفضل الممارسات
- أمثلة عملية

وسيتوفر باللغات:

- 🇬🇧 English
- 🇹🇯 Kurdish
- 🇸🇦 العربية

---

# الترخيص

هذا المشروع مرخص بموجب **MIT License**.

لمزيد من التفاصيل، راجع ملف **LICENSE**.