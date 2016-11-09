function SirSearchALotViewModel() {
    var self = this;

    self.NewPerson = new PersonViewModel();
    self.AddPerson = function () {
        $('#NewPersonForm').submit();
        self.NewPerson = new PersonViewModel();
    }

    self.SearchString = ko.observable();
    self.Search = function () {
        $.get("/api/Search/", { searchString: self.SearchString() }, function (data) {
            console.log(data);
        });
    }
    self.SearchResults = ko.observableArray();
}