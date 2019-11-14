using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Neo4jClient;

namespace ProjectShortName.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IGraphClient _neo4jClient;
        public ValuesController(IGraphClient neo4jClient)
        {
            _neo4jClient = neo4jClient ?? throw new ArgumentNullException(nameof(neo4jClient));
        }

        // GET api/values/neo4j
        [HttpGet("neo4j")]
        public IActionResult GetNeo4J()
        {
            var cypherQuery = _neo4jClient.Cypher
                .Match("(sean:Person { name: 'Sean Killeen'})")
                .Match("(excella:Company { name: 'Excella Consulting'})")
                .Match("(excella) -[:HAS_JOBS_AT]->(jobsPage: WebPage)")
                .Return<string>("sean.name + ' works with ' + excella.name + ' and loves it! Join him at: ' + jobsPage.url");

            return Ok(cypherQuery.Results.First());
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
