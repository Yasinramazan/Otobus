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
   
    public partial class GuzergahOlustur : Form
    {
        Kontrol.BusinessLogicLayer kontrol;
        public GuzergahOlustur()
        {
            InitializeComponent();
            kontrol = new BusinessLogicLayer();
        }

        private void manisa_CheckedChanged(object sender, EventArgs e)
        {
            if (manisa.Checked == true)
                if (!listBox1.Items.Contains(manisa.Text))
                    listBox1.Items.Add(manisa.Text);
                else { }
            else
            {
                listBox1.Items.Remove(manisa.Text);
            }
        }

        private void izmir_CheckedChanged_1(object sender, EventArgs e)
        {
            if (izmir.Checked == true)
                if (!listBox1.Items.Contains(izmir.Text))
                    listBox1.Items.Add(izmir.Text);
                else { }
            else
            {
                listBox1.Items.Remove(izmir.Text);
            }
        }

        private void usak_CheckedChanged_1(object sender, EventArgs e)
        {
            if (usak.Checked == true)
                if (!listBox1.Items.Contains(usak.Text))
                    listBox1.Items.Add(usak.Text);
                else { }
            else
            {
                listBox1.Items.Remove(usak.Text);
            }
        }

        private void aydin_CheckedChanged_1(object sender, EventArgs e)
        {
            if (aydin.Checked == true)
                if (!listBox1.Items.Contains(aydin.Text))
                    listBox1.Items.Add(aydin.Text);
                else { }
            else
            {
                listBox1.Items.Remove(aydin.Text);
            }
        }

        private void denizli_CheckedChanged(object sender, EventArgs e)
        {
            if (denizli.Checked == true)
                if (!listBox1.Items.Contains(denizli.Text))
                    listBox1.Items.Add(denizli.Text);
                else { }
            else
            {
                listBox1.Items.Remove(denizli.Text);
            }
        }

        private void mugla_CheckedChanged_1(object sender, EventArgs e)
        {
            if (mugla.Checked == true)
                if (!listBox1.Items.Contains(mugla.Text))
                    listBox1.Items.Add(mugla.Text);
                else { }
            else
            {
                listBox1.Items.Remove(mugla.Text);
            }
        }

        private void burdur_CheckedChanged_1(object sender, EventArgs e)
        {
            if (burdur.Checked == true)
                if (!listBox1.Items.Contains(burdur.Text))
                    listBox1.Items.Add(burdur.Text);
                else { }
            else
            {
                listBox1.Items.Remove(burdur.Text);
            }
        }

        private void antalya_CheckedChanged_1(object sender, EventArgs e)
        {
            if (antalya.Checked == true)
                if (!listBox1.Items.Contains(antalya.Text))
                    listBox1.Items.Add(antalya.Text);
                else { }
            else
            {
                listBox1.Items.Remove(antalya.Text);
            }
        }

        private void ankara_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ankara.Checked == true)
                if (!listBox1.Items.Contains(ankara.Text))
                    listBox1.Items.Add(ankara.Text);
                else { }
            else
            {
                listBox1.Items.Remove(ankara.Text);
            }
        }

        private void istanbul_CheckedChanged(object sender, EventArgs e)
        {
            if (istanbul.Checked == true)
                if (!listBox1.Items.Contains(istanbul.Text))
                    listBox1.Items.Add(istanbul.Text);
                else { }
            else
            {
                listBox1.Items.Remove(istanbul.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int bayrak = kontrol.guzergahYaz(listBox1.Items.OfType<string>().ToList());
            if (bayrak == 1)
                MessageBox.Show("Güzergah başarıyla eklendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (bayrak == -100)
                MessageBox.Show("Birden fazla şehir seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Sistem Hatası", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }   
    }
}
