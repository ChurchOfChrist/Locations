(function () {
    'use strict';
    angular.module('app')
        .controller('ChurchFormCtrl', ['$scope', '$modal','ChurchService',
            function ($scope, $modal, ChurchService) {
                $scope.Remove = function(index, list) {
                    list.splice(index, 1);
                };
                $scope.save = function (church) {
                    if (!$scope.$parent.ChurchMarker.coords || !church.Contacts.length || !church.WorshipDays.length) {
                        $scope.Submitted = true;
                        return;
                    }
                    var marker = $scope.$parent.ChurchMarker;
                    church.Latitude = marker.coords.latitude;
                    church.Longitude = marker.coords.longitude;
                    ChurchService.Save(church).success(function(data) {
                        if (data) {
                            location.reload();
                        } else {
                            alert(data);
                        }
                    }).error(function(result) {
                        alert(result);
                    });
                };
                var modal = function(templateUrl, ctrl, size, items) {
                    return $modal.open({
                        templateUrl: templateUrl,
                        controller: ctrl,
                        size: size | 'sm',
                        resolve: items
                    });
                };
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