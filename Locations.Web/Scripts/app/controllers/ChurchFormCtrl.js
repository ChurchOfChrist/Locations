(function () {
    'use strict';
    angular.module('app')
        .controller('ChurchFormCtrl', ['$scope', '$log', '$timeout', '$http', '$modal','ChurchService',
            function ($scope, $log, $timeout, $http, $modal, ChurchService) {
                $scope.Remove = function (index, list) {
                    list.splice(index, 1);
                }
                $scope.save = function (church) {
                    if (!$scope.$parent.ChurchMarker.coords || !church.Contacts.length || !church.WorshipDays.length) {
                        $scope.Submitted = true;
                        return;
                    }
                    var marker = $scope.$parent.ChurchMarker;
                    church.Lat = marker.coords.latitude;
                    church.Lng = marker.coords.longitude;
                    church.Address = marker.Address;
                    ChurchService.Save(church).success(function(data) {
                        if (data) {
                            $log.log('Saved');
                        } else {
                            $log.log('Error saving');
                        }
                    }).error(function(result) {
                        $log.log('Invalid input');
                        $log.log(result);
                    });
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