var carsCompareApp = angular.module('carsCompareApp');

carsCompareApp.filter('paramBlankValue', [function paramBlankValue() {
    'use strict';

    return function (value) {
        if (value === '') {
            return '—';
        } else {
            return value;
        }
    }
}])