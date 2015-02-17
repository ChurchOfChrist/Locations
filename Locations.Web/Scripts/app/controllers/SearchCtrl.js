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
                $scope.map = { center: { latitude: 45, longitude: -73 }, zoom: 8 };
                var events = {
                    places_changed: function (searchBox) {
                        console.log(searchBox);
                        var places = searchBox.getPlaces();
                        if (places.length === 0) {
                            return;
                        }
                        // For each place, get the icon, place name, and location.
                        var newMarkers = [];
                        var bounds = new google.maps.LatLngBounds();
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

                            bounds.extend(place.geometry.location);
                        }

                        $scope.map.bounds = {
                            northeast: {
                                latitude: bounds.getNorthEast().lat(),
                                longitude: bounds.getNorthEast().lng()
                            },
                            southwest: {
                                latitude: bounds.getSouthWest().lat(),
                                longitude: bounds.getSouthWest().lng()
                            }
                        }

                        _.each(newMarkers, function (marker) {
                            marker.closeClick = function () {
                                $scope.selected.options.visible = false;
                                marker.options.visble = false;
                                return $scope.$apply();
                            };
                            marker.onClicked = function () {
                                $scope.selected.options.visible = false;
                                $scope.selected = marker;
                                $scope.selected.options.visible = true;
                            };
                        });

                        $scope.map.markers = newMarkers;
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