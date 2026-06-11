using ProyectoTorneo;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ProyectoTorneo;

// Contiene los métodos encargados de realizar los cálculos relacionados con 
// costos, descuentos, clasificación y puntos de los jugadores.

public static class Calculos
{
    // Calcula el costo total de inscripción sumando
    // los precios de los torneos seleccionados.

    public static double CalcularSubtotal(Dictionary<string, double> torneos, List<string> torneosSeleccionados)
    {
        double subtotal = 0;

        // Recorre cada torneo seleccionado y acumula su costo.

        foreach (string codigo in torneosSeleccionados)
        {
            subtotal += torneos[codigo];
        }
        return subtotal;
    }

    // Determina el porcentaje de descuento aplicable
    // según las reglas establecidas por el torneo.

    public static double CalcularPorcentajeDescuento(List<string> torneosSeleccionados)
    {
        double porcentajeDescuento = 0;

        // Aplica un 10% de descuento por inscribirse en tres o más torneos.

        if (torneosSeleccionados.Count >= 3)
        {
            porcentajeDescuento += 10;
        }

        // Aplica un 5% adicional si participa en League of Legends (T03).

        if (torneosSeleccionados.Contains("T03"))
        {
            porcentajeDescuento += 5;
        }

        // Aplica un 7% adicional si participa simultáneamente en Call of Duty y Valorant.

        if (torneosSeleccionados.Contains("T02") && torneosSeleccionados.Contains("T05"))
        {
            porcentajeDescuento += 7;
        }

        return porcentajeDescuento;

    }

    // Calcula el monto final a pagar después de aplicar el descuento correspondiente.

    public static double CalcularTotalFinal(double subtotal, double porcentajeDescuento) 
    {
        double descuento = (subtotal * porcentajeDescuento) / 100;
        return subtotal - descuento;
    }

    // Determina la clasificación del jugador según el monto final de inscripción.

    public static string ObtenerClasificacion(double totalFinal)
    {
        if (totalFinal >= 40)
        {
            return "VIP";
        }else
        {
            return "NORMAL";
        }
    }

    // Calcula la puntuación total del jugador en función de los resultados obtenidos.

    public static int CalcularPuntos(List<int> resultados)
    {
        int puntos = 0; 
        int ganados = 0;

        foreach (int resultado in resultados)
        {
            // Participar otorga 10 puntos.
            if(resultado == 1)
            {
                puntos += 10;
            }

            // Ganar otorga 60 puntos.
            if(resultado == 2)
            {
                puntos += 60;
                ganados++; 
            }
        }

        // Bono adicional por ganar tres o más torneos.

        if(ganados >= 3)
        {
            puntos += 15;
        }
        return puntos;
    }

}