using Entidades;

internal class Program
{

    private static void Main(string[] args)
    {
        Funcionalidades.empresa = new Empresa();
        Grupo grupo = new("0");
        Funcionalidades.empresa.GruposDeObreros.Add(grupo);
        int opcion;
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
                        Funcionalidades.AgregarObrero();
                        break;
                    case 2:
                        Funcionalidades.BorrarObrero();
                        break;
                    case 3:
                        do
                        {
                            Console.WriteLine("Menú de opciones:");
                            Console.WriteLine("1. Listado de obreros.");
                            Console.WriteLine("2. Listado de obras en ejecución.");
                            Console.WriteLine("3. Listado de Jefes de Obras.");
                            Console.WriteLine("5. Salir");
                            Console.Write("Seleccione una opción: ");
                            if (int.TryParse(Console.ReadLine(), out opcion))
                            {
                                switch (opcion)
                                {
                                    case 1:
                                        Console.WriteLine(Funcionalidades.empresa.ListarObreros());
                                        break;
                                    case 2:
                                        break;
                                    case 3:
                                        break;
                                    case 5:
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
                        } while (opcion != 5);
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
        } while (opcion != 4);
        /*

         Empresa empresa = new Empresa();
         Obrero obrero = new Obrero("kevin", "veliz", 43898582, 24, 24000, "albañil");
         Obrero obrero2 = new Obrero("Elias", "veliz", 43898583, 53, 7532, "albañil");
         Obrero obrero3 = new Obrero("PEPE", "veliz", 43898583, 53, 7532, "Electricista");
         Obrero obrero4 = new Obrero("RAUL", "veliz", 66363635, 53, 7532, "Electricista");
         List<Obrero> obreros = new List<Obrero>();
         JefeDeObra jefeDeObra = new JefeDeObra("PEDRO", "FERNANDEZ", 28958221, 09, 400000, "Jefe de Obra", 50000);
         Obra obra = new Obra("Raul", 25555555, "B11", "remodelación", 25, jefeDeObra, 1000000);
         Grupo grupo = new Grupo(obra.CodInterno);

         empresa.GruposDeObreros.Add(grupo);
         empresa.AgregarObra(obra);
         Console.WriteLine("Obras en proceso.");
         Console.WriteLine(empresa.ListarObrasEjecucionAvanceMasMitad());
         Console.WriteLine("Obras Finalizadas.");
         Console.WriteLine(empresa.ListarObrasFinalizadas());
         Console.WriteLine("Jefes de obras."); 
         Console.WriteLine(empresa.ListarJefesDeObras());

         empresa.ContratarObrero(obrero);
         empresa.ContratarObrero(obrero2);
         empresa.ContratarObrero(obrero3);
         empresa.ContratarObrero(obrero4);
         */
        /*
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
            Console.WriteLine("No se eliminó porque no se encuentra el obrero.");
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
        }*/
    }
}