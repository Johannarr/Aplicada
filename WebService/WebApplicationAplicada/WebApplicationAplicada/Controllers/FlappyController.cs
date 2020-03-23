using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBConexion;

namespace WebApplicationAplicada.Controllers
{
    public class FlappyController : ApiController
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

       // PUT api/flappy
       public int Put([FromBody]FlappyScore newScore)
       {
           FlappyScore gScore = new FlappyScore();
           gScore.Id = newScore.Id;
           gScore.PlayerName = newScore.PlayerName;
           gScore.Score = newScore.Score;

           dbContext.FlappyScores.Add(gScore);
           return dbContext.SaveChanges();

       }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}