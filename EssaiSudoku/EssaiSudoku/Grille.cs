using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essaisudoku
{
    
    class Grille
    {
        Case[,] tabGrille = new Case[3, 3];

        internal Case[,] TabGrille
        {
            get { return tabGrille; }
            set { tabGrille = value; }
        }

       

        public Grille()
        {
            int i = 0;
            int j = 0;

            for (j = 0; j < tabGrille.GetLength(1); j++)
            {
                for (i = 0; i < tabGrille.GetLength(0); i++)
                {
                    tabGrille[i, j] = new Case(this, i, j);          
                } 
            }

            remplirAvecNum();

        }


        /// <summary>
        /// parcours le tableau et le remplit de chiffres cohérents
        /// </summary>
        private void remplirAvecNum()
        {
            int i = 0;
            int j = 0;
            
            for (j = 0; j < tabGrille.GetLength(1); j++)
            {
                for (i = 0; i < tabGrille.GetLength(0); i++)
                {
                    tabGrille[i, j].remplir();
                }
            }
        }



        public bool isNumValid(int num, int xc, int yc, int xg, int yg) {
            int k = 0;
            int l = 0;
            int i = 0;
            int j = 0;
            bool result = true;

            for (j = 0; j < tabGrille.GetLength(1); j++)
            {
                for (i = 0; i < tabGrille.GetLength(0); i++)
                {
                    for (k = 0; k < tabGrille[i, j].TabCase.GetLength(1); k++)
                    {
                        for (l = 0; l < tabGrille[i, j].TabCase.GetLength(0); l++)
                        {
                            if (xg == i && yg == j && xc == k && yc == l) {
                                if (num == tabGrille[i, j].TabCase[k, l]) {
                                   result = false;        
                                }                         
                            }                              
                        }
                    }
                }
            }
          return result;
        }

        public void AfficherGrille(Object o){
             
        
        }


    }
}
