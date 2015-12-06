using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Campong.Modele
{
    public class LivreOr
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

        public LivreOr(String mailClient,DateTime dateRedaction,String texte)
        {
            this.mailClient = mailClient;
            this.dateRedaction = dateRedaction;
            this.texte = texte;
        }
    }
}