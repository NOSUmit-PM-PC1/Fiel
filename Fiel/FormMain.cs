using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fiel
{
    public partial class FormMain : Form
    {
        string word, template;
        int error = 0;
        Random rnd = new Random();

        string MakeStringStars(string word)
        {
            string stars = "";
            foreach (char b in word)
                stars += "*";
            return stars;
        }

        string GenerateNewWord()
        {
            string[] words = { "крокодил", "стул", "молоко", "класс", "пенал", "кенгуру", "якубович", "пилот"};
            int n = rnd.Next(0, words.Length - 1);
            return words[n];
        }
        void NewGame()
        {
            word = "стул";//GenerateNewWord();
            template = MakeStringStars(word);
            labelTemplate.Text = template;
            error = 0;
        }
        public FormMain()
        {
            InitializeComponent();
            NewGame();
        }


        private void textBoxLetter_TextChanged(object sender, EventArgs e)
        {
            if (textBoxLetter.Text.Length == 0)
                buttonOk.Enabled = false;
            else
            {
                buttonOk.Enabled = true;
            }
        }

        private void textBoxLetter_KeyDown(object sender, KeyEventArgs e)
        {
            textBoxLetter.Text = "";

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            /*
            if (textBoxLetter.Text.Length == 0)
            {
                MessageBox.Show("введи букву, кретин!");
                return;
            }
            */

            char letter = textBoxLetter.Text[0];
            string tempTemplate = "";
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == letter)
                    tempTemplate += letter;
                else
                    tempTemplate += template[i];
            }
            if (template == tempTemplate)
            {
                error++;
                if (error > 6)
                {
                    MessageBox.Show("Вы проиграли!");
                }
                else
                {
                    string fileName = "error" + error.ToString() + ".png";
                    pictureBoxError.Load(fileName);
                }
            }
            else
            {
                if (tempTemplate == word)
                {
                    pictureBoxError.Load("win.jpg");
                    if (MessageBox.Show("Вы победили! \n Загадать новое слово?", "Конец игры", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        NewGame();
                    }
                    else
                    {
                        this.Close();
                    }
                    
                }
                else
                {
                    template = tempTemplate;
                    labelTemplate.Text = template;
                }
            }
        }

   
    }
}
