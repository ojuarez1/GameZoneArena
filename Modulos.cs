namespace ProyectoTorneo;

public static class Modulos
{
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

        Console.WriteLine("MENÚ PRINCIPAL");

        foreach(string item in menu)
        {
            Console.WriteLine(item);
        }

        string? opcion;

        do
        {
            Console.WriteLine("Digite una opción:");
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
        Console.WriteLine("Registro de jugador");

        string nombreCompleto = SolicitarNombre();

        string nickname = SolicitarNickname();

        int cantidadTorneos = SolicitarCantidadTorneos();

        string codigo = SolicitarCodigoTorneo();

        string resultado = SolicitarResultado();

        Console.WriteLine($"{nombre} se registró correctamente.");
    }

    public static string SolicitarNombre()
    {
        Console.WriteLine("Nombre completo:");
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

    public static void MostrarReporteGeneral()
    {
        Console.WriteLine("Reporte general");
    }

    public static void BusquedaNickname()
    {
        Console.WriteLine("Buscar jugador");
    }

    public static void MostrarRanking()
    {
        Console.WriteLine("Ranking");
    }

    public static void MostrarTercerJugador()
    {
        Console.WriteLine("Tercer jugador");
    }
}