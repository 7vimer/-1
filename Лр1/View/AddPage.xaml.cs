using System.Text.Json;
using Ëð1;
using Ëð1.Model;
using Ëð1.ViewModel;

namespace MauiApp1;

public partial class AddPage : ContentPage
{
	MainPage MP;
	public AddPage(MainPage mp)
	{
		InitializeComponent();
		MP = mp;
	}
	private async void SaveButtonCl(object sender, EventArgs e)
	{
		Fashion f = new Fashion();
		f.Name = Procedure.Text;
		f.Description = DescriptionEntry.Text;
		f.Cost = Convert.ToInt16(Cost.Text);
		f.Image = ImageEntry.Text;

		var stream = AppDomain.CurrentDomain.BaseDirectory + "Fashion.json";
		using var reader = new StreamReader(stream);
		var contents = await reader.ReadToEndAsync();
		reader.Close();
		List<Fashion> fList = new();
		fList = JsonSerializer.Deserialize<List<Fashion>>(contents);
		f.Id = fList.Count + 1;
		fList.Add(f);
		File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Fashion.json", JsonSerializer.Serialize(fList));
		//MP.BindingContext = new FashionViewModel();
		Navigation.RemovePage(this);
	}
}
