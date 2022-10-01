const queryModeKey = "QueryMode";

export function getSearchQueryMode() {
    return localStorage[queryModeKey];
}

export function setSearchQueryMode(mode) {
    localStorage[queryModeKey] = mode;
}