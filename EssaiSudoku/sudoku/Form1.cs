using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Grille grille = new Grille();
            Console.WriteLine("grille créée");
         

            int i = 0;
            int j = 0;
        

        /*    for (j = 0; j < grille.TabGrille.GetLength(1); j++)
            {
                for (i = 0; i < grille.TabGrille.GetLength(0); i++)
                {
                    cible = "lab" + i + j;


                    grille.TabGrille[i, j].AfficheCase();
                }
            }*/

            lab11.Text = grille.TabGrille[0, 0].AffichageCase(); 
            lab12.Text = grille.TabGrille[0, 1].AffichageCase();
            lab13.Text = grille.TabGrille[0, 2].AffichageCase();
            lab21.Text = grille.TabGrille[1, 0].AffichageCase();
            lab22.Text = grille.TabGrille[1, 1].AffichageCase();
            lab23.Text = grille.TabGrille[1, 2].AffichageCase();

            lab31.Text = grille.TabGrille[2, 0].AffichageCase();
            lab32.Text = grille.TabGrille[2, 1].AffichageCase();
            lab33.Text = grille.TabGrille[2, 2].AffichageCase();

            Console.WriteLine(grille.TabGrille[0,0].AffichageCase());
            Console.WriteLine(grille.TabGrille[0, 1].AffichageCase());
            Console.ReadLine();
        }
    }
}
