using STRAYS.Models;
using STRAYS.ViewModels;

namespace STRAYS.Views;

public partial class AlertaPage : ContentPage
{
	public AlertaPage(AlertaViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        List<AlertaModel> mascota = App.Repositorio.GetAllAlertas();
        lista.ItemsSource = mascota;
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var alerta = (Models.AlertaModel)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(AlertaRegistroPage)}?{nameof(AlertaRegistroPage.ItemId)}={alerta.IdAlerta}");

            // Unselect the UI
            lista.SelectedItem = null;
        }
    }
    private void irArriba(object sender, EventArgs e)
    {
        lista.ScrollTo(0);
    }


}