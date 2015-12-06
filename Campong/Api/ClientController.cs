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
    public class ClientController : ApiController
    {
        // GET: api/Client
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Client/5
        public Client Get(String mailClient)
        {
            return ClientDao.RechercheClient(mailClient);
        }

        // POST: api/Client
        public void Post([FromBody]JObject client)
        {
            ClientDao.AjouterClient(client.GetValue("mailClient").ToString(), client.GetValue("nom").ToString(), client.GetValue("prenom").ToString(), client.GetValue("adressePostale").ToString(), client.GetValue("numeroTel").ToString(), client.GetValue("mdpClient").ToString(), (DateTime)client.GetValue("dateNaissance"));
        }

        // PUT: api/Client/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Client/5
        public void Delete(int id)
        {
        }
    }
}
