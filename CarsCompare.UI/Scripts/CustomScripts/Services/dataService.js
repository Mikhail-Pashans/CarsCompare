var carsCompareApp = angular.module('carsCompareServices');

carsCompareApp.factory('dataService',
    [
        '$http', '$q', '$log',
        function dataService($http, $q, $log) {
            'use strict';

            return {
                getData: function (conf) {
                    var deferred = $q.defer();
                    $http(conf)
                        .success(function (data, status, headers, config) {
                            $log.info('Status code: ' + status);
                            $log.info('Data amount: ' + headers('content-length'));
                            $log.info(config);

                            deferred.resolve(data);
                        }).error(function (data, status, headers, config) {
                            $log.error('Status code: ' + status);
                            $log.error('Data amount: ' + headers('content-length'));
                            $log.error(config);

                            deferred.reject(status);
                        });

                    return deferred.promise;
                }
            }
        }
    ]);