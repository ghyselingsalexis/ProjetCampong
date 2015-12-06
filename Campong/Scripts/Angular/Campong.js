(function () {
    var app = angular.module("Campong", ["ngRoute", "ngAnimate", "ui.bootstrap"]);
})();

// Factory d'un emplacement 
(function () {
    angular.module("Campong").factory("EmplacementFactory", ['$http', function EmplacementFactory($http) {
        return {
            add: function (Emplacement) {
                return $http({
                    method: "POST", url: "/api/Emplacement", data: Emplacement
                });
            },
            getAll: function () {
                return $http({
                    method: "GET", url: "/api/Emplacement"
                });
            },

            getEmplacementsMaintenance:function(dateDeb,dateFin,id){
                return $http({
                    method: "POST", url: "/api/Emplacement/postMaintenance", data: { dateDeb: dateDeb, dateFin: dateFin, id: id }
                })
            },
            delete: function (numero) {
                return $http({
                    method: "DELETE", url: "/api/Emplacement/", params: { numero: numero }
                });
            },
            modifier: function (numero, Emplacement) {
                return $http({
                    method: "PUT", url: "/api/Emplacement/", params: { numero: numero }, data: Emplacement
                });
            }
        }
    }]);
})();


// controller d'un emplacement 
(function () {
    angular.module("Campong").controller("EmplacementCtrl", ["$scope","$uibModal", "EmplacementFactory", function ($scope,$uibModal, EmplacementFactory) {



        $scope.getAllEmplacements = function () {
            EmplacementFactory.getAll().success(function (emplacementsFromDB) {
                $scope.emplacements = emplacementsFromDB;
            });
        };

        $scope.supprimer = function (index) {
            var idToDelete = $scope.emplacements[index].Numero;
            $scope.emplacements.splice(index, 1);
            EmplacementFactory.delete(idToDelete);


        };

        $scope.modifier = function (emplacement) {
            $scope.emplacement = emplacement;

            var modalGestionInstance = $uibModal.open({
                animation: true,
                templateUrl: "GestionEmplacement.html",
                controller: "GestionEmplacementController",
                resolve: {
                    emp: function () {
                        return $scope.emplacement;
                    }
                }
            });

            modalGestionInstance.result.then(function () {
                $scope.getAllEmplacements();
                console.log("recharge la page maintenant après modification");
            });



        };
        $scope.ajouter = function () {
            var ajoutEmplacement = $uibModal.open({
                animation: true,
                templateUrl: "AjoutEmplacement.html",
                controller: "AjoutEmplacementController",

            });

            ajoutEmplacement.result.then(function () {
                $scope.getAllEmplacements();
                console.log("recharge la page maintenant après modification");
            });

        };
        $scope.getAllEmplacements();
    }]);
})();

//Controller pour l'employe
(function () {
    angular.module("Campong").controller("EmployeCtrl", ["$scope", "$uibModal", "EmployeFactory", function ($scope, $uibModal, EmployeFactory) {



        $scope.getAllEmployes = function () {
            EmployeFactory.getAll().success(function (employesFromDB) {
                $scope.employes = employesFromDB;
            });
        };

        $scope.supprimer = function (index) {
            var idToDelete = $scope.employes[index].NomUtilisateur;
            $scope.employes.splice(index, 1);
            EmployeFactory.delete(idToDelete);


        };

        $scope.modifier = function (employe) {
            $scope.employe = employe;

            var modalGestionInstance = $uibModal.open({
                animation: true,
                templateUrl: "GestionEmploye.html",
                controller: "GestionEmployeController",
                resolve: {
                    emplo: function () {
                        return $scope.employe;
                    }
                }
            });

            modalGestionInstance.result.then(function () {
                $scope.getAllEmployes();
                console.log("recharge la page maintenant après modification");
            });



        };
        $scope.ajouter = function () {
            var AjoutEmploye = $uibModal.open({
                animation: true,
                templateUrl: "AjoutEmploye.html",
                controller: "AjoutEmployeController",

            });

            AjoutEmploye.result.then(function () {
                $scope.getAllEmployes();
                console.log("recharge la page maintenant après modification");
            });

        };
        $scope.getAllEmployes();
    }]);
})();
// controller pour la gestion d'un employé
(function () {
    angular.module("Campong").controller('GestionEmployeController', ["$scope", "$uibModalInstance", "EmployeFactory", "emplo", function ($scope, $uibModalInstance, EmployeFactory, emplo) {
        $scope.employe = emplo;
        var nom = emplo.NomUtilisateur;



        $scope.ok = function () {
            if ($scope.employe.NomUtilisateur == null || $scope.employe.Nom == null || $scope.employe.Prenom == null || $scope.employe.MdpEmploye == null ||
                       $scope.employe.Affectation == null) {
                alert(" Vous ne pouvez pas laisser un champ vide lors de la modification de la fiche d'un employé ");
            }
            else if ($scope.employe.NomUtilisateur == "" || $scope.employe.Nom == "" || $scope.employe.Prenom == "" || $scope.employe.MdpEmploye == "" ||
                $scope.employe.Affectation == "") {
                alert(" Vous ne pouvez pas laisser un champ vide lors de la modification de la fiche d'un employé");
            }
            else {
                EmployeFactory.modifier($scope.employe.NomUtilisateur, $scope.employe).success(function () {
                    $uibModalInstance.close();
                })
            }
        }

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }

    }]);
})();

