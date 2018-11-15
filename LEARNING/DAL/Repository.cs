using System.Linq;

namespace DAL
{
	public abstract class Repository<T> : object, IRepository<T> where T : Models.BaseEntity
	{
		// نمی‌نويسيم Default Constructor ،Repository برای
		//public Repository() : base()
		//{
		//}

		public Repository(Models.DatabaseContext databaseContext) : base()
		{
			if (databaseContext == null)
			{
				throw (new System.ArgumentNullException("databaseContext"));
			}

			DatabaseContext = databaseContext;
			DbSet = DatabaseContext.Set<T>();
		}

		protected System.Data.Entity.DbSet<T> DbSet { get; set; }

		protected Models.DatabaseContext DatabaseContext { get; set; }

		public virtual void Insert(T entity)
		{
			if (entity == null)
			{
				throw (new System.ArgumentNullException("entity"));
			}

			entity.InsertDateTime = System.DateTime.Now;
			entity.UpdateDateTime = System.DateTime.Now;

			DbSet.Add(entity);
		}

		public virtual void Update(T entity)
		{
			if (entity == null)
			{
				throw (new System.ArgumentNullException("entity"));
			}

			entity.UpdateDateTime = System.DateTime.Now;

			// **************************************************
			// Just For Debug!
			// **************************************************
			System.Data.Entity.EntityState
				entityState = DatabaseContext.Entry(entity).State;
			// **************************************************
			// /Just For Debug!
			// **************************************************

			if (entityState == System.Data.Entity.EntityState.Detached)
			{
				DbSet.Attach(entity);
			}

			// **************************************************
			// Just For Debug!
			// **************************************************
			entityState =
				DatabaseContext.Entry(entity).State;
			// **************************************************
			// /Just For Debug!
			// **************************************************

			DatabaseContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;

			// **************************************************
			// Just For Debug!
			// **************************************************
			entityState = DatabaseContext.Entry(entity).State;
			// **************************************************
			// /Just For Debug!
			// **************************************************
		}

		public virtual void Delete(T entity)
		{
			if (entity == null)
			{
				throw (new System.ArgumentNullException("entity"));
			}

			//////////// **************************************************
			//////////// Just For Debug!
			//////////// **************************************************
			//////////System.Data.Entity.EntityState entityState = DatabaseContext.Entry(entity).State;
			//////////// **************************************************
			//////////// /Just For Debug!
			//////////// **************************************************

			//////////if (entityState == System.Data.Entity.EntityState.Detached)
			//////////{
			//////////	DbSet.Attach(entity);
			//////////}

			//////////// **************************************************
			//////////// Just For Debug!
			//////////// **************************************************
			//////////entityState = DatabaseContext.Entry(entity).State;
			//////////// **************************************************
			//////////// /Just For Debug!
			//////////// **************************************************

			//////////DbSet.Remove(entity);

			//////////// **************************************************
			//////////// Just For Debug!
			//////////// **************************************************
			//////////entityState = DatabaseContext.Entry(entity).State;
			//////////// **************************************************
			//////////// /Just For Debug!
			//////////// **************************************************

			if (entity.IsDeleted == false)
			{
				entity.IsDeleted = true;
				entity.DeleteDateTime = System.DateTime.Now;

				Update(entity);
			}
		}

		public virtual T GetById(System.Guid id)
		{
			// Solution (1)
			//T entity =
			//	DbSet
			//	.Where(current => current.Id == id)
			//	.FirstOrDefault();

			//return (entity);
			// /Solution (1)

			// Solution (2)
			return DbSet.Find(id);
			// /Solution (2)
		}

		public virtual bool DeleteById(System.Guid id)
		{
			// Solution (1)
			//T entity = DbSet.Find(id);
			// /Solution (1)

			// Solution (2)
			T entity = GetById(id);
			// /Solution (2)

			if (entity == null)
			{
				return false;
			}
			else
			{
				Delete(entity);

				return true;
			}
		}

		//public virtual System.Linq.IQueryable<T> Get()
		//{
		//	return DbSet;
		//}

		protected virtual System.Linq.IQueryable<T> Get()
		{
			return DbSet;
		}

		public virtual System.Collections.Generic.IList<T> GetAll()
		{
			return DbSet.ToList();
		}

		//public IQueryable<T> Get(System.Linq.Expressions.Expression<System.Func<T, bool>> predicate)
		//{
		//	return DbSet.Where(predicate);
		//}

		//public virtual System.Collections.Generic.IEnumerable<T>
		//	GetWithRawSql(string query, params object[] parameters)
		//{
		//	return DbSet.SqlQuery(query, parameters).ToList();
		//}
	}
}
