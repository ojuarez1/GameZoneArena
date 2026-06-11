using ProyectoTorneo;
using System.Data;

public static class Reportes
{
    // ============================================================================
    // Muestra un reporte detallado de todos los jugadores registrados,
    // incluyendo torneos inscritos, resultados obtenidos y cálculos finales.

    public static void MostrarReporteGeneral() // metodo caso 2
    {
        Console.Clear();
        Console.WriteLine("\nREPORTE GENERAL DE JUGADORES");

        // Verifica si existen jugadores registrados en el sistema.

        if (Datos.Jugadores.Count == 0)
        {
            Console.WriteLine("\nNo existen jugadores registrados");
            return;           
        }

        int contador = 1;

        // Recorre la lista de jugadores para mostrar su información.

        foreach (Jugador jugador in Datos.Jugadores)
        {
            Console.WriteLine($"\nJUGADOR #{contador}");

            Console.WriteLine($"Nombre Completo: {jugador.NombreCompleto}!");
            Console.WriteLine($"Nickname: {jugador.Nickname}!");

            Console.WriteLine("\nTorneos Inscritos"); // Muestra los torneos en los que el jugador está inscrito.


            foreach (string codigo in jugador.Torneos)
            {
                Torneo? torneo = Datos.Torneos.Find(t => t.Codigo == codigo);

                if (torneo != null)
                {
                    Console.WriteLine($"{torneo.Codigo} - {torneo.Nombre}");
                }
            }
            
            Console.WriteLine("\nResultados: "); // Muestra el resultado obtenido en cada torneo.
            
            for (int i = 0;i < jugador.Torneos.Count; i++)
            {
                Torneo? torneo = Datos.Torneos.Find(t => t.Codigo == jugador.Torneos[i]);
                string descripcion = jugador.Resultados[i] == 1 ? "Participo" : "Gano     ";
                
                Console.WriteLine($"{descripcion}:  {torneo!.Nombre}");
            }

            // Muestra los cálculos realizados para el jugador.

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
