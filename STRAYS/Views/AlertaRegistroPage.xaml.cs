using STRAYS.Models;
using static Android.Content.ClipData;
namespace STRAYS.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class AlertaRegistroPage : ContentPage
{

    AlertaModel Item = new AlertaModel();
    AlertaModel aux = new AlertaModel();
    string img;

    public int ItemId
    {
        set { cargarMascota(value); }
    }
    public AlertaRegistroPage()
	{
		InitializeComponent();
	}

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        App.Repositorio.eliminar(aux.IdAlerta, "alerta");
        await Shell.Current.GoToAsync("..");
    }

    private void cargarMascota(int id)
    {
        Models.AlertaModel mascota = new Models.AlertaModel();
        mascota = App.Repositorio.GetAlertaById(id);
        aux = mascota;
        BindingContext = mascota;
    }


    private async void PickAndShow(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = FilePickerFileType.Images,
        });

        if (result == null)
        {
            return;
        }

        var stream = result.FullPath;
        imagen.Source = stream;
        img = stream;

        if (BindingContext != null)
        {
            aux.Imagen = stream;
        }
    }


    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext == null)
        {
            Item.Titulo = txtTitulo.Text;
            Item.Sexo = txtSexo.Text;
            Item.Raza = txtRaza.Text;
            Item.Ubicacion = txtUbicacion.Text;
            Item.Descripcion = txtDescripcion.Text;
            Item.Imagen = img;
            Item.Date = DateTime.Now;
            int error = App.Repositorio.insertRegistroAlerta(Item);
            if (error == 404)
            {
                await DisplayAlert("Alerta", "No se pudo ingresar la mascota", "OK");
            }
            else
            {
                await Shell.Current.GoToAsync("..");
            }
        }
        else
        {
            App.Repositorio.actualizarAlerta(aux.IdAlerta,
                aux.Titulo,
                aux.Sexo,
                aux.Raza,
                aux.Ubicacion,
                aux.Descripcion,
                img);
            await Shell.Current.GoToAsync("..");
        }
    }


    private void Cancelar(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }


}