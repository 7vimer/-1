using Лр1.ViewModel;

namespace Лр1;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

		BindingContext = new FashionViewModel();

	}

}

