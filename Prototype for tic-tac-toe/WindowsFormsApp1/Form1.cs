using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        char[,] array2d = new char[3, 3];
        bool turn = true;// true -> X,flase -> O;
        int cells = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            cells++;
            b.Enabled = false;
            if (turn)
                array2d[(b.TabIndex / 3), b.TabIndex % 3] = 'X';
            else
                array2d[(b.TabIndex / 3), b.TabIndex % 3] = 'O';
            Check_For_A_Winner();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            cells = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Text = "";
                    b.Enabled = true;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                            array2d[i, j] = 'c';
                    }
                }
            }
            catch { }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("by: Team*still didn't settle on a name yet*");
        }
        private void Check_For_A_Winner()
        {
            int x = 0, o = 0;
            for (int i = 0; i < 3; i++)
            {
                if ((array2d[i, 0] == 'X' && array2d[i, 1] == 'X' && array2d[i, 2] == 'X') || (array2d[0, i] == 'X' && array2d[1, i] == 'X' && array2d[2, i] == 'X'))
                    x++;
                if ((array2d[i, 0] == 'O' && array2d[i, 1] == 'O' && array2d[i, 2] == 'O') || (array2d[0, i] == 'O' && array2d[1, i] == 'O' && array2d[2, i] == 'O'))
                    o++;
            }
            if ((array2d[1, 1] == 'X' && array2d[2, 2] == 'X' && array2d[0, 0] == 'X') || (array2d[0, 2] == 'X' && array2d[1, 1] == 'X' && array2d[2, 0] == 'X'))
                x++;
            else if ((array2d[1, 1] == 'O' && array2d[2, 2] == 'O' && array2d[0, 0] == 'O') || (array2d[0, 2] == 'O' && array2d[1, 1] == 'O' && array2d[2, 0] == 'O'))
                o++;
            if (x != 0 && o == 0 && cells < 9)
            {
                MessageBox.Show("O WINS!!", "Okaay!!");
            }
            else if (o != 0 && x == 0 && cells < 9)
            {
                MessageBox.Show("X WINS!!", "Okaay!!");
            }
            else if (cells == 9 && o == 0 && x == 0)
            {
                MessageBox.Show("Its A Tie!!", "okaay!!");
            }

        }
    }
}
