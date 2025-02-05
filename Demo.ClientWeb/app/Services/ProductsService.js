/*
DemoApp.factory('ProductsService', ['$http','$httpParamSerializerJQLike', 
    function ($http,$httpParamSerializerJQLike) {
   
    var ProductsService = {};
   
    ProductsService.getProducts = function () {
        return $resource('http://localhost:1213/api/products/GET', null, { method: 'GET', isArray:true });
    };
    ProductsService.getProduct = function (id) {
        return $resource('http://localhost:1213/api/products/GET/:id/' + id, { method: 'GET' });
    };
    ProductsService.updateProduct = function (product) {
        return $resource('http://localhost:1213/api/products/PUT', $httpParamSerializerJQLike(product), { method: 'POST' });
    };
    ProductsService.addProduct = function (product) {
        return $resource('http://localhost:1213/api/products/POST', $httpParamSerializerJQLike(product), { method: 'POST' });
    };
    ProductsService.deleteProduct = function (id) {
        return $resource('http://localhost:1213/api/products/DELETE' + id , { method: 'POST' });
    };
    return ProductsService;
}]);
*/


DemoApp.service('ProductsService', ['$http', '$httpParamSerializerJQLike',
    function ($http, $httpParamSerializerJQLike) {

    //Create new record
    this.post = function (product) {
        var request = $http({
            method: "POST",
            url: "http://localhost:1213/api/products/POST/",
            data: $httpParamSerializerJQLike(product) ,
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            }
            });
        return request;
    }
    //Get Single Records
    this.get = function (id) {
        return $http.get("http://localhost:1213/api/products/GET/" + id);
    }

    //Get All 
    this.getProducts = function () {
        return $http.get("http://localhost:1213/api/products/GET");
    }

    //Update the Record
    this.put = function (product) {
        var request = $http({
            method: "POST",
            url: "http://localhost:1213/api/products/PUT", 
            data: $httpParamSerializerJQLike(product),
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            }
        });
    return request;
    }

    //Delete the Record
    this.delete = function (id) {
        var request = $http({
            method: "POST",
            url: "http://localhost:1213/api/products/DELETE/" + id
        });
        return request;
    }
}]);