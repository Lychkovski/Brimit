angular.module("ContactsApp.controllers",[]).
    controller("MainController", function ($scope, ContactsService) {

        ContactsService.GetContactsFromDB().then(function(d) {
            $scope.listContacts = d.data.list;
            $scope.contactAdded = ContactsService.contactAdded;
        })
    }).
    controller("AddContactController", function ($scope, ContactsService) {

        $scope.AddContact = function() {
            ContactsService.AddContact($scope.contact);
            ContactsService.contactAdded = true;
        }
    }).
    factory("ContactsService", ["$http", function ($http) {

    var fac = {};

    fac.GetContactsFromDB = function() {
        return $http.get("Contact/GetContacts");
    }

    fac.AddContact = function (contact) {
        $http.post("/Contact/AddContact", contact).then(function (data) {
            window.location.href = '#';
        })
    }

    fac.contactAdded = false;

    return fac;

 }])