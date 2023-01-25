using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRAYS.Models
{
    internal class AllNotes
    {
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

        public AllNotes() =>
            LoadNotes();

        public void LoadNotes()
        {
            Notes.Clear();


            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;
            appDataPath = Path.Combine(appDataPath, "PAE");

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Note> notes = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.notes.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new Note()
                                        {

                                            Filename1 = filename,
                                            Date = File.GetCreationTime(filename),
                                            Nombre = GetNombre(File.ReadAllText(filename)),
                                            Sexo = GetSexo(File.ReadAllText(filename)),
                                            Edad = GetEdad(File.ReadAllText(filename)),
                                            Raza = GetRaza(File.ReadAllText(filename)),
                                            Tamano = GetTamano(File.ReadAllText(filename)),
                                            Descripcion = GetDescripcion(File.ReadAllText(filename)),
                                            Imagen = GetImagen(File.ReadAllText(filename))
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(note => note.Date);

            // Add each note into the ObservableCollection
            foreach (Note note in notes)
                Notes.Add(note);
        }

        private string GetNombre(string completa)
        {
            string atributo = "";
            int contador = 0;

            for (int i = 0; i < completa.Length; i++)
            {
                if (completa[i].Equals('%'))
                {
                    contador++;
                    i++;
                }

                if (contador == 0)
                {
                    atributo += completa[i].ToString();
                }

                if (contador > 0)
                {
                    break;
                }
            }

            return atributo;
        }

        private string GetSexo(string completa)
        {
            string atributo = "";
            int contador = 0;

            for (int i = 0; i < completa.Length; i++)
            {
                if (completa[i].Equals('%'))
                {
                    contador++;
                    i++;
                }
                
                if(contador==1)
                {
                    atributo += completa[i].ToString();
                }

                if (contador > 1)
                {
                    break;
                }
            }

            return atributo;
        }

        private string GetEdad(string completa)
        {
            string atributo = "";
            int contador = 0;

            for (int i = 0; i < completa.Length; i++)
            {
                if (completa[i].Equals('%'))
                {
                    contador++;
                    i++;
                }

                if (contador == 2)
                {
                    atributo += completa[i].ToString();
                }

                if (contador > 2)
                {
                    break;
                }
            }

            return atributo;
        }

        private string GetRaza(string completa)
        {
            string atributo = "";
            int contador = 0;

            for (int i = 0; i < completa.Length; i++)
            {
                if (completa[i].Equals('%'))
                {
                    contador++;
                    i++;
                }

                if (contador == 3)
                {
                    atributo += completa[i].ToString();
                }

                if (contador > 3)
                {
                    break;
                }
            }

            return atributo;
        }

        private string GetTamano(string completa)
        {
            string atributo = "";
            int contador = 0;

            for (int i = 0; i < completa.Length; i++)
            {
                if (completa[i].Equals('%'))
                {
                    contador++;
                    i++;
                }

                if (contador == 4)
                {
                    atributo += completa[i].ToString();
                }

                if (contador > 4)
                {
                    break;
                }
            }

            return atributo;
        }

        private string GetDescripcion(string completa)
        {
            string atributo = "";
            int contador = 0;

            for (int i = 0; i < completa.Length; i++)
            {
                if (completa[i].Equals('%'))
                {
                    contador++;
                    i++;
                }

                if (contador == 5)
                {
                    atributo += completa[i].ToString();
                }

                if (contador > 5)
                {
                    break;
                }
            }

            return atributo;
        }

        private string GetImagen(string completa)
        {
            string atributo = "";
            int contador = 0;

            for (int i = 0; i < completa.Length; i++)
            {
                if (completa[i].Equals('%'))
                {
                    contador++;
                    i++;
                }

                if (contador == 6)
                {
                    atributo += completa[i].ToString();
                }

                if (contador > 6)
                {
                    break;
                }
            }

            return atributo;
        }
    }
}
