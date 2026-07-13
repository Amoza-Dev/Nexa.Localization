using Microsoft.AspNetCore.Components;
using Nexa.Localization.Abstractions;

namespace Nexa.Localization.Components;

public abstract class LocalizedComponentBase : ComponentBase, IDisposable
{
    [Inject]
    protected ILocalizationService L { get; set; } = default!;

    [Inject]
    protected ILanguageManager LanguageManager { get; set; } = default!;

    protected override void OnInitialized()
    {
        LanguageManager.LanguageChanged += OnLanguageChanged;
    }

    private void OnLanguageChanged()
    {
        InvokeAsync(StateHasChanged);
    }

    public virtual void Dispose()
    {
        LanguageManager.LanguageChanged -= OnLanguageChanged;
    }
}