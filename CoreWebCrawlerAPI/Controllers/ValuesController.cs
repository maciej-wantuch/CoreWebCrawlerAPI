using System.Collections.Generic;
using System.Linq;
using CoreWebCrawlerAPI.Models;
using CoreWebCrawlerAPI.SQLiteDB;
using Microsoft.AspNetCore.Mvc;
namespace CoreWebCrawlerAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public List<Trinket> Get()
        {
            return DataBase.readFromDataBaseToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
