using STRAYS.Data;
using STRAYS.Services;

namespace STRAYS;

public partial class App : Application
{
    public static DatabaseActions Repositorio { get; private set; }
    public static ImageGenerator API { get; private set; }

    public App(DatabaseActions repo, ImageGenerator api)
	{
		InitializeComponent();

		MainPage = new AppShell();

        Repositorio = repo;
        API = api;
    }
}
