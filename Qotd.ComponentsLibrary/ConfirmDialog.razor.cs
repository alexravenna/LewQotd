using Microsoft.AspNetCore.Components;

namespace Qotd.ComponentsLibrary;
public partial class ConfirmDialog
{
    [Parameter, EditorRequired]
    public string ConfirmTitle { get; set; } = string.Empty;

    [Parameter, EditorRequired]    
    public string ConfirmMessage { get; set; } = string.Empty;

    private bool _showConfirm;
}
