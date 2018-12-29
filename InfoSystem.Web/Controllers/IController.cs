using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
    public interface IController<T>
    {
        [HttpGet]
        ActionResult<IEnumerable<T>> Get();

        [HttpGet("{id}")]
        ActionResult<T> Get(int id);

        [HttpPost]
        void Post([FromBody] string name);

        [HttpPut("{id}")]
        void Put(int id, [FromBody] string value);

        [HttpDelete("{id}")]
        void Delete(int id);
    }
}