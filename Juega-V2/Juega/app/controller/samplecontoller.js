var myapp = angular.module('sampleapp', []);

myapp.controller('samplecontoller', function ($scope, $interval) {

    $scope.init = $interval(function () {

        var date = new Date();
        $scope.dates = [{ "date1": date }]

    }, 100)

});
myapp.filter('dateFormat', function ($filter) {
    return function (input) {
        if (input == null) { return ""; }

        var _date = $filter('date')(new Date(input), 'MMM dd yyyy');

        return _date.toUpperCase();

    };
});
myapp.filter('dateFormat1', function ($filter) {
    return function (input) {
        if (input == null) { return ""; }

        var _date = $filter('date')(new Date(input), 'MM dd yyyy');

        return _date.toUpperCase();

    };
});

myapp.filter('time', function ($filter) {
    return function (input) {
        if (input == null) { return ""; }

        var _date = $filter('date')(new Date(input), 'HH:mm:ss');

        return _date.toUpperCase();

    };
});
myapp.filter('datetime', function ($filter) {
    return function (input) {
        if (input == null) { return ""; }

        var _date = $filter('date')(new Date(input),
                                    'MMM dd yyyy - HH:mm:ss');

        return _date.toUpperCase();

    };
});
myapp.filter('datetime1', function ($filter) {
    return function (input) {
        if (input == null) { return ""; }

        var _date = $filter('date')(new Date(input),
                                    'MM dd yyyy - HH:mm:ss');

        return _date.toUpperCase();

    };
});

