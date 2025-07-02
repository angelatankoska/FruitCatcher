using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FruitCatcher
{
    public partial class GameOverForm: Form
    {
        private readonly int score;
        private readonly GameMode mode;
        private readonly int fruitsCaught;
        private readonly int timeRemaining;


        public GameOverForm(int score, GameMode mode, int fruitsCaught, int timeRemaining)
        {
            InitializeComponent();
            this.score = score;
            this.mode = mode;
            this.fruitsCaught = fruitsCaught;
            this.timeRemaining = timeRemaining;
            this.StartPosition = FormStartPosition.CenterScreen;
            tbScore.Text = "Score: " + score;
            SetScoreValue();
            this.ActiveControl = null;
        }


        private void SetScoreValue()
        {
            tbScore.Text = "Score: " + score;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChooseMode_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 gameForm = new Form1(mode);
            gameForm.FormClosed += (s, args) => this.Close();
            gameForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ModeSelectionForm modeForm = new ModeSelectionForm();
            modeForm.FormClosed += (s, args) => this.Close();
            modeForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void GameOverForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbScore_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
