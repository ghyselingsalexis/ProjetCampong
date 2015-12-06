(function () {
    angular.module("Campong").config(function ($routeProvider) {
        $routeProvider.when("/Emplacement", {
            templateUrl: "templates/Emplacement.html",
            controller: "EmplacementCtrl"
        }).when("/Employe", {
            templateUrl: "templates/Employe.html",
            controller: "EmployeCtrl"
        }).when("/Reservation", {
            templateUrl: "templates/Reservation.html",
            controller: "ReservationCtrl"
        }).when("/FormulaireReservation", {
            templateUrl: "templates/FormulaireReservation.html",
            controller: "FormulaireReservationCtrl"
        }).when("/Inscription", {
            templateUrl: "templates/Inscription.html",
            controller: "InscriptionCtrl"
        }).when("/LivreOr", {
            templateUrl: "templates/LivreOr.html",
            controller: "LivreOrCtrl"

        }).when("/Confirmation", {
            templateUrl: "templates/Confirmation.html",
            controller: "ConfirmationCtrl"

        }).when("/DateFerme", {
            templateUrl: "templates/DateFerme.html",
            controller: "DateFermeCtrl"

        }).when("/Historique", {
            templateUrl: "templates/Historique.html"
        }).when("/Decouvrir", {
            templateUrl: "templates/Decouvrir.html"
        }).when("/Animations", {
            templateUrl: "templates/Animations.html"
        }).when("/Tarif", {
            templateUrl: "templates/Tarif.html",
            controller : "EmplacementCtrl"
        }).otherwise({
            templateUrl: "templates/Accueil.html"
        });

    });
})();