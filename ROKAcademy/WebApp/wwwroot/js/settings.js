const queryModeKey = "QueryMode";
const searchHistoryKey = 'SearchHistory';

export function getSearchQueryMode() {
    return localStorage[queryModeKey];
}

export function setSearchQueryMode(mode) {
    localStorage[queryModeKey] = mode;
}

export function getSearchHistory() {
    return localStorage[searchHistoryKey];
}

export function setSearchHistory(searchHistory) {
    var json = JSON.stringify(searchHistory);
    localStorage[searchHistoryKey] = json;
}

export function validateLocalStorageMemory() {
    if (localStorage[searchHistoryKey] == undefined) {
        var json = JSON.stringify([]);
        localStorage[searchHistoryKey] = json;
    }
}