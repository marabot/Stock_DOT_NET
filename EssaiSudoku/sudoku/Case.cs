using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku
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

         for (i = 0; i < tabCase.GetLength(1); i++)
            {
                for (j = 0; j < tabCase.GetLength(0); j++)
                {

                    preRemplirCase();
                }
            }

          }



        /// <summary>
        /// remplit de -1
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void preRemplirCase()
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
        /// remplit la case, renvoi 0 si fail, et 1 si réussi
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public bool remplirCase() {
            int num=-1;
            Numeros tabNum = new Numeros();
            bool fail = false;
            i=0;
            

            while ((i < tabCase.GetLength(1))&&fail==false)
            {
                j = 0;
                while ((j < tabCase.GetLength(0)) && fail == false)
                {
                    
                    bool ok = false;
                    while (!ok) {

                        if (tabNum.isAllTested()){
                            ok = true;
                            fail = true;
                        }
                        else{
                               // cherche un chiffre pas encore testé
                                do{
                                num = new Random().Next(1, 10);
                                }while(tabNum.isTested(num));
                        
                                Console.WriteLine("try " + num + " pour [" + i+ ";" + j+"]");
                                // si chiffre pas encore utilisé dans la case, et si conditions valides, on utilise le chiffr dans l'emplacement i, j de la case
                                if (tabNum.isDispo(num) && myGrille.isNumValid(num, i, j, xG, yG))
                                    {
                                            tabCase[i,j] = num;
                                            tabNum.retireNum(num);
                                            ok = true;
                                            Console.WriteLine("ty :" + num  + "pour ["+i +":" + j+"]");                              
                                    }
                                tabNum.getTested(num);
                        }
                    } 
                    j++;
                }
                i++;
            }
            return !fail;
        }

        /// <summary>
        /// retourne la ligne
        /// </summary>
        /// <returns></returns>
        public String AffichageCase()
        {
            String ligne = "";

            for (j = 0; j < tabCase.GetLength(1); j++)
            {
                
                for (i = 0; i < tabCase.GetLength(0); i++)
                {
                    if (i != 2)
                    {
                        ligne = ligne + tabCase[i, j] + "   ";

                    }
                    else
                    {
                        ligne = ligne + tabCase[i, j] +"\r";
                    }
                }
            }
            return ligne;
        }

        /// <summary>
        /// affiche une case dans la console
        /// </summary>
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
                        ligne = ligne + "   " + tabCase[i, j];

                    }
                    else
                    {

                        Console.WriteLine(ligne + "   " + tabCase[i, j]);
                    }
                }
            }

        }

    }
}
