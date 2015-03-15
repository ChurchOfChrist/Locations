﻿(function () {
    'use strict';
    angular.module('app')
        .controller('ChurchFormCtrl', ['$scope', '$log', '$timeout', '$http', '$modal',
            function ($scope, $log, $timeout, $http, $modal) {
                $scope.Remove = function (index, list) {
                    list.splice(index, 1);
                }
                $scope.save = function (church) {
                    if (!$scope.$parent.ChurchMarker.coords || !church.Contacts.length || !church.WorshipDays.length) {
                        $scope.Submitted = true;
                        return;
                    }
                    church.cords = $scope.$parent.ChurchMarker.coords;
                    $log.log(church);
                    alert('Listo para agregar check ur console');
                    /* $http.get('/home/addpoint', {
                         params: {
                             address: $scope.Church.Details,
                             lat: $scope.Church.coords.latitude,
                             lng: $scope.Church.coords.longitude,
                             preacher: 'Yomismo',
                             days: 'Tolodia'
                         }
                     }).success(function (data) {
                         $log.log(data); //TODOD:Save details
                     });*/
                };
                var modal = function (templateUrl, ctrl, size, items) {
                    return $modal.open({
                        templateUrl: templateUrl,
                        controller: ctrl,
                        size: size | 'sm',
                        resolve: items
                    });
                }
                $scope.addWorship = function () {
                    modal('/Scripts/app/views/modals/worship.html', 'WorshipModalCtrl').result.then(function (wDay) {
                        $scope.Church.WorshipDays.push(wDay);
                    });
                };
                $scope.AddContact = function () {
                    modal('/Scripts/app/views/modals/contact.html', 'ContactModalCtrl').result.then(function (contact) {
                        $scope.Church.Contacts.push(contact);
                    });
                };


                $scope.Church = {
                    Contacts: [],
                    WorshipDays: []
                };
            }
        ]);
})();