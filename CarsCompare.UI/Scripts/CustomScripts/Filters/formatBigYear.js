var carsCompareApp = angular.module('carsCompareApp');

carsCompareApp.filter('formatBigYear', function () {
    return function (year) {
        if (year === 9999) {
            return 'наст. вр.';
        }
        else {
            return year;
        }
    }
})