using STRAYS.Views;

namespace STRAYS;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.CargaPage), typeof(Views.CargaPage));
        Routing.RegisterRoute(nameof(Views.PaePage), typeof(Views.PaePage));
        Routing.RegisterRoute(nameof(Views.PaeRegistroPage), typeof(Views.PaeRegistroPage));
        Routing.RegisterRoute(nameof(Views.InfoPage), typeof(Views.InfoPage));
        Routing.RegisterRoute(nameof(Views.AlertaPage), typeof(Views.AlertaPage));
        Routing.RegisterRoute(nameof(Views.InfoRegistroPage), typeof(Views.InfoRegistroPage));
        Routing.RegisterRoute(nameof(Views.AlertaRegistroPage), typeof(Views.AlertaRegistroPage));
    }

}
