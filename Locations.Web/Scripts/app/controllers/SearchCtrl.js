(function () {
    'use strict';
    angular.module('app')
        .run(['$templateCache', function ($templateCache) {
            $templateCache.put('searchbox.tpl.html', '<input id="pac-input" ng-model="$parent.searchText" class="form-control" type="text" placeholder="Search">');
        }])
        .controller('SearchCtrl', ['$scope', 'uiGmapGoogleMapApi', '$routeParams', '$log', '$timeout',
            function ($scope, uiGmapGoogleMapApi, $routeParams, $log, $timeout) {
                $scope.addingChurch = false;
                var clickEvent = function (themap, eventNam, args) {
                    if ($scope.displayChurchForm) {
                        $timeout(function () {
                            $scope.Church.coords = {
                                latitude: args[0].latLng.lat(),
                                longitude: args[0].latLng.lng()
                            };
                            $scope.Church.options.visible = true;
                        });
                    }
                }
                $scope.map = { center: { latitude: 18.4667, longitude: -69.9499 }, zoom: 8, events: { click: clickEvent } };
                var events = {
                    places_changed: function (searchBox) {
                        console.log(searchBox);
                        var places = searchBox.getPlaces();
                        if (places.length === 0) {
                            return;
                        }
                        $scope.map.center = { latitude: places[0].geometry.location.lat(), longitude: places[0].geometry.location.lng() };
                    }
                }
                $scope.searchbox = { template: 'searchbox.tpl.html', events: events, parentDiv: 'searchDiv' };
                uiGmapGoogleMapApi.then(function (maps) {
                    if ($routeParams.address) {
                        $scope.searchText = $routeParams.address;
                    }
                });

                $scope.addChurchEvent = function () {
                    $scope.displayChurchForm = !$scope.displayChurchForm;
                    $scope.Church.Preachers = [{ Name: '', PhoneNumber: '' }];
                    $scope.Church.Details = '';
                };
                $scope.Church = {
                    id: 0,
                    coords: {
                        latitude: 18.4667,
                        longitude: -69.9499
                    },
                    options: {
                        draggable: true,
                        visible: false
                    },
                    events: {
                        dragend: function (marker, eventName, args) {
                            $log.log('marker dragend');
                            var lat = marker.getPosition().lat();
                            var lon = marker.getPosition().lng();
                            $log.log(lat);
                            $log.log(lon);

                            $scope.Church.options = {
                                draggable: true,
                                labelContent: "lat: " + $scope.Church.coords.latitude + ' ' + 'lon: ' + $scope.Church.coords.longitude,
                                labelAnchor: "100 0",
                                labelClass: "marker-labels"
                            };
                        }
                    }
                };
                $scope.addPreacher = function () {
                    $scope.Church.Preachers.push({});
                    console.log($scope.Church.Preachers);
                }
                $scope.removePreacher = function (index) {
                    $scope.Church.Preachers.splice(index, 1);
                }
            }
        ]);
})();