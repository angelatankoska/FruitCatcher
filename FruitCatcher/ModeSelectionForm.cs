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
    public partial class ModeSelectionForm: Form
    {
        public ModeSelectionForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ModeSelectionForm_Load(object sender, EventArgs e)
        {

        }

        private void btnStandard_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 gameForm = new Form1(GameMode.Standard);
            gameForm.FormClosed += (s, args) => this.Close();
            gameForm.Show();
        }

        private void btnPoison_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 gameForm = new Form1(GameMode.Poison);
            gameForm.FormClosed += (s, args) => this.Close();
            gameForm.Show();
        }
    }
} 
