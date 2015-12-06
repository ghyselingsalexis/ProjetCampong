using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Campong.Modele
{
    public class Client
    {
        private String adresseMail;

        public String AdresseMail
        {
            get
            {
                return adresseMail;
            }
            set
            {
                this.adresseMail = value;
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
                this.nom = value;
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
                this.prenom = value;
            }
        }

        private String adressePostale;

        public String AdressePostale
        {
            get
            {
                return adressePostale;
            }
            set
            {
                this.adressePostale = value;
            }
        }

        private String numeroTel;

        public String NumeroTel
        {
            get
            {
                return numeroTel;
            }
            set
            {
                this.numeroTel = value;
            }
        }

        private String mdpClient;

        public String MdpClient
        {
            get
            {
                return mdpClient;
            }
            set
            {
                this.mdpClient = value;
            }
        }

        private DateTime dateNaissance;

        public DateTime DateNaissance
        {
            get
            {
                return dateNaissance;
            }
            set
            {
                this.dateNaissance = value;
            }
        }

        public Client(String adresseMail,String nom,String prenom,String adressePostale, String numeroTel,String mdpClient,DateTime dateNaissance)
        {
            this.adresseMail = adresseMail;
            this.nom = nom;
            this.prenom = prenom;
            this.adressePostale = adressePostale;
            this.numeroTel = numeroTel;
            this.mdpClient = mdpClient;
            this.dateNaissance = dateNaissance;
        }
        public Client()
        {

        }
    }
}