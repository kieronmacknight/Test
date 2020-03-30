using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Covid.Api.Controllers.V2
{
    /// <summary>
    /// Creates an instance of ValuesV1Controller
    /// </summary>
    [ApiVersion("1")]
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IEnumerable<string> _messages;
        private readonly Random rnd;

        public HomeController()
        {
            _messages = new List<string>()
            {
                "We're gonna need a bigger boat",
                "I'll be back.",
                "Say hello to my little friend.",
                "Thats not a knife, this is a knife.",
                "We ride together, we die together, bad boys for life",
                "Don't cross the streams.",
                "Get to the chopper",
            };

            rnd = new Random();
        }

        /// <summary>
        /// Retrieves values
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> Get()
        {
            var idx = rnd.Next(0, 6);
            return (_messages.ToArray())[idx];
        }

        /// <summary>
        /// Gets a value by id
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Creates an entity
        /// </summary>
        /// <param name="value">The entity</param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <param name="value">The entityparam>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// Deletes the specified entity
        /// </summary>
        /// <param name="id">The id of the entity</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
