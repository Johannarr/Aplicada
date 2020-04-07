using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBConexion;

namespace WebApplicationAplicada.Controllers
{
    public class CrocodrileController : ApiController
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

        // PUT api/crocodile
        public int Put([FromBody]CrocodileScore newScore)
        {
            CrocodileScore _newEntry = new CrocodileScore();
            _newEntry.Id = newScore.Id;
            _newEntry.PlayerName = newScore.PlayerName;
            _newEntry.BlueScore = newScore.BlueScore;
            _newEntry.GreenScore = newScore.GreenScore;
            _newEntry.RedScore = newScore.RedScore;
            _newEntry.OrangeScore = newScore.OrangeScore;
            _newEntry.FrogScore = newScore.FrogScore;


            dbContext.CrocodileScores.Add(_newEntry);
            return dbContext.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}