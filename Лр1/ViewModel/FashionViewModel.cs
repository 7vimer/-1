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

		private Fashion _selectedItem;


		FashionService fService = new();


		public ObservableCollection<Fashion> Fashions { get; } = new();


		public FashionViewModel()
		{
			GetFashionsAsync();
		}


		public string Desc { get; set; }


		public Fashion SelectedItem
		{
			get => _selectedItem;
			set
			{
				_selectedItem = value;
				Desc = value?.Description;

				OnPropertyChanged(nameof(Desc));
			}
		}


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
