
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
            this.obreros = new List<Obrero>();
            this.obrasEnProceso = new List<Obra>();
            this.obrasFinalizadas = new List<Obra>();
            this.gruposDeObreros = new List<Grupo>();
        }

        public List<Grupo> GruposDeObreros
        {
            get { return this.gruposDeObreros; }
            set { this.gruposDeObreros = value; }
        }

        public bool ContratarObrero(Obrero obrero)
        {
            Grupo grupo = ObtenerGrupoDisponible();
            bool retorno = false;

            if (grupo != null)
            {
                if (this.obreros.Count > 0)
                {
                    foreach (Obrero obreroLista in this.obreros)
                    {
                        if (obreroLista != obrero)
                        {
                            grupo.Obreros.Add(obrero);
                            obreros.Add(obrero);
                            retorno = true;
                            break;
                        }
                    }
                }
                else
                {
                    grupo.Obreros.Add(obrero);
                    obreros.Add(obrero);
                    retorno = true;
                }
                
               
            }
            return retorno;
        }

        public bool EliminarObrero(Obrero obrero)
        {
            bool retorno = false;   
            foreach(Obrero obreroLista in this.obreros)
            {
                if (obreroLista == obrero)
                {
                    this.obreros.Remove(obrero);
                    retorno = true;
                    break;
                }
                
            }
            return retorno;
        }

        private Grupo ObtenerGrupoDisponible()
        {
            foreach (Grupo grupo in gruposDeObreros)
            {
                if (grupo.Obreros.Count < 3)
                {
                    return grupo;
                }
            }
            return null;
        }

        public string ListarObreros()
        {
            StringBuilder mensaje = new StringBuilder();

            foreach (Obrero obrero in this.obreros)
            {
                mensaje.AppendLine(obrero.ToString());
            }
            return mensaje.ToString();
        }
    }
}
