using STRAYS.Models;
using STRAYS.ViewModels;

namespace STRAYS.Views;

public partial class InfoPage : ContentPage
{
	public InfoPage(InfoViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        List<InfoModel> mascota = App.Repositorio.GetAllInfos();
        lista.ItemsSource = mascota;
    }
    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var info = (Models.InfoModel)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(InfoRegistroPage)}?{nameof(InfoRegistroPage.ItemId)}={info.IdInfo}");

            // Unselect the UI
            lista.SelectedItem = null;
        }
    }
    private void irArriba(object sender, EventArgs e)
    {
        lista.ScrollTo(0);
    }
}