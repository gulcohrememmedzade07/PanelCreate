using System.Media;
namespace PanelCreate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        Random r = new Random();
        Random g = new Random();
        Random b = new Random();

        Random xL = new Random();
        Random yL = new Random();
        int count = 0;
        bool oyunBitdi = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (oyunBitdi == true)
                return;

            count++;
            Panel p = new Panel();
            p.Size = new Size(60, 60);
            p.Tag = "oyunPaneli";
            p.BackColor = Color.FromArgb(r.Next(0, 256), g.Next(0, 256), b.Next(0, 256));
            p.Location = new Point(xL.Next(0, 636), yL.Next(0, 300));
            this.Controls.Add(p);
            pictureBox1.BringToFront();
            label2.Text = count.ToString();

            Toqqusma();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (oyunBitdi == true)
                return;

            pictureBox1.Location = new Point(xL.Next(0, 636), yL.Next(0, 300));

            Toqqusma();
        }

        private void Toqqusma()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel && c.Tag == "oyunPaneli")
                {
                    if (c.Bounds.IntersectsWith(pictureBox1.Bounds))
                    {
                        oyunBitdi = true;
                        SoundPlayer ses = new SoundPlayer("explosion (1).wav");
                        ses.Play();
                        DialogResult cavab = MessageBox.Show("Yeni oyun başlasın?","Oyun bitdi",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (cavab == DialogResult.Yes)
                        {
                            YeniOyun();
                        }
                        break;
                    }
                }
            }
        }

        private void YeniOyun()
        {
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i] is Panel && Controls[i].Tag == "oyunPaneli")
                {
                    Controls.Remove(Controls[i]);
                }
            }

            count = 0;
            label2.Text = "0";

            pictureBox1.Location = new Point(xL.Next(0, 636), yL.Next(0, 300));

            oyunBitdi = false;
        }
    }
}
