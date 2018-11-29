using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class XML<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
                TextWriter file = new StreamWriter(path + archivo);
                XmlSerializer serializador = new XmlSerializer(typeof(T));

                serializador.Serialize(file, datos);
                file.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
                return false;
            }
        }

        public bool Leer(string archivo, out T datos)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = (T)serializer.Deserialize(sr);
                }
                return true;
            }
            catch (Exception a)
            {
                throw new ArchivosException(a);
            }
        }      
    }
}
