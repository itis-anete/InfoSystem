//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using InfoSystem.Core.Entities;
//using InfoSystem.Core.Entities.Basic;
//using InfoSystem.Infrastructure.DataBase.Context;
//using InfoSystem.Infrastructure.DataBase.Repos;
//using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
//using InfoSystem.Infrastructure.DataBase.UnitOfWork;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//
//namespace InfoSystem.Web.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EAVController : ControllerBase
//    {
//        private readonly IEntityRepository _entityRepository;
//        private readonly IPropertiesRepository _propertiesRepository;
//        private readonly IValuesRepository _valuesRepository;
//
//        public EAVController(IUnitOfWork uof)
//        {
//            _entityRepository = uof.EntityRepos;
//            _propertiesRepository = uof.PropertiesRepos;
//            _valuesRepository = uof.ValuesRepos;
//        }
//
//        [HttpPost("PostEntity")]
//        public void PostEntity([FromBody] string receivedEntity)
//        {
//            var entity = JsonConvert.DeserializeObject<Entity>(receivedEntity);
//            _entityRepository.Add(entity);
//        }
//
//        [HttpGet("GetEntities")]
//        public IEnumerable<Entity> GetEntities()
//        {
//            IEnumerable<Entity> entities = _entityRepository.Get();
//
//            foreach (var entity in entities)
//            {
//                var tempRepository = new PropertiesRepository(new InfoSystemDbContext());
//                entity.Properties = tempRepository.GetByEntityId(entity.Id);
//            }
//
//            return entities;
//            //return null;
//        }
//
//        [HttpPost("PostProperty")]
//        public void PostProperty([FromBody] string receivedProperty)
//        {
//            // Пример входных данных(можно вставлять в Swagger)
//            // "{name:\"myProperty\",entity:{Editable:false,Properties:null,EntityId:1234,Id:0},Value:{Value:null,Id:1},Id:123}"
//            
//            var prop = JsonConvert.DeserializeObject<Properties>(receivedProperty);
//            _propertiesRepository.Add(prop);
//        }
//        
//        [HttpGet("GetProperties")]
//        public IEnumerable<Properties> GetProperties()
//        {
//            return _propertiesRepository.Get();
//        }
//        
//        [HttpGet("GetPropertiesById")]
//        public IEnumerable<Properties> GetProperties(int entityId)
//        {
//            return _propertiesRepository.GetByEntityId(entityId);
//        }
//    }
//}