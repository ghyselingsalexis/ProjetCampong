using Campong.DAO;
using Campong.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Campong.Api
{
    public class AdministrateurController : ApiController
    {
        // GET: api/Administrateur
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Administrateur/5
        public Administrateur Get(String nomUtilisateur)
        {

            return AdministrateurDao.RechercheAdministrateur(nomUtilisateur);
        }

        // POST: api/Administrateur
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Administrateur/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Administrateur/5
        public void Delete(int id)
        {
        }
    }
}