// controller pour l'ajout d'un employé
(function () {
    angular.module("Campong").controller("AjoutEmployeController",
        ["$scope", "$uibModalInstance", "EmployeFactory",
            function ($scope, $uibModalInstance, EmployeFactory) {

                $scope.Ajoutemploye = {};

               

                $scope.ajout = function () {
                    if ($scope.Ajoutemploye.NomUtilisateur == null || $scope.Ajoutemploye.Nom == null || $scope.Ajoutemploye.Prenom == null || $scope.Ajoutemploye.MdpEmploye == null ||
                                            $scope.Ajoutemploye.Affectation == null) {
                        alert(" Veuillez compléter tous les champs ");
                    }
                    else if ($scope.Ajoutemploye.NomUtilisateur == "" || $scope.Ajoutemploye.Nom == "" || $scope.Ajoutemploye.Prenom == "" || $scope.Ajoutemploye.MdpEmploye == "" ||
                        $scope.Ajoutemploye.Affectation == "") {
                        alert(" Veuillez compléter tous les champs ");
                    }
                    else {
                        EmployeFactory.add($scope.Ajoutemploye).success(function () {
                            $uibModalInstance.close();
                        })

                    }
                }

                $scope.cancel = function () {
                    $uibModalInstance.dismiss('cancel');
                }
            }]);
})();

// Controller pour l'ajout d'un emplacement
(function () {
    angular.module("Campong").controller("AjoutEmplacementController",
        ["$scope", "$uibModalInstance", "EmplacementFactory", 
            function ($scope, $uibModalInstance, EmplacementFactory) {

                $scope.emplacement = {};



                $scope.ok = function () {
                   
                    if ($scope.emplacement.Type == null || $scope.emplacement.Surface == null || $scope.emplacement.NbPlaces == null ||
                        $scope.emplacement.PrixBase == null || $scope.emplacement.PrixEnfSup == null || $scope.emplacement.PrixAdultSup == null ||
                            $scope.emplacement.PrixVehicule == null || $scope.emplacement.PrixElectricite == null) {
                        alert(" Veuillez compléter tous les champs ");
                    }   
                    else if ($scope.emplacement.Type == "" || $scope.emplacement.Surface == "" || $scope.emplacement.NbPlaces == "" ||
                        $scope.emplacement.PrixBase == "" || $scope.emplacement.PrixEnfSup == "" || $scope.emplacement.PrixAdultSup == "" ||
                            $scope.emplacement.PrixVehicule == "" || $scope.emplacement.PrixElectricite == "") {
                        alert(" Veuillez compléter tous les champs ");
                    }
                    else {
                        EmplacementFactory.add($scope.emplacement).success(function () {
                            $uibModalInstance.close();
                        })
                    }

                }

                $scope.cancel = function () {
                    $uibModalInstance.dismiss('cancel');
                }
            }]);
})();

