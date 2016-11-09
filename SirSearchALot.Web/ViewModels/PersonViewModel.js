function PersonViewModel() {
    var self = this;
    self.FirstName = ko.observable();
    self.LastName = ko.observable();
    self.StreetAddress = ko.observable();
    self.City = ko.observable();
    self.State = ko.observable();
    self.ZipCode = ko.observable();

    self.NewInterest = ko.observable();
    self.Interests = ko.observableArray();
    self.ImageUrl = ko.observable();

    self.FileUploaded = ko.observable();

    self.Upload = function () {
        var form = $('#ProfileUploadForm')[0];
        var formData = new FormData(form);
        $.ajax("/api/Upload", {
            method: 'post',
            processData: false,
            contentType: false,
            data: formData
        }).done(function (data) {
            var realData = JSON.parse(data);
            if (realData.success == true) {
                self.ImageUrl("/Content/ProfileImages/" + realData.name);
                self.FileUploaded(true);
            } else {
                alert("error uploading");
            }
        }).fail(function (data) {
            console.log(data);
            alert('error uploading stuff');
        });
    }
    
    self.AddInterest = function () {
        self.Interests.push({ Name: self.NewInterest()});
        self.NewInterest(null);
    }
}