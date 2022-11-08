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
        public FormMain()
        {
            InitializeComponent();
            word = "стул";
            template = "****";
            labelTemplate.Text = template;
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
            template = tempTemplate;
            labelTemplate.Text = template;
        }

   
    }
}
