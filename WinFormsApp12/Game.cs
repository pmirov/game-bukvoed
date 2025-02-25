using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp12
{
    internal class Game
    {
        private string[,] grid;
        public List<Button> ListButton { get; private set; }
        private Random randomizer;
        private string[] checkAnswer;
        public Game()
        {
            grid = new string[3, 3];
            randomizer = new Random();
            ListButton = GeneratorButtons.Create(9, 3);
            string index = "ФЫАКЯЧСОТ";
            char[] ind = index.ToCharArray();
            int i = 0;
            foreach (var button in ListButton)
            {
                
                button.Text = Convert.ToString(ind[i]);
                i++;
            }
            Shuffle();

        }
        private void Shuffle()
        {
            for (int i = 0; i < ListButton.Count; i++)
            {
                int index = randomizer.Next(0, ListButton.Count);
                var temp = ListButton[i].Text;
                ListButton[i].Text = ListButton[index].Text;
                ListButton[index].Text = temp;
            }

            int ind = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = ListButton[ind].Text;
                    ind++;
                    if (grid[i, j] == "Т")
                    {
                        i9 = i;
                        j9 = j;
                    }
                }
        }

        public void Check(string value)
        {
            checkAnswer = new string[3];
            
            if (grid[1,0] == "К" && value == "К")
            {
                checkAnswer[0] = "К";
            }
            if (grid[1, 1] == "О" && value == "О")
            {
                checkAnswer[1] = "О";
            }
            if (grid[1, 2] == "Т" && value == "Т")
            {
                checkAnswer[2] = "Т";
            }
            CheckWin();

        }
        public void CheckWin()
        {

            if (checkAnswer[0] == "К" && checkAnswer[1] == "О" && checkAnswer[2] == "Т")
            {
                MessageBox.Show("Вы победили!");
            }
        }

        private int i9;
        private int j9;
        public void Step(string value)
        {
            if (i9 - 1 >= 0)
            {
                if (grid[i9 - 1, j9] == value)
                {
                    grid[i9 - 1, j9] = "Т";
                    grid[i9, j9] = value;
                }
            }
            if (i9 + 1 <= 3)
            {
                if (grid[i9 + 1, j9] == value)
                {
                    grid[i9 + 1, j9] = "Т";
                    grid[i9, j9] = value;
                }
            }
            if (j9 + 1 <= 3)
            {
                if (grid[i9, j9 + 1] == value)
                {
                    grid[i9, j9 + 1] = "Т";
                    grid[i9, j9] = value;
                }
            }
            if (j9 - 1 >= 0)
            {
                if (grid[i9, j9 - 1] == value)
                {
                    grid[i9, j9 - 1] = "Т";
                    grid[i9, j9] = value;
                }
            }
            Update();
            //Win();
        }

        private void Update()
        {

            int index = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ListButton[index].Text = grid[i, j];
                    //if (ListButton[index].Text == "Т")
                    //{
                    //    ListButton[index].Visible = false;
                    //    i9 = i;
                    //    j9 = j;
                    //}
                    //else
                    //{
                    //    ListButton[index].Visible = true;
                    //}
                    index++;
                }

            }

        }

        //public void CheckWin()
        //{

        //    if (grid[1, 0] == "К" && grid[1, 1] == "О" && grid[1, 2] == "Т")
        //    {
        //        MessageBox.Show("Вы победили!");
        //    }
        //}

        //private void ResetGame()
        //{
        //    foreach (Button button in buttons)
        //    {
        //        button.Enabled = true;
        //    }
        //}
        //private void Win()
        //{
        //    int index = 1;
        //    foreach (var item in ListButton)
        //    {
        //        if (item.Text == index.ToString())
        //        {
        //            index++;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //    if (index >= 9)
        //    {
        //        foreach (var item in ListButton)
        //        {
        //            item.BackColor = Color.GreenYellow;
        //            item.Visible = true;
        //            item.Enabled = false;
        //        }
        //    }
        //}



    }
}
