namespace STRAYS.Views;

public partial class PaePage : ContentPage
{
	public PaePage()
	{
		InitializeComponent();
        BindingContext = new Models.AllNotes();
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
        ((Models.AllNotes)BindingContext).LoadNotes();
    }


    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.Note)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(PaeRegistroPage)}?{nameof(PaeRegistroPage.ItemId)}={note.Filename1}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }

    private void AbrirFlyout(object sender, EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = true;
    }
}