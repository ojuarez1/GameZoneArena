// Crear menu 
Console.WriteLine("\n");

Console.WriteLine("Ingresa tu nombre ");
String? nombre = Console.ReadLine();
Console.WriteLine($"Nos alegra  {nombre} que estes aqui te presentamos nuestro Catálogo de Torneos\n");

//Console.WriteLine("Catálogo de Torneos\n");

Console.WriteLine("Codigo    Torneo".PadRight(30) + "Costo\n");
Console.WriteLine("T01   -   FIFA 26".PadRight(30) + "10.00");
Console.WriteLine("T02   -   Call of Duty".PadRight(30) + "15.00");
Console.WriteLine("T03   -   League of Leyends".PadRight(30) + "15.00");
Console.WriteLine("T04   -   Fortnite".PadRight(30) + "15.00");
Console.WriteLine("T05   -   Valorant".PadRight(30) + "15.00\n");

Console.WriteLine("A que torneo deseas inscribirte, elige una opcion digitando el codigo ");

String? opcion = Console.ReadLine();
//String? cant = opcion.Substring(1,2);
//int? corto = int.Parse(cant);

if (opcion != opcion.ToUpper() || opcion.Length != 3)
    
{   
    Console.WriteLine("Revisa que hayas digitado bien el codigo");
    if (opcion != opcion.ToUpper())
    {
        Console.WriteLine("- La T debe ser mayuscula");
        opcion = Console.ReadLine();
    }else
    if(opcion.Length != 3)
        {
            Console.WriteLine("- Deben ser tres caracteres la T mayuscala y dos numeros");
            opcion = Console.ReadLine();
        }else
        {
            Console.WriteLine("- El codigo digitado no se encuentra dentro del menú");
            opcion = Console.ReadLine();
        }
}

if (opcion == "T01")
{
    Console.WriteLine($"Bienvenido {nombre} a la FIFA 26\n");
    String[] menu = ["1 - Registrar jugador", "2 - Mostrar reporte general", "3 - Buscar jugador por nickname", "4 - Mostrar ranking de jugadores", "5 - Mostrar tercer jugador registrado", "6 - Salir"];

String? opcionMenu = "";

while (opcionMenu != "Salir")
{
    Console.WriteLine("Menu Prncipal");
    foreach (String item in menu)
        {
            Console.WriteLine(item);
        }
    Console.WriteLine("Digita el numero de la opcion que deseas realizar");
    opcionMenu = Console.ReadLine();
    if (opcionMenu == "1")
    {
        Console.WriteLine("Registrate\n");
        break;
    } else
    if (opcionMenu == "6")
        {
            opcionMenu = "Salir";
        }    
}

if (opcionMenu == "1")
{
    String[] registro = ["Nombre completo", "Nickname (único)", "Cantidad de torneo", "Codigo del torneo","Salir"];
    foreach (String i in registro)
    {
        Console.WriteLine(i);
        opcionMenu = Console.ReadLine();
        if (i == "Salir")
        {
            break;
        }
    }
    
}
    
} else
if (opcion == "T02")
    {
        Console.WriteLine($"Bienvenido {nombre} a Call of Duty\n");
        
    } else
if (opcion == "T03")
    {
        Console.WriteLine($"Bienvenido {nombre} a League of Leyends\n");
    } else
if (opcion == "T04")
    {
        Console.WriteLine($"Bienvenido {nombre} a Fortnite\n");
    } else
if (opcion == "T05")
    {
        Console.WriteLine($"Bienvenido {nombre} a Valorant\n");
    } else
        {
            Console.WriteLine($"Lo sentimos pero el codgo {opcion} no es correcto");
            Console.WriteLine("Vuelve a intentarlo");
        }





/*
 String[][] menu = new String[][]
{
    new String[] {"T01", "T02", "T03", "T04", "T05"},
    new String[] {"FIFA 26", "Call of Duty", "League of Leyends", "Fortnite", "Valorant"},
    new String[] {"10.00", "15.00", "20.00", "12.00", "18.00"}
};

foreach (String[] elem in menu)
{
    foreach (String item in elem)
    {
        
    }
};

string CatalogoTorneo(string codigo)
{
    Console.WriteLine(codigo);
    String nombre;
    nombre = Console.ReadLine();
    Console.WriteLine("Encantado de saludarte " + nombre);
}

CatalogoTorneo("Hello, World!");*/