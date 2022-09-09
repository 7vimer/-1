using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Лр1.Model;
using Лр1.Services;

namespace Лр1.ViewModel
{
	public class FashionViewModel : BindableObject
	{
		// Переменная для хранения состояния
		// выбранного элемента коллекции
		private Fashion _selectedItem;
		// Объект с логикой по извлечению данных
		// из источника
		FashionService fService = new();

		// Коллекция извлекаемых объектов
		public ObservableCollection<Fashion> Fashions { get; } = new();

		// Конструктор с вызовом метода
		// получения данных
		public FashionViewModel()
		{
			GetFashionsAsync();
		}

		// Публичное свойство для представления
		// описания выбранного элемента из коллекции
		public string Desc { get; set; }

		// Свойство для представления и изменения
		// состояния выбранного объекта
		public Fashion SelectedItem
		{
			get => _selectedItem;
			set
			{
				_selectedItem = value;
				Desc = value?.Description;
				// Метод отвечает за обновление данных
				// в реальном времени
				OnPropertyChanged(nameof(Desc));
			}
		}

		// Метод получения коллекции объектов
		async Task GetFashionsAsync()
		{
			try
			{
				var fashions = await fService.GetFood();

				if (Fashions.Count != 0)
					Fashions.Clear();

				foreach (var fashion in fashions)
				{
					Fashions.Add(fashion);
				}
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Ошибка!",
					$"Что-то пошло не так: {ex.Message}", "OK");
			}
		}

	}
}
