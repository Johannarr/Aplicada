using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBConexion;

namespace WebApplicationAplicada.Controllers
{
    public class BananaController : ApiController
    {
        AplicadaDBEntities dbContext = new AplicadaDBEntities();
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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

        // PUT api/banana
        public int Put([FromBody]BananaScore newScore)
        {
            BananaScore gScore = new BananaScore();
            gScore.Id = newScore.Id;
            gScore.PlayerName = newScore.PlayerName;
            gScore.Score = newScore.Score;

            dbContext.BananaScores.Add(gScore);
            return dbContext.SaveChanges();

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}