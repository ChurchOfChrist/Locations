(function () {
    'use strict';
    angular.module('app')
        .run(['$templateCache', function ($templateCache) {
            $templateCache.put('searchbox.tpl.html', '<input id="pac-input" class="pac-controls form-control" type="text" placeholder="Search">');
            $templateCache.put('window.tpl.html', '<div ng-controller="WindowCtrl" ng-init="showPlaceDetails(parameter)">{{place.name}}</div>');
        }])
        .controller('HomeCtrl', ['$scope', 'uiGmapGoogleMapApi',
            function ($scope, uiGmapGoogleMapApi) {
                var events = {
                    places_changed: function (searchBox) {
                    }
                }
                $scope.searchbox = { template: 'searchbox.tpl.html', events: events, parentDiv: 'searchDiv' };
                uiGmapGoogleMapApi.then(function (maps) {
                    $scope.map = { center: { latitude: 18.6667, longitude: -69.699999 }, zoom: 8 };
                });
            }
        ]);
})();