using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essaisudoku
{
    
   

    class Numeros
    {
        const int NBRE_CASES = 9;

       
        int[] tabNum = new int[NBRE_CASES];
        int i = 0;

        /// <summary>
        /// constructeur, remplit la table 
        /// </summary>
        public Numeros()
        {
            for (i = 0; i < tabNum.Length; i++)
            {
                tabNum[i] = i + 1;
            }
        }

        /// <summary>
        /// renvoi 1 si chiffre dispo, 0 si non
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool isDispo(int n) {
            bool result = false;

            for (i = 0; i < (NBRE_CASES); i++)
            {
                if (n==tabNum[i]){
                    result = true;
                }
            }

            return result;
        }

       
        /// <summary>
        /// mets à -1 la valeur de la case correspondante au numéro
        /// </summary>
        /// <param name="num"></param>
        public void retireNum(int num){
            tabNum[num-1]=-1;
        }
   }

}

