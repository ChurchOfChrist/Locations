(function () {
    'use strict';
    angular.module('app')
        .controller('ContactModalCtrl', ['$scope', '$modalInstance',
            function ($scope, $modalInstance) {
                $scope.Contact = {};
                $scope.save = function(contact) {
                    $modalInstance.close(contact);
                };
                $scope.cancel = function() {
                    $modalInstance.dismiss();
                };
            }
        ]);
})();