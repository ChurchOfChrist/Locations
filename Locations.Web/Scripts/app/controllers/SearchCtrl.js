(function () {
    'use strict';
    angular.module('app')
        .run(['$templateCache', function ($templateCache) {
            $templateCache.put('searchbox.tpl.html', '<input id="pac-input" ng-model="$parent.searchText" class="form-control" type="text" placeholder="Search">');
        }])
        .controller('SearchCtrl', ['$scope', 'uiGmapGoogleMapApi', '$routeParams', '$log', '$timeout',
            function ($scope, uiGmapGoogleMapApi, $routeParams, $log, $timeout) {
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
                }
                var searchEvents = {
                    places_changed: function (searchBox) {
                        console.log(searchBox);
                        var places = searchBox.getPlaces();
                        if (places.length === 0) {
                            return;
                        }
                        $scope.map.center = { latitude: places[0].geometry.location.lat(), longitude: places[0].geometry.location.lng() };
                    }
                }
                $scope.addChurchEvent = function () {
                    $scope.displayChurchForm = !$scope.displayChurchForm;
                    $scope.ChurchMarker.coords = undefined;
                };

                $scope.map = { center: { latitude: 18.4667, longitude: -69.9499 }, zoom: 8, events: { click: clickEvent } };            
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

                //TODO: Load Church logic
                /*var bounds = themap.getBounds();
                var ne = bounds.getNorthEast();
                var sw = bounds.getSouthWest();
                $http.get('/home/PointsInTheBox', {
                    params: {
                        nelng: ne.lng(),
                        nelt: ne.lat(),
                        swlng: sw.lng(),
                        swlt: sw.lat()
                    }
                }).success(function (data) {
                    $log.log(data);//TODO: Display the markets on the map
                });*/
            }
        ]);
})();