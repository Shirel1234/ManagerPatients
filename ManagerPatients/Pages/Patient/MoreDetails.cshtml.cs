using ManagerPatients.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ManagerPatients.Pages.Patient
{
    public class MoreDetailsModel : PageModel
    {

		private readonly IConfiguration configuration;
		public List<Vaccine> listVaccines = new List<Vaccine>();
		public List<Corona> listCorona = new List<Corona>();
		public MoreDetailsModel(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
		public void OnGet()
		{
			int id = Convert.ToInt32(Request.Query["id"]);
			DAL dal = new DAL();
			listVaccines = dal.GetVaccines(id, configuration);
			listCorona = dal.GetCorona(id, configuration);
		} 

    }
}
