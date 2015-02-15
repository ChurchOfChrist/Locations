//Search locations tests
describe('Search Controller Tests', function() {
    var $controller;
    var searchCtrl;
    var $scope;
    beforeEach(module('app'));
    beforeEach(inject(function(_$controller_, _$rootScope_) {
        $controller = _$controller_;
        $scope = _$rootScope_.$new();
    }));
    beforeEach(function() {
        searchCtrl = $controller('SearchCtrl', { $scope: $scope });
    });
    it('should have a SearchCtrl controller', function () {
        expect(searchCtrl).toBeDefined();
    });
    it('Should have an input changed method', function () {
        expect($scope.InputChanged).toBeDefined();
    });
    it('Should invoque the', function () {
        expect($scope.InputChanged).toBeDefined();
    });
});