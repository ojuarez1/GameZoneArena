// Crear menu 
Console.WriteLine("\n");

Console.WriteLine("Ingresa tu nombre ");
String nombre;
    nombre = Console.ReadLine();
    Console.WriteLine("Nos alegra que estes aqui " + nombre);

Console.WriteLine("Menu\n");

Console.WriteLine("Codigo    Torneo".PadRight(30) + "Costo\n");
Console.WriteLine("T01   -   FIFA 26".PadRight(30) + "10.00");
Console.WriteLine("T02   -   Call of Duty".PadRight(30) + "15.00");
Console.WriteLine("T03   -   League of Leyends".PadRight(30) + "15.00");
Console.WriteLine("T04   -   Fortnite".PadRight(30) + "15.00");
Console.WriteLine("T05   -   Valorant".PadRight(30) + "15.00\n");

Console.WriteLine("Que quieres jugar hoy, elige una opcion ");
String opcion;
opcion = Console.ReadLine();

if (opcion != opcion.ToUpper())    
{   
    Console.WriteLine("Revisa que hayas digitado bien el codigo");
    Console.WriteLine("- La T debe ser mayuscula");
    Console.WriteLine("- La T debe ir acompañada de dos numeros");
    
    opcion = Console.ReadLine();
}

if (opcion == "T01")
{
    Console.WriteLine($"Bienvenido {nombre} a la FIFA 26\n");
    
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
    }

/* String[][] menu = new String[][]
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