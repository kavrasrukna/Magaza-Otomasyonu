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
    public partial class bolum : Form
    {
        public bolum()
        {
            InitializeComponent();
        }
        magazalarEntities baglanti=new magazalarEntities();
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void listele()
        {
            dataGridView1.DataSource = baglanti.bolumlers.ToList();//görüntüler
        }
        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anasayfa git = new anasayfa();
            git.Show();
            this.Hide();
        }
        private void btnraporlar_Click(object sender, EventArgs e)
        {
            raporlar git = new raporlar();
            git.Show();
            this.Hide();
        }  
        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            txtsorumluno.Tag = satir.Cells["bolumno"].Value.ToString();
            txtsorumluno.Text = satir.Cells["sorumluno"].Value.ToString();
            txtbolumadi.Text = satir.Cells["bolumadi"].Value.ToString();
            txtbolumurunsayisi.Text = satir.Cells["bolumurunsayisi"].Value.ToString();          
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            bolumler bolum = new bolumler();
            bolum.sorumluno =Convert.ToInt32(txtsorumluno.Text);
            bolum.bolumadi = txtbolumadi.Text;
            bolum.bolumurunsayisi = Convert.ToInt32(txtbolumurunsayisi.Text);
            baglanti.bolumlers.Add(bolum);
            baglanti.SaveChanges();
            listele();
        }
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int bolno = Convert.ToInt32(txtsorumluno.Tag);
            var guncelle = baglanti.bolumlers.Where(a => a.bolumno == bolno).SingleOrDefault();
            guncelle.sorumluno = Convert.ToInt32(txtsorumluno.Text);
            guncelle.bolumadi = txtbolumadi.Text;
            guncelle.bolumurunsayisi = Convert.ToInt32(txtbolumurunsayisi.Text);
            baglanti.SaveChanges();
            listele();
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            int bolno = Convert.ToInt32(txtsorumluno.Tag);
            var sil = baglanti.bolumlers.Where(x => x.bolumno == bolno).FirstOrDefault();//var değişken tipi tüm değişken tiplerini karşılar ve sqlle form arasında ilişki sağlar.Lambda
            baglanti.bolumlers.Remove(sil);
            baglanti.SaveChanges();
            listele();
        }
        private void btnara_Click(object sender, EventArgs e)
        {
            string aranan = txtbolumadi.Text;
            var degerler = from item in baglanti.bolumlers where item.bolumadi.Contains(aranan) select item;
            dataGridView1.DataSource = degerler.ToList();
        }
        private void azsirala_Click(object sender, EventArgs e)
        {
            List<bolumler> liste1 = baglanti.bolumlers.OrderBy(p => p.bolumadi).ToList();
            //listenin içine <> tablonun adını yazdık,listenin adı ise liste1. bolumler tablomdan
            //listeyi alır ve p diye bir parametre tanımladık lambda ile burada bolum adına göre a->z ye sıralar
            dataGridView1.DataSource = liste1; //liste1 i datagridde gösterir
        }
        private void zasirala_Click(object sender, EventArgs e)
        {
            List<bolumler> liste2 = baglanti.bolumlers.OrderByDescending(p => p.bolumadi).ToList();
            //listenin içine <> tablonun adını yazdık,listenin adı ise liste1. bolumler tablomdan
            //listeyi alır ve p diye bir parametre tanımladık lambda ile burada bolum adına göre z den a ya sıralar
            dataGridView1.DataSource = liste2; //liste1 i datagridde gösterir
        }
    }
}
