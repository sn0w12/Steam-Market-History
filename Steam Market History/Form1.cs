using System;
using System.Windows.Forms;
using System.IO;

namespace Steam_Market_History
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Generate clean output
        private void button1_Click(object sender, EventArgs e)
        {
            string raw = richTextBox1.Text;
            char[] charsToTrim = { '[', ']', '"', '{', '}', ':', };
            if (raw.Length > 63)
            {
                string step1 = raw.Remove(0, 63);
                string step2 = step1.Replace(" 01: +0", "");
                string step3 = step2.Trim(charsToTrim);
                string step4 = step3.Replace('"', ' ');
                string step5 = step4.Replace(" ],[ ", "\n");
                string step6 = step5.Replace(" , ", ",");
                string step7 = step6.Replace(" ,", ",");
                string step8 = step7.Replace(", ", ",");
                string step9 = step8.Replace(",", ";");
                string step10 = step9.Replace(".", ",");
                string step11 = Date(step10);
                string step12 = removeStuff(step11);
                string step13 = step12.Replace(" ;", ";");

                richTextBox2.Text = step13;
            }
            else
            {
                string step2 = raw.Replace(" 01: +0", "");
                string step3 = step2.Trim(charsToTrim);
                string step4 = step3.Replace('"', ' ');
                string step5 = step4.Replace(" ],[ ", "\n");
                string step6 = step5.Replace(" , ", ",");
                string step7 = step6.Replace(" ,", ",");
                string step8 = step7.Replace(", ", ",");
                string step9 = step8.Replace(",", ";");
                string step10 = step9.Replace(".", ",");
                string step11 = Date(step10);
                string step12 = removeStuff(step11);
                string step13 = step12.Replace(" ;", ";");

                richTextBox2.Text = step13;
            }
        }
        //Copy output text
        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox2.TextLength > 0)
                Clipboard.SetText(richTextBox2.Text);
            else
                return;
        }
        //Clear raw and output
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }
        //Load english
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = ("Jan");
            textBox2.Text = ("Feb");
            textBox3.Text = ("Mar");
            textBox4.Text = ("Apr");
            textBox5.Text = ("May");
            textBox6.Text = ("Jun");
            textBox7.Text = ("Jul");
            textBox8.Text = ("Aug");
            textBox9.Text = ("Sep");
            textBox10.Text = ("Oct");
            textBox11.Text = ("Nov");
            textBox12.Text = ("Dec");
        }
        //Load swedish
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = ("Jan");
            textBox2.Text = ("Feb");
            textBox3.Text = ("Mars");
            textBox4.Text = ("Apr");
            textBox5.Text = ("Maj");
            textBox6.Text = ("Juni");
            textBox7.Text = ("Juli");
            textBox8.Text = ("Aug");
            textBox9.Text = ("Sep");
            textBox10.Text = ("Okt");
            textBox11.Text = ("Nov");
            textBox12.Text = ("Dec");
        }
        //Generate market history link
        private void button6_Click(object sender, EventArgs e)
        {
            string input = textBox13.Text;
            string clean = input.Replace("Paste Marketplace link", "");
            if (comboBox1.Text == "Euro")
            {
                if (input.Length > 43)
                {
                    string game = clean.Remove(0, 43);
                    int index = game.IndexOf("/");
                    if (index >= 0)
                        game = game.Substring(0, index);

                    string listing = "listings/" + game + "/";

                    string step1 = clean.Replace(listing, "pricehistory/?country=US&currency=3&appid=730&market_hash_name=");
                    string step2 = step1.Replace("730", game);
                    textBox14.Text = step2;
                }
                else
                {
                    textBox14.Text = "Incorrect URL";
                }
            }
            else if (comboBox1.Text == "Dollar")
            {
                if (input.Length > 43)
                {
                    string game = clean.Remove(0, 43);
                    int index = game.IndexOf("/");
                    if (index >= 0)
                        game = game.Substring(0, index);

                    string listing = "listings/" + game + "/";

                    string step1 = clean.Replace(listing, "pricehistory/?country=US&currency=3&appid=730&market_hash_name=");
                    string step2 = step1.Replace("730", game);
                    string step3 = step2.Replace("currency=3", "currency=1");
                    textBox14.Text = step3;
                }
                else
                {
                    textBox14.Text = "Incorrect URL";
                }
            }
            else
            {
                textBox14.Text = "Choose Euro or Dollar";
            }
        }
        //Copy price history link
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox14.TextLength > 0)
            {
                Clipboard.SetText(textBox14.Text);
            }
            else
            {
                return;
            }
        }
        //Clear marketplace links
        private void button7_Click(object sender, EventArgs e)
        {
            textBox13.Text = "";
            textBox14.Text = "";
        }
        //Replace dates in raw
        private string Date(string input)
        {
            string step1 = input.Replace("Jan", textBox1.Text);
            string step2 = step1.Replace("Feb", textBox2.Text);
            string step3 = step2.Replace("Mar", textBox3.Text);
            string step4 = step3.Replace("Apr", textBox4.Text);
            string step5 = step4.Replace("May", textBox5.Text);
            string step6 = step5.Replace("Jun", textBox6.Text);
            string step7 = step6.Replace("Jul", textBox7.Text);
            string step8 = step7.Replace("Aug", textBox8.Text);
            string step9 = step8.Replace("Sep", textBox9.Text);
            string step10 = step9.Replace("Oct", textBox10.Text);
            string step11 = step10.Replace("Nov", textBox11.Text);
            string step12 = step11.Replace("Dec", textBox12.Text);

            return step12;
        }
        //Remove "00: +0", "01: +0" etc
        private string removeStuff(string input)
        {
            string step1 = input.Replace("00: +0", "");
            for (int i = 99; i >= 0; i--)
            {
                step1 = step1.Replace(i + ": +0", "");
            }
            string step2 = step1.Replace(" 0;", ";");

            return step2;
        }
        //Save custom dates
        private void button9_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + "," + textBox4.Text + "," + textBox5.Text + "," + textBox6.Text + "," + textBox7.Text + "," + textBox8.Text + "," + textBox9.Text + "," + textBox10.Text + "," + textBox11.Text + "," + textBox12.Text + Environment.NewLine;
            using (StreamWriter writetext = new StreamWriter("write.txt"))
            {
                writetext.WriteLine(text);
            }
        }
        //Load custom dates
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader readtext = new StreamReader("write.txt"))
                {
                    string readText = readtext.ReadLine();
                    string[] words = readText.Split(',');
                    textBox1.Text = words[0];
                    textBox2.Text = words[1];
                    textBox3.Text = words[2];
                    textBox4.Text = words[3];
                    textBox5.Text = words[4];
                    textBox6.Text = words[5];
                    textBox7.Text = words[6];
                    textBox8.Text = words[7];
                    textBox9.Text = words[8];
                    textBox10.Text = words[9];
                    textBox11.Text = words[10];
                    textBox12.Text = words[11];
                }
            }
            catch
            {
                richTextBox2.Text = "No saved dates";
            }

        }
        //Clear "Paste Marketplace link" from textbox when you click on it
        private void textBox13_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "Paste Marketplace link")
                textBox13.Text = "";
        }
            
    }
}
