
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
                Console.WriteLine("------------------------------");
                Console.WriteLine("Obrero agregado correctamente.");
                Console.WriteLine("------------------------------");
            }
            else
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Error al agregar el obrero. Ya existe o no hay grupo.");
                Console.WriteLine("-----------------------------------------------------");
            }
        }
        public static void BorrarObrero()
        {
            if(empresa.Obreros.Count > 0)
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

                if (empresa.EliminarObrero(obrero1))
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Se eliminó correctamente.");
                    Console.WriteLine("--------------------------");
                }
                else
                {
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("No se eliminó correctamente. Verificar legajo.");
                    Console.WriteLine("----------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("No hay obreros en la empresa.");
                Console.WriteLine("------------------------------");
            }
        }
        public static void AgregarUnaObra()
        {
            try
            {
                Console.WriteLine("--Crear un Jefe De Obra--");
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

                Console.WriteLine("Ingresar bonificación: ");
                double bonificacion;
                do
                {
                    Console.Write("Por favor, ingrese valores numéricos: ");
                } while (!double.TryParse(Console.ReadLine(), out bonificacion));

                JefeDeObra obrero = new JefeDeObra(nombre, apellido, dni, nroLegajo, sueldo, "Jefe de obra",bonificacion);

                if(empresa.ContratarObrero(obrero))
                {
                    Console.WriteLine("Agregado correctamente al grupo y a la empresa.");
                }
                else
                {
                    throw new NoHayGrupoLibreException("No hay grupos disponibles o el obrero ya está en la empresa.");
                }
                Console.WriteLine("--Crear Obra--");
                Console.WriteLine("Ingrese nombre del propietario: ");
                string nombrePropietario = Console.ReadLine();
                Console.WriteLine("Ingrese dni del propietario: ");
                int dniPropietario;
                do
                {
                    Console.Write("Por favor, ingrese valores numéricos: ");
                } while (!int.TryParse(Console.ReadLine(), out dniPropietario));

                Console.WriteLine("Ingrese el codigo interno: ");
                string codInterno = Console.ReadLine();

                Console.WriteLine("Ingrese el tipo: ");
                string tipo = Console.ReadLine();

                Console.WriteLine("Ingrese dias: ");
                int dias;
                do
                {
                    Console.Write("Por favor, ingrese valores numéricos: ");
                } while (!int.TryParse(Console.ReadLine(), out dias));

                Console.WriteLine("Ingrese costo: ");
                double costo;
                do
                {
                    Console.Write("Por favor, ingrese valores numéricos: ");
                } while (!double.TryParse(Console.ReadLine(), out costo));

                Obra obra = new Obra(nombrePropietario, dniPropietario, codInterno, tipo, dias, costo);
                obra.AsignarJefeDeObra(obrero);
                empresa.AgregarObra(obra);
                foreach(Grupo grupoEmpresa in empresa.GruposDeObreros)
                {
                    if(grupoEmpresa.Obreros.Contains(obrero))
                    {
                        grupoEmpresa.CodigoObra = obra.CodInterno;
                    }
                }
                Console.WriteLine("Agregador correctamente.");
            }
            catch (NoHayGrupoLibreException ex)
            {
                Console.WriteLine("Mensaje: " + ex.Message);
            }
        }

        public static void ModificarEstadoObra()
        {


            if(empresa.ObrasEnProceso.Count > 0)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Elegir obra a modificar estado");
                Console.WriteLine("------------------------------");

                int contador = 1;

                foreach (Obra obraProceso in empresa.ObrasEnProceso)
                {
                    Console.WriteLine(contador.ToString() + ":");
                    Console.WriteLine(obraProceso.ToString());
                    contador++;
                }

                int obraSeleccionada;
                do
                {
                    Console.Write("Por favor, ingrese un valor numérico y dentro del rango permitido: ");
                } while (!int.TryParse(Console.ReadLine(), out obraSeleccionada) || obraSeleccionada <= 0 || obraSeleccionada > empresa.ObrasEnProceso.Count);
                obraSeleccionada = obraSeleccionada - 1;
                Obra obra = empresa.ObrasEnProceso[obraSeleccionada];

                Console.WriteLine("-- Ingrese el estado de avance --");
                double estado;
                do
                {
                    Console.Write("Por favor, ingrese valores numéricos y un estado menor o igual a 100: ");
                } while (!double.TryParse(Console.ReadLine(), out estado) && estado <= 100);
                empresa.EliminarObraTerminada(estado, obra);
            }
            else
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("No hay obras en proceso.");
                Console.WriteLine("------------------------");

            }

        }

        public static void EliminarJefeDeObra()
        {
            Console.WriteLine(empresa.ListarJefesDeObras());
            List<JefeDeObra> jefesDeObras = new List<JefeDeObra>();
            int jefeDeObraSeleccionado;

            foreach(Obrero obreroEmpresa in empresa.Obreros)
            {
                if(obreroEmpresa is JefeDeObra)
                {
                    jefesDeObras.Add((JefeDeObra)obreroEmpresa);
                }
            }

            if(jefesDeObras.Count > 0)
            {
                Console.WriteLine("-- Seleccione el jefe de obra a eliminar --");
                do
                {
                    Console.Write("Por favor, ingrese un valor numérico y dentro del rango permitido: ");
                } while (!int.TryParse(Console.ReadLine(), out jefeDeObraSeleccionado) || jefeDeObraSeleccionado <= 0 || jefeDeObraSeleccionado > empresa.ObrasEnProceso.Count);

                JefeDeObra jefeDeObra = jefesDeObras[jefeDeObraSeleccionado - 1];

                foreach (Obrero obreroEmpresa in empresa.Obreros)
                {
                    if (obreroEmpresa.NroLegajo == jefeDeObraSeleccionado)
                    {
                        empresa.Obreros.Remove(obreroEmpresa);
                    }
                }

                if (empresa.EliminarJefeDeObra(jefeDeObra))
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Eliminado correctamente el jefe de obra.");
                    Console.WriteLine("----------------------------------------");
                }
                else
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("No se pudo eliminar el jefe de obra.");
                    Console.WriteLine("------------------------------------");
                }
            }
        }
    }
}
