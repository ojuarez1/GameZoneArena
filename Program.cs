using ProyectoTorneo;
class Program
{
    static void Main(string[] args)
    {
        // Solicita el nombre del usuario que utilizará el sistema
        Console.WriteLine("Ingresa tu nombre de Usuario:");
        string? nombre = Console.ReadLine();

    // Muestra un mensaje de bienvenida personalizado
    Console.WriteLine($"\nNos alegra que estés aquí {nombre} ;D");

    string opcion;

// Mantiene el menú activo hasta que el usuario seleccione la opción de salir
do
{
    // Muestra el menú principal y almacena la opción seleccionada
    opcion = Modulos.MostrarMenu();

    // Ejecuta la acción correspondiente según la opción elegida
    switch(opcion)
    {
        case "1":
            // Registra un nuevo jugador en el sistema
            Modulos.RegistrarJugador(nombre);
            break;

        case "2":
            // Muestra el reporte general de jugadores registrados
            Reportes.MostrarReporteGeneral();
            break;

        case "3":
            // Permite buscar un jugador por su nickname
            Modulos.BusquedaNickname();
            break;

        case "4":
            // Muestra el ranking de jugadores
            Modulos.MostrarRanking();
            break;

        case "5":
            // Muestra la información del tercer jugador registrado
            Modulos.MostrarTercerJugador();
            break;

        case "6":
            // Finaliza la ejecución del programa
            Console.WriteLine("Saliendo del Sistema...");
            break;
    }    
        // Pausa la ejecución antes de regresar al menú principal
        if (opcion != "6")
        {
            Console.WriteLine("\nPrecione una tecla para continuar :D !!!");
            Console.ReadKey();
            Console.Clear();
        }
        
} while (opcion != "6"); // Repite el menú hasta que el usuario decida salir
    }
}
