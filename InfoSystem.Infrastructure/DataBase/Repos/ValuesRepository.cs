using System;
using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
using Microsoft.EntityFrameworkCore;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
    public class ValuesRepository : IValuesRepository
    {
        private readonly InfoSystemDbContext _context;

        public ValuesRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }

        public bool Add(Value receivedObj)
        {
            try
            {
                _context.Values.Add(receivedObj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public Value GetById(int entityId, string attributeName)
        {
            var entity = _context.Entities.FirstOrDefault(e => e.Id == entityId);
            if (entity == null)
                throw new NullReferenceException("Database doesn't have such entity!");
            var attribute =
                _context.Attributes.FirstOrDefault(a => a.Name == attributeName && a.TypeId == entity.TypeId);
            return attribute == null
                ? null
                : _context.Values.FirstOrDefault(v => v.EntityId == entityId && v.AttributeId == attribute.Id);
        }

        public Value GetById(int id)
        {
            return _context.Values.Where(x => x.Id == id).Include(x => x.Attribute).FirstOrDefault();
        }

        public IEnumerable<Value> GetEntityValues(int entityId)
        {
            var entity = _context.Entities.Find(entityId);
            var attributes = _context.Attributes.Where(a => a.TypeId == entity.TypeId);
            return _context.Values.Where(value => value.EntityId == entityId
                                                  && attributes.Any(attribute => attribute.Id == value.AttributeId))
                .Include(x => x.Attribute);
        }

        public bool Update(Value updatedValue)
        {
            try
            {
                _context.Values.Update(updatedValue);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }
    }
}