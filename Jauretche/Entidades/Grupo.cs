

namespace Entidades
{
    public class Grupo
    {
        private double codigoObra;
        private List<Obrero> obreros;

        private Grupo()
        {
            this.obreros = new List<Obrero>();
            this.codigoObra = 0;
        }

        public Grupo(double codigoObre, List<Obrero> obreros) : this()
        {
            this.codigoObra = codigoObre;
            this.obreros = obreros;
        }
        
        public double CodigoObra
        {
            get { return this.codigoObra; }
            set { this.codigoObra = value; }
        }


        public List<Obrero> Obreros
        {
            get { return this.obreros; }
            set { this.obreros = value; }
        }

        public void agregarObreroGrupo(Obrero obrero)
        {
            this.obreros.Add(obrero);
        }

        public bool eliminarObreroGrupo(Obrero obrero)
        {
            bool retorno = false;

            foreach (Obrero obrero1 in this.obreros)
            {
                if (obrero1 == obrero)
                {
                    retorno = true;
                    this.obreros.Remove(obrero);
                    break;
                }
            }

            return retorno;
        }
    }
}
