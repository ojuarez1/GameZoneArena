/*
// Crear menu 
using System.Reflection.Metadata;

Console.WriteLine("\n");

/******* INICIO DEL PROGRAMA, SOLICITA INGRESO DEL NOMBRE *******/

/*Console.WriteLine("Ingresa tu nombre ");
String? nombre = Console.ReadLine();
Console.WriteLine($"Nos alegra  {nombre} que estes aqui te presentamos nuestro Menú\n");


/******* VALIDACIONES DEL MENU PRINCIPAL *******/

/*String[] menu = ["1 - Registrar jugador", "2 - Mostrar reporte general", "3 - Buscar jugador por nickname", "4 - Mostrar ranking de jugadores", "5 - Mostrar tercer jugador registrado", "6 - Salir"];
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

/*do{
    if (opcionMenu == "1")
    {
        //List<String> acumular = new List<String>();
        Console.WriteLine("Registrate\n");
        String[] registro = ["Nombre completo", "Nickname (único)", "Cantidad de torneo", "Codigo del torneo","Resultado por torneo"];
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
            if (i == "Cantidad de torneo")
            {
                opcionMenu = Console.ReadLine();
                bool sale = false;
                do
                {
                    if (!int.TryParse(opcionMenu, out int dato))
                    {
                        Console.WriteLine("Solo se permiten numeros");
                        opcionMenu = Console.ReadLine();
                    }else
                    if (dato < 1)
                    {
                        Console.WriteLine("Debes digitar almenos 1");
                        opcionMenu = Console.ReadLine();
                    }else
                    if (dato > 5)
                    {
                        Console.WriteLine("Máximo permitido 5");
                        opcionMenu = Console.ReadLine();
                    }else
                    if(opcionMenu.Contains(" "))
                    {
                        Console.WriteLine("No debe contener espacios vacios");
                        opcionMenu = Console.ReadLine();
                    }else
                    {
                        sale=true;
                    }
                } while(sale==false);              
    }else
            if (i == "Codigo del torneo")
            {
                Console.WriteLine("Codigo    Torneo".PadRight(30) + "Costo\n");
                Console.WriteLine("T01   -   FIFA 26".PadRight(30) + "10.00");
                Console.WriteLine("T02   -   Call of Duty".PadRight(30) + "15.00");
                Console.WriteLine("T03   -   League of Leyends".PadRight(30) + "15.00");
                Console.WriteLine("T04   -   Fortnite".PadRight(30) + "15.00");
                Console.WriteLine("T05   -   Valorant".PadRight(30) + "15.00\n");

                Console.WriteLine("A que torneo deseas inscribirte, elige una opcion digitando el codigo ");
                opcionMenu = Console.ReadLine();
                String? cant2 = opcionMenu.Substring(opcionMenu.Length - 2);
                bool verdadero = false;

                do{
                    if(!int.TryParse(cant2, out int numero))
                    {
                        Console.WriteLine("Los dos caracteres despues de la T deben ser numeros");
                        opcionMenu = Console.ReadLine();
                        cant2 = opcionMenu.Substring(opcionMenu.Length - 2);

                    } else
                    if(numero > 5)
                    {
                        Console.WriteLine("El codio digitado no esta dentro del menu");
                        opcionMenu = Console.ReadLine();
                        cant2 = opcionMenu.Substring(opcionMenu.Length - 2);
                    }else
                    if(numero <= 0)
                    {
                        Console.WriteLine("El codio digitado no esta dentro del menu");
                        opcionMenu = Console.ReadLine();
                        cant2 = opcionMenu.Substring(opcionMenu.Length - 2);
                    }else
                    if(opcionMenu.Length != 3)
                    {
                        Console.WriteLine("- Deben ser tres caracteres la T mayuscala y dos numeros");
                        opcionMenu = Console.ReadLine();
                        cant2 = opcionMenu.Substring(opcionMenu.Length - 2);
                    }
                    else
                    if (opcionMenu != opcionMenu.ToUpper())
                    {
                    Console.WriteLine("- La T debe ser mayuscula");
                        opcionMenu = Console.ReadLine();
                        cant2 = opcionMenu.Substring(opcionMenu.Length - 2); 
                    }else
                    {
                        verdadero = true;
                    }
                        
                }while(verdadero == false);

                String[] codigo = {"T01", "T02", "T03", "T04", "T05"};
                String[] main =  {"FIFA 26", "Call of Duty", "League of Leyends", "Fortnite", "Valorant"};
                int cuenta=0;

                foreach (String item in codigo)
                {
                    if (opcionMenu == item)
                    {
                        Console.WriteLine($"{nombre} te has inscrito al torneo {main[cuenta]}\n");
                        break;
                    }
                    cuenta++;
                }

            }else
            if (i == "Resultado por torneo")
            {
                Console.WriteLine("o 1 = participó");
                Console.WriteLine("o 2 = ganó\n");
                opcionMenu = Console.ReadLine();
                do
                {
                    Console.WriteLine("Solo se permite 1 o 2, digita una de estas 2 opciones");
                    opcionMenu = Console.ReadLine();
                } while(opcionMenu != "1" && opcionMenu != "2");              
            }            
        } 
        Console.WriteLine("Tu registro se ha completado");
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
        Console.WriteLine("Tercer jugador registrado\n");
        break;
    } if (opcionMenu == "6")
        {
            break;
        }
} while(opcionMenu != "Salir"); */

using ProyectoTorneo;

Console.WriteLine("Ingresa tu nombre:");
string? nombre = Console.ReadLine();

Console.WriteLine($"Nos alegra {nombre} que estés aquí\n");

string opcion = Modulos.MostrarMenu();

switch(opcion)
{
    case "1":
        Modulos.RegistrarJugador(nombre);
        break;

    case "2":
        Modulos.MostrarReporteGeneral();
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
        Console.WriteLine("Saliendo...");
        break;
}