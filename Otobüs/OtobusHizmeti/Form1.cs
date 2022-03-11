using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kontrol;

namespace OtobusHizmeti
{
    public partial class Form1 : Form
    {
        BusinessLogicLayer BLL;
        public Form1()
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GuzergahOlustur go = new GuzergahOlustur();
            go.Show();
            this.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] sehirListesi = { "Denizli", "İzmir", "Uşak", "Muğla", "Aydın", "Antalya", "Ankara", "İstanbul", "Burdur", "Manisa" };
            baslangic.Items.AddRange(sehirListesi);
            bitis.Items.AddRange(sehirListesi);
            
            int a = 2; 
            for (int i = 1; i < 21; i++)
            {
                Button btn = new Button();
                btn.Size = new Size(50, 50);
                btn.BackColor = Color.Empty;
                btn.Click += Btn_Click;
                flowLayoutPanel1.Controls.Add(btn);
                btn.Text = a.ToString();
                if (i % 2 == 0)
                    a += 2;
                else
                    a++;
            }
            a = 1;
            for (int i = 1; i < 11; i++)
            {
                Button btn = new Button();
                btn.Size = new Size(50, 50);
                btn.BackColor = Color.Empty;
                btn.Click += Btn_Click;
                flowLayoutPanel2.Controls.Add(btn);
                btn.Text = a.ToString();
                a += 3;
            }

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int bayrak;
            if (seferler.SelectedItem != null)
            {
                if (btn.BackColor != Color.Red)
                    bayrak = BLL.musteriEkle(btn.Text, baslangic.SelectedItem.ToString(), bitis.SelectedItem.ToString(),
                        ad.Text, soyad.Text, tc.Text, seferler.SelectedItem);
                else
                    bayrak = -2;
            }
            else
                bayrak = -100;


            if (bayrak == 1)
                MessageBox.Show("İşlem başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (bayrak == -100)
                MessageBox.Show("Doldurulmayan yerler var", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (bayrak == -2)
                MessageBox.Show("Dolu bir koltuk seçtiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Sistem Hatası", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void baslangic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(bitis.SelectedIndex>-1)
            {
                seferler.DataSource=BLL.guzergahGetir(baslangic.Text,bitis.Text);
                
            }
        }

        private void bitis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (baslangic.SelectedIndex > -1)
            {
                seferler.DataSource = BLL.guzergahGetir(baslangic.Text, bitis.Text);
            }
        }

        private void seferler_SelectedIndexChanged(object sender, EventArgs e)
        { 
            Button btn = new Button();
            Entities.OtobusBilgileri o = (Entities.OtobusBilgileri)seferler.SelectedItem;
            List<string> k = BLL.koltukGetir(o.OtobusID,baslangic.Text,bitis.Text);

            foreach (Control item in flowLayoutPanel1.Controls)
            {
                btn = (Button)item;
                if (k.Contains(item.Text))
                {
                    btn.BackColor = Color.Red;
                }
                else
                {
                    btn.BackColor = Color.Empty;    
                }

            }


            foreach (Control item in flowLayoutPanel2.Controls)
            {
                btn = (Button)item;
                if (k.Contains(item.Text))
                {
                    btn.BackColor = Color.Red;
                }
                else
                {
                    btn.BackColor = Color.Empty;
                }

            }
        }
    }
}
