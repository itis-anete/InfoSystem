using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoSystem.App.DataBase.ReposInterfaces;
using InfoSystem.Infrastructure.Entities;
using InfoSystem.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InfoSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EAVController : ControllerBase
    {
        private readonly IEntityRepository _entityRepository;
        private readonly IPropertiesRepository _propertiesRepository;
        private readonly IValuesRepository _valuesRepository;

        public EAVController(IUnitOfWork uof)
        {
            _entityRepository = uof.EntityRepos;
            _propertiesRepository = uof.PropertiesRepos;
            _valuesRepository = uof.ValuesRepos;
        }
        
        [HttpPost("PostEntity")]
        public ActionResult<Entity> PostEntity([FromBody] string receivedEntity)
        {
            var entity = JsonConvert.DeserializeObject<Entity>(receivedEntity);
            _entityRepository.Add(entity);
            return entity; //_entityRepository.Get().First();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Entity>> Get()
        {
            return _entityRepository.Get().ToList();
        }
    }
}