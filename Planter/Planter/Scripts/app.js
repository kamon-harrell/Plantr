var ViewModel = function () {
    var self = this;
    self.plants = ko.observableArray();
    self.error = ko.observable();

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

    // Fetch the initial data.
    getAllPlants();
};

ko.applyBindings(new ViewModel());