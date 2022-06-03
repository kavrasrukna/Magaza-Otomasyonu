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
    public partial class raporlar : Form
    {
        public raporlar()
        {
            InitializeComponent();
        }
        magazalarEntities baglanti = new magazalarEntities();
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
            dataGridView1.DataSource = baglanti.sorumlus.ToList();//görüntüler
        }
        private void btnmagaza1_Click(object sender, EventArgs e)
        {
            //Mağaza ile malzemeler tablosunu birleştirip malzemeadi,malzemeadet,malzemebirimfiyat,magazaadini getiren sorgu
            var islem = from magaza in baglanti.magazas  //magaza ve malzeme takma ad lambda
                        join malzeme in baglanti.malzemes
                        on magaza.magazano equals malzeme.magazano
                        select new
                        {
                           magaza.magazaadi,
                           malzeme.malzemeadi,
                           malzeme.malzemeadet,
                           malzeme.malzemebirimfiyat
                        };
            dataGridView1.DataSource = islem.ToList();
        }
        private void btnmagaza2_Click(object sender, EventArgs e)
        {
            // Sorumlular tablosundan sorumlu vardiyaya göre gruplandırıp primlerini getiren sorgu
            var sonuc = baglanti.sorumlus.GroupBy(b => b.sorumluvardiya); //linq ile sorgu
            dataGridView1.DataSource = sonuc.ToList();
        }
        private void btnmagaza3_Click(object sender, EventArgs e)
        {
            //Sorumlular tablosundan sorumlu maasa göre desc sırala
            var sonuc = baglanti.sorumlus.OrderByDescending(x => x.sorumlumaas).ToList();
            dataGridView1.DataSource = sonuc;
        }
        private void btnbolum1_Click(object sender, EventArgs e)
        {
            //Malzeme açıklamaya göre malzeme adını gruplandıran sorgu
            var sonuc = baglanti.malzemes.Where(a => a.malzemeadi == "ceket").GroupBy(b => b.malzemeaciklama); 
            dataGridView1.DataSource = sonuc.ToList();
        }
        private void btnbolum2_Click(object sender, EventArgs e)
        {
            //Sorumlular ile bölümler tablosunu birleştirip sorumluadi,vardiyası,bolumadini getiren sorgu
            var islem = from sorumlu in baglanti.sorumlus
                        join bolum in baglanti.bolumlers
                        on sorumlu.sorumluno equals bolum.sorumluno
                        select new
                        {
                           sorumlu.sorumluadi,
                           sorumlu.sorumluvardiya,
                           bolum.bolumadi
                        };
            dataGridView1.DataSource = islem.ToList();
        }
        private void btnbolum3_Click(object sender, EventArgs e)
        {
            //Mağaza ve sorumlular tablosunu birleştirip magazaadi,magazaciro,sorumlumaas ve primi getiren sorgu
            var islem = from magaza in baglanti.magazas
                        join sorumlu in baglanti.sorumlus
                        on magaza.magazano equals sorumlu.magazano
                        select new
                        {
                            magaza.magazaadi,
                            magaza.magazaciro,
                            sorumlu.sorumlumaas,
                            sorumlu.sorumluprim
                        };
            dataGridView1.DataSource = islem.ToList();
        }
        private void btnmalzemeler1_Click(object sender, EventArgs e)
        {
            //vardiyası gündüz olan sorumluların adlarını sırala--burada vardiyayı nasıl getiricem sorr
            var sonuc2 = baglanti.sorumlus.Where(i => i.sorumluvardiya == "gündüz").GroupBy(i => i.sorumluadi);
            dataGridView1.DataSource = sonuc2.ToList();
        }
        private void btnmalzemeler2_Click(object sender, EventArgs e)
        {
            //Mağaza adlarını asc sırala ve ilk 3 kaydı getir
            List<magaza> kayit1 = baglanti.magazas.OrderBy(p => p.magazaadi).Take(3).ToList();
            dataGridView1.DataSource = kayit1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Toplam malzeme sayısını getiren sorgu
            int toplam = baglanti.malzemes.Count();
            MessageBox.Show(toplam.ToString(), "Toplam Malzeme Sayısı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Malzemeler tablosunda fiyatların toplamını getiren sorgu
            var toplam = baglanti.malzemes.Sum(p => p.malzemebirimfiyat);
            MessageBox.Show(toplam.ToString(), "Malzeme Fiyat Toplamı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
