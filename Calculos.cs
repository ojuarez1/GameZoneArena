using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ProyectoTorneo;

public static class Calculos
{
    // Recibe un diccionario del codigo por cada torneo, y su precio
    // Tambien recibe la lista de los torneos seleccionador que el usuario elije por consola
    public static double CalcularSubtotal(Dictionary<string, double> torneos, List<string> torneosSeleccionados)
    {
        double subtotal = 0;
        foreach (string codigo in torneosSeleccionados) //En este foreach intera sobre la lista de torneos y le suma 
                                                        // los precios segun las selecciones que hizo el usuario y asu aplica el subtotal
        {
            subtotal += torneos[codigo];
        }
        return subtotal;
    }

    // Calcula el porcentaje de descuento segun las validaciones que estan en la rubrica
    public static double CalcularPorcentajeDescuento(List<string> torneosSeleccionados)
    {
        double porcentajeDescuento = 0;

        if (torneosSeleccionados.Count >= 3)
        {
            porcentajeDescuento += 10;
        }
        if (torneosSeleccionados.Contains("T03"))
        {
            porcentajeDescuento += 5;
        }
        if (torneosSeleccionados.Contains("T02") && torneosSeleccionados.Contains("T05"))
        {
            porcentajeDescuento += 7;
        }

        return porcentajeDescuento;

    }

    //Calcula el total a descontar segun el porcentaje aplicado
    public static double CalcularTotalFinal(double subtotal, double porcentajeDescuento) //Recibe el porcentaje y el subtotal
    {
        double descuento = (subtotal * porcentajeDescuento) / 100;
        return subtotal - descuento;
    }

    // Solo corre una validacion segun los puntos obtenido para darle una Clasificacion
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

    // Este metodo recibe una lista de los resultados es decir si gano o solo participo
    //en base a esto se distribuyen lo asignan los puntos
    public static int CalcularPuntos(List<int> resultados)
    {
        int puntos = 0; //Acumulador inicializado
        int ganados = 0; //Acumulador inicializado

        foreach (int resultado in resultados)
        {
            if(resultado == 1)
            {
                puntos += 10;
            }
            if(resultado == 2)
            {
                puntos += 60;
                ganados++; // Esto cuanta los ganes se coloco aqui por que solo cuando de 2 sera equivalente a que gano
            }
        }
        // Evalua las veces ganadas para asignar los puntos correspondientes
        if(ganados >= 3)
        {
            puntos += 15;
        }
        return puntos;
    }






}