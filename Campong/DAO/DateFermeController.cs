using Campong.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Campong.DAO
{
    public class DateFermeController : ApiController
    {
        // GET: api/DateFerme
        public IEnumerable<Reservation> Get()
        {
            return ReservationDao.getAllReserv();
        }

        // GET: api/DateFerme/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DateFerme
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DateFerme/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DateFerme/5
        public void Delete(int id)
        {
        }
    }
}
