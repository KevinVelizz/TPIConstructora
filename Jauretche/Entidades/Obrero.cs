
using System.Text;

namespace Entidades
{
    public class Obrero : Persona
    { 
        int nroLegajo;
        double sueldo;
        string cargo;


        public Obrero(string nombre, string apellido ,int dni,int nroLegajo, double sueldo, string cargo) : base(nombre, apellido, dni)
        {
            this.nroLegajo = nroLegajo;
            this.sueldo = sueldo;
            this.cargo = cargo;
        }

        public int NroLegajo 
        {
            get { return nroLegajo; }
            set { nroLegajo = value;}
        }

        public double Sueldo 
        { 
            get { return sueldo; }
            set { sueldo = value; }
        }

        public string Cargo 
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public static bool operator ==(Obrero obrero, Obrero obrero1)
        {
            return obrero.nroLegajo == obrero1.nroLegajo;
        }

        public static bool operator !=(Obrero obrero, Obrero obrero1)
        {
            return !(obrero == obrero1);
        }

        protected override string Mostrar()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine($"{base.Mostrar()}");
            mensaje.AppendLine($"Nro Legajo: {this.NroLegajo}");
            mensaje.AppendLine($"Sueldo: {this.sueldo}");
            mensaje.AppendLine($"Cargo: {this.cargo}");
            return mensaje.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

    }
}
