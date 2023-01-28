using STRAYS.Models;

namespace STRAYS.Views;

public partial class PaePage : ContentPage
{
	public PaePage()
	{
		InitializeComponent();
        List<PaeModel> mascota = App.Repositorio.GetAllPaes();
        lista.ItemsSource = mascota;
    }

	private void GoToPaePage(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync(nameof(PaePage));
    }

	private void GoToPaeRegistroPage(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync(nameof(PaeRegistroPage));
    }

	private void GoToInfoPage(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync(nameof(InfoPage));
    }

	private void GoToAlertaPage(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync(nameof(AlertaPage));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        List<PaeModel> mascota = App.Repositorio.GetAllPaes();
        lista.ItemsSource = mascota;
    }


    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var pae = (Models.PaeModel)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(PaeRegistroPage)}?{nameof(PaeRegistroPage.ItemId)}={pae.IdPae}");

            // Unselect the UI
            lista.SelectedItem = null;
        }
    }

    private void AbrirFlyout(object sender, EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = true;
    }

}