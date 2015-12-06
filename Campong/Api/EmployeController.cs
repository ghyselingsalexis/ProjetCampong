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
    public class EmployeController : ApiController
    {
        // GET: api/Employe
        public IEnumerable<Employe> Get()
        {
            return EmployeDao.getAll();
        }

        // GET: api/Employe/5
        public Employe Get(String nomUtilisateur)
        {
            return EmployeDao.RechercheEmploye(nomUtilisateur);
        }

        // POST: api/Employe
        public void Post([FromBody]JObject value)
        {
            
            Employe emplo= new Employe(value.GetValue("NomUtilisateur").ToString(), value.GetValue("Nom").ToString(), value.GetValue("Prenom").ToString(), value.GetValue("MdpEmploye").ToString(), value.GetValue("Affectation").ToString());

            EmployeDao.add(emplo);
        }

        // PUT: api/Employe/5
        public void Put(String nomUtilisateur, [FromBody]JObject value)
        {
            Employe emp= new Employe(value.GetValue("NomUtilisateur").ToString(), value.GetValue("Nom").ToString(), value.GetValue("Prenom").ToString(), value.GetValue("MdpEmploye").ToString(), value.GetValue("Affectation").ToString());

            EmployeDao.modifier(nomUtilisateur, emp);
        }

        // DELETE: api/Employe/5
        public void Delete(String nomUtilisateur)
        {
            EmployeDao.delete(nomUtilisateur);
        }
    }
}
