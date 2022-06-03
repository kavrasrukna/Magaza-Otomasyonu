using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace magazaproje3
{
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anasayfa git = new anasayfa();
            git.Show();
            this.Hide();
        }
        private void btnmagazalar_Click(object sender, EventArgs e)
        {
            magazalar git = new magazalar();
            git.Show();
            this.Hide();
        }
        private void btnmalzemeler_Click(object sender, EventArgs e)
        {
            malzemeler git = new malzemeler();
            git.Show();
            this.Hide();
        }
        private void btnraporlar_Click(object sender, EventArgs e)
        {
            raporlar git = new raporlar();
            git.Show();
            this.Hide();
        }
        private void btnbolumler_Click(object sender, EventArgs e)
        {
            bolum git = new bolum();
            git.Show();
            this.Hide();
        }
        private void btnsorumlular_Click(object sender, EventArgs e)
        {
            sorumlular git = new sorumlular();
            git.Show();
            this.Hide();
        }
    }
}