// controller pour la gestion d'un emplacement
(function () {
    angular.module("Campong").controller("GestionEmplacementController",
        ["$scope", "$uibModalInstance", "EmplacementFactory", "emp","ReservationService",
            function ($scope, $uibModalInstance, EmplacementFactory, emp, ReservationService) {

                $scope.emplacement = emp;
                $scope.DateDebMaintenance = null;
                $scope.DateFinMaintenance = null;
                

                $scope.ok = function () {
                    if ($scope.emplacement.Type == null || $scope.emplacement.Surface == null || $scope.emplacement.NbPlaces == null ||
                        $scope.emplacement.PrixBase == null || $scope.emplacement.PrixEnfSup == null || $scope.emplacement.PrixAdultSup == null ||
                            $scope.emplacement.PrixVehicule == null || $scope.emplacement.PrixElectricite == null) {
                        alert(" Vous ne pouvez pas laisser un champ vide lors de la modification d'un emplacement déjà créé ");
                    }
                    else if ($scope.emplacement.Type == "" || $scope.emplacement.Surface == "" || $scope.emplacement.NbPlaces == "" ||
                        $scope.emplacement.PrixBase == "" || $scope.emplacement.PrixEnfSup == "" || $scope.emplacement.PrixAdultSup == "" ||
                            $scope.emplacement.PrixVehicule == "" || $scope.emplacement.PrixElectricite == "") {
                        alert(" Vous ne pouvez pas laisser un champ vide lors de la modification d'un emplacement déjà créé  ");
                    }
                    else {
                        if ($scope.DateDebMaintenance == null || $scope.DateFinMaintenance == null) {
                            $scope.emplacement.DateDebMaintenance = "02-01-2000";
                            $scope.emplacement.DateFinMaintenance = "02-01-2000";
                            EmplacementFactory.modifier($scope.emplacement.Numero, $scope.emplacement).success(function () {
                                $uibModalInstance.close();
                            })
                        }
                        else {
                            $scope.DateDebMaintenance.setHours($scope.DateDebMaintenance.getHours() + 1);
                            $scope.DateFinMaintenance.setHours($scope.DateFinMaintenance.getHours() + 1);
                            EmplacementFactory.getEmplacementsMaintenance($scope.DateDebMaintenance, $scope.DateFinMaintenance, $scope.emplacement.Numero).success(function (emplacementEnMaintenance) {
                                if (emplacementEnMaintenance == "") {
                                    $scope.emplacement.DateDebMaintenance = $scope.DateDebMaintenance;
                                    $scope.emplacement.DateFinMaintenance = $scope.DateFinMaintenance;
                                    EmplacementFactory.modifier($scope.emplacement.Numero, $scope.emplacement).success(function () {
                                        $uibModalInstance.close();
                                    })
                                }
                                else {
                                    alert("L'emplacement est réservé à cette date là");

                                }
                            })
                        }
                    }
                   
                }

                $scope.cancel = function () {
                   $uibModalInstance.dismiss('cancel');
                }

                $scope.toggleMin = function () {
                    $scope.minDate = $scope.minDate ? null : new Date();
                };
                $scope.toggleMin();
                $scope.maxDate = new Date(2020, 5, 22);

                $scope.open = function () {
                    $scope.status.opened = true;
                };

                $scope.status = {
                    opened: false
                };
                $scope.ouvrir = function () {
                    if ($scope.DateDebMaintenance >= $scope.DateFinMaintenance) {
                        $scope.DateFinMaintenance = null;
                    }
                    if ($scope.DateDebMaintenance != null) {
                        $scope.min = null;
                        $scope.min = new Date();
                        $scope.min.setDate($scope.DateDebMaintenance.getDate() + 1);
                        $scope.min.setMonth($scope.DateDebMaintenance.getMonth());
                        $scope.min.setFullYear($scope.DateDebMaintenance.getFullYear());
                        $scope.statut.opened = true;
                    } else {
                        $scope.DateFinMaintenance = null;
                    };
                };
                $scope.statut = {
                    opened: false
                };
            }]);
})();
// Controller pour la confirmation d'un emplacement
(function () {
    angular.module("Campong").controller('ConfirmationCtrl', ["$scope", "$uibModal", "ReservationFactory", function ($scope, $uibModal, ReservationFactory) {
        $scope.getAllReservations = function () {
            ReservationFactory.getAll().success(function (reservationFromDB) {
                $scope.reservations = reservationFromDB;
            });
        };

        $scope.change =  function(reservation){
            $scope.reservation=reservation;
            var AjoutEmploye = $uibModal.open({
                animation: true,
                templateUrl: "ConfirmationReservation.html",
                controller: "ConfirmationModalCtrl",
                resolve: {
                reserv: function () {
                return $scope.reservation;
            }
        }
            })
            AjoutEmploye.result.then(function () {
                console.log("recharge la page maintenant après modification");
                $scope.getAllReservations();
            });

        };

        $scope.getAllReservations();
    }])
})();

