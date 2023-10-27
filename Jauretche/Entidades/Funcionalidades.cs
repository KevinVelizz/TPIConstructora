
namespace Entidades
{
    public static class Funcionalidades
    {
        public static Empresa empresa;
        static Funcionalidades()
        {
          empresa = new Empresa();
        }

        public static void AgregarObrero()
        {
            Console.WriteLine("Ingresar nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingresar apellido: ");
            string apellido = Console.ReadLine();
            Console.WriteLine("Ingresar dni: ");
            int dni;
            do
            {
                Console.Write("Por favor, ingrese valores numéricos: ");
            } while (!int.TryParse(Console.ReadLine(), out dni));

            Console.WriteLine("Ingresar nroLegajo: ");
            int nroLegajo;
            do
            {
                Console.Write("Por favor, ingrese valores numéricos: ");
            } while (!int.TryParse(Console.ReadLine(), out nroLegajo));

            Console.WriteLine("Ingresar sueldo: ");
            double sueldo;
            do
            {
                Console.Write("Por favor, ingrese valores numéricos: ");
            } while (!double.TryParse(Console.ReadLine(), out sueldo));

            Console.WriteLine("Ingresar cargo: ");
            string cargo = Console.ReadLine();
            Obrero obrero = new Obrero(nombre, apellido, dni, nroLegajo, sueldo, cargo);
            if(empresa.ContratarObrero(obrero))
            {
                Console.WriteLine("Obrero agregado correctamente.");
            }
            else
            {
                Console.WriteLine("Error al agregar el obrero.");
            }
        }

        public static void BorrarObrero()
        {
            Console.WriteLine("Ingrese el numero de legajo: ");
            int nroLegajo;
            do
            {
                Console.Write("Por favor, ingrese valores numéricos: ");
            } while (!int.TryParse(Console.ReadLine(), out nroLegajo));
            Obrero obrero1 = new Obrero("kevin", "veliz", 43898582, 24, 24000, "albañil");

            foreach (Obrero obrero in empresa.Obreros)
            {
                if (obrero.NroLegajo == nroLegajo)
                {
                    obrero1 = obrero;
                    break;
                }
            }
           
            if(empresa.EliminarObrero(obrero1))
            {
                Console.WriteLine("Se eliminó correctamente.");
            }    
            else
            {
                Console.WriteLine("No se eliminó correctamente. Verificar legajo.");
            }
        }
    }
}
