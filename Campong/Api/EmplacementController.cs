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
    public class EmplacementController : ApiController
    {
        // GET: api/Emplacement
        public IEnumerable<Emplacement> Get()
        {
            return EmplacementDao.getAll();
        }

        // GET: api/Emplacement/5
        [Route("api/Emplacement/postMaintenance")]
        public IEnumerable<Emplacement> PostMaintenance([FromBody]JObject value)
        {
          
            return EmplacementDao.getEmplacementsMaintenance((DateTime)value.GetValue("dateDeb"),(DateTime)value.GetValue("dateFin"), (int)value.GetValue("id"));
            
        }

        // POST: api/Emplacement
        public void Post([FromBody]JObject value)
        {
            Emplacement emplace= new Emplacement(value.GetValue("Type").ToString(), (int)value.GetValue("Surface"), (int)value.GetValue("NbPlaces"), (float)value.GetValue("PrixBase"), (float)value.GetValue("PrixEnfSup"), (float)value.GetValue("PrixAdultSup"), (float)value.GetValue("PrixVehicule"), (float)value.GetValue("PrixElectricite"));

            EmplacementDao.add(emplace);
        }

        // PUT: api/Emplacement/5
        public void Put(int numero, [FromBody]JObject value)
        {
            if(value.GetValue("DateDebMaintenance").ToString()=="" || value.GetValue("DateFinMaintenance").ToString() == "") 
                 EmplacementDao.modifier(numero, new Emplacement(value.GetValue("Type").ToString(), (int)value.GetValue("Surface"), (int)value.GetValue("NbPlaces"), (float)value.GetValue("PrixBase"), (float)value.GetValue("PrixEnfSup"), (float)value.GetValue("PrixAdultSup"), (float)value.GetValue("PrixVehicule"), (float)value.GetValue("PrixElectricite")));
            else
                 EmplacementDao.modifier(numero, new Emplacement(value.GetValue("Type").ToString(), (int)value.GetValue("Surface"), (int)value.GetValue("NbPlaces"), (float)value.GetValue("PrixBase"), (float)value.GetValue("PrixEnfSup"), (float)value.GetValue("PrixAdultSup"),(DateTime)value.GetValue("DateDebMaintenance"),(DateTime)value.GetValue("DateFinMaintenance"), (float)value.GetValue("PrixVehicule"), (float)value.GetValue("PrixElectricite")));

        }

        // DELETE: api/Emplacement
        public void Delete(int numero)
        {
            EmplacementDao.delete(numero);
        }

   
    }
}
