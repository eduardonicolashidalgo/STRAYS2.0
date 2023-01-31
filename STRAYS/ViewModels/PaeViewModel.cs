using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using STRAYS.Models;
using STRAYS.Views;

namespace STRAYS.ViewModels
{
    public partial class PaeViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<PaeModel> mascota = App.Repositorio.GetAllPaes();

        [RelayCommand]
        public void GoToPaeRegistroPage()
        {
            Shell.Current.GoToAsync(nameof(PaeRegistroPage));
        }

        [RelayCommand]
        private void AbrirFlyout()
        {
            Shell.Current.FlyoutIsPresented = true;
        }
    }
}
