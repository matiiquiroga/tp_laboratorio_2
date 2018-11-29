using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";

                using (StreamWriter file = new StreamWriter(path + archivo, false))
                {
                    file.Write(datos);
                }

                return true;
            }
            catch (ArchivosException e)
            {
                throw new ArchivosException(e);
            }
        }

        public bool Leer(string archivo, out string datos)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";

                using (StreamReader file = new StreamReader(archivo + path))
                {
                    datos = file.ReadToEnd();
                }

                return true;
            }
            catch (ArchivosException e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
