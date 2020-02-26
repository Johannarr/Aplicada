using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBConexion;

namespace WebApplicationAplicada.Controllers
{
    public class EsenciaController : ApiController
    {
        AplicadaDBEntities dbContext = new AplicadaDBEntities();
        // GET api/guardados
        public IEnumerable<EsenciaScore> Get()
        {
            return dbContext.EsenciaScores.OrderByDescending(esencia =>
            esencia.BlueScore + esencia.GreenScore + esencia.PinkScore + esencia.PurpleScore + esencia.RedScore +
            esencia.YellowScore).Take(2).ToList();

        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/esencia
        public int Put([FromBody]EsenciaScore newScore)
        {
            EsenciaScore _newEntry = new EsenciaScore();
            _newEntry.PlayerName = newScore.PlayerName;
            _newEntry.Id = newScore.Id;
            _newEntry.PinkScore = newScore.PinkScore;
            _newEntry.PurpleScore = newScore.PurpleScore;
            _newEntry.RedScore = newScore.RedScore;
            _newEntry.GreenScore = newScore.GreenScore;
            _newEntry.BlueScore = newScore.BlueScore;
            

            dbContext.EsenciaScores.Add(_newEntry);
            return dbContext.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}