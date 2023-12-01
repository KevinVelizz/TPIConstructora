using System.Text;
namespace Entidades
{
    public class Empresa
    {
        private List<Obra> obrasEnProceso;
        private List<Obra> obrasFinalizadas;
        private List<Obrero> obreros;
        private List<Grupo> gruposDeObreros;

        public Empresa()
        {
            this.Obreros = new List<Obrero>();
            this.ObrasEnProceso = new List<Obra>();
            this.ObrasFinalizadas = new List<Obra>();
            this.gruposDeObreros = new List<Grupo>();
        }

        public List<Grupo> GruposDeObreros
        {
            get { return this.gruposDeObreros; }
            set { this.gruposDeObreros = value; }
        }
        public List<Obra> ObrasEnProceso { get => obrasEnProceso; set => obrasEnProceso = value; }
        public List<Obra> ObrasFinalizadas { get => obrasFinalizadas; set => obrasFinalizadas = value; }
        public List<Obrero> Obreros { get => obreros; set => obreros = value; }

        public bool ContratarObrero(Obrero obrero)
        {
            Grupo grupo = ObtenerGrupoDisponible(obrero);
            bool retorno = false;

            if (grupo != null)
            {
                grupo.Obreros.Add(obrero);
                Obreros.Add(obrero);
                retorno = true;
            }
            return retorno;
        }

        public bool EliminarObrero(Obrero obrero)
        {
            foreach(Obrero obreroLista in this.Obreros)
            {
                if (obreroLista == obrero)
                {
                    foreach(Grupo grupo in this.gruposDeObreros)
                    {
                        if (grupo.Obreros.Contains(obrero))
                        {
                            grupo.eliminarObreroGrupo(obrero);
                            this.Obreros.Remove(obrero);
                            return true;
                        }    
                    }
                }
            }
            return false;
        }

        private Grupo ObtenerGrupoDisponible(Obrero obrero)
        {
            foreach (Grupo grupo in this.gruposDeObreros)
            {
                if(grupo.Obreros.Count > 0)
                {
                    foreach (Obrero obreroEmpresa in grupo.Obreros)
                    {
                        if (obreroEmpresa == obrero)
                        {
                            return null;
                        }
                        else if (grupo.Obreros.Count < 3)
                        {
                            if(obrero is JefeDeObra)
                            {
                                if(!grupo.Obreros.OfType<JefeDeObra>().Any())
                                {
                                    return grupo;
                                }
                                continue;
                            }
                            return grupo;
                        }
                    }
                }
                else
                {
                    return grupo;
                }
            }
            return null;
        }

        public bool AgregarObra(Obra obra)
        {
            bool retorno = false;
            if (obra.Estado != 100)
            {
                this.ObrasEnProceso.Add(obra);
                retorno = true;
            }
            return retorno;
        }

        public string ListarObreros()
        {
            StringBuilder mensaje = new StringBuilder();


            if(this.obreros.Count > 0)
            {
                foreach (Obrero obrero in this.Obreros)
                {
                    mensaje.AppendLine(obrero.ToString());
                }
            }
            else
            {
                mensaje.AppendLine("-----------------------------");
                mensaje.AppendLine("No hay obreros en la empresa.");
                mensaje.AppendLine("-----------------------------");
            }
            return mensaje.ToString();
        }

        public string ListarObrasEjecucionAvanceMasMitad()
        {

            StringBuilder mensaje = new StringBuilder();
            List<Obra> obraMasCincuenta = new List<Obra>();
            if(this.obrasEnProceso.Count > 0)
            {
                foreach (Obra obra in this.ObrasEnProceso)
                {
                    if (obra.Estado > 50)
                    {
                        obraMasCincuenta.Add(obra);
                    }
                }
                if(obraMasCincuenta.Count > 0)
                { 
                    foreach(Obra obra2 in obraMasCincuenta)
                    {
                        mensaje.AppendLine("---------------");
                        mensaje.AppendLine($"{obra2.Estado}");
                        mensaje.AppendLine("---------------");
                    }
                }
                else
                {
                    mensaje.AppendLine("-----------------------------------------");
                    mensaje.AppendLine("No hay obras en ejecución con mas del 50%");
                    mensaje.AppendLine("-----------------------------------------");
                }
            }
            else
            {
                mensaje.AppendLine("---------------------------");
                mensaje.AppendLine("No hay obras en ejecución.");
                mensaje.AppendLine("----------------------------");
            }
            
            return mensaje.ToString();
        }

        public string ListarObrasFinalizadas()
        {
            StringBuilder mensaje = new StringBuilder();
            if (this.ObrasFinalizadas.Count > 0)
            {
                mensaje.AppendLine("-- Obras finalizadas --");
                foreach (Obra obra in this.ObrasFinalizadas)
                {
                    mensaje.AppendLine("----------------");
                    mensaje.AppendLine(obra.ToString());
                    mensaje.AppendLine("----------------");
                }
            }
            else
            {
                mensaje.AppendLine("------------------------");
                mensaje.AppendLine("No hay obras finalizadas");
                mensaje.AppendLine("------------------------");
            }
            return mensaje.ToString();
        }

        public string ListarJefesDeObras()
        {
            StringBuilder mensaje = new StringBuilder();
            int contador = 1;

            List<JefeDeObra> jefesDeObra = new List<JefeDeObra>();

            foreach(Obrero obrero in this.obreros)
            {
                if(obrero is JefeDeObra)
                {
                    jefesDeObra.Add((JefeDeObra)obrero);
                }
            }
            if(jefesDeObra.Count > 0)
            {
                foreach (JefeDeObra jefe in jefesDeObra)
                {
                    mensaje.Append(contador.ToString() + ": ");
                    mensaje.AppendLine(jefe.ToString());
                }
                
            }
            else
            {
                mensaje.AppendLine("------------------------------------");
                mensaje.AppendLine("No hay jefes de obra en la empresa.");
                mensaje.AppendLine("------------------------------------");
            }
            return mensaje.ToString();
        }

        public bool EliminarJefeDeObra(JefeDeObra jefeDeObra)
        {
            if(this.obrasEnProceso.Count > 0)
            {
                foreach(Obra obra in this.ObrasEnProceso)
                {
                    if(obra.JefeDeObra == jefeDeObra)
                    {
                        foreach(Grupo grupo in this.gruposDeObreros)
                        {
                            if(obra.CodInterno == grupo.CodigoObra)
                            {
                                grupo.CodigoObra = "0";
                                grupo.eliminarObreroGrupo(jefeDeObra);
                                this.obrasEnProceso.Remove(obra);
                                this.obreros.Remove(jefeDeObra);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

       /* public void ImprimirCiudadesMasDe5Recursivo(List<string> ciudades, int indice)
        {
            if (indice < ciudades.Count)
            {
                if (ciudades[indice].Length > 5)
                {
                    Console.WriteLine(ciudades[indice]);
                }
                ImprimirCiudadesMasDe5Recursivo(ciudades, indice + 1);
            }
        }*/
        public bool EliminarObraTerminada(double estado, Obra obra)
        {
            bool retorno = false;
            obra.ModificarEstado(estado);
            if(obra.Estado == 100)
            {
                this.obrasEnProceso.Remove(obra);
                this.obrasFinalizadas.Add(obra);
                retorno = true;
            }
            return retorno;
        }
    }
}
