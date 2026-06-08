using ProyectoTorneo;
public class Jugador
{
    public string NombreCompleto {get ; set; } = "";
    public string Nickname { get; set; } = "";
    public List<string> Torneos { get; set; } = new(); //Inicia una lista vacia de Torneos, get y set leer y modifi
    public List<int> Resultados { get; set; } = new(); //Almacena los resultados por jugador si gano o solo participo
    public double Subtotal { get; set; }
    public double Descuento { get; set; }
    public double TotalFinal { get; set; }
    public string Clasificacion { get; set; } = "";
    public int Puntos { get; set; }
}