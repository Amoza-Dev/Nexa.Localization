# Nexa.Localization

إطار عمل حديث، سريع، وقوي لإدارة الترجمة (Localization) في تطبيقات .NET.

**Nexa.Localization** هو إطار عمل خفيف يعتمد على ملفات JSON ومولد الشيفرة **Roslyn Incremental Source Generator** لإنشاء مفاتيح ترجمة قوية (Strongly Typed Localization Keys). يوفر تبديل اللغة أثناء التشغيل (Runtime)، ودعم Dependency Injection، والتحقق من الموارد عند بدء التشغيل، بالإضافة إلى تصميم نظيف ومستقل عن أي واجهة مستخدم.

---

# الميزات

## الترجمة (Localization)

- دعم ملفات JSON
- مفاتيح ترجمة Strongly Typed
- تبديل اللغة أثناء التشغيل
- دعم تعدد اللغات
- دعم Fallback Culture
- دعم اللغات من اليمين إلى اليسار (RTL)

---

## الأداء (Performance)

- أداء عالي
- Thread-safe Localization Cache
- التحقق عند بدء التشغيل
- أقل استهلاك ممكن للذاكرة

---

## تجربة المطور (Developer Experience)

- Roslyn Incremental Source Generator
- IntelliSense
- Compile-time Safety
- Refactoring Friendly
- بدون Magic Strings
- دعم Dependency Injection

---

## التصميم (Architecture)

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

## 1. تسجيل خدمات Localization

```csharp
builder.Services.AddNexaLocalization(options =>
{
    options.DefaultCulture = "ar";
    options.FallbackCulture = "en";

    options.AddDefaultLanguages();
});
```

---

## 2. تهيئة Localization

```csharp
var app = builder.Build();

await app.Services.InitializeNexaLocalizationAsync();

app.Run();
```

---

# هيكل مجلدات Localization

```text
Shared/
└── Localization/
    ├── ar/
    ├── en/
    └── ckb/
```

مثال:

```json
{
    "button.save": "حفظ",
    "button.cancel": "إلغاء"
}
```

---

# استخدام Strongly Typed Keys

يقوم Source Generator بإنشاء جميع مفاتيح الترجمة تلقائياً.

```csharp
NexaKeys.Button.Save

NexaKeys.Button.Cancel

NexaKeys.Status.Active

NexaKeys.Dialog.Confirm
```

مثال في Razor:

```razor
<button>@NexaKeys.Button.Save</button>

<span>@NexaKeys.Status.Active</span>
```

### المزايا

- IntelliSense
- Compile-time Safety
- بدون Magic Strings
- Refactoring Friendly
- أداء أفضل

---

# مكتبة الموارد (Resource Library)

يأتي **Nexa.Localization** مع مكتبة جاهزة من ملفات الترجمة.

### الإحصائيات الحالية

| العنصر | العدد |
|--------|------:|
| اللغات | 3 |
| ملفات JSON | 87 |
| مفاتيح الترجمة | 2,469 |

اللغات المدعومة:

- English (en)
- Kurdish (ckb)
- العربية (ar)

للاطلاع على جميع الملفات والمفاتيح، راجع **ResourceLibrary.md**.

---

# الإعدادات

```csharp
builder.Services.AddNexaLocalization(options =>
{
    options.DefaultCulture = "ar";
    options.FallbackCulture = "en";

    options.EnableCaching = true;
    options.ValidateOnStartup = true;

    options.AddDefaultLanguages();
});
```

---

# إضافة اللغات

اللغات الافتراضية:

```csharp
options.AddKurdish();

options.AddEnglish();

options.AddArabic();

options.AddDefaultLanguages();
```

أو أضف لغتك الخاصة:

```csharp
options.AddLanguage(
    code: "fr",
    name: "French",
    nativeName: "Français");
```

---

# الحزم

| الحزمة | الحالة | الوصف |
|--------|:------:|--------|
| Nexa.Localization | ✅ | إطار العمل الأساسي |
| Nexa.Localization.SourceGenerator | ✅ | إنشاء Strongly Typed Keys |
| Nexa.Localization.Blazor | 🚧 | قريباً |
| Nexa.Localization.WinForms | 📅 | مخطط له |
| Nexa.Localization.WPF | 📅 | مخطط له |
| Nexa.Localization.MAUI | 📅 | مخطط له |

---

# خارطة الطريق

## الإصدار 1.x

- دعم Blazor
- دعم WinForms
- دعم WPF
- دعم .NET MAUI
- Cookie Language Storage
- Browser LocalStorage
- Session Storage
- Database Storage
- Performance Benchmarks

## المستقبل

- AI Translation
- AI Resource Suggestions
- AI Missing Key Detection
- Cloud Resource Synchronization
- Visual Studio Extension
- CLI Tools

---

# التوثيق

يتضمن التوثيق:

- البدء السريع
- التثبيت
- الإعدادات
- Source Generator
- Resource Library
- Runtime API
- أفضل الممارسات
- مشاريع تجريبية

سيتوفر التوثيق باللغات:

- English
- Kurdish
- العربية

---

# الترخيص

يتم توزيع هذا المشروع بموجب **MIT License**.

راجع ملف **LICENSE** لمزيد من المعلومات.