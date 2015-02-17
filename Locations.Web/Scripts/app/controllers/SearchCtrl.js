(function () {
    'use strict';
    angular.module('app')
        .run(['$templateCache', function ($templateCache) {
            $templateCache.put('searchbox.tpl.html', '<input id="pac-input" class="pac-controls form-control" type="text" placeholder="Search">');
            $templateCache.put('window.tpl.html', '<div ng-controller="WindowCtrl" ng-init="showPlaceDetails(parameter)">{{place.name}}</div>');
        }])
        .controller('SearchCtrl', ['$scope', 'uiGmapGoogleMapApi',
            function ($scope, uiGmapGoogleMapApi) {
                var mapService;
                $scope.map = { center: { latitude: 18.4667, longitude: -69.9499 }, zoom: 8 };
                var events = {
                    places_changed: function (searchBox) {
                        console.log(searchBox);
                        var places = searchBox.getPlaces();
                        if (places.length === 0) {
                            return;
                        }
                        // For each place, get the icon, place name, and location.
                        var newMarkers = [];
                        for (var i = 0, place; place = places[i]; i++) {
                            // Create a marker for each place.
                            var marker = {
                                id: i,
                                place_id: place.place_id,
                                name: place.name,
                                latitude: place.geometry.location.lat(),
                                longitude: place.geometry.location.lng(),
                                options: {
                                    visible: false
                                },
                                templateurl: 'window.tpl.html',
                                templateparameter: place
                            };
                            newMarkers.push(marker);
                        }

                        $scope.map.markers = newMarkers;
                        console.log(newMarkers);
                        $scope.map.center = {latitude: newMarkers[0].latitude, longitude:newMarkers[0].longitude};
                    }
                }
                $scope.searchbox = { template: 'searchbox.tpl.html', events: events, parentDiv: 'searchDiv' };

                // uiGmapGoogleMapApi is a promise.
                // The "then" callback function provides the google.maps object.
                uiGmapGoogleMapApi.then(function (maps) {
                    $scope.map = { center: { latitude: 45, longitude: -73 }, zoom: 8 };
                    mapService = maps;
                    console.log(mapService);
                });
            }
        ]);
})();