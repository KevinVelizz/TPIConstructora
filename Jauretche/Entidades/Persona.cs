
using System.Text;

namespace Entidades
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private int dni;

        public Persona(string nombre,string apellido, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
        }

        public string Nombre { get => nombre; }
        public string Apellido { get => apellido;}
        public int Dni { get => dni; }

        protected virtual string Mostrar()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine($"Nombre: {this.nombre}");
            mensaje.AppendLine($"Apellido: {this.apellido}");
            mensaje.Append($"DNI: {this.dni}");
            return mensaje.ToString();
        }
    }
}
