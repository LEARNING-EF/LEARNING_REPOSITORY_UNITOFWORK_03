using System.Linq;
using System.Data.Entity;

namespace LEARNING
{
	public partial class MainForm : System.Windows.Forms.Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			DAL.UnitOfWork unitOfWork = null;

			try
			{
				unitOfWork =
					new DAL.UnitOfWork();

				Models.User user = null;

				System.Guid sId =
					new System.Guid
						("a1a57f49-51fc-4c4b-8f06-19cd117d5c9e");

				// **************************************************
				// Get Data
				// **************************************************
				//var users =
				//	unitOfWork.UserRepository
				//	.Get()
				//	.ToList()
				//	;

				//var users =
				//	unitOfWork.UserRepository
				//	.Get()
				//	.Where(current => current.IsActive)
				//	.ToList()
				//	;

				//var users =
				//	unitOfWork.UserRepository
				//	.GetActiveUsers()
				//	.ToList()
				//	;

				var users =
					unitOfWork.UserRepository
					.GetActiveUsers()
					;
				// **************************************************
				// /Get Data
				// **************************************************

				// **************************************************
				// Add New User
				// **************************************************
				unitOfWork =
					new DAL.UnitOfWork();

				user = new Models.User();

				user.Id = sId;
				user.IsActive = true;
				user.Username = "Dariush";

				unitOfWork.UserRepository.Insert(user);

				unitOfWork.Save();
				unitOfWork.Dispose();
				unitOfWork = null;
				// **************************************************
				// /Add New User
				// **************************************************

				// **************************************************
				// Get And Update
				// **************************************************
				unitOfWork =
					new DAL.UnitOfWork();

				user =
					unitOfWork.UserRepository
					.GetById(sId);

				if (user != null)
				{
					user.IsActive = !user.IsActive;

					unitOfWork.UserRepository.Update(user);

					unitOfWork.Save();
				}

				unitOfWork.Dispose();
				unitOfWork = null;
				// **************************************************
				// /Get And Update
				// **************************************************

				// **************************************************
				// Just Update
				// **************************************************
				unitOfWork =
					new DAL.UnitOfWork();

				user = new Models.User();

				user.Id = sId;
				user.Username = "AliReza";
				user.IsActive = !user.IsActive;

				unitOfWork.UserRepository.Update(user);

				unitOfWork.Save();
				unitOfWork.Dispose();
				unitOfWork = null;
				// **************************************************
				// /Just Update
				// **************************************************

				// **************************************************
				// Get And Delete
				// **************************************************
				unitOfWork =
					new DAL.UnitOfWork();

				user =
					unitOfWork.UserRepository
					.GetById(sId);

				if (user != null)
				{
					unitOfWork.UserRepository.Delete(user);

					unitOfWork.Save();
				}

				unitOfWork.Dispose();
				unitOfWork = null;
				// **************************************************
				// /Get And Delete
				// **************************************************

				// **************************************************
				// Add Again New User
				// **************************************************
				unitOfWork =
					new DAL.UnitOfWork();

				user = new Models.User();

				user.Id = sId;
				user.IsActive = true;
				user.Username = "Dariush";

				unitOfWork.UserRepository.Insert(user);

				unitOfWork.Save();
				unitOfWork.Dispose();
				unitOfWork = null;
				// **************************************************
				// Add New User
				// **************************************************

				// **************************************************
				// Just Delete
				// **************************************************
				unitOfWork =
					new DAL.UnitOfWork();

				user = new Models.User();

				user.Id = sId;

				unitOfWork.UserRepository.Delete(user);

				unitOfWork.Save();
				unitOfWork.Dispose();
				unitOfWork = null;
				// **************************************************
				// /Just Delete
				// **************************************************
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
			finally
			{
				if (unitOfWork != null)
				{
					unitOfWork.Dispose();
					unitOfWork = null;
				}
			}
		}
	}
}
