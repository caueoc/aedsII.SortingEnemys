using SortingEnemys.enemys;
using SortingEnemys.read;
using System.Globalization;

namespace SortingEnemys;


class Program
{
    public static void Main(string[] args)
    {
        EnemiesList lista = new EnemiesList();
        lista.ListEnemies();
        Console.WriteLine("Qual atributo você deseja usar para ordenar?");
        Console.WriteLine("1 - Level\n2 - Health\n3 - Attack\n4 - Defense\n5 - Speed\n6 - Level");
        int attrChoice = int.Parse(Console.ReadLine());

        Func<Enemy, int> selector = attrChoice switch
        {
            1 => e => e.GetLevel(),
            2 => e => e.GetHealth(),
            3 => e => e.GetAttack(),
            4 => e => e.GetDefense(),
            5 => e => e.GetSpeed(),
            6 => e => e.GetLevel()
        };
        Console.WriteLine("Qual algoritmo deseja usar?");
        Console.WriteLine("1 - Bubble Sort\n2 - Selection Sort\n3 - Insertion Sort\n4 - Shell Sort");
        int sortChoice = int.Parse(Console.ReadLine());

        Console.WriteLine("\nAntes da ordenação:");
        lista.PrintList(lista.enemieslist);

        switch (sortChoice)
        {
            case 1:
                Sorters.BubbleSort(lista.enemieslist, selector);
                break;
            case 2:
                Sorters.SelectionSort(lista.enemieslist, selector);
                break;
            case 3:
                Sorters.InsertionSort(lista.enemieslist, selector);
                break;
            case 4:
                Sorters.ShellSort(lista.enemieslist, selector);
                break;
        }

        Console.WriteLine("\nDepois da ordenação:");
        lista.PrintList(lista.enemieslist);

    }
}
