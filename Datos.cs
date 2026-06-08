using System.Xml.Serialization;
using ProyectoTorneo;
public class Datos
{
    public static List<Jugador> Jugadores = new();
    public static List<string> ApodosExistentes = new();

public static List<Torneo> Torneos = new List<Torneo>
{
    //new Torneo {Codigo = "Codigo", Nombre = "Nombre de torneo"},
    new Torneo {Codigo = "  T01", Nombre = "     FIFA 26"},
    new Torneo {Codigo = "  T02", Nombre = "     Call of Duty"},
    new Torneo {Codigo = "  T03", Nombre = "     League of Legends"},
    new Torneo {Codigo = "  T04", Nombre = "     Fortnite"},
    new Torneo {Codigo = "  T05", Nombre = "     Valorant"}
};
}