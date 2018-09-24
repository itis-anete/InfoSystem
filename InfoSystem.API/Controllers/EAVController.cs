using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoSystem.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InfoSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EAVController : ControllerBase
    {
        [HttpPost]
        public void Post([FromBody] string entity)
        {
            var entity = JsonConvert.DeserializeObject<Entity>(entity);
            _repository.Add(entity);
        }
    }
}