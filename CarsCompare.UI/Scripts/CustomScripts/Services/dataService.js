var carsCompareApp = angular.module('carsCompareApp');

carsCompareApp.factory('dataService', ['$http', '$q', '$log',
    function dataService($http, $q, $log) {
        'use strict';

        return {
            getData: function (conf) {
                var deferred = $q.defer();
                $http(conf)
                    .success(function (data, status, headers, config) {
                        $log.info('Код ответа: ' + status);
                        $log.info('Объём данных: ' + headers('content-length'));
                        $log.info(config);

                        deferred.resolve(data);
                    }).error(function (data, status, headers, config) {
                        $log.error('Код ответа: ' + status);
                        $log.error('Объём данных: ' + headers('content-length'));
                        $log.error(config);

                        deferred.reject(status);
                    });

                return deferred.promise;
            }
        }
    }
])