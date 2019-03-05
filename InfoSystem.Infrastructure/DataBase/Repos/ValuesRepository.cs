using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
    public class ValuesRepository
    {
        private readonly InfoSystemDbContext _context;

        public ValuesRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(Value receivedObj)
        {
            _context.Values.Add(receivedObj);
            _context.SaveChanges();
        }

        public Value GetById(int entityId, string attributeName)
        {
            // TODO - entityId = костыль 

            var attribute = _context.Attributes.FirstOrDefault(a => a.Name == attributeName);
            return attribute == null
                ? null
                : _context.Values.FirstOrDefault(v => v.EntityId == entityId && v.AttributeId == attribute.Id);
        }
    }
}