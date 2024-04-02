using ManagerPatients.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static ManagerPatients.Model.Valid;

namespace ManagerPatients.Pages.Patient
{
    public class CreateCoronaModel : PageModel
    {
		public string successMessage = String.Empty;
		public string errorMessage = String.Empty;
		public Corona corona = new Corona();

		private readonly IConfiguration configuration;
		public CreateCoronaModel(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
		public void OnGet()
        {
        }
		public void OnPost()
		{
			if (!CheckDate(Request.Form["PositiveDate"]))
			{
				errorMessage = "The Date Of Positive is incorrect.";
				return;
			}
			if (!CheckDate(Request.Form["RecoveryDate"]))
			{
				errorMessage = "The Date Of Recovery is incorrect.";
				return;
			}
			corona.ID = Convert.ToInt32(Request.Query["id"]);
			corona.PositiveDate = Convert.ToDateTime(Request.Form["PositiveDate"]);
			corona.RecoveryDate = Convert.ToDateTime(Request.Form["RecoveryDate"]);
			if (corona.PositiveDate == null || corona.RecoveryDate == null || corona.ID.ToString().Length == 0)
			{
				errorMessage = "All fileds are required.";
				return;
			}

			try
			{
				DAL dal = new DAL();
				int i = dal.AddCorona(corona, configuration);
			}
			catch (Exception ex)
			{
				errorMessage = ex.Message;
				return;
			}
			int id = corona.ID;
			corona.ID = 0; corona.PositiveDate = DateTime.MinValue; corona.RecoveryDate = DateTime.MinValue;
			successMessage = "Vaccine has been added.";
			Response.Redirect("/Patient/MoreDetails?id=" + id);

		}
	}
}
