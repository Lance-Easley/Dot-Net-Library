const body = document.querySelector("#knockout-app")
const updateDelay = 500
    
function DNLViewModel() {
    var self = this

    self.bookInventory = ko.observableArray()

    self.nextDbId = ko.observable(0)
    
    fetch('http://localhost:8080/api/books/')
        .then(response => response.json())
        .then(data => {
            self.bookInventory(data)
            if (data.length > 0) {
                self.nextDbId(data[data.length - 1].id + 1)
            }
        });
    
    // Delete
    self.deleteBook = function(data, event) {
        var idToRemove = event.target.getAttribute("item-id")
        
        fetch('http://localhost:8080/api/book/' + idToRemove + '/', {
            method: 'DELETE'
        })

        for (let i = 0; i < self.bookInventory().length; i++) {
            let book = self.bookInventory()[i]
            if (book.id == idToRemove) {
                self.bookInventory.splice(i, 1)
            }
        }

        // Ensure bookInventory synced with database
        setTimeout(() => {
            fetch('http://localhost:8080/api/books/')
                .then(response => response.json())
                .then(data => self.bookInventory(data));
        }, updateDelay)
    }

    // Add Form
    self.showAddForm = ko.observable(false)

    self.title = ko.observable("").extend({
        validation: {
            message: "Title must be no longer than 100 characters.",
            validator: function(value) {
                return value.length <= 100;
            }
        }
    })
    self.author = ko.observable("").extend({
        validation: {
            message: "Author must be no longer than 50 characters.",
            validator: function(value) {
                return value.length <= 50;
            }
        }
    })
    self.description = ko.observable("").extend({
        validation: {
            message: "Description must be no longer than 250 characters.",
            validator: function(value) {
                return value.length <= 250;
            }
        }
    })
    self.date = ko.observable("")

    self.addFormFilled = ko.computed(function() {
        return self.title().length > 0 && self.author().length > 0 && self.description().length > 0 && self.date().length == 10
    })

    self.handleAddSubmit = function() {
        if (self.addFormFilled()) {

            const newBook = {
                "title": self.title(),
                "author": self.author(),
                "description": self.description(),
                "publishDate": self.date()
            }
        
            fetch('http://localhost:8080/api/book/', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(newBook)
            })
                .then(response => response.json())
                .then(data => self.nextDbId(data.id + 1));

            newBook.id = self.nextDbId()

            self.nextDbId(newBook.id + 1)

            self.bookInventory.push(newBook)

            self.title("")
            self.author("")
            self.description("")
            self.date("")
            
            // Ensure bookInventory synced with database
            setTimeout(() => {
                fetch('http://localhost:8080/api/books/')
                    .then(response => response.json())
                    .then(data => self.bookInventory(data));
            }, updateDelay)
        }

        $('#addBookModel').modal('hide');
    }

    // Edit Book
    self.editing = ko.observable()

    self.editTitle = ko.observable("").extend({
        validation: {
            message: "Title must be no longer than 100 characters.",
            validator: function(value) {
                return value.length <= 100;
            }
        }
    })
    self.editAuthor = ko.observable("").extend({
        validation: {
            message: "Author must be no longer than 50 characters.",
            validator: function(value) {
                return value.length <= 50;
            }
        }
    })
    self.editDescription = ko.observable("").extend({
        validation: {
            message: "Description must be no longer than 250 characters.",
            validator: function(value) {
                return value.length <= 250;
            }
        }
    })
    self.editDate = ko.observable("")

    self.editFormFilled = ko.computed(function() {
        return self.editTitle().length > 0 && self.editAuthor().length > 0 && self.editDescription().length > 0 && self.editDate().length == 10
    })
    
    self.editBook = function(data, event) {
        self.editing(parseInt(event.target.getAttribute("item-id")))

        self.showAddForm(false)

        self.editTitle(data.title)
        self.editAuthor(data.author)
        self.editDescription(data.description)
        self.editDate(data.publishDate)
    }

    self.handleEditSubmit = function() {
        const idToUpdate = self.editing()

        const updateBook = {
            "title": self.editTitle(),
            "author": self.editAuthor(),
            "description": self.editDescription(),
            "publishDate": self.editDate()
        }
        
        fetch('http://localhost:8080/api/book/' + idToUpdate + '/', {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(updateBook)
        })

        updateBook.id = idToUpdate

        for (let i = 0; i < self.bookInventory().length; i++) {
            let book = self.bookInventory()[i]
            if (book.id == idToUpdate) {
                self.bookInventory.splice(i, 1, updateBook)
            }
        }

        self.editing(null)

        // Ensure bookInventory synced with database
        setTimeout(() => {
            fetch('http://localhost:8080/api/books/')
                .then(response => response.json())
                .then(data => self.bookInventory(data));
        }, updateDelay)

        $('#editBookModel').modal('hide');
    }
}

ko.applyBindings(new DNLViewModel(), body)