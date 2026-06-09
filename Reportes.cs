using ProyectoTorneo;
using System.Data;

public static class Reportes
{
    public static void MostrarReporteGeneral()
    {
        Console.Clear();
        Console.WriteLine("\nREPORTE GENERAL DE JUGADORES");
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
            foreach (string codigo in jugador.Torneos)
            {
                Torneo? torneo = Datos.Torneos.Find(t => t.Codigo == codigo);

                if (torneo != null)
                {
                    Console.WriteLine($"{torneo.Codigo} - {torneo.Nombre}");
                }
            }
            
            Console.WriteLine("\nResultados: ");
            
            for (int i = 0;i < jugador.Torneos.Count; i++)
            {
                Torneo? torneo = Datos.Torneos.Find(t => t.Codigo == jugador.Torneos[i]);
                string descripcion = jugador.Resultados[i] == 1 ? "Participo" : "Gano     ";
                
                Console.WriteLine($"{descripcion}:  {torneo!.Nombre}");
            }
            Console.WriteLine("\nCalculos:");

            Console.WriteLine($"Subtotal ========== $ {jugador.Subtotal:F2}");
            Console.WriteLine($"Descuento ========= {jugador.Descuento}%");
            Console.WriteLine($"Total Final ======= $ {jugador.TotalFinal}");
            Console.WriteLine($"Clasificacion ===== {jugador.Clasificacion}");
            Console.WriteLine($"Puntos Obtenidos == {jugador.Puntos}");
            Console.WriteLine("====================================");
            contador++;
        }

        Console.WriteLine($"\nTotal de jugadores registrados {Datos.Jugadores.Count}");
        
    }
}
