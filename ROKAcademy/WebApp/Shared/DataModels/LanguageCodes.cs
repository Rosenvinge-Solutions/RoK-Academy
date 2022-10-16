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

    public string ?DisplayName { get; init; }

    public string ?Code { get; init; }

    public string ?Country { get; init; }

    public bool IsDisabled { get; init; }
}