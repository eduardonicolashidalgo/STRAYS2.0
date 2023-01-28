namespace STRAYS.Views;

public partial class CargaPage : ContentPage
{
	public CargaPage()
	{
		InitializeComponent();
    }

	private void IniciarApp(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync(nameof(PaePage));
    }
}