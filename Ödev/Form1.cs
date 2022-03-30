namespace Ödev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            Form2 f2 = new Form2();
            Form2 frm2 = new Form2();
            f1.Visible = false;
            f2.label1.Text = textBox1.Text;
            f2.label2.Text = textBox2.Text;
            f2.label12.Text = textBox4.Text;
            f2.label10.Text = textBox5.Text;
            f2.Oyuncular[0] = textBox1.Text;
            f2.Oyuncular[1] = textBox2.Text;
            f2.Oyuncular[2] = textBox4.Text;
            f2.Oyuncular[3] = textBox5.Text;
            f2.ShowDialog();
        }
    }
}