//controller pour la date ferme d'une réservation
(function () {
    angular.module("Campong").controller('DateFermeCtrl', ["$scope", "$uibModal", "ReservationFactory", function ($scope, $uibModal, ReservationFactory) {
       
        $scope.getAllDateFermes = function () {
            ReservationFactory.getAllReserv().success(function (reservationFromDB) {
                $scope.reservations = reservationFromDB;
            });
        };
        $scope.getAllDateFermes();
        $scope.changeDate = function (reservation) {
            $scope.reservation = reservation;

            var modalGestionInstance = $uibModal.open({
                animation: true,
                templateUrl: "DateFerme.html",
                controller: "ChoisirDateFermeController",
                resolve: {
                    reserv: function () {
                        return $scope.reservation;
                    }
                }
            });

            modalGestionInstance.result.then(function () {
                console.log("recharge la page maintenant après modification");
                $scope.getAllDateFermes();
            });
        };
        
    }])
 })();

// modal de la date ferme
 (function () {
     angular.module("Campong").controller('ChoisirDateFermeController', ["$scope", "$uibModalInstance", "ReservationFactory","reserv", function ($scope, $uibModalInstance, ReservationFactory,reserv) {

         $scope.reservation = reserv;
           
         $scope.minDate = new Date($scope.reservation.DateFin);
         

         $scope.minDate.setDate($scope.minDate.getDate() - 3);
         
                $scope.open = function () {
                    $scope.status.opened = true;
                };

                $scope.status = {
                    opened: false
                };
                $scope.confirmer = function () {
                    if ($scope.DateFermeModel == null || $scope.DateFermeModel == "") {
                        alert("Veuillez sélectionner une date ou annuler l'action en cours");
                    }
                    else {
                        ReservationFactory.DateFerme($scope.reservation.Id, $scope.DateFermeModel).success(function () {
                            $uibModalInstance.close();
                        })

                    }
                }

                $scope.cancel = function () {
                    $uibModalInstance.dismiss('cancel');
                }
               
                
            }])
  })();

// Modal pour la confirmation
(function () {
    angular.module("Campong").controller('ConfirmationModalCtrl', ["$scope", "$uibModalInstance","reserv", "ReservationFactory", function ($scope,$uibModalInstance,reserv,ReservationFactory) {
        
        
        $scope.reservation = reserv;
       

        $scope.confirmer = function () {

            
            ReservationFactory.ConfirmationReservation($scope.reservation.Id).success(function () {
                $uibModalInstance.close();
            })
        }

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }
  
        }]);
    })();

// Controller pour la réservation
(function () {
    angular.module("Campong").controller('ReservationCtrl', ["$scope", "ReservationFactory","ReservationService","UtilisateurService","ClientFactory","ClientService", function ($scope, ReservationFactory,ReservationService,UtilisateurService,ClientFactory, ClientService) {
        $scope.typeUtil = UtilisateurService.getTypeUtil();

        $scope.$watch(UtilisateurService.getTypeUtil, function () {
            $scope.typeUtil = UtilisateurService.getTypeUtil();
        }, true);
        
        $scope.emplacements = [];
        $scope.isLoading = false;
        $scope.toggleMin = function() {
            $scope.minDate = $scope.minDate ? null : new Date();
        };
        $scope.toggleMin();
        $scope.maxDate = new Date(2020, 5, 22);

        $scope.open = function() {
            $scope.status.opened = true;
        };

        $scope.status = {
            opened: false
        };
        $scope.ouvrir = function () {
            if ($scope.dateDeb >= $scope.dateFin) {
                $scope.dateFin = null;
            }
            if ($scope.dateDeb != null) {
                $scope.min = null;
                $scope.min = new Date();
                $scope.min.setDate($scope.dateDeb.getDate() + 1);
                $scope.min.setMonth($scope.dateDeb.getMonth());
                $scope.min.setFullYear($scope.dateDeb.getFullYear());
                $scope.statut.opened = true;
            } else {
                $scope.dateFin = null;
            };
        };
        $scope.statut = {
            opened: false
        };

        $scope.rechercher = function () {
            $scope.isLoading = true;
            if ($scope.dateDeb!=null && $scope.dateFin!=null && $scope.dateDeb < $scope.dateFin) {
                $scope.dateDeb.setHours($scope.dateDeb.getHours() + 1);
                $scope.dateFin.setHours($scope.dateFin.getHours() + 1);
                ReservationFactory.get($scope.dateDeb, $scope.dateFin).success(function (emplacements) {
                    $scope.emplacements = emplacements;
                    $scope.isLoading = false;
                });
            } else {
                alert("Entrez des dates correctes");
                $scope.isLoading = false;
                $scope.dateDeb = null;
                $scope.dateFin = null;
                $scope.emplacements = null;
            }
   
        };
        $scope.envoiParametre = function (emplacement) {
            if ($scope.typeUtil == "client" || $scope.typeUtil == "Employe") {
                if ($scope.typeUtil == "Employe") {
                    var adresseCli = prompt("Entrez l'adresse mail du client");
                    ClientFactory.get(adresseCli).success(function (client) {
                        if (!client) {
                            alert("Adresse mail incorrecte");
                        } else {
                            ClientService.setClient(client);
                            $scope.dateDeb.setHours($scope.dateDeb.getHours() + 1);
                            $scope.dateFin.setHours($scope.dateFin.getHours() + 1);
                            ReservationService.setDateDeb($scope.dateDeb);
                            ReservationService.setDateFin($scope.dateFin);
                            ReservationService.setEmplacement(emplacement);
                            document.location.href = "#/FormulaireReservation";
                        }
                    })
                } else {
                    $scope.dateDeb.setHours($scope.dateDeb.getHours() + 1);
                    $scope.dateFin.setHours($scope.dateFin.getHours() + 1);
                    ReservationService.setDateDeb($scope.dateDeb);
                    ReservationService.setDateFin($scope.dateFin);
                    ReservationService.setEmplacement(emplacement);
                    document.location.href = "#/FormulaireReservation";
                }
            } else {
                alert("Vous devez vous connecter pour effectuer une réservation");
            }
        };
    }]);
})();

