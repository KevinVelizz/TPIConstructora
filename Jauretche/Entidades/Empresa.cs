
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
                        else if (grupo.Obreros.Count < 3 && !grupo.Obreros.OfType<JefeDeObra>().Any())
                        {
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

            foreach (Obrero obrero in this.Obreros)
            {
                mensaje.AppendLine(obrero.ToString());
            }
            return mensaje.ToString();
        }

        public string ListarObrasEjecucionAvanceMasMitad()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine("--Obras en procesos mas del 50%--");
            foreach(Obra obra in this.ObrasEnProceso)
            {
                if(obra.Estado > 50)
                {
                    mensaje.AppendLine(obra.ToString());
                }
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
                    mensaje.AppendLine(obra.ToString());
                }
            }
            else
            {
                mensaje.AppendLine("No hay obras finalizadas");
            }
            return mensaje.ToString();
        }

        public string ListarJefesDeObras()
        {
            StringBuilder mensaje = new StringBuilder();
            int contador = 1;

            foreach(Obrero obrero in this.obreros)
            {
                if(obrero is JefeDeObra)
                {
                    mensaje.Append(contador.ToString() + ": ");
                    mensaje.AppendLine(obrero.ToString());
                }
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
