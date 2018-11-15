using System.Linq;

namespace DAL
{
	public class UserRepository : Repository<Models.User>, IUserRepository
	{
		public UserRepository(Models.DatabaseContext databaseContext) : base(databaseContext)
		{
		}

		public System.Collections.Generic.IList<Models.User> GetActiveUsers()
		{
			//var users =
			//	Get()
			//	.Where(current => current.IsActive)
			//	.ToList()
			//	;

			var users =
				Get()
				.Where(current => current.IsActive)
				.Where(current => current.IsDeleted == false)
				.ToList()
				;

			return (users);
		}
	}
}
