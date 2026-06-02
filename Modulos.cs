namespace ProyectoTorneo;

public static class Modulos
{
    static Dictionary<string, double> torneos = new()
    {
        {"T01", 10.00},
        {"T02", 15.00},
        {"T03", 20.00},
        {"T04", 12.00},
        {"T05", 18.00},
    };
    public static string MostrarMenu()
    {
        string[] menu =
        {
            "1 - Registrar jugador",
            "2 - Mostrar reporte general",
            "3 - Buscar jugador por nickname",
            "4 - Mostrar ranking de jugadores",
            "5 - Mostrar tercer jugador registrado",
            "6 - Salir"
        };

        Console.WriteLine("\nMENÚ PRINCIPAL"); //agregue un salto de linea al inicio

        foreach(string item in menu)
        {
            Console.WriteLine(item);
        }

        string? opcion;

        do
        {
            Console.WriteLine("Digite una opción: "); //Agregue un espacio despues del :
            opcion = Console.ReadLine();

        } while(!ValidarMenu(opcion));

        return opcion!;
    }

    public static bool ValidarMenu(string? opcion)
    {
        if(string.IsNullOrWhiteSpace(opcion))
            return false;

        if(!int.TryParse(opcion, out int numero))
            return false;

        return numero >= 1 && numero <= 6;
    }

    public static void RegistrarJugador(string? nombre)
    {
        Console.WriteLine("Registro de jugador"); //agregue un salto de linea al inicio

        string nombreCompleto = SolicitarNombre();

        string nickname = SolicitarNickname();

        int cantidadTorneos = SolicitarCantidadTorneos();

        //Inicializando listas de Torneos seleccionados y resultados si gano o solo participo
        //Inicio
        List<string> torneosSeleccionados =  new();
        List<int> resultados = new();

        for(int i = 0; i < cantidadTorneos; i++)
        {
            Console.WriteLine($"\nTorneo #{i + 1}");
            string codigo = SolicitarCodigoTorneo();
            torneosSeleccionados.Add(codigo);

            int resultado = Convert.ToInt32(SolicitarResultado());
            resultados.Add(resultado);
        }
        

        //string codigo = SolicitarCodigoTorneo();

        //string resultado = SolicitarResultado();

        //Console.WriteLine($"{nombre} se registró correctamente.");

        double subtotal = Calculos.CalcularSubtotal(torneos, torneosSeleccionados);
        double descuento = Calculos.CalcularPorcentajeDescuento(torneosSeleccionados);
        double totalFinal = Calculos.CalcularTotalFinal(subtotal, descuento);
        string clasificacion = Calculos.ObtenerClasificacion(totalFinal);
        int puntos = Calculos.CalcularPuntos(resultados);

        Jugador jugador = new()
        {
            NombreCompleto = nombreCompleto,
            Nickname = nickname,
            Resultados = resultados,
            Subtotal = subtotal,
            Descuento = descuento,
            TotalFinal = totalFinal,
            Clasificacion = clasificacion,
            Puntos = puntos

        };
        Datos.Jugadores.Add(jugador);

        Console.WriteLine("\n'''''' REPORTE ''''''");
        Console.WriteLine($"Nombre: {nombreCompleto}");
        Console.WriteLine($"Nickname: {nickname}");
        Console.WriteLine($"Subtotal: ${subtotal:F2}");
        Console.WriteLine($"Descuento: {descuento}%");
        Console.WriteLine($"Total Final: ${totalFinal:F2}");
        Console.WriteLine($"Clasificación: {clasificacion}");
        Console.WriteLine($"Puntos: {puntos}");

        Console.WriteLine($"\n{nombre} registró correctamente al jugador.");
    }
// Fin
    public static string SolicitarNombre()
    {
        Console.WriteLine("Nombre completo: ");
        return Console.ReadLine()!;
    }

    public static string SolicitarNickname()
    {
        string[] apodos = { "Oscar", "Jason", "Erick" };

        string? nickname;

        do
        {
            Console.WriteLine("Nickname:");
            nickname = Console.ReadLine();

            if(!apodos.Contains(nickname))
                return nickname!;

            Console.WriteLine("Ese nickname ya existe.");

        } while(true);
    }

    public static int SolicitarCantidadTorneos()
    {
        int cantidad;

        do
        {
            Console.WriteLine("Cantidad de torneos (1-5):");

        } while(!int.TryParse(Console.ReadLine(), out cantidad)
                || cantidad < 1
                || cantidad > 5);

        return cantidad;
    }

    public static string SolicitarCodigoTorneo()
    {
        Console.WriteLine("T01 - FIFA 26");
        Console.WriteLine("T02 - Call of Duty");
        Console.WriteLine("T03 - League of Legends");
        Console.WriteLine("T04 - Fortnite");
        Console.WriteLine("T05 - Valorant");

        string? codigo;

        do
        {
            Console.WriteLine("Código:");
            codigo = Console.ReadLine()?.ToUpper();

        } while(codigo != "T01" &&
                codigo != "T02" &&
                codigo != "T03" &&
                codigo != "T04" &&
                codigo != "T05");

        return codigo!;
    }

    public static string SolicitarResultado()
    {
        string? resultado;

        do
        {
            Console.WriteLine("1 = Participó");
            Console.WriteLine("2 = Ganó");

            resultado = Console.ReadLine();

        } while(resultado != "1" && resultado != "2");

        return resultado!;
    }

    public static void BusquedaNickname() //meotodo implementado
    {
        Console.WriteLine("\n!!!BUSCAR JUGADOR!!!");
        Console.Write("Ingrese el nickname: ");
        string? nickname = Console.ReadLine();

        Jugador? jugador = Datos.Jugadores.FirstOrDefault(j=>j.Nickname.Equals(nickname!, StringComparison.OrdinalIgnoreCase));

        if (jugador == null)
        {
            Console.WriteLine("Jugador no encontrado.");
            return;
        }

        Console.WriteLine("\n*** JUGADOR ENCONTRADO ***");
        Console.WriteLine($"Nombre: {jugador.NombreCompleto}");
        Console.WriteLine($"Nickname: {jugador.Nickname}");
        Console.WriteLine($"Puntos: {jugador.Puntos}");
        Console.WriteLine($"Clasificacion: {jugador.Clasificacion}");
    }

    public static void MostrarRanking() //meotodo implementado
    {
        Console.WriteLine("\n!!!RANKING DE JUGADORES!!!");
        if (Datos.Jugadores.Count == 0)
        {
            Console.WriteLine("No existen jugadores registrados");
            return;
        }
        List<Jugador> ranking = Datos.Jugadores.OrderByDescending(j => j.Puntos).ToList();

        int posicion = 1;
        foreach (Jugador jugador in ranking)
        {
            Console.WriteLine($"{posicion}. {jugador.Nickname} - {jugador.Puntos} puntos :D");
            posicion++;
        }
    }

    public static void MostrarTercerJugador() //meotodo implementado
    {
        Console.WriteLine("\n!!!MOSTRAR JUGADOR REGISTRADO!!!");

        if (Datos.Jugadores.Count < 3)
        {
            Console.WriteLine("Todavia no existen 3 jugadores registrados!");
            return;
        }

        Jugador jugador = Datos.Jugadores[2];
        Console.WriteLine($"Nombre: {jugador.NombreCompleto}");
        Console.WriteLine($"Nickname: {jugador.Nickname}");
        Console.WriteLine($"Puntos: {jugador.Puntos}");
        Console.WriteLine($"Clasificación: {jugador.Clasificacion}");

    }
}