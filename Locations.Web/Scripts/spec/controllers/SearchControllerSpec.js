//Search locations tests
describe('Search Controller Tests', function () {
    var $controller, searchCtrl, $scope, searchService;
    beforeEach(module('app'));
    beforeEach(inject(function (_$controller_, _$rootScope_, _SearchService_) {
        $controller = _$controller_;
        searchService = _SearchService_;
        $scope = _$rootScope_.$new();
    }));
    beforeEach(function () {
        searchCtrl = $controller('SearchCtrl', { $scope: $scope });
    });
    it('SearchCtrl should exist', function () {
        expect(searchCtrl).toBeDefined();
    });
    describe('Find places tests', function () {
        it('Should have a find places method', function () {
            expect($scope.FindPlaces).toBeDefined();
        });
    });
});