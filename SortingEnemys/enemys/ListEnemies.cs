using SortingEnemys.enemys;
using SortingEnemys.write;
using System;
using System.Reflection.Emit;

public class EnemiesList
{
    public Enemy[] enemieslist = new Enemy[100];
    string eName;
    int eLevel;
    int eHealth;
    int eAttack;
    int eDefense;
    int eSpeed;
    public void ListEnemies()
    {
        string file = "enemys/enemys.txt";
        string caminhoAbsoluto = Path.GetFullPath(file);
        int i = 0;
        foreach (var line in File.ReadLines(caminhoAbsoluto))
        {
            var separation = line.Split(',');
            if (separation.Length == 6)
            {

                eName = separation[0];
                eLevel = int.Parse(separation[1]);
                eHealth = int.Parse(separation[2]);
                eAttack = int.Parse(separation[3]);
                eDefense = int.Parse(separation[4]);
                eSpeed = int.Parse(separation[5]);

                enemieslist[i] = new Enemy(eName, eLevel, eHealth, eAttack, eDefense, eSpeed);
                i++;
            }
        }
    }

    public void SaveListedEnemies(string fileDirectory, Enemy [] lista)
    {
        using (StreamWriter sw = new StreamWriter(fileDirectory))
        {
            for (int i = 0; i < lista.Length; i++)
            {
                if (lista[i] != null)
                {
                    sw.WriteLine(lista[i].ToString());
                }
            }
        }
    }

    public void PrintList(Enemy[] list)
    {
        foreach (var enemy in list)
        {
            if (enemy == null) break;
            Console.WriteLine(enemy.ToString());
        }
    }

}
