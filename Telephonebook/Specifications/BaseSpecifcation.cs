using System.Linq.Expressions;
using Telephonebook.Interfaces;

namespace Telephonebook.Specifications
{
    public class BaseSpecifcation<T> : ISpecification<T>
	{
		public BaseSpecifcation()
		{
		}
		public BaseSpecifcation(Expression<Func<T, bool>> criteria)
		{
			Criteria = criteria;
		}
		public Expression<Func<T, bool>>? Criteria { get; }
		public List<Expression<Func<T, object>>>? Includes { get; } = new List<Expression<Func<T, object>>>();
		public Expression<Func<T, object>>? OrderBy { get; private set; }
		public Expression<Func<T, object>>? OrderByDescending { get; private set; }
		public Expression<Func<T, object>>? FirstOrDefault { get; private set; }

		protected void AddInclude(Expression<Func<T, object>> includeExpression)
		{
			if(Includes != null)
			{
			Includes.Add(includeExpression);

			}

		}
		protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
		{
			OrderBy = orderByExpression;
		}
		protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
		{
			OrderByDescending = orderByDescExpression;
		}
		protected void AddFirstOrDefault(Expression<Func<T, object>> orderByDescExpression)
		{
			FirstOrDefault = orderByDescExpression;
		}
	}
}
