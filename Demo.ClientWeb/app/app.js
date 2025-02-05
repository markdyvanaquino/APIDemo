var DemoApp = angular.module('DemoApp', ['ngResource', 'ngRoute']);
// configure our routes
DemoApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'Products/List.html',
            controller: 'ProductsController'
        })

        // route for Edit
        .when('/:id/Edit', {
            templateUrl: 'Products/Edit.html',
            controller: 'ProductsController'
        })

        // route for Delete
        .when('/:id/Delete', {
            templateUrl: 'Products/Delete.html',
            controller: 'ProductsController'
        })

        // route for Add
        .when('/Add', {
            templateUrl: 'Products/Add.html',
            controller: 'ProductsController'
        });
}
]);