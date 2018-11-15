namespace DAL
{
	public interface IUserRepository : IRepository<Models.User>
	{
		System.Collections.Generic.IList<Models.User> GetActiveUsers();
	}
}
