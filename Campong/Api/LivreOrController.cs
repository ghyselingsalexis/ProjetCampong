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
    public class LivreOrController : ApiController
    {
        // GET: api/LivreOr
        public List<LivreOrClient> Get()
        {
            return LivreOrDao.getAll();
        }

        // GET: api/LivreOr/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/LivreOr
        public void Post([FromBody]JObject livre)
        {
            LivreOrDao.add(livre.GetValue("mailClient").ToString(),(DateTime) livre.GetValue("dateRedaction"), livre.GetValue("texte").ToString());
        }

        // PUT: api/LivreOr/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LivreOr/5
        public void Delete(int id)
        {
        }
    }
}