(function () {
    angular.module("Campong").factory("ReservationFactory", ['$http', function ReservationFactory($http) {
        return {
            get: function (dateDeb, dateFin) {
                return $http({
                    method: "POST", url: "/api/Reservation", data: {
                        dateDeb: dateDeb,
                        dateFin: dateFin
                    }
                });
            },

            ConfirmationReservation:function(id){
                return $http({
                    method: "PUT", url: "/api/Reservation" , params :{ id : id}
                });
            },
            DateFerme: function (id,DateFin) {
                return $http({
                    method: "PUT", url: "/api/Reservation", params: { id: id , dateFin:DateFin}
                });
            },

            getAll: function () {
                return $http({
                    method: "GET", url: "/api/Reservation"
                });
            },
            getAllReserv: function () {
                return $http({
                    method: "GET", url: "/api/DateFerme" 
                });
            },
            add: function (mailClient, numeroEmplacement, dateDeb, dateFin, dateFerme,nbAdultes,nbEnfants,nbVehicule,electricite,confirmation) {
                return $http({
                    method:"PUT",url:"/api/Reservation",data: {
                        mailClient: mailClient,
                        numeroEmplacement: numeroEmplacement,
                        dateDeb: dateDeb,
                        dateFin: dateFin,
                        dateFerme: dateFerme,
                        nbAdultes: nbAdultes,
                        nbEnfants: nbEnfants,
                        nbVehicule: nbVehicule,
                        electricite: electricite,
                        confirmation:confirmation
                    }
                });
            }
        };
    }]);
})();

(function () {
    angular.module("Campong").service("ReservationService", function ReservationService() {
        var dateDeb = {};
        var dateFin = {};
        var emplacement = {};

        return {
            getDateDeb : function () {
                return dateDeb;
            },

            setDateDeb : function (date) {
                dateDeb = date || {};
            },

            getDateFin : function () {
                return dateFin;
            },

            setDateFin : function (date) {
                dateFin = date || {};
            },
            getEmplacement: function () {
                return emplacement;
            },

            setEmplacement: function (e) {
                emplacement = e || {};
            }

        };
    });
})();

