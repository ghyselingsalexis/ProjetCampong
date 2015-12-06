using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Campong.Modele
{
    public class Administrateur
    {
        private String nomUtilisateur;
        public String NomUtilisateur
        {
            get
            {
                return nomUtilisateur;
            }
            set
            {
                nomUtilisateur = value;
            }
        }

        private String nom;
        public String Nom
        {
            get
            {
                return nom;
            }
            set
            {
                nom = value;
            }
        }

        private String prenom;
        public String Prenom
        {
            get
            {
                return prenom;
            }
            set
            {
                prenom = value;
            }
        }

        private String mdpAdministrateur;
        public String MdpAdministrateur
        {
            get
            {
                return mdpAdministrateur;
            }
            set
            {
                mdpAdministrateur = value;
            }
        }

        public Administrateur()
        {

        }

        public Administrateur(String nomUtilisateur, string nom,String prenom, String mdpAdministrateur)
        {
            this.nomUtilisateur = nomUtilisateur;
            this.nom = nom;
            this.prenom = prenom;
            this.mdpAdministrateur = mdpAdministrateur;
        }
    }
}