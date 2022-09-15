using MauiApp1;
using Лр1.ViewModel;

namespace Лр1;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

		BindingContext = new FashionViewModel();
 
	}

	private async void AddItem(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AddPage(this));
		
	}

}

