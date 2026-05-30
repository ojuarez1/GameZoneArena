// Crear menu 
using System.Reflection.Metadata;

Console.WriteLine("\n");

/******* INICIO DEL PROGRAMA, SOLICITA INGRESO DEL NOMBRE *******/

Console.WriteLine("Ingresa tu nombre ");
String? nombre = Console.ReadLine();
Console.WriteLine($"Nos alegra  {nombre} que estes aqui te presentamos nuestro Catálogo de Torneos\n");


/******* MUESTRA EN CONSOLA EL MENU CON LAS OPCIONES DEL TORNEO A ELEGIR *******/

Console.WriteLine("Codigo    Torneo".PadRight(30) + "Costo\n");
Console.WriteLine("T01   -   FIFA 26".PadRight(30) + "10.00");
Console.WriteLine("T02   -   Call of Duty".PadRight(30) + "15.00");
Console.WriteLine("T03   -   League of Leyends".PadRight(30) + "15.00");
Console.WriteLine("T04   -   Fortnite".PadRight(30) + "15.00");
Console.WriteLine("T05   -   Valorant".PadRight(30) + "15.00\n");

Console.WriteLine("A que torneo deseas inscribirte, elige una opcion digitando el codigo ");
String? opcion = Console.ReadLine();


/******* VALIDACIONES DEL MENU DE TORNEOS *******/

String? cant2 = opcion.Substring(opcion.Length - 2);
bool verdadero = false;

do{
    if(!int.TryParse(cant2, out int numero))
    {
        Console.WriteLine("Los dos caracteres despues de la T deben ser numeros");
        opcion = Console.ReadLine();
        cant2 = opcion.Substring(opcion.Length - 2);

    } else
    if(numero > 5)
    {
        Console.WriteLine("El codio digitado no esta dentro del menu");
        opcion = Console.ReadLine();
        cant2 = opcion.Substring(opcion.Length - 2);
    }else
    if(numero <= 0)
    {
        Console.WriteLine("El codio digitado no esta dentro del menu");
        opcion = Console.ReadLine();
        cant2 = opcion.Substring(opcion.Length - 2);
    }else
    if(opcion.Length != 3)
    {
        Console.WriteLine("- Deben ser tres caracteres la T mayuscala y dos numeros");
        opcion = Console.ReadLine();
        cant2 = opcion.Substring(opcion.Length - 2);
    }
    else
    if (opcion != opcion.ToUpper())
    {
       Console.WriteLine("- La T debe ser mayuscula");
        opcion = Console.ReadLine();
        cant2 = opcion.Substring(opcion.Length - 2); 
    }else
    {
        verdadero = true;
    }
        
}while(verdadero == false);


/******* SI SE HA DIGITADO CORRECTAMENTE EL CODIGO, AQUI SELECCIONA EL NOMBRE DEL TORNEO  *******/

String[] codigo = {"T01", "T02", "T03", "T04", "T05"};
String[] main =  {"FIFA 26", "Call of Duty", "League of Leyends", "Fortnite", "Valorant"};
int cuenta=0;

foreach (String item in codigo)
{
    if (opcion == item)
    {
        Console.WriteLine($"Bienvenido {nombre} a la {main[cuenta]}\n");
        break;
    }
    cuenta++;
}


/******* VALIDACIONES DEL MENU PRINCIPAL *******/

String[] menu = ["1 - Registrar jugador", "2 - Mostrar reporte general", "3 - Buscar jugador por nickname", "4 - Mostrar ranking de jugadores", "5 - Mostrar tercer jugador registrado", "6 - Salir"];
Console.WriteLine("Menu Prncipal");
    foreach (String item in menu)
        {
            Console.WriteLine(item);
        }
    Console.WriteLine("Digita el numero de la opcion que deseas realizar");
    String? opcionMenu = Console.ReadLine();
    bool evalua = false;

do{
    if(!int.TryParse(opcionMenu, out int num))
    {
        Console.WriteLine("Debes digitar solo numeros");
        opcionMenu  = Console.ReadLine();

    }
    else
    if(opcionMenu.Contains(" "))
    {
        Console.WriteLine("El numero digitado no debe contener espacios vacios");
        opcionMenu  = Console.ReadLine();
    }else
    if(num > 6 || num < 1)
    {
        Console.WriteLine("El numero digitado no se encuentra dentro de menú");
        opcionMenu  = Console.ReadLine();
    }else
    if(opcionMenu.Length != 1)
    {
        Console.WriteLine("El numero digitado solo debe contener un caracter");
        opcionMenu  = Console.ReadLine();
                }
                else
                {
                    evalua = true;
                }
}while(evalua == false);


/******* SI SE HA DIGITADO CORRECTAMENTE LA OPCION, AQUI MUESTRA LOS DETALLES DE LA OPCION SELECCIONADA  *******/

do{
    if (opcionMenu == "1")
    {
        //List<String> acumular = new List<String>();
        Console.WriteLine("Registrate\n");
        String[] registro = ["Nombre completo", "Nickname (único)", "Cantidad de torneo", "Codigo del torneo","Resultado por torneo","Salir"];
        foreach (String i in registro)
        {
            Console.WriteLine(i);
            if (i == "Nombre completo")
            {
                opcionMenu = Console.ReadLine();
            }else
            if (i == "Nickname (único)")
            {
                String[] apodos = ["Oscar", "Jason", "Erick"];
                bool name = false;
                opcionMenu = Console.ReadLine();
                do{
                    if(apodos.Contains(opcionMenu))
                    {
                        Console.WriteLine("Este Nickname ya existe, debes eliger otro");
                        opcionMenu = Console.ReadLine();
                    }else
                    {
                        Console.WriteLine("Tu Nickname se ha registrado, exitosamente");
                        name = true;
                    }                   
                } while(name == false);
            }else
            if (i == "Resultado por torneo")
            {
                Console.WriteLine("Digitar 1 si participó");
                Console.WriteLine("Digitar 2 si ganó\n");
                opcionMenu = Console.ReadLine();                
            } else
            if (i == "Salir")
            {
                opcionMenu = i;
                break;
            }
        } 
        break;

    } if (opcionMenu == "2")
    {
        Console.WriteLine("Reporte general\n");
        break;
    } if (opcionMenu == "3")
    {
        Console.WriteLine("Jugador por nickname\n");
        break;
    } if (opcionMenu == "4")
    {
        Console.WriteLine("Ranking de jugadores\n");
        break;
    } if (opcionMenu == "5")
    {
        Console.WriteLine("Rercer jugador registrado\n");
        break;
    } if (opcionMenu == "6")
        {
            break;
        }
} while(opcionMenu != "Salir"); 



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