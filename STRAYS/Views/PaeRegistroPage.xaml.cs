using Microsoft.Maui.Storage;

namespace STRAYS.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class PaeRegistroPage : ContentPage
{
    public string ItemId
    {
        set { LoadNote(value); }
    }

    public PaeRegistroPage()
	{
		InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        appDataPath = Path.Combine(appDataPath, "PAE");
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

	private void GoToPaePage(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync(nameof(PaePage));
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
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
    }

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

    private void LoadNote(string fileName)
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
}