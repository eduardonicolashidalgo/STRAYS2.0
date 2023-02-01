using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using STRAYS.Models;
using STRAYS.Views;

namespace STRAYS.ViewModels
{
    public partial class AlertaViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<AlertaModel> mascota = App.Repositorio.GetAllAlertas();

        [RelayCommand]
        public void GoToAlertaRegistroPage()
        {
            Shell.Current.GoToAsync(nameof(AlertaRegistroPage));
        }

        [RelayCommand]
        private void AbrirFlyout()
        {
            Shell.Current.FlyoutIsPresented = true;
        }
    }

}

