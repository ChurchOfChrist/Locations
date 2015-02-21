(function () {
    'use strict';
    angular.module('app')
        .run(['$templateCache', function ($templateCache) {
            $templateCache.put('searchbox.tpl.html', '<input id="pac-input" class="pac-controls form-control" type="text" placeholder="Search">');
        }])
        .controller('HomeCtrl', ['$scope', 'uiGmapGoogleMapApi','$location',
            function ($scope, uiGmapGoogleMapApi,$location) {
                var events = {
                    places_changed: function (searchBox) {
                        var url = '/search';
                        var places = searchBox.getPlaces();
                        if (places[0]) {
                            url += '/' + places[0].name;
                        }
                        $location.path(url);
                    }
                }
                $scope.searchbox = { template: 'searchbox.tpl.html', events: events, parentDiv: 'searchDiv'};
                uiGmapGoogleMapApi.then(function (maps) {
                    $scope.map = { center: { latitude: 18.6667, longitude: -69.699999 }, zoom: 8 };
                });
            }
        ]);
})();