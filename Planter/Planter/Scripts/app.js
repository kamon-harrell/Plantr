var ViewModel = function () {

    var self = this;

    self.plants = ko.observableArray();
    self.error = ko.observable();

    self.newPlant = {
        Id: ko.observable(),
        Name: ko.observable(),
        Description: ko.observable(),
        Price: ko.observable(),
        Harvest: ko.observable(),
        Space: ko.observable(),
        Water: ko.observable(),
        Germination: ko.observable()
    }

    var plantsUri = '/api/Plants/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllPlants() {
        ajaxHelper(plantsUri, 'GET').done(function (data) {
            self.plants(data);
        });
    }

    self.addPlant = function (formElement) {
        var plant = {
            Name: self.newPlant.Name(),
            Description: self.newPlant.Description(),
            Price: self.newPlant.Price(),
            Harvest: self.newPlant.Harvest(),
            Space: self.newPlant.Space(),
            Water: self.newPlant.Water(),
            Germination: self.newPlant.Germination()
        };

        ajaxHelper(plantsUri, 'POST', plant).done(function (item) {
            self.plants.push(item);
        });
    }

    function deletePlant() {
        ajaxHelper(plantsUri, 'DELETE', plant).done(function (data) {
            self.plants(data)
        })
    }

    // Fetch the initial data.
    getAllPlants();
};

ko.applyBindings(new ViewModel());