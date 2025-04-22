using SortingEnemys.enemys;

namespace SortingEnemys.read
{
    public class Reader
    {
        public void Readtxt()
        {
            string file = "enemys/enemys.txt";
            string caminhoAbsoluto = Path.GetFullPath(file);
            string conteudo = File.ReadAllText(caminhoAbsoluto);
            Console.WriteLine(conteudo);
        }
    }
}
