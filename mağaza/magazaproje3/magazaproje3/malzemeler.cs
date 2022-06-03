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
    public partial class malzemeler : Form
    {
        public malzemeler()
        {
            InitializeComponent();
        }
        magazalarEntities baglanti = new magazalarEntities();
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void listele()
        {
            dataGridView1.DataSource = baglanti.malzemes.ToList();//görüntüler
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
            txtmagno.Tag = satir.Cells["malzemeno"].Value.ToString();//COMBOBOXA DATADAN GETİRME İŞLEMİ
            txtmagno.Text = satir.Cells["magazano"].Value.ToString();
            txtmalzemeadi.Text = satir.Cells["malzemeadi"].Value.ToString();
            txtmadet.Text = satir.Cells["malzemeadet"].Value.ToString();
            txtbirimfiyat.Text = satir.Cells["malzemebirimfiyat"].Value.ToString();
            txtmalzemekod.Text = satir.Cells["malzemekod"].Value.ToString();
            txtmalzemeaciklama.Text = satir.Cells["malzemeaciklama"].Value.ToString();
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            malzeme malzeme = new malzeme();
            malzeme.magazano = Convert.ToInt32(txtmagno.Text);
            malzeme.malzemeadi = txtmalzemeadi.Text;
            malzeme.malzemeadet =Convert.ToInt32( txtmadet.Text);
            malzeme.malzemebirimfiyat = Convert.ToDecimal(txtbirimfiyat.Text);
            malzeme.malzemekod = txtmalzemekod.Text;
            malzeme.malzemeaciklama = txtmalzemeaciklama.Text;
            baglanti.malzemes.Add(malzeme);
            baglanti.SaveChanges();
            listele();
        }
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int malno =Convert.ToInt32( txtmagno.Tag);
            var guncelle = baglanti.malzemes.Where(a => a.malzemeno == malno).SingleOrDefault();
            guncelle.magazano = Convert.ToInt32(txtmagno.Text);
            guncelle.malzemeadi = txtmalzemeadi.Text;
            guncelle.malzemeadet = Convert.ToInt32(txtmadet.Text);
            guncelle.malzemebirimfiyat = Convert.ToDecimal(txtbirimfiyat.Text);
            guncelle.malzemekod =txtmalzemekod.Text;
            guncelle.malzemeaciklama = txtmalzemeaciklama.Text;
            baglanti.SaveChanges();
            listele();
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            int magno = Convert.ToInt32(txtmagno.Tag);
            var sil = baglanti.malzemes.Where(x => x.malzemeno == magno).FirstOrDefault();//var değişken tipi tüm değişken tiplerini karşılar ve sqlle form arasında ilişki sağlar.Lambda
            baglanti.malzemes.Remove(sil);
            baglanti.SaveChanges();
            listele();
        }
        private void btnara_Click(object sender, EventArgs e)
        {
            string aranan = txtmalzemeadi.Text;
            var degerler = from item in baglanti.malzemes where item.malzemeadi.Contains(aranan) select item;
            dataGridView1.DataSource = degerler.ToList();
        }
        private void azsirala_Click(object sender, EventArgs e)
        {
            List<malzeme> liste1 = baglanti.malzemes.OrderBy(p => p.malzemeadi).ToList();
            //listenin içine <> tablonun adını yazdık,listenin adı ise liste1. malzeme tablomdan
            //listeyi alır ve p diye bir parametre tanımladık lambda ile burada malzeme adına göre a->z ye sıralar
            dataGridView1.DataSource = liste1; //liste1 i datagridde gösterir
        }
        private void zasirala_Click(object sender, EventArgs e)
        {
            List<malzeme> liste2 = baglanti.malzemes.OrderByDescending(p => p.malzemeadi).ToList();
            //listenin içine <> tablonun adını yazdık,listenin adı ise liste1. malzeme tablomdan
            //listeyi alır ve p diye bir parametre tanımladık lambda ile burada malzeme adına göre z den a ya sıralar
            dataGridView1.DataSource = liste2; //liste1 i datagridde gösterir
        }
    }
}
