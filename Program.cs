using ProyectoTorneo;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingresa tu nombre de Usuario:");
    string? nombre = Console.ReadLine();

    Console.WriteLine($"\nNos alegra que estés aquí {nombre} ;D");

string opcion;
do
{
    opcion = Modulos.MostrarMenu();

    switch(opcion)
    {
        case "1":
            Modulos.RegistrarJugador(nombre);
            break;

        case "2":
            Reportes.MostrarReporteGeneral();
            break;

        case "3":
            Modulos.BusquedaNickname();
            break;

        case "4":
            Modulos.MostrarRanking();
            break;

        case "5":
            Modulos.MostrarTercerJugador();
            break;

        case "6":
            Console.WriteLine("Saliendo del Sistema...");
            break;
    }        
        if (opcion != "6")
        {
            Console.WriteLine("\nPrecione una tecla para continuar :D !!!");
            Console.ReadKey();
            Console.Clear();
        }
        
} while (opcion != "6");
    }
}
