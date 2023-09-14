
using TPIIntegrador.Aplicacion.Modelos;

namespace TPIIntegrador.Aplicacion.Servicios
{
    public class ServicioDatosPrueba : IServicioDatosPrueba
    {


        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public IEnumerable<TestearAPI> ObtenerValores()
        {

            return Enumerable.Range(1, 5).Select(index => new TestearAPI
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


    }
}