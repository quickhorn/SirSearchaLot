function PersonViewModel() {
    var self = this;
    self.FirstName = ko.observable();
    self.LastName = ko.observable();
    self.StreetAddress = ko.observable();
    self.City = ko.observable();
    self.State = ko.observable();

    self.NewInterest = ko.observable();
    self.Interests = ko.observableArray();

    self.AddInterest = function () {
        self.Interests.push({ Name: self.NewInterest()});
        self.NewInterest(null);
    }
}