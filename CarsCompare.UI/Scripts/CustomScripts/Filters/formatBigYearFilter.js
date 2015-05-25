var carsCompareApp = angular.module('carsCompareApp');

carsCompareApp.filter('formatBigYear',
    [
        function formatBigYear() {
            'use strict';

            return function (year) {
                if (year === 9999) {
                    return 'наст. вр.';
                } else {
                    return year;
                }
            }
        }
    ]);