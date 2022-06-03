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
    public partial class magazalar : Form
    {
        public magazalar()
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
            git.Show();
            this.Hide();
        }
        public void listele()
        {
            dataGridView1.DataSource = baglanti.magazas.ToList();//görüntüler
        }
        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            txtmagazaadi.Tag = satir.Cells["magazano"].Value.ToString();
            txtmagazaadi.Text= satir.Cells["magazaadi"].Value.ToString();
            txtmagazaciro.Text = satir.Cells["magazaciro"].Value.ToString();
            txtmagazaadres.Text = satir.Cells["magazaadres"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["sevkiyattarih"].Value.ToString();
            comboBox1.Text = satir.Cells["sevkiyatgunu"].Value.ToString();
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            magaza magaza = new magaza();
            magaza.magazaadi = txtmagazaadi.Text;
            magaza.magazaciro = txtmagazaciro.Text;
            magaza.magazaadres = txtmagazaadres.Text;
            magaza.sevkiyattarih = dateTimePicker1.Text;//maaş money olduğundan todecimal
            magaza.sevkiyatgunu = comboBox1.Text;
            baglanti.magazas.Add(magaza);
            baglanti.SaveChanges();
            listele();
        }
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int magno = Convert.ToInt32(txtmagazaadi.Tag);
            var guncelle = baglanti.magazas.Where(a => a.magazano == magno).SingleOrDefault();
            guncelle.magazaadi = txtmagazaadi.Text;
            guncelle.magazaciro = txtmagazaciro.Text;
            guncelle.magazaadres =txtmagazaadres.Text;
            guncelle.sevkiyattarih = dateTimePicker1.Text;
            guncelle.sevkiyatgunu = comboBox1.Text;
            baglanti.SaveChanges();
            listele();
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            int magno = Convert.ToInt32(txtmagazaadi.Tag);
            var sil = baglanti.magazas.Where(x => x.magazano == magno).FirstOrDefault();//var değişken tipi tüm değişken tiplerini karşılar ve sqlle form arasında ilişki sağlar.Lambda
            baglanti.magazas.Remove(sil);
            baglanti.SaveChanges();
            listele();
        }
        private void btnraporlar_Click(object sender, EventArgs e)
        {
            raporlar git = new raporlar();
            git.Show();
            this.Hide();
        }
        private void btnara_Click(object sender, EventArgs e)
        {
            //string aranan = txtmagazaadi.Text;
            //var degerler=from item in baglanti.magazas where item.magazaadi.Contains(aranan)  select item;
            //dataGridView1.DataSource = degerler.ToList();

            //2.arama işlemi büyük ve küçük harfe uyumlu
            dataGridView1.DataSource=baglanti.magazas.Where(x=>x.magazaadi.ToLower().Contains(txtmagazaadi.Text)|| x.magazaadi.ToUpper().Contains(txtmagazaadi.Text)).ToList();                                     
        }

        private void azsirala_Click(object sender, EventArgs e)
        {
            List<magaza> liste1 = baglanti.magazas.OrderBy(p => p.magazaadi).ToList();
            //listenin içine <> tablonun adını yazdık,listenin adı ise liste1. mağaza tablomdan
            //listeyi alır ve p diye bir parametre tanımladık lambda ile burada mağaza adına göre a->z ye sıralar
            dataGridView1.DataSource = liste1; //liste1 i datagridde gösterir
        }

        private void zasirala_Click(object sender, EventArgs e)
        {
            List<magaza> liste2 = baglanti.magazas.OrderByDescending(p => p.magazaadi).ToList();
            //listenin içine <> tablonun adını yazdık,listenin adı ise liste1. magaza tablomdan
            //listeyi alır ve p diye bir parametre tanımladık lambda ile burada magaza adına göre z den a ya sıralar
            dataGridView1.DataSource = liste2; //liste1 i datagridde gösterir
        }
    }
}
