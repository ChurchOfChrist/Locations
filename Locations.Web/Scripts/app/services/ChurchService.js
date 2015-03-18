(function () {
    "use strict";
    angular.module('app')
        .service('ChurchService', [
            '$http', function ($http) {
                var self = this;
            self.GetInBox = function(nelng, nelt, swlng, swlt) {
                return $http.get('/api/church', {
                    params: {
                        coords: {
                            nelng:nelng ,nelt :nelt, swlng:swlng,swlt:swlt
                        }
                    }
                });
            };
            self.Save = function(church) {
              return $http.post('/api/church', church);
            };

        }
        ]);
})();