(function () {
    angular.module("Campong").controller("FormulaireReservationCtrl", ["$scope", "ReservationFactory", "ReservationService", "UtilisateurService", "ClientService", function ($scope, ReservationFactory, ReservationService, UtilisateurService, ClientService) {
        //Récupération de l'utilisateur et son type
        $scope.typeUtil = UtilisateurService.getTypeUtil();
        if ($scope.typeUtil == "Employe") {
            $scope.utilisateur = ClientService.getClient();
        } else {
            $scope.utilisateur = UtilisateurService.getUtilisateur();

            $scope.$watch(UtilisateurService.getUtilisateur, function () {
                $scope.utilisateur = UtilisateurService.getUtilisateur();
            }, true);
            $scope.$watch(UtilisateurService.getTypeUtil, function () {
                $scope.typeUtil = UtilisateurService.getTypeUtil();
            }, true);
        }

        //Récupération de la date de début, la date de fin et l'emplacement depuis le service
        $scope.dateDeb = ReservationService.getDateDeb();
        $scope.dateFin = ReservationService.getDateFin();
        $scope.emplacement = ReservationService.getEmplacement();
        $scope.$watch(ReservationService.getDateDeb, function () {
            $scope.dateDeb = ReservationService.getDateDeb();
        }, true);
        $scope.$watch(ReservationService.getDateFin, function () {
            $scope.dateFin = ReservationService.getDateFin();
        }, true);
        $scope.$watch(ReservationService.getEmplacement, function () {
            $scope.emplacement = ReservationService.getEmplacement();
        }, true);

        $scope.dateFerme = true;

        //Calcul du nombre de jours à réserver
        var dateDebEnJours = $scope.dateDeb.getTime() / 86400000;
        var dateFinEnJours = $scope.dateFin.getTime() / 86400000;
        $scope.nbNuits = new Number(dateFinEnJours - dateDebEnJours).toFixed(0);
        $scope.nbAdultes = 2;
        $scope.nbEnfants = 0;
        $scope.nbVehicule = 0;

        //Calcul de la facture
        var facture = function () {
            $scope.sousTotPrixBase = $scope.nbNuits * $scope.emplacement.PrixBase
            if ($scope.electricite) {
                $scope.sousTotPrixBase += $scope.nbNuits * $scope.emplacement.PrixElectricite;
            }
            $scope.sousTotAdulteSup = ($scope.nbAdultes - 2) * $scope.emplacement.PrixAdultSup;
            $scope.sousTotEnfSup = $scope.nbEnfants * $scope.emplacement.PrixEnfSup;
            $scope.sousTotVehicule = $scope.nbVehicule * $scope.emplacement.PrixVehicule;
            $scope.totalFacture = $scope.sousTotPrixBase + $scope.sousTotAdulteSup + $scope.sousTotEnfSup + $scope.sousTotVehicule;
        }
        
        facture();

        //appeler lorsque l'utilisateur confirme sa demande de réservation
        $scope.confirmation = function () {
            if ($scope.dateFerme == null) {
                $scope.dateFerme = false;
            }
            if ($scope.electricite == null) {
                $scope.electricite = false;
            }
            if ($scope.typeUtil == "Employe") {
                ReservationFactory.add($scope.utilisateur.AdresseMail, $scope.emplacement.Numero, $scope.dateDeb, $scope.dateFin, $scope.dateFerme, $scope.nbAdultes, $scope.nbEnfants, $scope.nbVehicule, $scope.electricite, true).success(function () {
                    alert("La réservation a bien été faite");
                    document.location.href = "#/Accueil";
                });
            } else {
                ReservationFactory.add($scope.utilisateur.AdresseMail, $scope.emplacement.Numero, $scope.dateDeb, $scope.dateFin, $scope.dateFerme, $scope.nbAdultes, $scope.nbEnfants, $scope.nbVehicule, $scope.electricite, false).success(function () {
                    alert("La demande de réservation a bien été faite");
                    document.location.href = "#/Accueil";
                });
            }
        }
        //calcul du prix pour les véhicules
        $scope.nombreVehicule = function () {
            facture();
        }
        //Calcul du nombre d'adultes possible
        $scope.nombreAdultes = function () {
            var adultes = [];
            for (var i = 2; i <= ($scope.emplacement.NbPlaces - $scope.nbEnfants) ; i++) {
                adultes.push(i);
            }
            $scope.adultes = adultes;
            facture();
        }

        //Calcul du nombre d'enfants possible
        $scope.nombreEnfants = function () {
            var enfants = [];
            for (var i = 0; i <= ($scope.emplacement.NbPlaces - $scope.nbAdultes) ; i++) {
                enfants.push(i);
            }
            $scope.enfants = enfants;
            facture();
        }
        $scope.isElectricite = function () {
            facture();
        }
        $scope.nombreAdultes();
        $scope.nombreEnfants();
    }]);
})();
(function () {
    angular.module("Campong").controller("IndexCtrl", ["$scope", "UtilisateurService", "ClientFactory", "EmployeFactory", "AdministrateurFactory", function ($scope, UtilisateurService, ClientFactory, EmployeFactory, AdministrateurFactory) {
        $scope.deconnecte = true;
        $scope.admin = false;
        $scope.employe = false;
        $scope.connexion = function () {
            if ($scope.email != null && $scope.mdp != null) {
                ClientFactory.get($scope.email)
                    .success(function (client) {
                        if (client != null && client.MdpClient == $scope.mdp) {
                            alert("Bonjour " + client.Prenom);
                            $scope.utilisateur = client;
                            UtilisateurService.setUtilisateur(client);
                            UtilisateurService.setTypeUtil("client");
                            $scope.deconnecte = false;
                            $scope.mdp = null;
                            $scope.email = null;
                        } else if (client != null) {
                            alert("Mot de passe incorrect");
                            $scope.mdp = null;
                            $scope.email = null;
                        } else {
                            EmployeFactory.get($scope.email)
                            .success(function (Employe) {
                                if (Employe != null && Employe.MdpEmploye == $scope.mdp) {
                                    alert("Bonjour " + Employe.Prenom);
                                    $scope.utilisateur = Employe;
                                    UtilisateurService.setUtilisateur(Employe);
                                    UtilisateurService.setTypeUtil("Employe");
                                    $scope.deconnecte = false;
                                    $scope.employe = true;
                                    $scope.mdp = null;
                                    $scope.email = null;
                                } else if (Employe != null) {
                                    alert("Mot de passe employé incorrect");
                                    $scope.mdp = null;
                                    $scope.email = null;
                                } else {
                                    AdministrateurFactory.get($scope.email)
                                    .success(function (Administrateur) {
                                        if (Administrateur != null && Administrateur.MdpAdministrateur == $scope.mdp) {
                                            alert("Bonjour " + Administrateur.Prenom);
                                            $scope.utilisateur = Administrateur;
                                            UtilisateurService.setUtilisateur(Administrateur);
                                            UtilisateurService.setTypeUtil("Administrateur");
                                            $scope.admin = true;
                                            $scope.deconnecte = false;
                                            $scope.mdp = null;
                                            $scope.email = null;
                                        } else if (Administrateur != null) {
                                            alert("Mot de passe administrateur incorrect ");
                                            $scope.mdp = null;
                                            $scope.email = null;
                                        } else {
                                            alert("Adresse Mail incorrecte");
                                            $scope.mdp = null;
                                            $scope.email = null;
                                        }
                                    });
                                }
                               
                            });
                        }
                    });
            }
        }
        $scope.deconnexion = function () {
            UtilisateurService.setUtilisateur();
            UtilisateurService.setTypeUtil();
            $scope.deconnecte = true;
            $scope.admin = false;
            $scope.employe = false;
            document.location.href = "#/Accueil";
        }
    }]);
})();
(function () {
    angular.module("Campong").service("UtilisateurService", function UtilisateurService() {
        var utilisateur = {};
        var typeUtil = {};

        return {
            getUtilisateur: function () {
                return utilisateur;
            },

            setUtilisateur: function (util) {
                utilisateur = util || {};
            },

            getTypeUtil: function () {
                return typeUtil;
            },

            setTypeUtil: function (type) {
                typeUtil = type || {};
            }
        };
    });
})();
(function () {
    angular.module("Campong").service("ClientService", function ClientService() {
        var client = {};

        return {
            getClient: function () {
                return client;
            },

            setClient: function (cli) {
                client = cli || {};
            }
        };
    });
})();
(function () {
    angular.module("Campong").factory("ClientFactory", ['$http', function ClientFactory($http) {
        return {
            get: function(mailClient){
                return $http({
                    method:"GET",url:"/api/Client",params:{mailClient:mailClient}
                });
            },
            add: function (mailClient, nom, prenom, adressePostale, numeroTel, mdpClient, dateNaissance) {
                return $http({
                    method:"POST",url:"/api/Client",data:
                        {
                            mailClient: mailClient,
                            nom: nom,
                            prenom: prenom,
                            adressePostale: adressePostale,
                            numeroTel: numeroTel,
                            mdpClient: mdpClient,
                            dateNaissance:dateNaissance
                        }
                });
            }
         }
    }]);
})();

