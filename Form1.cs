namespace GorselProgramlamaFinalOdev
{
    public partial class Form1 : Form
    {
        Label etk1 = null;
        Label etk2 = null;
        Random random = new Random();
        List<string> icon = new List<string>()
        {
            "!","!",",",",","N","N","k","k","b","b","v","v","w","w","z","z"
        };
        private void HucrelereResimAta()
        {
            foreach (Control etk in tableLayoutPanel1.Controls)
            {
                Label resEtk = etk as Label;
                if (resEtk != null)
                {
                    int rs = random.Next(icon.Count);
                    resEtk.Text = icon[rs];
                    resEtk.ForeColor = resEtk.BackColor;
                    icon.RemoveAt(rs);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            HucrelereResimAta();
        }

        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true) 
            {
                return;
            }
            Label secilen = sender as Label;
            if (secilen != null)
            {
                if (secilen.ForeColor == Color.Black)
                {
                    return;
                }
                if (etk1 == null)
                {
                    etk1 = secilen;
                    etk1.ForeColor = Color.Black;
                    return;
                }
                etk2 = secilen;
                etk2.ForeColor = Color.Black;
                oyunBittimi();
                if (etk1.Text == etk2.Text) 
                {
                    etk1 = null;
                    etk2 = null;
                    return;
                }
                timer1.Start();


            }
        }
        private void oyunBittimi() 
        {
            foreach(Control etk in tableLayoutPanel1.Controls) 
            {
                Label resEtk = etk as Label;
                if(resEtk!= null) 
                {
                    if(resEtk.ForeColor== resEtk.BackColor) { return; }
                }
            }
            MessageBox.Show("Oyun Bitti!");
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            etk1.ForeColor = etk1.BackColor;
            etk2.ForeColor = etk2.BackColor;
            etk1 = null;
            etk2 = null;
        }
    }
}
