using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kółko_i_krzyżyk
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int turn_count = 0;
        static String player1, player2;

        public Form1()
        {
            InitializeComponent();
        }

        public static void setPlayerNames(String n1, String n2)
        {
            player1 = n1;
            player2 = n2;
        }
        private void pomocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jak grać:", "Pomoc");
        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                round_for.Text = player2;
                b.Text = "X";         
            }
            else
            {
                round_for.Text = player1;
                b.Text = "O";
            }
            turn = !turn;
            b.Enabled = false;  
            turn_count++;
            checkForWinner();
        }
        private void checkForWinner()
        {
            bool there_is_a_winner = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                there_is_a_winner = true;

            if (there_is_a_winner)
            {
                disableButtons();
                String winner = "";
                if (turn)
                {
                    winner = player2;
                    o_win.Text = (Int32.Parse(o_win.Text) + 1).ToString();
                }
                else
                {
                    winner = player1;
                    x_win.Text = (Int32.Parse(x_win.Text) + 1).ToString();
                }
                MessageBox.Show("Wygrał gracz: " + winner, "Hura!");
                round_for.Text = "KONIEC";
                
            }
            else
            {
                if (turn_count == 9)
                {
                    round_for.Text = "KONIEC";
                    MessageBox.Show("Remis!", "Ups...");
                    draw.Text = (Int32.Parse(draw.Text) + 1).ToString();
                }
                
            }
            
        }

        private void disableButtons()
        {
            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
                catch { }
            }
        }

        private void nowaGraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            round_for.Text = player1;

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void resetujWynikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x_win.Text = "0";
            o_win.Text = "0";
            draw.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            label3.Text = player1;
            label2.Text = player2;
            round_for.Text = player1;
        }
    }
}
