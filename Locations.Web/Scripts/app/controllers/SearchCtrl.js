(function () {
    'use strict';
    angular.module('app')
        .run(['$templateCache', function ($templateCache) {
            $templateCache.put('searchbox.tpl.html', '<input id="pac-input" ng-model="$parent.searchText" class="form-control" type="text" placeholder="Search">');
        }])
        .controller('SearchCtrl', ['$scope', 'uiGmapGoogleMapApi', '$routeParams', '$log', '$timeout', 'ChurchService',
            function ($scope, uiGmapGoogleMapApi, $routeParams, $log, $timeout, ChurchService) {
                var clickEvent = function (themap, eventNam, args) {
                    if ($scope.displayChurchForm) {
                        $timeout(function () {
                            $scope.ChurchMarker.coords = {
                                latitude: args[0].latLng.lat(),
                                longitude: args[0].latLng.lng()
                            };
                            $scope.ChurchMarker.options.visible = true;
                        });
                    }
                };
                var searchEvents = {
                    places_changed: function (searchBox) {
                        console.log(searchBox);
                        var places = searchBox.getPlaces();
                        if (places.length === 0) {
                            return;
                        }
                        $scope.map.center = { latitude: places[0].geometry.location.lat(), longitude: places[0].geometry.location.lng() };
                    }
                };
                var mapBoundChanged = function(themap) {
                    var bounds = themap.getBounds();
                    var ne = bounds.getNorthEast();
                    var sw = bounds.getSouthWest();
                    ChurchService.GetInBox(ne.lng(), ne.lat(), sw.lng(), sw.lat()).success(function(data) {
                        var markers = data.map(function(church) {
                            return { id: church.Id, latitude: church.Latitude, longitude: church.Longitude, title: church.Comment };
                        });
                        $scope.Churches.Markers.push(markers);
                    });
                };
                $scope.addChurchEvent = function () {
                    $scope.displayChurchForm = !$scope.displayChurchForm;
                    $scope.ChurchMarker.coords = undefined;
                };
                $scope.Churches = {
                    Markers: [],
                    Id: 0
                };
                $scope.map = { center: { latitude: 18.4667, longitude: -69.9499 }, zoom: 8, events: { click: clickEvent, bounds_changed: mapBoundChanged } };
                $scope.searchbox = { template: 'searchbox.tpl.html', events: searchEvents, parentDiv: 'searchDiv' };
                uiGmapGoogleMapApi.then(function (maps) {
                    if ($routeParams.address) {
                        $scope.searchText = $routeParams.address;
                    }
                });
                $scope.ChurchMarker = {
                    id: 0,
                    options: {
                        draggable: true,
                        visible: false
                    },
                    events: {
                        dragend: function (marker, eventName, args) {
                            //Maybe display a message advertising to the user about the new position of the church
                        }
                    }
                };
            }
        ]);
})();