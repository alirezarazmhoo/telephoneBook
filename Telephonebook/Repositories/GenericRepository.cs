using Microsoft.EntityFrameworkCore;
using Telephonebook.Data;
using Telephonebook.Interfaces;
using Telephonebook.Specifications;
using static Telephonebook.Interfaces.IGenericRepository;

namespace Telephonebook.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly TelephonebookContext _Context;
		public GenericRepository(TelephonebookContext context)
		{
			_Context = context;
		}
		public async Task<List<T>> GetAllAsync()
		{
			return await _Context.Set<T>().ToListAsync();
		}
		public async Task<T> GetByIdAsync(int id)
		{
			return await _Context.Set<T>().FindAsync(id);
		}
		public async Task Insert(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity not found");
			}
			await _Context.AddAsync(entity);
			await _Context.SaveChangesAsync();
		}
		public void Delete(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity not found");
			}
			_Context.Remove(entity);
			_Context.SaveChanges();
		}
		public IEnumerable<T> FindWithSpecificationPattern(ISpecification<T>? specification = null)
		{
			return SpecificationEvaluator<T>.GetQuery(_Context.Set<T>().AsQueryable(), specification);
		}
	}
}
