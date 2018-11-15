namespace DAL
{
	public class UnitOfWork : object, IUnitOfWork
	{
		public UnitOfWork() : base()
		{
			IsDisposed = false;
		}

		protected bool IsDisposed { get; set; }

		// **************************************************
		private Models.DatabaseContext databaseContext;

		protected Models.DatabaseContext DatabaseContext
		{
			get
			{
				if (databaseContext == null)
				{
					databaseContext =
						new Models.DatabaseContext();
				}

				return (databaseContext);
			}
		}
		// **************************************************

		// **************************************************
		//private IXXXXXRepository xXXXXRepository;

		//public IXXXXXRepository XXXXXRepository
		//{
		//	get
		//	{
		//		if (xXXXXRepository == null)
		//		{
		//			xXXXXRepository =
		//				new XXXXXRepository(DatabaseContext);
		//		}

		//		return (xXXXXRepository);
		//	}
		//}
		// **************************************************

		// **************************************************
		private IUserRepository userRepository;

		public IUserRepository UserRepository
		{
			get
			{
				if (userRepository == null)
				{
					userRepository =
						new UserRepository(DatabaseContext);
				}

				return (userRepository);
			}
		}
		// **************************************************

		public void Save()
		{
			DatabaseContext.SaveChanges();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (IsDisposed == false)
			{
				if (disposing)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}

			IsDisposed = true;
		}

		public void Dispose()
		{
			Dispose(true);

			System.GC.SuppressFinalize(this);
		}
	}
}
