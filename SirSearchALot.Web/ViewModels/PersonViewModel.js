function PersonViewModel() {
    //consider using knockout-validation to verify that all of the fields are 
    //filled in before sending it to the server.
    var self = this;

    self.AvailableStates = ['AL', 'AK', 'AZ', 'CA', 'CO', 'CT', 'DE', 'DC', 'FL', 'GA',
                            'HI', 'ID', 'IL', 'IN', 'IA', 'KA', 'KY', 'LA', 'ME', 'MD',
                            'MA', 'MI', 'MN', 'MS', 'MO', 'MT', 'NE', 'NV', 'NH', 'NJ',
                            'NM', 'NY', 'NC', 'ND', 'OH', 'OK', 'OR', 'PA', 'RI', 'SC',
                            'SD', 'TN', 'TX', 'UT', 'VT', 'VA', 'WA', 'WV', 'WI', 'WY']

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
    self.File = ko.observable();

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
            console.log(realData);
            if (realData.success == true) {
                //self.ImageUrl("/Content/ProfileImages/" + realData.name);
                self.ImageUrl(realData.imageLocation);
                self.FileUploaded(true);
            } else {
                alert("error uploading. " + realData.message);
                self.File('');
            }
        }).fail(function (data) {
            //It'd be awesome if we can get these into little error divs instead of as alerts. No one likes alerts.
            self.File('');
            alert('Error uploading image. Verify the file is an image file');
        });
    }
    
    self.AddInterestButtonEnabled = ko.computed(function () {
        var interst = (self.NewInterest() != undefined) && (self.NewInterest().length > 0);
        return interst;
    });
    self.AddInterest = function () {
        self.Interests.push({ Name: self.NewInterest()});
        self.NewInterest(null);
    }
}