const cultureStorageKey = "Culture";

window.setDotNetReferenceForLanguageSelector = (dotNetReference) => {
    const ref = dotNetReference;

    var matches = window.matchMedia("(min-width: 768px)").matches ? false : true;
    ref.invokeMethodAsync("InitializeMobileDeviceMode", matches)
        .then(() => {});

    window.matchMedia("(min-width: 768px)").addEventListener('change', event => {
        if (ref == null) {
            console.warn("Dotnet help reference is null.");
            return;
        }

        try {
            ref.invokeMethodAsync("InitializeMobileDeviceMode", event.matches ? false : true)
                .then(() => {});
        } catch (e) {
            console.error("Unsupported error occurred: {0}", e);
        }
    });
}

export function getCulture() {
    return localStorage[cultureStorageKey];
};

export function setCulture(value) {
    localStorage[cultureStorageKey] = value;
};