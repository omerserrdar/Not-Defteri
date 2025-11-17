using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Not_Defteri
{
    public partial class Form1 : Form
    {
        private string gecerliDosyaYolu = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void farkliKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            saveFileDialog1.Filter = "Metin Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
            saveFileDialog1.DefaultExt = "txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    gecerliDosyaYolu = saveFileDialog1.FileName;
                    System.IO.File.WriteAllText(gecerliDosyaYolu, richTextBox1.Text);                  
                    this.Text = System.IO.Path.GetFileName(gecerliDosyaYolu);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya kaydedilirken bir hata oluştu: " + ex.Message);
                }
            }
        }
        

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear(); 
            gecerliDosyaYolu = null; 
            this.Text = "Yeni Not Defteri"; 
        }

        private void acToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            openFileDialog1.Filter = "Metin Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {                   
                    gecerliDosyaYolu = openFileDialog1.FileName;                  
                    string dosyaIcerigi = System.IO.File.ReadAllText(gecerliDosyaYolu);
                    richTextBox1.Text = dosyaIcerigi;                   
                    this.Text = System.IO.Path.GetFileName(gecerliDosyaYolu);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya açılırken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gecerliDosyaYolu))
            {
                farkliKaydetToolStripMenuItem_Click(sender, e);
            }
            else
            {             
                try
                {
                    System.IO.File.WriteAllText(gecerliDosyaYolu, richTextBox1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya kaydedilirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void cikisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
