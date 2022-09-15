using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Лр1.Model;


namespace Лр1.Services
{
	public class FashionService
	{
		List<Fashion> fList = new();

		public async Task<IEnumerable<Fashion>> GetFood()
		{

			if (fList?.Count > 0)
				return fList;


			var stream = AppDomain.CurrentDomain.BaseDirectory + "Fashion.json";
			using var reader = new StreamReader(stream);
			var contents = await reader.ReadToEndAsync();
			fList = JsonSerializer.Deserialize<List<Fashion>>(contents);

			return fList;
		}

	}
}
