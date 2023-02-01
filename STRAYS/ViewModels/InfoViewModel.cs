using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using STRAYS.Models;
using STRAYS.Views;

namespace STRAYS.ViewModels
{
    public partial class InfoViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<InfoModel> mascota = App.Repositorio.GetAllInfos();

        [RelayCommand]
        public void GoToInfoRegistroPage()
        {
            Shell.Current.GoToAsync(nameof(InfoRegistroPage));
        }

        [RelayCommand]
        private void AbrirFlyout()
        {
            Shell.Current.FlyoutIsPresented = true;
        }
    }
}
