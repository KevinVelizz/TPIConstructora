using System.Text;

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

        public double Bonificacion
        {
            get { return bonificacion; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Bonificación: {this.bonificacion}");
            return sb.ToString();
        }
    }
}
