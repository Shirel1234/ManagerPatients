using ManagerPatients.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static ManagerPatients.Model.Valid;

namespace ManagerPatients.Pages.Patient
{
	public class CreateVaccineModel : PageModel
	{
		public string successMessage = String.Empty;
		public string errorMessage = String.Empty;
		public Vaccine vaccine = new Vaccine();

		private readonly IConfiguration configuration;
		public CreateVaccineModel(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
		public void OnGet()
		{
		}

		public void OnPost()
		{
		    if (!CheckDate(Request.Form["VaccineDate"]))
			{
				errorMessage = "The Date Of Vaccine is incorrect.";
				return;
			}		
			vaccine.ID = Convert.ToInt32(Request.Query["id"]);
			vaccine.VaccineDate = Convert.ToDateTime(Request.Form["VaccineDate"]);
			vaccine.VaccineManufacturer = Request.Form["VaccineManufacturer"];
			if (vaccine.VaccineManufacturer.Length == 0 || vaccine.VaccineDate == null || vaccine.ID.ToString().Length == 0)
			{
				errorMessage = "All fileds are required.";
				return;
			}

			try
			{
				DAL dal = new DAL();
				int i = dal.AddVaccine(vaccine, configuration);
			}
			catch (Exception ex)
			{
				errorMessage = ex.Message;
				return;
			}
			int id = vaccine.ID;
			vaccine.ID = 0; vaccine.VaccineDate = DateTime.MinValue; vaccine.VaccineManufacturer = "";
			successMessage = "Vaccine has been added.";
			Response.Redirect("/Patient/MoreDetails?id=" + id);

		}
	}

}
