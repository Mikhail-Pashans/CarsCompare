var carsCompareApp = angular.module('carsCompareApp');

carsCompareApp.controller("compareCtrl", function compareCtrl($scope, dataService) {
    'use strict';

    var conf = {
        method: 'GET',
        url: '/Home/GetData',
        timeout: 15000
    };

    var promiseObj = dataService.getData(conf);
    promiseObj.then(function (data) {
        $scope.response = data;        
    });
})