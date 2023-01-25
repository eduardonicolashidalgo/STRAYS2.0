namespace STRAYS.Views;

public partial class InfoPage : ContentPage
{
	public InfoPage()
	{
		InitializeComponent();
        BindingContext = new Models.AllNotes2();
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

    private void GoToInfoRegistroPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(InfoRegistroPage));
    }
    protected override void OnAppearing()
    {
        ((Models.AllNotes2)BindingContext).LoadNotes();
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.Note2)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(InfoRegistroPage)}?{nameof(InfoRegistroPage.ItemId)}={note.Filename1}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }

    private void AbrirFlyout(object sender, EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = true;
    }
}