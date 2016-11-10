function SirSearchALotViewModel() {
    var self = this;

    self.NewPerson = ko.observable(new PersonViewModel());
    self.AddPerson = function () {
        self.PageIsLoading();
        //$('#NewPersonForm').submit();
        $.post("/api/Person", ko.toJS(self.NewPerson()), function (data) {
            if (data.Success) {
                self.NewPerson(new PersonViewModel());
                self.PageHasLoaded();
            } else {
                alert('Unable to add person. ' + data.Message);
            }
        }).fail(function () {
            self.PageHasLoaded();
        })
    }

    self.DialogClosing = function () {
        self.NewPerson(new PersonViewModel());
    }

    self.SearchResults = ko.observableArray();

    self.SearchString = ko.observable();
    self.Search = function () {
        self.PageIsLoading();
        self.SearchResults('');
        var search = self.SearchString() ? self.SearchString() : '';
        console.log(search);
        $.get("/api/Search/", { searchString: search }, function (data) {
            if (data.Success) {
                self.SearchResults(data.MatchedPersons);
            } else {
                alert("Unable to retrieve data. Something went horribly wrong!");
            }
            self.PageHasLoaded();
        }).fail(function () {
            self.PageHasLoaded();
            alert('Searching failed! Something went horribly wrong!')
        });
    }

    self.PageIsLoading = function () {
        $('#LoadingModal').modal('show');
    }

    self.PageHasLoaded = function () {
        $('#LoadingModal').modal('hide');
    }
}
