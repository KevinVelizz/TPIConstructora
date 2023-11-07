using Entidades;
using System.Text.RegularExpressions;

internal class Program
{

    private static void Main(string[] args)
    {
        Funcionalidades.empresa = new Empresa();
        for(int i = 0; i < 2; i++)
        {
            Funcionalidades.empresa.GruposDeObreros.Add(new Grupo("0"));
        }
        
        int opcion;
        do
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Agregar obrero.");
            Console.WriteLine("2. Eliminar obrero.");
            Console.WriteLine("3. SubMenú.");
            Console.WriteLine("4. Agregar obra y jefe.");
            Console.WriteLine("5. Modificar el estado de avance.");
            Console.WriteLine("6. Dar de baja a un jefe.");
            Console.WriteLine("7. Salir.");
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
                            Console.WriteLine("4. Obras finalizadas.");
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
                                        Console.WriteLine(Funcionalidades.empresa.ListarObrasEjecucionAvanceMasMitad());
                                        break;
                                    case 3:
                                        Console.WriteLine(Funcionalidades.empresa.ListarJefesDeObras());
                                        break;
                                    case 4:
                                        Console.WriteLine(Funcionalidades.empresa.ListarObrasFinalizadas());
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
                        Funcionalidades.AgregarUnaObra();
                        break;
                    case 5:
                        Funcionalidades.ModificarEstadoObra();
                        break;
                    case 6:
                        Funcionalidades.EliminarJefeDeObra();
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
        } while (opcion != 7);
    }
}