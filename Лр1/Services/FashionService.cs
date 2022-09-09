using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Лр1.Model;


namespace Лр1.Services
{
	public class FashionService
	{
		// Создаем список для хранения данных из источника
		List<Fashion> fList = new();

		// Метод GetFood() служит для извлечения и сруктурирования данных
		// в соответсвии с существующей моделью данных
		public async Task<IEnumerable<Fashion>> GetFood()
		{
			// Если список содержит какие-то элементы
			// то вернется последовательность с содержимым этого списка
			if (fList?.Count > 0)
				return fList;

			// В данном блоке кода осуществляется подключение, чтение
			// и дессериализация файла - источника данных
			using var stream = await FileSystem.OpenAppPackageFileAsync("Fashion.json");
			using var reader = new StreamReader(stream);
			var contents = await reader.ReadToEndAsync();
			fList = JsonSerializer.Deserialize<List<Fashion>>(contents);

			return fList;
		}

	}
}
