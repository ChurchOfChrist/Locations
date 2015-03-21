(function () {
    'use strict';
    angular.module('app')
        .controller('WorshipModalCtrl', ['$scope', '$modalInstance',
            function ($scope, $modalInstance) {
                var defaultStart = new Date();
                var defaultEnd = new Date();
                defaultStart.setHours(9);
                defaultStart.setMinutes(0);
                defaultEnd.setHours(11);
                defaultEnd.setMinutes(0);
                $scope.Worship = {
                    Day: 'Sunday',
                    Start: defaultStart,
                    End: defaultEnd
                };
                $scope.save = function (worship) {
                    $modalInstance.close(worship);
                };
                $scope.cancel = function () {
                    $modalInstance.dismiss();
                };
            }
        ]);
})();