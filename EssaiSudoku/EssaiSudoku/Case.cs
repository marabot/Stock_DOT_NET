using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essaisudoku
{
    class Case
    {
        Grille myGrille;
        int xG = -1;
        int yG = -1;
        int[,] tabCase = new int[3, 3];

        public int[,] TabCase
        {
            get { return tabCase; }
            set { tabCase = value; }
        }


         int i = 0;
         int j = 0;
        Numeros tabNum=new Numeros();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent">grille contenant la case</param>
        /// <param name="myXg">position x de la case sur la grille</param>
        /// <param name="myYg">position x de la case sur la grille</param>
        public Case(Grille parent, int myXg, int myYg) {
            myGrille = parent;
            xG = myXg;
            yG = myYg;

         for (j = 0; j < tabCase.GetLength(1); j++)
            {
                for (i = 0; i < tabCase.GetLength(0); i++)
                {

                    preRemplir(i, j);
                }
            }

          }



        /// <summary>
        /// remplit de -1
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void preRemplir(int i, int j)
        {
            for (j = 0; j < tabCase.GetLength(1); j++)
            {
                for (i = 0; i < tabCase.GetLength(0); i++)
                {
                   tabCase[i, j]=-1;
                    
                    }
                }
            }
        

        /// <summary>
        /// remplit la case (foireux, à revoir et diviser)
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void remplir() {
            int num=-1;
            
            Random rand = new Random();
            bool ok = false;
            int safetyNum = 0;

            for (j = 0; j < tabCase.GetLength(1); j++)
            {
                for (i = 0; i < tabCase.GetLength(0); i++)
                {
                    ok = false;
                    while (!ok && safetyNum<50) {
                        num = rand.Next(1, 10);
                     
                        if (tabNum.isDispo(num)&& myGrille.isNumValid(num, i, j, xG, yG ))
                            {
                                tabCase[i, j] = num;
                                tabNum.retireNum(num);
                                ok = true;
                                Console.WriteLine("ty :"+num);
                            }
                        else
                            {
                                safetyNum++;
                            }            
                    }            
                }
            }
        }

        public void AfficherCase()
        {
            String ligne = "";

            for (j = 0; j < tabCase.GetLength(1); j++)
            {
                ligne = "";
                for (i = 0; i < tabCase.GetLength(0); i++)
                {
                    if (i != 2)
                    {
                        ligne = ligne+ "   " + tabCase[i, j];

                    }
                    else
                    {
                       
                      Console.WriteLine(ligne+ "   " + tabCase[i, j] +"\r");
                    }
                }
            }
            
        }
    }
}