// Factory d'un employé
(function () {
    angular.module("Campong").factory("EmployeFactory", ['$http', function EmployeFactory($http) {
        return {
            get: function (nomUtilisateur) {
                return $http({
                    method: "GET", url: "/api/Employe", params: {
                        nomUtilisateur: nomUtilisateur
                    }
                });
            },
                add: function (Employe) {
                    return $http({
                        method: "POST", url: "/api/Employe", data: Employe
                    });
                },
                getAll: function () {
                    return $http({
                        method: "GET", url: "/api/Employe"
                    });
                },
                delete: function (nomUtilisateur) {
                    return $http({
                        method: "DELETE", url: "/api/Employe/", params: { nomUtilisateur: nomUtilisateur }
                    });
                },
                modifier: function (nomUtilisateur, Employe) {
                    return $http({
                        method: "PUT", url: "/api/Employe/", params: { nomUtilisateur: nomUtilisateur } , data: Employe
                    });
                    
                }
            }
        
    }])
})();

// Factory d'un administrateur
(function () {
    angular.module("Campong").factory("AdministrateurFactory", ['$http', function AdministrateurFactory($http) {
        return {
            get: function (nomUtilisateur) {
                return $http({
                    method: "GET", url: "/api/Administrateur", params: {
                        nomUtilisateur: nomUtilisateur
                    }
                });
            }
        }
    }])
})();

