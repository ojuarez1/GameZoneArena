using ProyectoTorneo;
using System.Data;
using System.Runtime.Serialization.Formatters;

public static class Reportes
{
    // Muestra un reporte estadistico de todos los jugadores registrados,
    // incluyendo Promedios de torneos inscritos, resultados de cálculos finales.

    public static void MostrarReporteGeneral() // metodo caso 2
    {
        //Console.Clear();
        Console.WriteLine("\n========== REPORTE GENERAL DE JUGADORES ==========");
        
        //Total Jugadores Registrados
        Console.WriteLine($"\nTotal de Jugadores Realizados: {Datos.Jugadores.Count}");


        //SubTotal Recaudado Sin Descuentos
        double totalSinDescuento = 0;

        foreach (Jugador jugador in Datos.Jugadores)
        {
            totalSinDescuento += jugador.Subtotal;
        }

        Console.WriteLine($"\nTotal Recaudado Sin Descuento: {totalSinDescuento:F2}");


        //SubTotal Recaudado Con Descuentos
        double totalConDescuento = 0;
        foreach (Jugador jugador in Datos.Jugadores)
        {
            totalConDescuento += jugador.TotalFinal;
        }

        Console.WriteLine($"Total Recaudado Con Descuento: {totalConDescuento}");


        //SubTotal Recaudado Con Descuentos
        double sumaPagos = 0;
        foreach (Jugador jugador in Datos.Jugadores) //Recorre todos los jugadores y suma sis pagos finales
        {
            sumaPagos += jugador.TotalFinal;
        }

                                                    //Calcular el promedio
        double promedioPago = 0;
        if (Datos.Jugadores.Count > 0)
        {
            promedioPago = sumaPagos / Datos.Jugadores.Count;
        }

        Console.WriteLine($"\nPromedio de pagos por jugador: ${promedioPago:F2}");

        //Promedio de puntaje general
        int sumaPuntos = 0;
        foreach (Jugador jugador in Datos.Jugadores) //Recorre todos los jugadores y suma los puntos
        {
            sumaPuntos += jugador.Puntos;
        }
                                                        //Calcular Promedio
        int promedioPuntos = 0;
        if (Datos.Jugadores.Count > 0)
        {
            promedioPuntos = sumaPuntos / Datos.Jugadores.Count;
        }

        Console.WriteLine($"Promedo De Puntaje General: {promedioPuntos:F2}");

        //Cantidad de Jugadores VIP
        int cantidadVIP = 0;
        foreach(Jugador jugador in Datos.Jugadores)
        {
            if(jugador.Clasificacion == "VIP")
            {
                cantidadVIP++;
            }
            
        }
        Console.WriteLine($"\nCantidad e Jugadores VIP: {cantidadVIP}");

        //ESTADISTICAS

    //Jugador con mayor puntaje
    int mayorPuntaje = Datos.Jugadores[0].Puntos;

    foreach (Jugador jugador in Datos.Jugadores)
        {
            if(jugador.Puntos > mayorPuntaje)
            {
                mayorPuntaje = jugador.Puntos;
            }
        }

    Console.WriteLine("\n---------------- ESTADISTICAS ----------------");    
    //mostrar todos los jugadores con tengan los mismos puntos
    Console.WriteLine("\nJugador(es) con mayor puntaje: ");
    foreach(Jugador jugador in Datos.Jugadores)
        {
            if(jugador.Puntos == mayorPuntaje)
            {
                Console.WriteLine($"{jugador.NombreCompleto} - {jugador.Puntos} Puntos!");
            }
        }

    //Jugador con menor Puntaje
    int menorPuntaje = Datos.Jugadores[0].Puntos;
    foreach(Jugador jugador in Datos.Jugadores)
        {
            if(jugador.Puntos < menorPuntaje)
            {
                menorPuntaje = jugador.Puntos;
            }
        }
        //Mostrar todos los jugadores con el mismo puntaje
    Console.WriteLine("\nJugador(es) con Menor Puntaje: ");
    foreach(Jugador jugador in Datos.Jugadores)
        {
            if(jugador.Puntos == menorPuntaje)
            {
                Console.WriteLine($"{jugador.NombreCompleto} - {jugador.Puntos} Puntos!");
            }
        }
    //Torneos mas Seleccionador
    Dictionary<string, int> conteo = new Dictionary<string, int>();
    foreach(Jugador jugador in Datos.Jugadores)
        {
            foreach(string codigo in jugador.Torneos)
            {
                if (conteo.ContainsKey(codigo))
                {
                    conteo[codigo]++;
                }
                else
                {
                    conteo[codigo] = 1;
                }
            }
        }
    
    int mayorCantidad = conteo.Values.Max();

    Console.WriteLine("\nTorneo(s) mas Seleccionado(s):");
    foreach(var item in conteo)
        {
            if(item.Value == mayorCantidad)
            {
                Torneo? torneo = Datos.Torneos.Find(t => t.Codigo == item.Key);
                Console.WriteLine($"{torneo!.Nombre} ({item.Value} Inscripciones)");
            }
        }
    Console.WriteLine("\n---------------- RANKING ----------------");
    //Ranking de jugadores por puntaje (descendente)
    var ranking = Datos.Jugadores.OrderByDescending(j => j.Puntos).ToList();
    //Console.WriteLine("\nRANKING DE JUGADORES");
    int posicion = 1;
        foreach (Jugador jugador in ranking)
        {
            Console.WriteLine($"{posicion}. {jugador.NombreCompleto} - {jugador.Puntos} Puntos.");
            posicion++;
        }




    }
    

    
}
