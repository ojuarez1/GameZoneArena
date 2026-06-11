using ProyectoTorneo;

// Representa a un jugador inscrito en el sistema de torneos.
// Almacena sus datos personales, torneos registrados,
// resultados obtenidos y estadísticas calculadas.

public class Jugador
{
    public string NombreCompleto {get ; set; } = ""; // Nombre completo del jugador.
    public string Nickname { get; set; } = ""; // Apodo único utilizado para identificar al jugador.
    public List<string> Torneos { get; set; } = new(); // Lista de códigos de los torneos en los que participa.
    public List<int> Resultados { get; set; } = new(); // Resultado obtenido en cada torneo: 1 = Participó o 2 = Ganó
    public double Subtotal { get; set; } // Suma de los costos de inscripción antes de aplicar descuentos.
    public double Descuento { get; set; } // Porcentaje de descuento aplicado según las reglas del torneo.
    public double TotalFinal { get; set; } // Monto final a pagar después de aplicar el descuento.
    public string Clasificacion { get; set; } = ""; // Categoría asignada al jugador según el monto final pagado.
    public int Puntos { get; set; } // Puntuación total acumulada por el jugador.
}