(function(){
    angular.module("Campong").controller("InscriptionCtrl", ["$scope", "ClientFactory", function InscriptionCtrl($scope, ClientFactory) {
        $scope.btnInscription = function () {
            if ($scope.nom == "" || $scope.prenom == "" || $scope.adresseMail == "" || $scope.adressePostale == "" || $scope.numeroTel == "" || $scope.mdp == "" || $scope.dateNaissance == "" || $scope.nom == null || $scope.prenom == null || $scope.adresseMail == null || $scope.adressePostale == null || $scope.numeroTel == null || $scope.mdp == null || $scope.dateNaissance == null) {
                alert("Veuillez completer tous les champs.");
            } else {
                ClientFactory.get($scope.adresseMail).success(function (Client) {
                    if (Client == null) {
                        $scope.dateNaissance.setDate($scope.dateNaissance.getDate() + 1);
                        ClientFactory.add($scope.adresseMail, $scope.nom, $scope.prenom, $scope.adressePostale, $scope.numeroTel, $scope.mdp, $scope.dateNaissance)
                        .success(function () {
                            alert("Votre compte a bien été créé");
                            document.location.href = "#/Accueil";
                        })
                    } else {
                        alert("Adresse mail déjà existante");
                        $scope.adresseMail = "";
                    }
                })
            }
            
        }
    }])
})();

(function () {
    angular.module("Campong").factory("LivreOrFactory",["$http", function LivreOrFactory($http){
        return {
            getAll: function () {
                return $http({
                    method: "GET", url: "/api/LivreOr"
                })
            },
            add: function (mailClient,dateRedaction,texte) {
                return $http({
                    method: "POST", url: "/api/LivreOr", data: {
                        mailClient: mailClient,
                        dateRedaction: dateRedaction,
                        texte:texte
                    }
                })
            }
        }
    }])
})();

(function () {
    angular.module("Campong").controller("LivreOrCtrl",["$scope","UtilisateurService","LivreOrFactory","ClientFactory", function livreOrCrtl($scope,UtilisateurService,LivreOrFactory,ClientFactory){
        $scope.formulaireLivreOr = false;
        $scope.isLoading = false;
        //Récupération de l'utilisateur et son type
        $scope.utilisateur = UtilisateurService.getUtilisateur();
        $scope.typeUtil = UtilisateurService.getTypeUtil();
        $scope.$watch(UtilisateurService.getUtilisateur, function () {
            $scope.utilisateur = UtilisateurService.getUtilisateur();
        });
        $scope.$watch(UtilisateurService.getTypeUtil, function () {
            $scope.typeUtil = UtilisateurService.getTypeUtil();
            $scope.afficherFormulaire();
        }, true);
        $scope.envoyer = function () {
            if ($scope.texte != null && $scope.texte!='') {
                var dateRed=new Date();
                dateRed.setHours(dateRed.getHours()+1);
                LivreOrFactory.add($scope.utilisateur.AdresseMail,dateRed,$scope.texte).success(function () {
                    alert("Votre message a bien été envoyé");
                    document.location.href = "#/Acceuil";
                    document.location.href = "#/LivreOr";
                })
            }
        }
        
        $scope.getAllLivreOr = function () {
            LivreOrFactory.getAll().success(function (livresFromBD) {
                $scope.isLoading = true;
                $scope.livres = livresFromBD
            })
        }
        $scope.afficherFormulaire = function () {
            if ($scope.typeUtil == "client") {
                $scope.formulaireLivreOr = true;
            }
        }
        $scope.getAllLivreOr();
        $scope.afficherFormulaire();
    }])
})();