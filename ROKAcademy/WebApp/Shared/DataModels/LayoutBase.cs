using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using WebApp.Shared.Extensions;

namespace WebApp.Shared.DataModels;

public abstract class LayoutBase : LayoutComponentBase, IModuleImport
{
    [Inject] public IJSRuntime? JSRuntime { get; init; }

    public Task<IJSObjectReference> ImportModuleReferenceAsync(string module)
    {
        if (JSRuntime is null)
        {
            throw new ArgumentNullException("Couldn't import reference due to null reference.", nameof(JSRuntime));
        }

        return JSRuntime.InjectJsObjectReference("import", module);
    }
}
