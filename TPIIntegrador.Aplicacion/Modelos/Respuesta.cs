namespace TPIIntegrador.Aplicacion.Modelos
{
    public class Respuesta<T>
    {
        public bool estado { get; set; }
        public T valor { get; set; }
        public string mensaje { get; set; }
    }
}