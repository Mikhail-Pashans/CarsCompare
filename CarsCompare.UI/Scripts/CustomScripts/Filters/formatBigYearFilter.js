var carsCompareApp = angular.module('carsCompareApp');

carsCompareApp.filter('formatBigYear', ['$filter', function formatBigYear($filter) {
    'use strict';

    return function (year) {
        if (year === 9999) {
            return 'наст. вр.';
        }
        else {
            return year;
        }
    }
}])