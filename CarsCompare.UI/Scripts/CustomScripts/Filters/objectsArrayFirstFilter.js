﻿var carsCompareApp = angular.module('carsCompareApp');

carsCompareApp.filter('objectsArrayFirst', [function objectsArrayFirst() {
    'use strict';

    return function (inputArray, searchCriteria) {
        if (!angular.isDefined(searchCriteria) || !angular.isObject(searchCriteria)) {
            return inputArray;
        }
        var resultArray = [];
        var keepGoing = true;
        angular.forEach(inputArray, function (item) {
            if (keepGoing) {
                if (item.paramName.id === searchCriteria.id) {
                    resultArray.push(item);
                    keepGoing = false;
                }
            }            
        });

        return resultArray;
    }
}])