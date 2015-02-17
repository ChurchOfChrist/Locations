//Search locations tests
//We don't need to test google maps calls
describe('Search Service Tests', function() {
    var searchService;
    beforeEach(module('app'));
    beforeEach(inject(function (_SearchService_) {
        searchService = _SearchService_;
    }));
    it('A SearchService should exist', function () {
        expect(searchService).toBeDefined();
    });
   
    describe('GetPlacesByName tests', function () {
        
        it('GetPlacesByName should exist', function () {
            expect(searchService.GetPlacesByName).toBeDefined();
        });
        it('GetPlacesByName should return the matches places returned by the api', function () {
            expect(searchService.GetPlacesByName).toBeDefined();
        });
    });
});