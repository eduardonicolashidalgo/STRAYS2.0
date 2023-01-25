namespace STRAYS.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class InfoRegistroPage : ContentPage
{
    public string ItemId
    {
        set { LoadNote(value); }
    }

    public InfoRegistroPage()
	{
		InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        appDataPath = Path.Combine(appDataPath, "INFO");
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    private void GoToPaePage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(PaePage));
    }

    private void GoToInfoPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(InfoPage));
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTitulo.Text) ||
            string.IsNullOrEmpty(txtSexo.Text) ||
            string.IsNullOrEmpty(txtRaza.Text) ||
            string.IsNullOrEmpty(txtUbicacion.Text) ||
            string.IsNullOrEmpty(txtDescripcion.Text)
            )
        {
            await DisplayAlert("Alerta", "Porfavor complete todos los campos", "OK");
        }
        else
        {
            if (BindingContext is Models.Note2 note)
            {
                File.WriteAllText(note.Filename1,
                    char.ToUpper(txtTitulo.Text[0]) + txtTitulo.Text.Substring(1) + "%" +
                    txtSexo.Text + "%" +
                    txtRaza.Text + "%" +
                    txtUbicacion.Text + "%" +
                    txtDescripcion.Text + "% "
                    );
            }
            await Shell.Current.GoToAsync("..");
        }
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note2 note)
        {
            // Delete the file.
            if (File.Exists(note.Filename1))
                File.Delete(note.Filename1);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadNote(string fileName)
    {
        Models.Note2 noteModel = new Models.Note2();
        noteModel.Filename1 = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            string[] atributos = Clasificar(File.ReadAllText(fileName));
            noteModel.Titulo = atributos[0];
            noteModel.Sexo = atributos[1];
            noteModel.Raza = atributos[2];
            noteModel.Ubicacion = atributos[3];
            noteModel.Descripcion = atributos[4];
            noteModel.Imagen = atributos[5];
        }

        BindingContext = noteModel;
    }

    private string[] Clasificar(string completa)
    {
        string[] atributos = new string[6];
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

        if (result == null)
        {
            return;
        }

        var stream = result.FullPath;

        if (string.IsNullOrEmpty(txtTitulo.Text) ||
            string.IsNullOrEmpty(txtSexo.Text) ||
            string.IsNullOrEmpty(txtRaza.Text) ||
            string.IsNullOrEmpty(txtUbicacion.Text) ||
            string.IsNullOrEmpty(txtDescripcion.Text)
            )
        {
            await DisplayAlert("Alerta", "Porfavor complete todos los campos", "OK");
        }
        else
        {
            if (BindingContext is Models.Note2 note)
            {
                File.WriteAllText(note.Filename1,
                    char.ToUpper(txtTitulo.Text[0]) + txtTitulo.Text.Substring(1) + "%" +
                    txtSexo.Text + "%" +
                    txtRaza.Text + "%" +
                    txtUbicacion.Text + "%" +
                    txtDescripcion.Text + "% " +
                    stream
                    );
            }
            await Shell.Current.GoToAsync("..");
        }
    }
}