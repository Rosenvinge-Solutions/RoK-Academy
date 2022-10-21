namespace WebApp.Shared.DataModels;

sealed class LanguageCodes
{
    public LanguageCodes()
    {
    }

    public LanguageCodes(string code, string displayName, string country, bool isDisabled = false)
    {
        Code = code;
        DisplayName = displayName;
        Country = country;
        IsDisabled = isDisabled;
    }

    public string DisplayName { get; init; } = string.Empty;

    public string Code { get; init; } = string.Empty;

    public string Country { get; init; } = string.Empty;

    public bool IsDisabled { get; init; } = default;
}