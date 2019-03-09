using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
	public class TypeRepository
	{
		public TypeRepository(InfoSystemDbContext dbContext)
		{
			_context = dbContext;
		}

		public EntityType GetById(int id)
		{
			return _context.Types.Find(id);
		}

		private readonly InfoSystemDbContext _context;
	}
}