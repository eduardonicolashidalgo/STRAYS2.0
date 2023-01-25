namespace STRAYS.Views;

public partial class AlertaPage : ContentPage
{
	public AlertaPage()
	{
		InitializeComponent();
        BindingContext = new Models.AllNotes3();
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

    private void GoToAlertaRegistroPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AlertaRegistroPage));
    }

    protected override void OnAppearing()
    {
        ((Models.AllNotes3)BindingContext).LoadNotes();
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.Note2)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(AlertaRegistroPage)}?{nameof(AlertaRegistroPage.ItemId)}={note.Filename1}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }

    private void AbrirFlyout(object sender, EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = true;
    }
}