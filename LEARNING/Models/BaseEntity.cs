namespace Models
{
	public abstract class BaseEntity : object
	{
		public BaseEntity() : base()
		{
			Id = System.Guid.NewGuid();
		}

		// **********
		public System.Guid Id { get; set; }
		// **********

		// **********
		public bool IsActive { get; set; }
		// **********

		// **********
		public bool IsDeleted { get; set; }
		// **********

		// **********
		public System.DateTime InsertDateTime { get; set; }
		// **********

		// **********
		public System.DateTime UpdateDateTime { get; set; }
		// **********

		// **********
		public System.DateTime? DeleteDateTime { get; set; }
		// **********
	}
}
