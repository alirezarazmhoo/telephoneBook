namespace Telephonebook.Interfaces
{
	public interface IEditContactGroupRepository
	{
		Task AddAsync(int GroupId , List<int> PersonIds);
	}
}
