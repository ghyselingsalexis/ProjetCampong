using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Campong.Modele
{
    public class Emplacement
    {
        private int numero;
        public int Numero
        {
            get
            {
                return this.numero;
            }
            set
            {
                this.numero = value;
            }
        }
   
        private String type;
        public String Type
        {
            get
            {
                return this.type;
            }
            set
            {
                type = value;
            }
        }

        private int surface;
        public int Surface
        {
            get
            {
                return this.surface;
            }
            set
            {
                surface = value;
            }
        }
        private int nbPlaces;
        public int NbPlaces
        {
            get
            {
                return this.nbPlaces;
            }
            set
            {
                nbPlaces = value;
            }
        }

        private float prixBase, prixEnfSup, prixAdultSup;
        public float PrixBase
        {
            get
            {
                return this.prixBase;
            }
            set
            {
                prixBase = value;
            }
        }
        public float PrixEnfSup
        {
            get
            {
                return this.prixEnfSup;
            }
            set
            {
                prixEnfSup = value;
            }
        }
        public float PrixAdultSup
        {
            get
            {
                return this.prixAdultSup;
            }
            set
            {
                prixAdultSup = value;
            }
        }

        private DateTime dateDebMaintenance;
        public DateTime DateDebMaintenance
        {
            get
            {
                return this.dateDebMaintenance;
            }
            set
            {
                dateDebMaintenance = value;
            }
        }

        private DateTime dateFinMaintenance;
        public DateTime DateFinMaintenance
        {
            get
            {
                return this.dateFinMaintenance;

            }
            set
            {
                dateFinMaintenance = value;
            }
        }

        private float prixVehicule;
        public float PrixVehicule
        {
            get
            {
                return this.prixVehicule;
            }
            set
            {
                prixVehicule = value;
            }
        }

        private float prixElectricite;
        public float PrixElectricite
        {
            get
            {
                return this.prixElectricite;
            }
            set
            {
                prixElectricite = value;
            }
        }
        public Emplacement(String type, int surface, int nbPlaces, float prixBase, float prixEnfSup, float prixAdultSup,float prixVehicule,float prixElectricite)
        {
            Type = type;
            Surface = surface;
            NbPlaces = nbPlaces;
            PrixAdultSup = prixAdultSup;
            PrixBase = prixBase;
            PrixEnfSup = prixEnfSup;
            PrixVehicule = prixVehicule;
            PrixElectricite = prixElectricite;
        }

        public Emplacement(String type, int surface, int nbPlaces, float prixBase, float prixEnfSup, float prixAdultSup,DateTime dateDebMaintenance,DateTime dateFinMaintenance,float prixVehicule, float prixElectricite)
        {
            Type = type;
            Surface = surface;
            NbPlaces = nbPlaces;
            PrixAdultSup = prixAdultSup;
            PrixBase = prixBase;
            PrixEnfSup = prixEnfSup;
            DateDebMaintenance = dateDebMaintenance;
            DateFinMaintenance = dateFinMaintenance;
            PrixVehicule = prixVehicule;
            PrixElectricite = prixElectricite;
        }
    }

}
