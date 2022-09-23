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
            string input = richTextBox1.Text;
            char[] charsToTrim = { '[', ']', '"', '{', '}', ':', };
            if (input.Length > 63)
                input = input.Remove(0, 63);
            input = input.Replace(" 01: +0", "");
            input = input.Trim(charsToTrim);
            input = replaceChar(input);
            input = replaceDate(input);
            input = removeStuff(input);
            input = input.Replace(" ;", ";");

            richTextBox2.Text = input;
        }
        //Copy output text
        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox2.TextLength > 0)
                Clipboard.SetText(richTextBox2.Text);
        }
        //Clear input and output
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }
        //Load dates
        private void dateLoad(string[] dates)
        {
            textBox1.Text = (dates[0]);
            textBox2.Text = (dates[1]);
            textBox3.Text = (dates[2]);
            textBox4.Text = (dates[3]);
            textBox5.Text = (dates[4]);
            textBox6.Text = (dates[5]);
            textBox7.Text = (dates[6]);
            textBox8.Text = (dates[7]);
            textBox9.Text = (dates[8]);
            textBox10.Text = (dates[9]);
            textBox11.Text = (dates[10]);
            textBox12.Text = (dates[11]);
        }
        //Load english
        private void button4_Click(object sender, EventArgs e)
        {
            string[] engDates = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            dateLoad(engDates);
        }
        //Load swedish
        private void button5_Click(object sender, EventArgs e)
        {
            string[] sweDates = { "Jan", "Feb", "Mars", "Apr", "Maj", "Juni", "Juli", "Aug", "Sep", "Okt", "Nov", "Dec" };
            dateLoad(sweDates);
        }
        //Generate market history link
        private void button6_Click(object sender, EventArgs e)
        {
            string input = textBox13.Text;
            string clean = input.Replace("Paste Marketplace link", "");
            if (input.Length > 43)
            {
                string game = clean.Remove(0, 43);
                int index = game.IndexOf("/");
                if (index >= 0)
                    game = game.Substring(0, index);

                string listing = "listings/" + game + "/";

                clean = clean.Replace(listing, "pricehistory/?country=US&currency=3&appid=730&market_hash_name=");
                clean = clean.Replace("730", game);
                if (comboBox1.Text == "Dollar")
                    clean = clean.Replace("currency=3", "currency=1");
                else if (comboBox1.Text == "")
                    clean = "Choose currency";
                textBox14.Text = clean;
            }
            else
                textBox14.Text = "Incorrect URL";
        }
        //Copy price history link
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox14.TextLength > 0)
                Clipboard.SetText(textBox14.Text);
        }
        //Clear marketplace links
        private void button7_Click(object sender, EventArgs e)
        {
            textBox13.Text = "";
            textBox14.Text = "";
        }
        //Replace dates in input
        private string replaceDate(string input)
        {
            input = input.Replace("Jan", textBox1.Text);
            input = input.Replace("Feb", textBox2.Text);
            input = input.Replace("Mar", textBox3.Text);
            input = input.Replace("Apr", textBox4.Text);
            input = input.Replace("May", textBox5.Text);
            input = input.Replace("Jun", textBox6.Text);
            input = input.Replace("Jul", textBox7.Text);
            input = input.Replace("Aug", textBox8.Text);
            input = input.Replace("Sep", textBox9.Text);
            input = input.Replace("Oct", textBox10.Text);
            input = input.Replace("Nov", textBox11.Text);
            input = input.Replace("Dec", textBox12.Text);

            return input;
        }
        //Replace several characters that are bad
        private string replaceChar(string input)
        {
            input = input.Replace('"', ' ');
            input = input.Replace(" ],[ ", "\n");
            input = input.Replace(" , ", ",");
            input = input.Replace(" ,", ",");
            input = input.Replace(", ", ",");
            input = input.Replace(",", ";");
            input = input.Replace(".", ",");

            return input;
        }
        //Remove "00: +0", "01: +0" etc
        private string removeStuff(string input)
        {
            input = input.Replace("00: +0", "");
            for (int i = 99; i >= 0; i--)
                input = input.Replace(i + ": +0", "");

            input = input.Replace(" 0;", ";");

            return input;
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
        //Select default combobox value on load
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}