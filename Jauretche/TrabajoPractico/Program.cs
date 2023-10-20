using Entidades;

internal class Program
{

    private static void Main(string[] args)
    {
        /*int opcion;
        do
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Agregar obrero.");
            Console.WriteLine("2. Eliminar obrero.");
            Console.WriteLine("3. SubMenú.");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        
                        // Coloca aquí el código para la Opción 1
                        break;
                    case 2:
                        // Coloca aquí el código para la Opción 2
                        break;
                    case 3:
                        do
                        {
                            switch(opcion)
                            {
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;

                            }

                        } while (true);
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Seleccione una opción válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, Ingrese un número válido.");
            }
            Console.WriteLine(); 
        } while (opcion != 4);
        */

        Empresa empresa = new Empresa();
        Obrero obrero = new Obrero("kevin", "veliz", 43898582, 24, 24000, "albañil");
        Obrero obrero2 = new Obrero("Elias", "veliz", 43898583, 53, 7532, "albañil");
        Obrero obrero3 = new Obrero("PEPE", "veliz", 43898583, 53, 7532, "Electricista");
        Obrero obrero4 = new Obrero("RAUL", "veliz", 66363635, 53, 7532, "Electricista");
        List<Obrero> obreros = new List<Obrero>();

        Grupo grupo = new Grupo(1,obreros);
        empresa.GruposDeObreros.Add(grupo);

        if (empresa.ContratarObrero(obrero))
        {
            Console.WriteLine("Se agregó correctamente");
        }
        else
        {
            Console.WriteLine("No se agregó porque ya está o el grupo está lleno.");
        }

        if (empresa.EliminarObrero(obrero))
        {
            Console.WriteLine("Se eliminó correctamente");
        }
        else
        {
            Console.WriteLine("No se agregó porque ya está o el grupo está lleno.");
        }

        if (empresa.ContratarObrero(obrero3))
        {
            Console.WriteLine("Se agregó correctamente");
        }
        else
        {
            Console.WriteLine("No se agregó porque ya está o el grupo está lleno.");
        }

        if (empresa.ContratarObrero(obrero4))
        {
            Console.WriteLine("Se agregó correctamente");
        }
        else
        {
            Console.WriteLine("No se agregó porque ya está o el grupo está lleno.");
        }

        Console.WriteLine(empresa.ListarObreros());

        Console.ReadKey();
    }
}