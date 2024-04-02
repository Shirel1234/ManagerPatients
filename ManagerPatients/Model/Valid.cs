namespace ManagerPatients.Model
{
	public static class Valid
	{
		public static bool CheckId(string id)
		{
			if(id.Length>9 || id.Length<9)
			{
				return false;
			}
			for(int i = 0; i< id.Length;i++)
			{
                if (id[i]<='/' || id[i] >=':')
				{
					return false;
				}
			}
			return true;
		}

		public static bool CheckString(string name)
		{
			for (int i = 0; i < name.Length; i++)
			{
				if (name[i] > '/' && name[i] < ':')
				{
					return false;
				}
			}
			return true;
		}
		public static bool CheckPhoneNumber(string num)
		{
			if (num.Length > 9 || num.Length < 9)
			{
				return false;
			}
			if (num[0] != '0')
			{
				return false;
			}
			for (int i = 1; i < num.Length; i++)
			{
				if (num[i] <= '/' && num[i] >= ':')
				{
					return false;
				}
			}
			return true;
		}
		public static bool CheckMobilePhone(string num)
		{
			if(num.Length>10 || num.Length < 10)
			{
				return false;
			}
			if (num[0] != '0' || num[1] != '5')
			{
				return false;
			}
			for (int i = 2; i < num.Length; i++)
			{
				if (num[i] <= '/' && num[i] >= ':')
				{
					return false;
				}
			}
			return true;
		}
		public static bool CheckDate(string date)
		{
			if (date.Length > 10 || date.Length<10)
			{
				return false;
			}
			for (int i = 0; i < 9; i+=3)
			{
				if (date[i] <= '/' || date[i] >= ':' || date[i+1] <= '/' || date[i+1] >= ':')
				{
					return false;
				}
			}
			if (date[8] <= '/' || date[8] >= ':' || date[9] <= '/' || date[9] >= ':')
			{
				return false;
			}
			if (date[2] != '/' || date[5] != '/')
			{
					return false;
			}
			
			return true;
		}
	}
}
