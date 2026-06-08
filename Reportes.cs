using ProyectoTorneo;
using System.Data;

public static class Reportes
{
    public static void MostrarReporteGeneral()
    {
        Console.Clear();
        Console.WriteLine("REPORTE GENERAL DE JUGADORES");
        if (Datos.Jugadores.Count == 0)
        {
            Console.WriteLine("\nNo existen jugadores registrados");
            return;           
        }

        int contador = 1;
        foreach (Jugador jugador in Datos.Jugadores)
        {
            Console.WriteLine($"\nJUGADOR #{contador}");

            Console.WriteLine($"Nombre Completo: {jugador.NombreCompleto}!");
            Console.WriteLine($"Nickname: {jugador.Nickname}!");

            Console.WriteLine("\nTorneos Inscritos");

            foreach (string torneo in jugador.Torneos)
            {
                Console.WriteLine($"  - {torneo}");
            }
            
            Console.WriteLine("\nResultados: ");
            foreach (int resultado in jugador.Resultados)
            {
                string descripcion = resultado == 1 ? "Participo" : "Gano"; //Ternario
                Console.WriteLine($"- {descripcion}");       
            }
            Console.WriteLine("\nCalculos!");

            Console.WriteLine($"Subtotal ======= $ {jugador.Subtotal:F2}");
            Console.WriteLine($"Descuento ====== {jugador.Descuento}%");
            Console.WriteLine($"Total Final ==== $ {jugador.TotalFinal}");
            Console.WriteLine($"Clasificacion ==== {jugador.Clasificacion}");
            Console.WriteLine($"Puntos Obtenidos = {jugador.Puntos}");

            contador++;
        }

        Console.WriteLine($"\nTotal de jugadores registrados {Datos.Jugadores.Count}");
        
    }
}
