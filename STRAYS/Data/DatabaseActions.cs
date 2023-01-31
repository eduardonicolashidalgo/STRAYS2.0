using STRAYS.Models;
using SQLite;

namespace STRAYS.Data
{
    public class DatabaseActions
    {
        string _dbPath;                                  //String que tendrá la conexión a la base de datos
        private SQLiteConnection conn;                   //Variable que tendrá la conexión

        public DatabaseActions(string DatabasePath)     //Constructor de la clase
        {
            _dbPath = DatabasePath;
        }

        private void Init()
        {
            if (conn != null)                            //Si la conexión ya existe, no se hace nada
                return;
            conn = new SQLiteConnection(_dbPath);        //Si no existe la conexión, la creamos
            conn.CreateTable<PaeModel>();                //Creamos la tabla Burger, si ya está creada entonces solo se actualiza
            conn.CreateTable<InfoModel>();
            conn.CreateTable<AlertaModel>();
        }
        //------------------------------------------------------ INSERTS ---------------------------------------------------------------------
        public int insertRegistroPae(PaeModel pae)         //Crea la conexión, inserta un objeto nuevo, regresa las filas afectadas
        {
            Init();
            try
            {
                int result = conn.Insert(pae);
                return result;
            }
            catch (Exception)
            {
                return 404;
            }
        }

        public int insertRegistroAlerta(AlertaModel alerta)         
        {
            Init();
            try
            {
                int result = conn.Insert(alerta);
                return result;
            }
            catch (Exception)
            {
                return 404;
            }
        }

        public int insertRegistroInfo(InfoModel info)        
        {
            Init();
            try
            {
                int result = conn.Insert(info);
                return result;
            }
            catch (Exception)
            {
                return 404;
            }
        }

        //------------------------------------------------------ SELECTS *  ---------------------------------------------------------------------
        public List<PaeModel> GetAllPaes()            //Crea la conexión, recupera una lista de todas las filas, regresa la lista
        {
            Init();
            List<PaeModel> paes = conn.Table<PaeModel>().ToList();
            return paes;
        }

        public List<AlertaModel> GetAllAlertas()            
        {
            Init();
            List<AlertaModel> alertas = conn.Table<AlertaModel>().ToList();
            return alertas;
        }

        public List<InfoModel> GetAllInfos()            
        {
            Init();
            List<InfoModel> info = conn.Table<InfoModel>().ToList();
            return info;
        }

        //------------------------------------------------------ BUSCADORES  ---------------------------------------------------------------------
        public List<PaeModel> GetPaesByName(string contiene)
        {
            Init();
            var mascota = from m in conn.Table<PaeModel>()
                         where m.Nombre.Contains(contiene)
                         select m;

            return mascota.ToList();
        }

        public List<AlertaModel> GetAlertasByRaza(string contiene)
        {
            Init();
            var mascota = from m in conn.Table<AlertaModel>()
                          where m.Raza.Contains(contiene)
                          select m;

            return mascota.ToList();
        }

        public List<InfoModel> GetInfosByRaza(string contiene)
        {
            Init();
            var mascota = from m in conn.Table<InfoModel>()
                          where m.Raza.Contains(contiene)
                          select m;

            return mascota.ToList();
        }

        //------------------------------------------------------ BUSCAR POR ID  ---------------------------------------------------------------------
        public PaeModel GetPaeById(int id)
        {
            Init();
            var burger = from b in conn.Table<PaeModel>()
                         where b.IdPae == id
                         select b;

            return burger.FirstOrDefault();
        }

        public AlertaModel GetAlertaById(int id)
        {
            Init();
            var burger = from b in conn.Table<AlertaModel>()
                         where b.IdAlerta == id
                         select b;

            return burger.FirstOrDefault();
        }

        public InfoModel GetInfoById(int id)
        {
            Init();
            var burger = from b in conn.Table<InfoModel>()
                         where b.IdInfo == id
                         select b;

            return burger.FirstOrDefault();
        }

        //------------------------------------------------------ ACTUALIZAR ---------------------------------------------------------------------
        public void actualizarPae(
            int id, 
            string nom, 
            string sexo, 
            int edad, 
            string raza,
            string tam,
            string des,
            string img)
        {
            Init();
            var actualizada = conn.Table<PaeModel>().Where(r => r.IdPae == id).FirstOrDefault();
            if (actualizada != null)
            {
                // Update the values
                actualizada.Nombre = nom;
                actualizada.Sexo = sexo;
                actualizada.Edad = edad;
                actualizada.Raza = raza;
                actualizada.Tamano = tam;
                actualizada.Descripcion = des;
                actualizada.Imagen = img;
                actualizada.Date = DateTime.Now;

                // Submit the changes to the database
                conn.Update(actualizada);
            }
        }

        public void actualizarAlerta(
            int id,
            string tit,
            string sexo,
            string raza,
            string ubi,
            string des,
            string img)
        {
            Init();
            var actualizada = conn.Table<AlertaModel>().Where(r => r.IdAlerta == id).FirstOrDefault();
            if (actualizada != null)
            {
                // Update the values
                actualizada.Titulo = tit;
                actualizada.Sexo = sexo;
                actualizada.Raza = raza;
                actualizada.Ubicacion = ubi;
                actualizada.Descripcion = des;
                actualizada.Imagen = img;
                actualizada.Date = DateTime.Now;

                // Submit the changes to the database
                conn.Update(actualizada);
            }
        }

        public void actualizarInfo(
            int id,
            string tit,
            string sexo,
            string raza,
            string ubi,
            string des,
            string img)
        {
            Init();
            var actualizada = conn.Table<InfoModel>().Where(r => r.IdInfo == id).FirstOrDefault();
            if (actualizada != null)
            {
                // Update the values
                actualizada.Titulo = tit;
                actualizada.Sexo = sexo;
                actualizada.Raza = raza;
                actualizada.Ubicacion = ubi;
                actualizada.Descripcion = des;
                actualizada.Imagen = img;
                actualizada.Date = DateTime.Now;

                // Submit the changes to the database
                conn.Update(actualizada);
            }
        }

        //------------------------------------------------------ ELIMINAR ---------------------------------------------------------------------
        public void eliminar(int id, string tabla)
        {
            switch(tabla)
            {
                case "pae":
                    var mascotaEliminada = conn.Table<PaeModel>().Where(r => r.IdPae == id).FirstOrDefault();
                    if (mascotaEliminada != null)
                    {
                        conn.Delete(mascotaEliminada);
                    }
                    break;
                case "alerta":
                    var mascotaEliminada2 = conn.Table<AlertaModel>().Where(r => r.IdAlerta == id).FirstOrDefault();
                    if (mascotaEliminada2 != null)
                    {
                        conn.Delete(mascotaEliminada2);
                    }
                    break;
                case "info":
                    var mascotaEliminada3 = conn.Table<InfoModel>().Where(r => r.IdInfo == id).FirstOrDefault();
                    if (mascotaEliminada3 != null)
                    {
                        conn.Delete(mascotaEliminada3);
                    }
                    break;
                default:
                    throw new Exception("Nombre de tabla inválido");
            }
            
        }

        /*public void purgarBurger()
        {
            conn.DeleteAll<BurgerJM>();
            conn.Execute("UPDATE sqlite_sequence SET seq = 0 WHERE name = 'burger'");
        }*/
    }
}

