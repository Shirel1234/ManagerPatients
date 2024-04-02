using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace ManagerPatients.Model
{
	public class DAL
	{
		public string constring = "Data Source=DESKTOP-DQSSMT4\\SQLEXPRESS;Initial Catalog=PatientsDB;Integrated Security=True";
		public List<Patients> GetPatients(IConfiguration _configuration)
		{
			List<Patients> listPatients = new List<Patients>();
			using (SqlConnection con = new SqlConnection(constring))
			{
					con.Open();
					string sql = "select * from patients";
					using(SqlCommand cmd = new SqlCommand(sql, con))
					{
						SqlDataReader reader = cmd.ExecuteReader();

						while (reader.Read())
						{
							Patients patient = new Patients();
							patient.ID = reader.GetInt32("ID");
							patient.FirstName = Convert.ToString(reader.GetString("FirstName"));
							patient.LastName = Convert.ToString(reader.GetString("LastName"));
							patient.Address = Convert.ToString(reader.GetString("Address"));
							patient.DateOfBirth = Convert.ToDateTime(reader.GetDateTime("DateOfBirth"));
							patient.MobilePhone = Convert.ToString(reader.GetString("MobilePhone"));
							patient.Phone = Convert.ToString(reader.GetString("Phone"));

							listPatients.Add(patient);


						}
					}
			}
			return listPatients;
		}
		public int AddPatient(Patients patient, IConfiguration configuration) 
		{
			int i = 0;
			using (SqlConnection con = new SqlConnection(constring))
			{
				//SqlCommand cmd = new SqlCommand("INSERT INTO Patients(ID, FirstName, LastName, Address, DateOfBirth, MobilePhone, Phone) VALUES('"+ patient.ID + "' , '" + patient.FirstName + "' , '" + patient.LastName + "' , '" + patient.Address + "' , '" + patient.DateOfBirth + "' , '" + patient.MobilePhone + "' , '" + patient.Phone + "')", con);
				SqlCommand cmd = new SqlCommand("INSERT INTO Patients(ID, FirstName, LastName, Address, DateOfBirth, MobilePhone, Phone) VALUES(@ID, @FirstName, @LastName, @Address, @DateOfBirth, @MobilePhone, @Phone)", con);

				// Add parameters and set their values
				cmd.Parameters.AddWithValue("@ID", patient.ID);
				cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
				cmd.Parameters.AddWithValue("@LastName", patient.LastName);
				cmd.Parameters.AddWithValue("@Address", patient.Address);
				cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
				cmd.Parameters.AddWithValue("@MobilePhone", patient.MobilePhone);
				cmd.Parameters.AddWithValue("@Phone", patient.Phone);

				con.Open();

				i = cmd.ExecuteNonQuery();
				con.Close();
			}
			return i;

		}
		public Patients GetPatient(int id, IConfiguration configuration) 
		{
			Patients patient = new Patients();
			using (SqlConnection con = new SqlConnection(constring))
			{
				con.Open();
				string sql = "SELECT * FROM Patients WHERE ID = '"+id+"'";
				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						patient.ID = reader.GetInt32("ID");
						patient.FirstName = Convert.ToString(reader.GetString("FirstName"));
						patient.LastName = Convert.ToString(reader.GetString("LastName"));;
						patient.Address = Convert.ToString(reader.GetString("Address"));
						patient.DateOfBirth = Convert.ToDateTime(reader.GetDateTime("DateOfBirth"));
						patient.MobilePhone = Convert.ToString(reader.GetString("MobilePhone"));
						patient.Phone = Convert.ToString(reader.GetString("Phone"));
					}
				}
			}
			return patient;
		}
		public int UpdatePatient(Patients patient, IConfiguration configuration)
		{
			int i = 0;
			using (SqlConnection con = new SqlConnection(constring))
			{
				//SqlCommand cmd = new SqlCommand("UPDATE Patients SET FirstName = '" + patient.FirstName + "',LastName= '" + patient.LastName + "',Address = '" + patient.Address + "',DateOfBirth = '" + patient.DateOfBirth + "',MobilePhone = '" + patient.MobilePhone + "',Phone = '" + patient.Phone + "' WHERE ID = '" +patient.ID+"' ", con);
				SqlCommand cmd = new SqlCommand("UPDATE Patients SET FirstName = @FirstName, LastName = @LastName, Address = @Address, DateOfBirth = @DateOfBirth, MobilePhone = @MobilePhone, Phone = @Phone WHERE ID = @ID", con);

				// Add parameters and set their values
				cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
				cmd.Parameters.AddWithValue("@LastName", patient.LastName);
				cmd.Parameters.AddWithValue("@Address", patient.Address);
				cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
				cmd.Parameters.AddWithValue("@MobilePhone", patient.MobilePhone);
				cmd.Parameters.AddWithValue("@Phone", patient.Phone);
				cmd.Parameters.AddWithValue("@ID", patient.ID);

				con.Open();
				i = cmd.ExecuteNonQuery();
				con.Close();
			}
			return i;

		}
		public int DeletePatient(string id, IConfiguration configuration)
		{
			int i = 0;
			using (SqlConnection con = new SqlConnection(constring))
			{
				SqlCommand cmd = new SqlCommand("DELETE FROM Patients WHERE ID = '" + id + "' ", con);
				con.Open();
				i = cmd.ExecuteNonQuery();
				con.Close();
			}
			return i;

		}
		public List<Vaccine> GetVaccines(int id, IConfiguration _configuration)
		{
			List<Vaccine> listVaccines = new List<Vaccine>();
			using (SqlConnection con = new SqlConnection(constring))
			{
				con.Open();
				string sql = "SELECT * FROM VaccineDetails WHERE ID = '"+ id +"'";
				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						Vaccine vaccine = new Vaccine();
						vaccine.ID = reader.GetInt32("ID");
						vaccine.VaccineDate = Convert.ToDateTime(reader.GetDateTime("VaccineDate"));
						vaccine.VaccineManufacturer = Convert.ToString(reader.GetString("VaccineManufacturer"));

						listVaccines.Add(vaccine);


					}
				}
			}
			return listVaccines;
		}
		public List<Corona> GetCorona(int id, IConfiguration _configuration)
		{
			List<Corona> listCorona = new List<Corona>();
			using (SqlConnection con = new SqlConnection(constring))
			{
				con.Open();
				string sql = "SELECT * FROM CoronaDetails WHERE ID = '" + id + "'";
				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						Corona corona = new Corona();
						corona.ID = reader.GetInt32("ID");
						corona.PositiveDate = Convert.ToDateTime(reader.GetDateTime("PositiveDate"));
						corona.RecoveryDate = Convert.ToDateTime(reader.GetDateTime("RecoveryDate"));
						listCorona.Add(corona);
					}

				}
			}
			return listCorona;
		}
		public int AddVaccine(Vaccine vaccine, IConfiguration configuration)
		{
			int i = 0;
			using (SqlConnection con = new SqlConnection(constring))
			{
				//SqlCommand cmd = new SqlCommand("INSERT INTO Patients(ID, FirstName, LastName, Address, DateOfBirth, MobilePhone, Phone) VALUES('"+ patient.ID + "' , '" + patient.FirstName + "' , '" + patient.LastName + "' , '" + patient.Address + "' , '" + patient.DateOfBirth + "' , '" + patient.MobilePhone + "' , '" + patient.Phone + "')", con);
				SqlCommand cmd = new SqlCommand("INSERT INTO VaccineDetails(ID, VaccineDate, VaccineManufacturer) VALUES(@ID, @VaccineDate, @VaccineManufacturer)", con);

				// Add parameters and set their values
				cmd.Parameters.AddWithValue("@ID", vaccine.ID);
				cmd.Parameters.AddWithValue("@VaccineDate", vaccine.VaccineDate);
				cmd.Parameters.AddWithValue("@VaccineManufacturer", vaccine.VaccineManufacturer);

				con.Open();

				i = cmd.ExecuteNonQuery();
				con.Close();
			}
			return i;

		}
		public int AddCorona(Corona corona, IConfiguration configuration)
		{
			int i = 0;
			using (SqlConnection con = new SqlConnection(constring))
			{
				SqlCommand cmd = new SqlCommand("INSERT INTO CoronaDetails(ID, PositiveDate, RecoveryDate) VALUES(@ID, @PositiveDate, @RecoveryDate)", con);

				// Add parameters and set their values
				cmd.Parameters.AddWithValue("@ID", corona.ID);
				cmd.Parameters.AddWithValue("@PositiveDate", corona.PositiveDate);
				cmd.Parameters.AddWithValue("@RecoveryDate", corona.RecoveryDate);

				con.Open();

				i = cmd.ExecuteNonQuery();
				con.Close();
			}
			return i;

		}
		/*public Vaccine GetVaccine(int id, DateTime vaccineDate, IConfiguration configuration)
		{
			Vaccine vaccine = new Vaccine();
			using (SqlConnection con = new SqlConnection(constring))
			{
				con.Open();
				string sql = "SELECT * FROM VaccineDetails WHERE ID = @id AND VaccineDate = @vaccineDate ";
				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.AddWithValue("@id", id);
					cmd.Parameters.AddWithValue("@vaccineDate", vaccineDate);
					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						vaccine.ID = reader.GetInt32("ID");
						vaccine.VaccineDate = Convert.ToDateTime(reader.GetDateTime("VaccineDate"));
						vaccine.VaccineManufacturer = Convert.ToString(reader.GetString("VaccineManufacturer")); ;
					}
				}
			}
			return vaccine;
		}*/
		public int DeleteVaccine(string id, DateTime date, IConfiguration configuration)
		{
			int i = 0;
			using (SqlConnection con = new SqlConnection(constring))
			{
				SqlCommand cmd = new SqlCommand("DELETE FROM PatientsDB.dbo.VaccineDetails WHERE ID = @ID AND VaccineDate = @VaccineDate", con);
				cmd.Parameters.AddWithValue("@VaccineDate", date);
				cmd.Parameters.AddWithValue("@ID", id);
				con.Open();
				i = cmd.ExecuteNonQuery();
				con.Close();
			}
			return i;

		}
		public int DeleteCorona(string id, DateTime date, IConfiguration configuration)
		{
			int i = 0;
			using (SqlConnection con = new SqlConnection(constring))
			{
				SqlCommand cmd = new SqlCommand("DELETE FROM PatientsDB.dbo.CoronaDetails WHERE ID = @ID AND PositiveDate = @PositiveDate", con);
				cmd.Parameters.AddWithValue("@PositiveDate", date);
				cmd.Parameters.AddWithValue("@ID", id);
				con.Open();
				i = cmd.ExecuteNonQuery();
				con.Close();
			}
			return i;

		}
	}
}
