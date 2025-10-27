using DoubleList;
using System.ComponentModel.Design;

var list = new DoublyLinkedList<string>();
var opc = "0";

do
{
    opc = Menu();
    switch (opc)
    {
        case "0":
            Console.WriteLine("Bye");
            break;

        case "1":
            Console.WriteLine("Ingrese el dato: ");
            var sortedData = Console.ReadLine();
            if (sortedData != null)
            {
                list.InsertOrdered(sortedData);
                Console.WriteLine("Dato insertado. ");
            }
            break;

        case "2": // 
            Console.WriteLine(list.GetForward());
            break;

        case "3": // 
            Console.WriteLine(list.GettBackward());
            break;

        case "4":
            list.Reverse();
            Console.WriteLine("Lista invertida.");
            break;

        case "5": 
            var modes = list.ShowMode();
            if (modes.Count == 0)
            {
                Console.WriteLine("La lista está vacía o no tiene moda.");
            }
            else
            {
                Console.WriteLine("Moda(s): ");
                Console.WriteLine( string.Join(", ", modes));
            }
            break;

        case "6":
            list.ShowGraph();
            break;



        case "7":
            Console.WriteLine("Ingrese el dato a buscar: ");
            var search = Console.ReadLine();
            if (search != null)
            {
                if (list.Exists(search))
                    Console.WriteLine($"El dato '{search}' SÍ existe en la lista.");
                else
                    Console.WriteLine($"El dato '{search}' NO existe en la lista.");
            }
            break;


        case "8":
            Console.WriteLine("Ingrese el dato a eliminar: ");
            var remove = Console.ReadLine();
            if (remove != null)
            {
                bool removed = list.Remove(remove);

                if (removed)
                {
                    Console.WriteLine("Item eliminado correctamente.");
                }
                   
                else
                {
                    Console.WriteLine("Dato no encontrado o la lista está vacía. ");
                }

            }
            break;

        case "9":
            Console.WriteLine("Ingrese el dato a eliminar: ");
            var removeAll = Console.ReadLine();
            if (removeAll != null)
            {
                list.RemoveAll(removeAll);
                Console.WriteLine("Se eliminaron todas las ocurrencias. ");
            }
        break;


    }

} while (opc != "0"); // exit




string Menu()
{
    Console.WriteLine();
    Console.WriteLine("1. Adicionar. ");
    Console.WriteLine("2. mostrar la lista hacia adelante.");
    Console.WriteLine("3. mostrar la lista hacia atras.");
    Console.WriteLine("4. Invertir la lista.");
    Console.WriteLine("5. Mostrar las Modas.");
    Console.WriteLine("6. Gráfico. ");
    Console.WriteLine("7. Existe.");
    Console.WriteLine("8. Eliminar una ocurrencia.");
    Console.WriteLine("9. Eliminar todas las ocurrencias.");
    Console.WriteLine("0. Salir");
    Console.Write("ingrese una opcion: ");
    return Console.ReadLine() ?? "0";
}
 

    


