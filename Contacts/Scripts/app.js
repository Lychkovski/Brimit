var app = angular.module("ContactsApp", ["ContactsApp.controllers", "ngRoute"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.
    when("/", { templateUrl: "/Partials/ContactsList.html", controller: "MainController" }).
    when("/AddContact", { templateUrl: "/Partials/AddContact.html", controller: "AddContactController" }).
    otherwise({ riderectTo: "/" });
}])

app.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.hashPrefix('');
}]);