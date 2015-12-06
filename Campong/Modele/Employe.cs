using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Campong.Modele
{
    public class Employe
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

        private String mdpEmploye;
        public String MdpEmploye
        {
            get
            {
                return mdpEmploye;
            }
            set
            {
                mdpEmploye = value;
            }
        }

        private String affectation;
        public String Affectation
        {
            get
            {
                return affectation;
            }
            set
            {
                affectation = value;
            }
        }

        public Employe(String nomUtilisateur,String nom,String prenom,String mdpEmploye,String affectation)
        {
            this.NomUtilisateur = nomUtilisateur;
            this.Nom = nom;
            this.Prenom = prenom;
            this.MdpEmploye = mdpEmploye;
            this.Affectation = affectation;
        }

        public Employe()
        {

        }
    }
}