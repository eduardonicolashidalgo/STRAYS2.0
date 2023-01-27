using Microsoft.Maui.Storage;
using static CoreMedia.CMTime;
using System.Runtime.Intrinsics.X86;
using STRAYS.Models;

namespace STRAYS.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class PaeRegistroPage : ContentPage
{
    PaeModel Item = new PaeModel();
    PaeModel aux = new PaeModel();

    public int ItemId
    {
        set { cargarMascota(value); }
    }

    public PaeRegistroPage()
	{
		InitializeComponent();
    }

	private void GoToPaePage(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync(nameof(PaePage));
    }

    /*private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(txtNombre.Text) ||
            string.IsNullOrEmpty(txtSexo.Text) ||
            string.IsNullOrEmpty(txtEdad.Text) ||
            string.IsNullOrEmpty(txtRaza.Text) ||
            string.IsNullOrEmpty(txtTamano.Text) ||
            string.IsNullOrEmpty(txtDescripcion.Text)
            )
        {
            await DisplayAlert("Alerta", "Porfavor complete todos los campos", "OK");
        }
        else
        {
            if (BindingContext is Models.Note note)
            {
                File.WriteAllText(note.Filename1,
                    char.ToUpper(txtNombre.Text[0]) + txtNombre.Text.Substring(1) + "%" +
                    txtSexo.Text + "%" +
                    txtEdad.Text + "%" +
                    txtRaza.Text + "%" +
                    txtTamano.Text + "%" +
                    txtDescripcion.Text + "% "
                    );
            }
            await Shell.Current.GoToAsync("..");
        }
    }*/

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            // Delete the file.
            if (File.Exists(note.Filename1))
                File.Delete(note.Filename1);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void cargarMascota(int id)
    {
        Models.Note noteModel = new Models.Note();
        noteModel.Filename1 = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            string[] atributos = Clasificar(File.ReadAllText(fileName));
            noteModel.Nombre = atributos[0];
            noteModel.Sexo = atributos[1];
            noteModel.Edad = atributos[2];
            noteModel.Raza = atributos[3];
            noteModel.Tamano = atributos[4];
            noteModel.Descripcion = atributos[5];
            noteModel.Imagen = atributos[6];
        }

        BindingContext = noteModel;
    }

    private string[] Clasificar(string completa)
    {
        string[] atributos = new string[7];
        int contador = 0;
        string atributo = "";

        for (int i = 0; i < completa.Length; i++)
        {
            if (completa[i].Equals('%'))
            {
                atributos[contador] = atributo;
                contador++;
                i++;
                atributo = "";
            }
            atributo += completa[i].ToString();
        }

        return atributos;
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

        if (string.IsNullOrEmpty(txtNombre.Text) ||
            string.IsNullOrEmpty(txtSexo.Text) ||
            string.IsNullOrEmpty(txtEdad.Text) ||
            string.IsNullOrEmpty(txtRaza.Text) ||
            string.IsNullOrEmpty(txtTamano.Text) ||
            string.IsNullOrEmpty(txtDescripcion.Text)
            )
        {
            await DisplayAlert("Alerta", "Porfavor complete todos los campos", "OK");
        }
        else
        {
            if (BindingContext is Models.Note note)
            {
                File.WriteAllText(note.Filename1,
                    char.ToUpper(txtNombre.Text[0]) + txtNombre.Text.Substring(1) + "%" +
                    txtSexo.Text + "%" +
                    txtEdad.Text + "%" +
                    txtRaza.Text + "%" +
                    txtTamano.Text + "%" +
                    txtDescripcion.Text + "%" +
                    stream
                    );
            }
            await Shell.Current.GoToAsync("..");
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
            Item.Tamano = txtNombre.Text;
            int error = App.Repositorio.AddNewBurger(Item);
            if (error == 404)
            {
                await DisplayAlert("Alerta", "La hamburguesa no se pudo ingresar debido a que su nombre ya existe", "OK");
            }
            else
            {
                await Shell.Current.GoToAsync("..");
            }
        }
        else
        {
            App.Repositorio.actualizarBurger(aux.IdJM, aux.NombreJM, aux.DescripcionJM, aux.ConQuesoExtraJM);
            await Shell.Current.GoToAsync("..");
        }
    }
}



private void OnCancelClicked(object sender, EventArgs e)
{
    Shell.Current.GoToAsync("..");
}

private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
{
    _flag = e.Value;
}

private void cargarBurger(int id)
{
    Models.BurgerJM burgerBuscada = new Models.BurgerJM();
    burgerBuscada = App.Repositorio.GetById(id);
    aux = burgerBuscada;
    BindingContext = burgerBuscada;
}

private async void eliminarBurgerBDD(object sender, EventArgs e)
{
    App.Repositorio.eliminarBurger(aux.IdJM);
    await Shell.Current.GoToAsync("..");
}