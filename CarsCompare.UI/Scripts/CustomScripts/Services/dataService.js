var carsCompareApp = angular.module('carsCompareApp');

carsCompareApp.factory('dataService', function ($http, $q, $log) {
    'use strict';

    return {
        getData: function (conf) {
            var deferred = $q.defer();
            $http(conf)
                .success(function (response, status, headers, config) {
                    deferred.resolve(response);
                    $log.info('Код ответа: ' + status);
                    $log.info('Объём данных: ' + headers('content-length'));
                    $log.info(config);
                }).error(function (response, status, headers, config) {
                    deferred.reject(response);
                    $log.error('Код ответа: ' + status);
                    $log.error('Объём данных: ' + headers('content-length'));
                    $log.error(config);
                });

            return deferred.promise;
        }
    }
})