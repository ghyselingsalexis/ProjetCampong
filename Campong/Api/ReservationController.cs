using Campong.DAO;
using Campong.Modele;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Campong.Api
{
    public class ReservationController : ApiController
    {
        // GET: api/Reservation
        public List<Emplacement> Post([FromBody] JObject dates)
        {
            return ReservationDao.getListEmplacementsParDate((DateTime)dates.GetValue("dateDeb"), (DateTime)dates.GetValue("dateFin"));
        }
        public IEnumerable<Reservation> Get()
        {
            return ReservationDao.getAll();
            
        }
    
        public void Put(int id)
        {
            ReservationDao.ConfirmationReservation(id);
        }
        public void Put(int id,DateTime DateFin)
        {
            ReservationDao.DateFerme(id, DateFin);
        }
        public void Put([FromBody] JObject reservation)
        {
            ReservationDao.AjouterReservation(reservation.GetValue("mailClient").ToString(), (int)reservation.GetValue("numeroEmplacement"), (DateTime)reservation.GetValue("dateDeb"), (DateTime)reservation.GetValue("dateFin"), (bool)reservation.GetValue("dateFerme"),(int)reservation.GetValue("nbAdultes"),(int)reservation.GetValue("nbEnfants"),(int)reservation.GetValue("nbVehicule"),(bool)reservation.GetValue("electricite"),(bool)reservation.GetValue("confirmation"));
        }
    }
}
