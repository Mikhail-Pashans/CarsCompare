var carsCompareApp = angular.module('carsCompareApp');

carsCompareApp.factory('dataService', function ($http, $q) {
    'use strict';

    return {
        getData: function (conf) {
            var deferred = $q.defer();
            $http(conf)
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                    console.log('Код ответа: ' + status);
                    console.log('Объём данных: ' + headers('content-length'));
                    console.log(config);
                }).error(function (data, status, headers, config) {
                    deferred.reject(status);
                    console.log('Код ответа: ' + status);
                    console.log('Объём данных: ' + headers('content-length'));
                    console.log(config);
                });

            return deferred.promise;
        }
    }
});