using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebApp.Shared.DataModels
{
    public interface IModuleImport
    {
        IJSRuntime? JSRuntime { get; }

        Task<IJSObjectReference>? ImportModuleReferenceAsync(string module);
    }
}