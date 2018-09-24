using System;
using System.Collections.Generic;
using InfoSystem.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.API
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