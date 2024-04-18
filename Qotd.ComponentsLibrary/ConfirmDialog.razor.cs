using Microsoft.AspNetCore.Components;

namespace Qotd.ComponentsLibrary;
public partial class ConfirmDialog
{
    [Parameter, EditorRequired]
    public string ConfirmTitle { get; set; } = string.Empty;

    [Parameter, EditorRequired]    
    public string ConfirmMessage { get; set; } = string.Empty;

    private bool _showConfirm;

    [Parameter] public EventCallback<bool> OnConfirmChangedCallback { get; set; }

    public void Show()
    {
        _showConfirm = true;
    }

    private async Task OnConfirmChange(bool value)
    {
        _showConfirm = false;
        await OnConfirmChangedCallback.InvokeAsync(value);
    }
}
