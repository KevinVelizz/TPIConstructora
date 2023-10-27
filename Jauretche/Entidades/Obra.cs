

using System.Text;

namespace Entidades
{
    public class Obra
    {
        private string nombrePropietario;
        private int dni;
        private string codInterno;
        private string tipo;
        private int dias;
        private double estado;
        private JefeDeObra jefeDeObra;
        private double costo;

        public Obra(string nombrePropietario,int dni, string codInterno, string tipo, int dias, JefeDeObra obrero, double costo)
        {   
            this.nombrePropietario = nombrePropietario;
            this.dni = dni;
            this.codInterno = codInterno;
            this.tipo = tipo;
            this.dias = dias;
            this.estado = 0;
            this.JefeDeObra = obrero;
            this.costo = costo;
        }
        
        public string CodInterno
        {
            get { return this.codInterno; }
            set { this.codInterno = value; }
        }

        public string Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

        public int Dias
        {
            get { return this.dias; }
            set { this.dias = value; }
        }

        public double Estado
        { 
            get { return this.estado; } 
            set { this.estado = value; }
        }

        public double Costo
        {
            get { return this.costo; }
            set { this.costo = value; }
        }
        public JefeDeObra JefeDeObra 
        {
            get { return this.jefeDeObra; }
            set { this.jefeDeObra = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Codigo Interno: {this.CodInterno}");
            sb.AppendLine($"Tipo: {this.Tipo}");
            sb.AppendLine($"Dias: {this.Dias}");
            sb.AppendLine($"Estado: {this.Estado}%");
            sb.AppendLine($"Costo: {this.Costo}");
            sb.AppendLine(JefeDeObra.ToString());
            return sb.ToString();
        }
    }
}