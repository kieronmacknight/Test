using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        /// <summary>
        /// Retrieves values
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
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
