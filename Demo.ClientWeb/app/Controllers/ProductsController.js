DemoApp.controller('ProductsController', function ($scope, $location, $routeParams, ProductsService) {

    $scope.Title = "Products";
    $scope.init = function()
    {
        getProducts();
        $scope.selectedProduct = [];
    }
    
    var getProducts = function () {
        ProductsService.getProducts().then(function (products) {
            $scope.products = products.data
        },
        function (error) {
            $log.error('failure loading products', error);
        });
    }
        $scope.go = function ( path ) {
          $location.path( path );
        };

        $scope.loadEdit = function ()
        {
            var id = $routeParams.id;
            ProductsService.get(id).then(function (product) {
                $scope.selectedProduct = product.data;
            });
        }

        $scope.updateProduct = function (product) {
            ProductsService.put(product).then(function (data) {
                if (data) {
                    $scope.go('/');
                }
            });
        }

        $scope.addProduct = function (product) {
            ProductsService.post(product).then(function (data) {
                if (data) {
                    $scope.go('/');
                }
            });
        }
        $scope.deleteProduct = function (id) {
            ProductsService.delete(id).then(function (data) {
                if (data) {
                    $scope.go('/');
                }
            });
        }

        $scope.loadDelete = function () {
            var id = $routeParams.id;
            ProductsService.get(id).then(function (product) {
                $scope.selectedProduct = product.data;
            });
        }

        $scope.loadAdd = function ()
        {
            $scope.selectedProduct = getProductObject();
        }

        var getProductObject = function()
        {
            var Product = 
            {
                Id : 0,
                Name: "",
                Price: 0
            };
            return Product;
        }
});