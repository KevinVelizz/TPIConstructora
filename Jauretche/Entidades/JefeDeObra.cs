
namespace Entidades
{
    
    public class JefeDeObra : Obrero
    {
        private double bonificacion;

        public JefeDeObra(string nombre, string apellido, int dni, int nroLegajo, double sueldo, string cargo,double bonificacion)
            : base(nombre, apellido, dni, nroLegajo, sueldo, cargo)
        {
            this.bonificacion = bonificacion;
        }
    }
}
