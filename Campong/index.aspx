<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Campong.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"> 
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Berkshire Swash"/>
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Cookie"/>
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Playball"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    
    <link href="Styles/Campong.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    
    <script src="//ajax.googleapis.com/ajax/libs/angularjs/1.4.7/angular.js"></script>
    <script src="//ajax.googleapis.com/ajax/libs/angularjs/1.4.7/angular-animate.js"></script>
    <script src="//angular-ui.github.io/bootstrap/ui-bootstrap-tpls-0.14.3.js"></script>

    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.5.0-beta.1/angular-route.min.js"></script>
    <script src="Scripts/Angular/Campong.js"></script>
    <script src="Scripts/Angular/Route.js"></script>

    <form id="form1" runat="server">
        <div ng-app="Campong" ng-controller="IndexCtrl">
            <div id="header" >
                <img id="Logo" src="Images/campong.png" />
                <span ng-show="deconnecte">
                    <span id="connexion">
                        <label id="labelEmail">Adresse e-mail :</label>
                        <label id="labelMdp">Mot de passe :</label><br />
                        <input id="inputEmail" type="text" ng-model="email"/>
                        <input id="inputMdp" type="password"ng-model="mdp"/>
                    </span>
                    <span class="btnConnexion">               
                        <a class="btn btn-success" ng-click="connexion()">Se connecter</a>
                        <a id="btnInscrire" class="btn btn-primary" href="#/Inscription">S'inscrire</a>
                    </span>
                </span>
                <span ng-hide="deconnecte">
                    <span id="deconnexion"> 
                      {{utilisateur.Nom}} {{utilisateur.Prenom}}
                    </span>
                    <span class="btnConnexion">
                        <a class="btn btn-danger" ng-click="deconnexion()">Se déconnecter</a>
                    </span>
                </span>
            </div>
            
            <div id="cadreExtBanderole">
                <div id="cadreIntBanderole">
                </div>
            </div>
            <div id="contenu">
                <div id="cadreExtMenu">
                    <div id="cadreIntMenu" >
                        <span id="menu">Menu</span>
                        <ul id="listeMenu">
                            <li  ><a  href="#/Accueil" >Accueil</a></li>
                            <li ng-show="admin"><a href="#/Emplacement">Gestion des emplacements</a></li>
                            <li ng-hide="admin"><a href="#/Historique">Historique</a></li>
                            <li ng-hide="admin"><a href="#/Decouvrir">Découvrir</a></li>
                            <li ng-hide="admin"><a href="#/Animations">Animations</a></li>
                            <li ng-hide="admin"><a href="#/Reservation">Reservation</a></li>
                            <li ng-hide="admin"><a href="#/LivreOr">Livre d'or</a></li>
                            <li ng-show="admin"><a href="#/Employe">Gestion des employés</a></li>
                            <li ng-hide="admin"><a href="#/Tarif">Tarif emplacements</a></li>
                            <li ng-show="employe"><a href="#/Confirmation">Confirmation d'un emplacement</a></li>
                            <li ng-show="admin"><a href="#/DateFerme">Définir date ferme</a></li>

                        </ul>
                    </div>
                </div>                       
                <div ng-view id="ngview">
                </div>   
            </div> 
            <div id="footer">
            </div>
        </div>

        
    </form>
</body>
</html>
