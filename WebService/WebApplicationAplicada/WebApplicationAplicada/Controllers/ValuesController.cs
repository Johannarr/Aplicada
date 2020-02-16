﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBConexion;

namespace WebApplicationAplicada.Controllers
{
    public class ValuesController : ApiController
    {

        AplicadaDBEntities dbContext = new AplicadaDBEntities();
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values
        public int Put([FromBody]GravilotaScore newScore)
        {
            GravilotaScore gScore = new GravilotaScore();
            gScore.Id = newScore.Id;
            gScore.PlayerName = newScore.PlayerName;
            gScore.Score = newScore.Score;

            dbContext.GravilotaScores.Add(gScore);
            return dbContext.SaveChanges();

        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}