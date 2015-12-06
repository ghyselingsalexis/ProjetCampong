using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Campong.Modele
{
    public class LivreOrClient
    {
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
            }
        }
        private String mailClient;

        public String MailClient
        {
            get
            {
                return mailClient;
            }
            set
            {
                this.mailClient = value;
            }
        }
        private DateTime dateRedaction;

        public DateTime DateRedaction
        {
            get
            {
                return dateRedaction;
            }
            set
            {
                this.dateRedaction = value;
            }
        }
        private String texte;
        
        public String Texte
        {
            get
            {
                return texte;
            }
            set
            {
                this.texte = value;
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

        public LivreOrClient(DateTime dateRedaction,String texte,String nom,String prenom)
        {
            this.dateRedaction = dateRedaction;
            this.texte = texte;
            this.nom = nom;
            this.prenom = prenom;
        }
    }
}