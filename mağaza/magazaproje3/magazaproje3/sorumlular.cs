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
    public partial class sorumlular : Form
    {
        public sorumlular()
        {
            InitializeComponent();
        }
        magazalarEntities baglanti=new magazalarEntities();
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anasayfa git = new anasayfa();
            git.ShowDialog();
            this.Hide();
        }
        private void btnraporlar_Click(object sender, EventArgs e)
        {
            raporlar git = new raporlar();
            git.Show();
            this.Hide();
        }
        public void listele()
        {
            dataGridView1.DataSource = baglanti.sorumlus.ToList();//görüntüler
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
           txtmagazano.Tag = satir.Cells["sorumluno"].Value.ToString();//COMBOBOXA DATADAN GETİRME İŞLEMİ
            txtmagazano.Text = satir.Cells["magazano"].Value.ToString();
            txtsorumluadi.Text = satir.Cells["sorumluadi"].Value.ToString();
            txtsorumlumaas.Text = satir.Cells["sorumlumaas"].Value.ToString();//COMBOBOXA DATADAN GETİRME İŞLEMİ
            txtsorumluprim.Text = satir.Cells["sorumluprim"].Value.ToString();
            comboBox2.Text = satir.Cells["sorumluvardiya"].Value.ToString();
        }
        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            sorumlu sorumlu = new sorumlu();
            sorumlu.magazano = Convert.ToInt32(txtmagazano.Text);
            sorumlu.sorumluadi = txtsorumluadi.Text;
            sorumlu.sorumlumaas = Convert.ToDecimal(txtsorumlumaas.Text);
            sorumlu.sorumluprim = Convert.ToDecimal(txtsorumluprim.Text);
            sorumlu.sorumluvardiya = comboBox2.Text;
            baglanti.sorumlus.Add(sorumlu);
            baglanti.SaveChanges();
            listele();
        }
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int sorno = Convert.ToInt32(txtmagazano.Tag);
            var guncelle = baglanti.sorumlus.Where(a => a.sorumluno == sorno).SingleOrDefault();
            guncelle.magazano = Convert.ToInt32(txtmagazano.Text);
            guncelle.sorumluadi = txtsorumluadi.Text;
            guncelle.sorumlumaas = Convert.ToDecimal(txtsorumlumaas.Text);
            guncelle.sorumluprim = Convert.ToDecimal(txtsorumluprim.Text);
            guncelle.sorumluvardiya = comboBox2.Text;
            baglanti.SaveChanges();
            listele();
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            int sorno = Convert.ToInt32(txtmagazano.Tag);
            var sil = baglanti.sorumlus.Where(x => x.sorumluno == sorno).FirstOrDefault();//var değişken tipi tüm değişken tiplerini karşılar ve sqlle form arasında ilişki sağlar.Lambda
            baglanti.sorumlus.Remove(sil);
            baglanti.SaveChanges();
            listele();
        }
        private void btnara_Click(object sender, EventArgs e)
        {
            string aranan = txtsorumluadi.Text;
            var degerler = from item in baglanti.sorumlus where item.sorumluadi.Contains(aranan) select item;
            dataGridView1.DataSource = degerler.ToList();
        }
        private void azsirala_Click(object sender, EventArgs e)
        {
            List<sorumlu> liste1 = baglanti.sorumlus.OrderBy(p => p.sorumluadi).ToList();
            //listenin içine <> tablonun adını yazdık,listenin adı ise liste1. sorumlu tablomdan
            //listeyi alır ve p diye bir parametre tanımladık lambda ile burada sorumlu adına göre a->z ye sıralar
            dataGridView1.DataSource = liste1; //liste1 i datagridde gösterir
        }
        private void zasirala_Click(object sender, EventArgs e)
        {
            List<sorumlu> liste2 = baglanti.sorumlus.OrderByDescending(p => p.sorumluadi).ToList();
            //listenin içine <> tablonun adını yazdık,listenin adı ise liste1. sorumlu tablomdan
            //listeyi alır ve p diye bir parametre tanımladık lambda ile burada sorumlu adına göre z den a ya sıralar
            dataGridView1.DataSource = liste2; //liste1 i datagridde gösterir
        }
    }
}
