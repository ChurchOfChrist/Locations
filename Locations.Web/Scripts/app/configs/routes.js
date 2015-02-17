(function () {
    angular.module('app').config(['$routeProvider',function ($routeProvider) {
        $routeProvider
          .when('/', {
              templateUrl: '/Scripts/app/views/home.html',
              controller: 'HomeCtrl'
          })
          .when('/search', {
              templateUrl: '/Scripts/app/views/search.html',
              controller: 'SearchCtrl'
          })
          .otherwise({
              redirectTo: '/'
          });
    }]);
})();