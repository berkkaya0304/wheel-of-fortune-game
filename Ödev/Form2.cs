using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ödev
{
    public partial class Form2 : Form
    {
        GameWheel wheel;
        Random rand;
        string result = "";
        public string[] Oyuncular = new string[4];
        static int oyunsirasi = 0;
        public string[] Puan = new string[7];
        public int[] OyuncuPuan = new int[4];
        public Form2()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);


            this.Shown += new EventHandler(frm_Shown);
            panel.Click += new EventHandler(panel_Click);
            timerRepaint.Tick += new EventHandler(timerRepaint_Tick);
            kelimeleriAta();
            puanlariAta();
            oyunculariAta();
            timerRepaint.Interval = 55;
            rand = new Random();



        }
        Random r = new Random();
        string buluncakKelime = "";
        int resimSayisi = 0;
        string appPath = Path.GetDirectoryName(Application.ExecutablePath);


        #region Kelimeler

        public string[] kelimeler = new string[17];
        public void kelimeleriAta()
        {
            kelimeler[0] = "KUMANDA";
            kelimeler[1] = "TELEVİZYON";
            kelimeler[2] = "BİLGİSAYAR";
            kelimeler[3] = "ARABA";
            kelimeler[4] = "CİNSİYET";
            kelimeler[5] = "PROGRAMLAMA";
            kelimeler[6] = "KOLTUK";
            kelimeler[7] = "BİSİKLET";
            kelimeler[8] = "KAVGA";
            kelimeler[9] = "ARKADAŞLIK";
            kelimeler[10] = "GÖKDENİZ";
            kelimeler[11] = "TUNAHAN";
            kelimeler[12] = "EKMEK";
            kelimeler[13] = "RASTGELE";
            kelimeler[14] = "ÇARKIFELEK";
            kelimeler[15] = "DİREK";
            kelimeler[16] = "OYUNCAK";
        }
        public void puanlariAta()
        {
            Puan[0] = "100";
            Puan[1] = "200";
            Puan[2] = "300";
            Puan[3] = "500";
            Puan[4] = "1000";
            Puan[5] = "1200";//iflas
            Puan[6] = "1400";//pas
        }
        public void oyunculariAta()
        {
            OyuncuPuan[0] = Convert.ToInt32(label5.Text);
            OyuncuPuan[1] = Convert.ToInt32(label6.Text);
            OyuncuPuan[2] = Convert.ToInt32(label11.Text);
            OyuncuPuan[3] = Convert.ToInt32(label8.Text);
        }
        #endregion


        private void Form2_Load(object sender, EventArgs e)
        {
            kelimeleriAta();
            puanlariAta();
            oyunculariAta();
            label14.Text = Oyuncular[oyunsirasi];
        }

        private void btnYKelime_Click(object sender, EventArgs e)
        {
            lblKelime.Text = "";
            buluncakKelime = kelimeler[r.Next(10)];
            for (int i = 0; i < buluncakKelime.Length; i++)
            {
                lblKelime.Text += "?";
            }
            lbDenemeler.Items.Clear();
        }

        private void btnHarfdene_Click(object sender, EventArgs e)
        {
            txtTahminHarf.Text = txtTahminHarf.Text.ToUpper();
            char aranacakChar = char.Parse(txtTahminHarf.Text);
            char[] karakterler = buluncakKelime.ToCharArray();
            bool varmi = false;
            for (int i = 0; i <= lbDenemeler.Items.Count - 1; i++)
            {
                if (lbDenemeler.Items[i].ToString() == aranacakChar.ToString())
                {
                    MessageBox.Show("Bu harf daha önce girilmiştir. Başka Harf deneyin.");
                    return;
                }
            }

            lbDenemeler.Items.Add(aranacakChar.ToString());

            for (int i = 0; i < karakterler.Length; i++)
            {
                if (karakterler[i] == aranacakChar)
                {
                    lblKelime.Text = lblKelime.Text.Remove(i, 1);
                    lblKelime.Text = lblKelime.Text.Insert(i, aranacakChar.ToString());
                    varmi = true;
                    if (varmi == true)
                    {
                        if (label16.Text == Convert.ToString(100))
                        {
                            OyuncuPuan[oyunsirasi] = OyuncuPuan[oyunsirasi] + 100;
                        }
                        else if (label16.Text == Convert.ToString(200))
                        {
                            OyuncuPuan[oyunsirasi] = OyuncuPuan[oyunsirasi] + 200;
                        }
                        else if (label16.Text == Convert.ToString(300))
                        {
                            OyuncuPuan[oyunsirasi] = OyuncuPuan[oyunsirasi] + 300;
                        }
                        else if (label16.Text == Convert.ToString(500))
                        {
                            OyuncuPuan[oyunsirasi] = OyuncuPuan[oyunsirasi] + 500;
                        }
                        else if (label16.Text == Convert.ToString(1000))
                        {
                            OyuncuPuan[oyunsirasi] = OyuncuPuan[oyunsirasi] + 1000;
                        }
                        else if (label16.Text == Convert.ToString(1200))
                        {
                            MessageBox.Show("İflas Ettiniz :(( ");
                            OyuncuPuan[oyunsirasi] = 0;
                            oyunsirasi= oyunsirasi + 1;
                        }
                        else
                        {
                            MessageBox.Show("Bu eli pas geçtiniz :((");
                            oyunsirasi = oyunsirasi + 1;
                        }
                        if (oyunsirasi == 0)
                        {
                            label5.Text = "";
                            label5.Text = Convert.ToString(OyuncuPuan[oyunsirasi]);
                        }
                        if (oyunsirasi == 1)
                        {
                            label6.Text = "";
                            label6.Text = Convert.ToString(OyuncuPuan[oyunsirasi]);
                        }
                        if (oyunsirasi == 2)
                        {
                            label11.Text = "";
                            label11.Text = Convert.ToString(OyuncuPuan[oyunsirasi]);
                        }
                        if (oyunsirasi == 3)
                        {
                            label8.Text = "";
                            label8.Text = Convert.ToString(OyuncuPuan[oyunsirasi]);
                        }
                    }
                }
            }
            
            txtTahminHarf.Text = "";
            
            if (varmi == false)
                {
                    oyunsirasi++;
                    Oyuncular[oyunsirasi] = label14.Text;
                    resimSayisi++;
                    if (resimSayisi == 7)
                    {
                        MessageBox.Show("Bütün Haklarınız doldu oyunu kaybettiniz.");
                        lblKelime.Text = buluncakKelime;
                        return;
                    }
                }
            }

            private void btnTahminEt_Click(object sender, EventArgs e)
            {
                txtTahmin.Text = txtTahmin.Text.ToUpper();
                string tahmin = txtTahmin.Text;
                if (tahmin == buluncakKelime)
                {
                    MessageBox.Show("Kelime'yi bildiniz. TEBRİKLER.");
                    lblKelime.Text = buluncakKelime;
                }
                else
                {
                    MessageBox.Show("YANLIŞ TAHMİN");
                    oyunsirasi = oyunsirasi + 1;
                    label14.Text = Oyuncular[oyunsirasi];
                }
            }

            private void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show(lbDenemeler.Items[0].ToString());
            }

            private void frm_Shown(object sender, EventArgs e)
            {
                panel.Height = 618;
                panel.Width = 600;
                panel.Top = 172;
                panel.Left = 720;
                Point panelCenter = new Point(panel.Width / 2, panel.Height / 2);

                int radius = (this.ClientSize.Height - 50) / 3;
                string[] values = new String[] { "A", "B", "C", "D", "E", "F", "G" };
                wheel = new GameWheel(panelCenter, radius, values);
                wheel.SetGraphics(panel.CreateGraphics());
                wheel.Draw();
            }

            private void panel_Click(object sender, EventArgs e)
            {
                if (wheel.state == GameWheel.STATE_NOT_STARTED)
                {
                    timerRepaint.Start();
                    result = wheel.Spin(ref rand);
                }
            }

            private void timerRepaint_Tick(object sender, EventArgs e)
            {
                wheel.Refresh(true);
            }
            private void button1_Click_1(object sender, EventArgs e)
            {
                timerRepaint.Start();
                string result = wheel.Spin(ref rand);
                int sayi = Convert.ToInt32(Puan[rand.Next(0, 6)]);
                label16.Text = Convert.ToString(sayi);
        }
        }
    }





