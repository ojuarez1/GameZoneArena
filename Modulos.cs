using ProyectoTorneo;
namespace ProyectoTorneo;

public static class Modulos
{   
    // Diccionario que almacena el costo de inscripción
    // de cada tipo de torneo según su código.
    static Dictionary<string, double> torneos = new() 
    {
        {"T01", 10.00},
        {"T02", 15.00},
        {"T03", 20.00},
        {"T04", 12.00},
        {"T05", 18.00},
    };

    /// Muestra el menú principal y valida la opción ingresada por el usuario.
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

    // Valida que la opción ingresada en el menú sea un número
    // válido dentro del rango de opciones disponibles.
    public static bool ValidarMenu(string? opcion)
    {
        if(string.IsNullOrWhiteSpace(opcion))
            return false;

        if(!int.TryParse(opcion, out int numero))
            return false;

        return numero >= 1 && numero <= 6;
    }

    // Solicita los datos de un jugador, calcula sus costos y puntos,
    // y lo registra en el sistema.
    public static void RegistrarJugador(string? nombre)
    {
        // Crea una instancia temporal del jugador
        Jugador jugador = new Jugador();

        Console.WriteLine("Registro de jugador");

        string nombreCompleto = SolicitarNombre();

        string nickname = SolicitarNickname();

        int cantidadTorneos = SolicitarCantidadTorneos();

        // Listas que almacenan los torneos seleccionados
        // y los resultados obtenidos por el jugador.
        List<string> torneosSeleccionados =  new();
        List<int> resultados = new();

        for(int i = 0; i < cantidadTorneos; i++)
        {
            Console.WriteLine($"\nTorneo #{i + 1}");
            string codigo = SolicitarCodigoTorneo(jugador);
            torneosSeleccionados.Add(codigo);

            int resultado = Convert.ToInt32(SolicitarResultado());
            resultados.Add(resultado);
        }
        
        // Calcula los valores económicos y deportivos del jugador.
        double subtotal = Calculos.CalcularSubtotal(torneos, torneosSeleccionados);
        double descuento = Calculos.CalcularPorcentajeDescuento(torneosSeleccionados);
        double totalFinal = Calculos.CalcularTotalFinal(subtotal, descuento);
        string clasificacion = Calculos.ObtenerClasificacion(totalFinal);
        int puntos = Calculos.CalcularPuntos(resultados);

        // Crea el objeto Jugador con toda la información recopilada.
        jugador = new()
        {
            NombreCompleto = nombreCompleto,
            Nickname = nickname,
            Torneos = torneosSeleccionados,
            Resultados = resultados,
            Subtotal = subtotal,
            Descuento = descuento,
            TotalFinal = totalFinal,
            Clasificacion = clasificacion,
            Puntos = puntos

        };

        // Agrega el jugador a la lista general del sistema.
        Datos.Jugadores.Add(jugador);

        Console.WriteLine("\n'''''' REPORTE ''''''");
        Console.WriteLine($"Nombre: {nombreCompleto}");
        Console.WriteLine($"Nickname: {nickname}");
        Console.WriteLine($"Subtotal: ${subtotal:F2}");
        Console.WriteLine($"Descuento: {descuento}%");
        Console.WriteLine($"Total Final: ${totalFinal:F2}");
        Console.WriteLine($"Clasificación: {clasificacion}");
        Console.WriteLine($"Puntos: {puntos}");

        Console.WriteLine($"\n{nombre} registró correctamente al jugador {jugador.NombreCompleto}.");
    }

    // Solicita al usuario el nombre completo del jugador
    // y devuelve el valor ingresado.
    public static string SolicitarNombre()
    {
        Console.WriteLine("Nombre completo: ");
        return Console.ReadLine()!;
    }

    // Solicita un nickname único para el jugador.
    // No permite nicknames repetidos.
    public static string SolicitarNickname()
    {
        string? nickname;
        do
        {
            Console.WriteLine("Dijite su NickName: ");
            nickname = Console.ReadLine();

            // El operador ! indica al compilador que el valor
            // no será nulo en este punto del código.
            if(Datos.ApodosExistentes.Contains(nickname!))
            {
                Console.WriteLine("Este NickName ya Existe.");
            }
            else
            {
                Datos.ApodosExistentes.Add(nickname!);
                return nickname!;
            }
        }while(true);
    }

