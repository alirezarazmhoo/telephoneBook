namespace Telephonebook.Interfaces
{
    public interface IGenericRepository
	{
		public interface IGenericRepository<T> where T : class
		{
			Task<T> GetByIdAsync(int id);
			Task<List<T>> GetAllAsync();
			Task Insert(T entity);
			void Delete(T entity);
		Task<IEnumerable<T>> FindWithSpecificationPattern(ISpecification<T>? specification = null);
		}
	}
}
