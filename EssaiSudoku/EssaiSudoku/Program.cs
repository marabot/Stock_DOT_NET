using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Essaisudoku
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            Grille grille = new Grille();
            Console.WriteLine("grille créée");
            grille.TabGrille[0, 1].AffichageCase();
            Console.ReadLine();
        }
    }
}
