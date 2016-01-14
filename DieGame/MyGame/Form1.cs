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

            Turn result = new Turn();
            result.FirstPlayerResult = FirstPlayer.FaceValue;
            result.SecondPlayerResult = SecondPlayer.FaceValue;

            if (result.FirstPlayerResult > result.SecondPlayerResult)
                result.Winner = "First Player";
            else if (result.FirstPlayerResult < result.SecondPlayerResult)
                result.Winner = "Second Player";
            else
                result.Winner = "Tie Game";

            GamesList.Add(result); // Add an item to the end of the List<T> object
            TurnResultsGridView.DataSource = null; // hack for refreshing the DataGrid
            TurnResultsGridView.DataSource = GamesList;

            UpdateWinResults();
        }

        private void UpdateWinResults()
        {
            int firstTotal = 0, secondTotal = 0;
            //      type varName collection
            //        |    |       |
            //       \_/  \_/     \_/
            foreach(Turn item in GamesList)
            {
                if (item.Winner == "First Player")
                    firstTotal++;
                if (item.Winner == "Second Player")
                    secondTotal++;
            }
            FirstPlayerWinCount.Text = firstTotal.ToString();
            SecondPlayerWinCount.Text = secondTotal.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TurnResultsGridView.DataSource = GamesList;
        }
    }
}
