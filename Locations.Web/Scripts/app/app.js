(function() {
    angular.module('app', ['uiGmapgoogle-maps']).config(function (uiGmapGoogleMapApiProvider) {
        uiGmapGoogleMapApiProvider.configure({
            //    key: 'your api key',
            v: '3.17',
            libraries: 'places'
        });
    });
})();