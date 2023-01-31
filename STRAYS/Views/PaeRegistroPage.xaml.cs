using STRAYS.Models;

namespace STRAYS.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class PaeRegistroPage : ContentPage
{
    PaeModel Item = new PaeModel();
    PaeModel aux = new PaeModel();
    string img;

    public int ItemId
    {
        set { cargarMascota(value); }
    }

    public PaeRegistroPage()
	{
		InitializeComponent();
    }


    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        App.Repositorio.eliminar(aux.IdPae,"pae");
        await Shell.Current.GoToAsync("..");
    }

    private void cargarMascota(int id)
    {
        Models.PaeModel mascota = new Models.PaeModel();
        mascota = App.Repositorio.GetPaeById(id);
        aux = mascota;
        BindingContext = mascota;
    }

    private async void PickAndShow(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = FilePickerFileType.Images, 
        });

        if(result == null)
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
            Item.Nombre = txtNombre.Text;
            Item.Sexo = txtSexo.Text;
            Item.Edad = (int)stepperEdad.Value;
            Item.Raza= txtRaza.Text;
            Item.Tamano = txtTamano.Text;
            Item.Descripcion= txtDescripcion.Text;
            Item.Imagen = img;
            Item.Date = DateTime.Now;
            int error = App.Repositorio.insertRegistroPae(Item);
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
            App.Repositorio.actualizarPae(aux.IdPae,
                aux.Nombre, 
                aux.Sexo,
                aux.Edad,
                aux.Raza,
                aux.Tamano,
                aux.Descripcion,
                img);
            await Shell.Current.GoToAsync("..");
        }
    }

    private void Cancelar(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }


    public async void generarImg(object sender, EventArgs e)
    {
        input inp = new input() { size = "256x256", n = 1 };
        inp.prompt = descAPI.Text;
        responseModel resp;
        resp = await App.API.GenerateImage(inp);
        try
        {
            Uri imageurl = new Uri(resp.data[0].url);
            imagen.Source = ImageSource.FromUri(imageurl);
            img = imageurl.ToString();
        }catch(System.NullReferenceException)
        {
            await Application.Current.MainPage.DisplayAlert("Alerta", "No se logró contactar a la API", "OK");
        }

    }

    private void actualizarLlaveAPI(object sender, EventArgs e)
    {
        App.API.setKey(llaveapi.Text);
        mensajeLlave.IsVisible = true;
        llaveapi.Text = "";
    }

    private void cambiarColorPressed(object sender, EventArgs e)
    {
        btngenerar.BackgroundColor = Color.FromArgb("#dcc5d9");
    }

    private void cambiarColorReleased(object sender, EventArgs e)
    {
        btngenerar.BackgroundColor = Color.FromArgb("#8B3C7F"); ;
    }
}