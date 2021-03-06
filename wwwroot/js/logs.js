const body = document.querySelector("#knockout-app")
    
function DNLViewModel() {
    var self = this

    self.logs = ko.observableArray()

    self.filter = {
        get: ko.observable(true),
        post: ko.observable(true),
        put: ko.observable(true),
        delete: ko.observable(true),
        options: ko.observable(true)
    }

    self.filteredLogs = ko.computed(function () {
        let result = []

        for (const entry of self.logs()) {
            // If method has a filter observable
            if (self.filter.hasOwnProperty(entry.method.toLowerCase())) {
                if (self.filter[entry.method.toLowerCase()]()) {
                    var formattedEntry = entry
                    formattedEntry.time = formattedEntry.time
                        .substring(0,19)
                        .replace("T", " ")
                    result.push(formattedEntry)
                }
            } else {
                var formattedEntry = entry
                    formattedEntry.time = formattedEntry.time
                        .substring(0,19)
                        .replace("T", " ")
                result.push(formattedEntry)
            }
        }

        return result
    })
    
    fetch('http://localhost:8080/api/logs/')
        .then(response => response.json())
        .then(data => {
            self.logs(data)
        });
}

ko.applyBindings(new DNLViewModel(), body)