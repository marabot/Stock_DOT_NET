using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku
{
    
   

    class Numeros
    {
        const int NBRE_CASES = 9;

        bool[] tabTestedOrNot = new bool[NBRE_CASES];
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

            for (i = 0; i < tabTestedOrNot.Length; i++)
            {
                tabTestedOrNot[i] = false;
            }
           
        }

        /// <summary>
        /// renvoi 1 si chiffre dispo, 0 si non
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool isDispo(int n)
        {
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

        /// <summary>
        /// renvoi 1 si tous les numéros de la table ont été utilisés
        /// </summary>
        /// <returns></returns>
        public bool isVide(){
            int i=0;
            bool result = true;

            for (i = 0; i < tabNum.Length; i++) { 
                if (tabNum[i]!=-1){
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// retourne 1 si le chiffre a été testé
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool isTested(int n) {
            return tabTestedOrNot[n - 1]; ;
        }

        /// <summary>
        /// renvoi 1 si tout les chiffres ont été testés
        /// </summary>
        /// <returns></returns>
        public bool isAllTested() {
            bool result = true;
            int i=0;
            
            for (i=0;i<tabTestedOrNot.Length;i++){
                if (tabTestedOrNot[i]==false){
                    result=false;
                }
            }
            return result;
        }

        /// <summary>
        /// marque un chiffre comme testé
        /// </summary>
        /// <param name="n"></param>
        public void getTested(int n) {
            tabTestedOrNot[n - 1] = true;
            
        }
   }

}

