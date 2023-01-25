namespace STRAYS.Views;

public partial class CargaPage : ContentPage
{
	public CargaPage()
	{
		InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        if (!System.IO.Directory.Exists(Path.Combine(appDataPath, "PAE")))
        {
            System.IO.Directory.CreateDirectory(Path.Combine(appDataPath, "PAE"));
        }
        if (!System.IO.Directory.Exists(Path.Combine(appDataPath, "INFO")))
        {
            System.IO.Directory.CreateDirectory(Path.Combine(appDataPath, "INFO"));
        }
        if (!System.IO.Directory.Exists(Path.Combine(appDataPath, "ALERTA")))
        {
            System.IO.Directory.CreateDirectory(Path.Combine(appDataPath, "ALERTA"));
        }
    }

	private void IniciarApp(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync(nameof(PaePage));
    }
}