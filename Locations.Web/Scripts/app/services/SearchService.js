(function () {
    "use strict";
    angular.module('app')
        .service('SearchService', [
            'uiGmapGoogleMapApi', function (uiGmapGoogleMapApi) {
                var self = this;
                self.GetPlacesByName = function (name, callback) {
                    var request = {
                        query: name
                    };
                    new google.maps.places.PlacesService(map).textSearch(request, callback);
                };
            }
        ]);
})();