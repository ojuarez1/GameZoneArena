using System.Xml.Serialization;
using ProyectoTorneo;

/// Almacena la información global utilizada por el sistema, incluyendo los jugadores registrados, 
/// los apodos utilizados y los torneos disponibles.

public class Datos
{
    public static List<Jugador> Jugadores = new(); // Lista que contiene todos los jugadores registrados.

    public static List<string> ApodosExistentes = new(); // Almacena los nicknames utilizados para evitar duplicados.

// Catálogo de torneos disponibles en el sistema.

public static List<Torneo> Torneos = new List<Torneo>
{
    new Torneo {Codigo = "T01", Nombre = "FIFA 26"},
    new Torneo {Codigo = "T02", Nombre = "Call of Duty"},
    new Torneo {Codigo = "T03", Nombre = "League of Legends"},
    new Torneo {Codigo = "T04", Nombre = "Fortnite"},
    new Torneo {Codigo = "T05", Nombre = "Valorant"}
};
}