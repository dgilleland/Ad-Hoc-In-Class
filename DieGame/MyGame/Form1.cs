using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// A using statement tells the compiler to allow me access to all the 
// public classes in that namespace
using DieGame; // Now I don't have to type DieGame. (ie., the namespace)

namespace MyGame
{
    public partial class Form1 : Form
    {
        // Properties to hold important objects
        private DieGame.Die FirstPlayer { get; set; }
        private Die SecondPlayer { get; set; }
        private List<Turn> GamesList { get; set; }

        public Form1()
        {
            InitializeComponent();
            // Set up my own property values
            FirstPlayer = new DieGame.Die();
            SecondPlayer = new DieGame.Die();
            GamesList = new List<Turn>();
        }

        private void RollButton_Click(object sender, EventArgs e)
        {
            FirstPlayer.Roll();
            SecondPlayer.Roll();

            Player1.Text = FirstPlayer.FaceValue.ToString();
            Player2.Text = SecondPlayer.FaceValue.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
