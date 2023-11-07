namespace Entidades
{
    public class NoHayGrupoLibreException : Exception
    {
        public NoHayGrupoLibreException(string message) : base(message) 
        {
        }
    }
}
