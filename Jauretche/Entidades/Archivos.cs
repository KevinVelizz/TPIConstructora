using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace Entidades
{
    public sealed class Archivos
    {
        private static string pathObreros = Path.Combine(Archivos.TryGetSolutionDirectoryInfo().Parent.FullName, @"listaObreros.xml");

        public static DirectoryInfo? TryGetSolutionDirectoryInfo(string currentPath = null)
        {
            DirectoryInfo? directory = new DirectoryInfo(currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("Program.cs").Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }

        public static void SerealizarDatos<T>(List<Obrero> lista)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(pathObreros, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer((typeof(List<Obrero>)));
                    ser.Serialize(writer, lista);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR:{ex.Message} - {ex.StackTrace}");
            }
        }


        public static List<Obrero> DeserealizarAeronaves()
        {
            List<Obrero> listXML = new List<Obrero>();
            try
            {
                using (XmlTextReader sr = new XmlTextReader(Archivos.pathObreros))
                {
                    XmlSerializer serializer = new XmlSerializer((typeof(List<Obrero>)));
                    listXML = serializer.Deserialize(sr) as List<Obrero> ?? new();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message} - {ex.StackTrace}");
            }
            return listXML;
        }
    }
}
