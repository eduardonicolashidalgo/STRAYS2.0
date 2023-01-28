using STRAYS.Data;

namespace STRAYS;

public partial class App : Application
{
    public static DatabaseActions Repositorio { get; private set; }

    public App(DatabaseActions repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

        Repositorio = repo;
    }
}
