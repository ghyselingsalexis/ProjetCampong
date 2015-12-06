using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Campong.Modele
{
    public class Reservation
    {
        private int id;

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                id = value;
            }
        }

        private String mailClient;

        public String MailClient
        {
            get
            {
                return this.mailClient;
            }
            set
            {
                mailClient = value;
            }
        }

        private int numeroEmplacement;

        public int NumeroEmplacement
        {
            get
            {
                return this.numeroEmplacement;
            }
            set
            {
                numeroEmplacement = value;
            }
        }

        private DateTime dateDeb;

        public DateTime DateDeb
        {
            get
            {
                return this.dateDeb;
            }
            set
            {
                dateDeb = value;
            }
        }

        private DateTime dateFin;

        public DateTime DateFin
        {
            get
            {
                return this.dateFin;
            }
            set
            {
                dateFin = value;
            }
        }

        private bool dateFerme;

        public bool DateFerme
        {
            get
            {
                return this.dateFerme;
            }
            set
            {
                dateFerme = value;
            }
        }

        private int nbAdultes;

        public int NbAdultes
        {
            get
            {
                return this.nbAdultes;
            }
            set
            {
                nbAdultes = value;
            }
        }

        private int nbEnfants;
        public int NbEnfants
        {
            get
            {
                return this.nbEnfants;
            }
            set
            {
                nbEnfants = value;
            }
        }

        private bool confirmation;
        public bool Confirmation
        {
            get
            {
                return this.confirmation;
            }
            set
            {
                confirmation = value;
            }
        }
        private int nbVehicule;
        public int NbVehicule
        {
            get
            {
                return this.nbVehicule;
            }
            set
            {
                nbVehicule = value;
            }
        }
        private bool electricite;
        public bool Electricite
        {
            get
            {
                return this.electricite;
            }
            set
            {
                electricite = value;
            }
        }
        public Reservation(String mailClient,int numeroEmplacement,DateTime dateDeb,DateTime dateFin,bool dateFerme,int nbAdultes,int nbEnfants,int nbVehicule,bool electricite)
        {
            this.mailClient = mailClient;
            this.numeroEmplacement = numeroEmplacement;
            this.dateDeb = dateDeb;
            this.dateFin = dateFin;
            this.dateFerme = dateFerme;
            this.nbAdultes = nbAdultes;
            this.nbEnfants = nbEnfants;
            NbVehicule = nbVehicule;
            Electricite = electricite;
        }

    }
}