    // Solicita la cantidad de torneos que desea registrar el jugador.
    // Solo permite valores entre 1 y 5.
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

    // Muestra los torneos disponibles y valida que el código
    // ingresado exista y no haya sido seleccionado previamente.
    public static string SolicitarCodigoTorneo(Jugador jugador)
    {
        string? codigo;
        do
        {
        Console.WriteLine("Codigo\tNombre");
        foreach (var torneo in Datos.Torneos)
        {
            
            Console.WriteLine($"{torneo.Codigo} - {torneo.Nombre}");
        }
        
        
            Console.WriteLine("Digite el Codigo de Torneo: ");
            codigo = Console.ReadLine()?.ToUpper();
            

            // Verifica si el código ingresado existe dentro
            // de la lista de torneos disponibles.
            bool existe = Datos.Torneos.Any(t => t.Codigo == codigo); 
            
                                                             
            // Evita registrar el mismo torneo más de una vez
            // para el mismo jugador.
            if (!existe)
            {
                Console.WriteLine("Este Codigo no existe!!!");
                continue;
            }else if (jugador.Torneos.Contains(codigo!))
            {
                Console.WriteLine("Este torneo ya fue registro para este jugador!!!");
                continue;
            }else{
            jugador.Torneos.Add(codigo!);
            }
            return codigo!;


        }while(true);

        //return codigo!;
    }

    // Solicita el resultado obtenido por el jugador en un torneo.
    // Solo permite las opciones "1" (Participó) o "2" (Ganó).
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

    // Busca un jugador por su nickname y muestra
    // su información si existe.
    public static void BusquedaNickname() 
    {
        Console.WriteLine("\n!!!BUSCAR JUGADOR!!!");
        Console.Write("Ingrese el nickname: ");
        string? nickname = Console.ReadLine();

        // Busca el primer jugador cuyo nickname coincida
        // con el ingresado, ignorando mayúsculas y minúsculas.
        Jugador? jugador = Datos.Jugadores.FirstOrDefault(j=>j.Nickname.Equals(nickname!, StringComparison.OrdinalIgnoreCase));

        // Verifica si el jugador fue encontrado.
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

    // Muestra el ranking de jugadores ordenado
    // de mayor a menor según sus puntos.
    public static void MostrarRanking()
    {
        Console.WriteLine("\n!!!RANKING DE JUGADORES!!!");
        if (Datos.Jugadores.Count == 0)
        {
            Console.WriteLine("No existen jugadores registrados");
            return;
        }
        // Ordena la lista de jugadores de forma descendente
        // utilizando la cantidad de puntos obtenidos.
        List<Jugador> ranking = Datos.Jugadores.OrderByDescending(j => j.Puntos).ToList();

        int posicion = 1;

        // Recorre la lista ordenada mostrando la posición
        // de cada jugador dentro del ranking.
        foreach (Jugador jugador in ranking)
        {
            Console.WriteLine($"Puesto #{posicion} Nombre: {jugador.NombreCompleto} - Nickname: {jugador.Nickname} - puntos: {jugador.Puntos}");
            posicion++;
        }
    }

    // Muestra la información del tercer jugador
    // registrado en el sistema.
    public static void MostrarTercerJugador()
    {
        Console.WriteLine("\n!!!MOSTRAR TERCER JUGADOR REGISTRADO!!!");
        //Si no hay mas de 3 jugadores entonces no muestra ningun resultado
        if (Datos.Jugadores.Count < 3)
        {
            Console.WriteLine("Todavia no existen 3 jugadores registrados!");
            return;
        }

        Jugador jugador = Datos.Jugadores[2];
        Console.WriteLine($"Nombre:         {jugador.NombreCompleto}");
        Console.WriteLine($"Nickname:       {jugador.Nickname}");
        Console.WriteLine($"Puntos:         {jugador.Puntos}");
        Console.WriteLine($"Clasificación:  {jugador.Clasificacion}");

    }
}