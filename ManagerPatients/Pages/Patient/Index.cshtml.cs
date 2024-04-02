using ManagerPatients.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ManagerPatients.Pages.Patient
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration configuration;
        public List<Patients> listPatients = new List<Patients>();
        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
		}
		public void OnGet()
		{
			DAL dal = new DAL();
            listPatients = dal.GetPatients(configuration);
        }
    }
}
