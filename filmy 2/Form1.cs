using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace filmy_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void DodawanieDanych(string[] dane)
        {
            ListViewItem item = new ListViewItem(dane);
            listView1.Items.Add(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" ||  textBox2.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("¯adne pole nie mo¿e byæ puste!", "Komunikat");
            }
            else
            {
                string[] items = { textBox1.Text, textBox2.Text, dateTimePicker1.Text, textBox4.Text };
                ListViewItem item = new ListViewItem(items);
                listView1.Items.Add(item);
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
            }
        }

        private void UsuwanieDanych()
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
            listView1.Refresh();
        }

        private void usuñWybraneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuwanieDanych();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
        }
        private string[] WierszeDoPliku()
        {
            string[] linie = new string[listView1.Items.Count];
            int i = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                linie[i] = "";
                for (int k = 0; k < item.SubItems.Count; k++)
                {
                    linie[i] += item.SubItems[k].Text + "*";
                }
                i++;
            }
            return linie;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string[] linie = WierszeDoPliku();
            File.WriteAllLines("filmy.txt", linie);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string[] linie = WierszeDoPliku();
            File.WriteAllLines("filmy.txt", linie);
        }
        private void OdczytZPliku()
        {
            if (!File.Exists("filmy.txt"))
            {
                return;
            }
            string[] linie = File.ReadAllLines("filmy.txt");
            foreach (string linia in linie)
            {
                string[] temp = linia.Split('*');
                DodawanieDanych(temp);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            OdczytZPliku();
        }

        private void zmieñToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("¯adne pole nie mo¿e byæ puste!", "Komunikat");
            }
            else
            {
                listView1.SelectedItems[0].SubItems[0].Text = textBox1.Text;
                listView1.SelectedItems[0].SubItems[1].Text = textBox2.Text;
                listView1.SelectedItems[0].SubItems[2].Text = dateTimePicker1.Text;
                listView1.SelectedItems[0].SubItems[3].Text = textBox4.Text;
            }
        }
    }
}