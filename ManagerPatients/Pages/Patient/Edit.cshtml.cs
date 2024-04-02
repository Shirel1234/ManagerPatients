using ManagerPatients.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static ManagerPatients.Model.Valid;

namespace ManagerPatients.Pages.Patient
{
    public class EditModel : PageModel
    {
        public Patients patient = new Patients();
        public String successMessage = string.Empty;
        public String errorMessage = string.Empty;

		private readonly IConfiguration configuration;
		public EditModel(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
		public void OnGet()
        {
            int id = Convert.ToInt32(Request.Query["id"]);
			try
			{
				DAL dal = new DAL();
				patient = dal.GetPatient(id, configuration);
			}
			catch (Exception ex)
			{

				errorMessage = ex.Message ;
			}
        }

		public void OnPost()
		{
			if (!CheckString(Request.Form["FirstName"]))
			{
				errorMessage = "The First Name is incorrect.";
				return;
			}
			if (!CheckString(Request.Form["LastName"]))
			{
				errorMessage = "The Last Name is incorrect.";
				return;
			}
			if (!CheckDate(Request.Form["DateOfBirth"]))
			{
				errorMessage = "The Date Of Birth is incorrect.";
				return;
			}
			if (!CheckMobilePhone(Request.Form["MobilePhone"]))
			{
				errorMessage = "The Mobile Phone is incorrect.";
				return;
			}
			if (!CheckPhoneNumber(Request.Form["Phone"]))
			{
				errorMessage = "The Phone is incorrect.";
				return;
			}
			patient.ID = Convert.ToInt32(Request.Form["hiddenId"]);
			patient.FirstName = Request.Form["FirstName"];
			patient.LastName = Request.Form["LastName"];
			patient.Address = Request.Form["Address"];
			patient.DateOfBirth = Convert.ToDateTime(Request.Form["DateOfBirth"]);
			patient.MobilePhone = Request.Form["MobilePhone"];
			patient.Phone = Request.Form["Phone"];

			if (patient.FirstName.Length == 0 || patient.LastName.Length == 0 || patient.ID.ToString().Length == 0 || patient.Address.Length == 0 || patient.DateOfBirth == null || patient.MobilePhone.Length == 0 || patient.Phone.Length == 0)
			{
				errorMessage = "All fileds are required.";
				return;
			}

			try
			{
				DAL dal = new DAL();
				int i = dal.UpdatePatient(patient, configuration);
			}
			catch (Exception ex)
			{
				errorMessage = ex.Message;
				return;
			}


			//patient.ID = 0; patient.FirstName = ""; patient.LastName = ""; patient.Address = ""; patient.DateOfBirth = DateTime.MinValue; patient.MobilePhone = ""; patient.Phone = "";
			successMessage = "patient has been added.";
			Response.Redirect("/Patient/Index");

		}
	}
}
