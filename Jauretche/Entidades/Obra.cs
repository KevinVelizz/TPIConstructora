

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

        public Obra(string nombrePropietario,int dni, string codInterno, string tipo, int dias, double costo)
        {   
            this.nombrePropietario = nombrePropietario;
            this.dni = dni;
            this.codInterno = codInterno;
            this.tipo = tipo;
            this.dias = dias;
            this.estado = 0;
            this.costo = costo;
        }
        
        public string CodInterno
        {
            get { return this.codInterno; }
        }

        public string Tipo
        {
            get { return this.tipo; }
        }

        public int Dias
        {
            get { return this.dias; }
        }

        public double Estado
        { 
            get { return this.estado; } 
        }

        public double Costo
        {
            get { return this.costo; }
        }
        public JefeDeObra JefeDeObra 
        {
            get { return this.jefeDeObra; }
        }

        public Empresa Empresa
        {
            get => default;
            set
            {
            }
        }

        public bool AsignarJefeDeObra(JefeDeObra jefe)
        {
            bool retorno = false;   
            if(this.jefeDeObra is null)
            {
                this.jefeDeObra = jefe;
                retorno = true;
            }
            return retorno;
        }

        public void EliminarJefeDeObra()
        {
            this.jefeDeObra = null;
        }

        public void ModificarEstado(double estado)
        {
            this.estado = estado; 
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Codigo Interno: {this.CodInterno}");
            sb.AppendLine($"Tipo: {this.Tipo}");
            sb.AppendLine($"Dias: {this.Dias}");
            sb.AppendLine($"Estado: {this.Estado}%");
            sb.AppendLine($"Costo: {this.Costo}");
            sb.AppendLine("--Jefe de Obra de la obra--");
            sb.AppendLine(JefeDeObra.ToString());
            return sb.ToString();
        }
    }
}