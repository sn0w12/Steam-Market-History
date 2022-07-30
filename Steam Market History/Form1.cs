using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using System.Diagnostics;

namespace Steam_Market_History
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, System.Drawing.Color.FromArgb(28, 33, 45), ButtonBorderStyle.Solid);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string raw = richTextBox1.Text;
            char[] charsToTrim = { '[', ']', '"', '{', '}', ':', };
            if (raw.Length > 64)
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
                string step11 = step10.Replace("Jan", textBox1.Text);
                string step12 = step11.Replace("Feb", textBox2.Text);
                string step13 = step12.Replace("Mar", textBox3.Text);
                string step14 = step13.Replace("Apr", textBox4.Text);
                string step15 = step14.Replace("May", textBox5.Text);
                string step16 = step15.Replace("Jun", textBox6.Text);
                string step17 = step16.Replace("Jul", textBox7.Text);
                string step18 = step17.Replace("Aug", textBox8.Text);
                string step19 = step18.Replace("Sep", textBox9.Text);
                string step20 = step19.Replace("Oct", textBox10.Text);
                string step21 = step20.Replace("Nov", textBox11.Text);
                string step22 = step21.Replace("Dec", textBox12.Text);
                string step23 = removeStuff(step22);
                string step24 = step23.Replace(" ;", ";");

                richTextBox2.Text = step24;
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
                string step11 = step10.Replace("Jan", textBox1.Text);
                string step12 = step11.Replace("Feb", textBox2.Text);
                string step13 = step12.Replace("Mar", textBox3.Text);
                string step14 = step13.Replace("Apr", textBox4.Text);
                string step15 = step14.Replace("May", textBox5.Text);
                string step16 = step15.Replace("Jun", textBox6.Text);
                string step17 = step16.Replace("Jul", textBox7.Text);
                string step18 = step17.Replace("Aug", textBox8.Text);
                string step19 = step18.Replace("Sep", textBox9.Text);
                string step20 = step19.Replace("Oct", textBox10.Text);
                string step21 = step20.Replace("Nov", textBox11.Text);
                string step22 = step21.Replace("Dec", textBox12.Text);
                string step23 = removeStuff(step22);
                string step24 = step23.Replace(" ;", ";");

                richTextBox2.Text = step24;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox2.TextLength > 0)
            {
                Clipboard.SetText(richTextBox2.Text);
            }
            else
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }

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

        private void button6_Click(object sender, EventArgs e)
        {
            string input = textBox13.Text;
            string clean = input.Replace("Paste Marketplace link", "");
            if (checkBox1.Checked && checkBox2.Checked)
            {
                textBox14.Text = "Choose Euro or Dollar";
            }
            else if (checkBox1.Checked)
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
            else if (checkBox2.Checked)
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

        private void button7_Click(object sender, EventArgs e)
        {
            textBox13.Text = "";
            textBox14.Text = "";
        }

        //crazy shitty code
        private string removeStuff(string input)
        {
            string step = input.Replace("00: +0", "");
            string step99 = step.Replace("99: +0", "");
            string step98 = step99.Replace("98: +0", "");
            string step97 = step98.Replace("97: +0", "");
            string step96 = step97.Replace("96: +0", "");
            string step95 = step96.Replace("95: +0", "");
            string step94 = step95.Replace("94: +0", "");
            string step93 = step94.Replace("93: +0", "");
            string step92 = step93.Replace("92: +0", "");
            string step91 = step92.Replace("91: +0", "");
            string step90 = step91.Replace("90: +0", "");
            string step89 = step90.Replace("89: +0", "");
            string step88 = step89.Replace("88: +0", "");
            string step87 = step88.Replace("87: +0", "");
            string step86 = step87.Replace("86: +0", "");
            string step85 = step86.Replace("85: +0", "");
            string step84 = step85.Replace("84: +0", "");
            string step83 = step84.Replace("83: +0", "");
            string step82 = step83.Replace("82: +0", "");
            string step81 = step82.Replace("81: +0", "");
            string step80 = step81.Replace("80: +0", "");
            string step79 = step80.Replace("79: +0", "");
            string step78 = step79.Replace("78: +0", "");
            string step77 = step78.Replace("77: +0", "");
            string step76 = step77.Replace("76: +0", "");
            string step75 = step76.Replace("75: +0", "");
            string step74 = step75.Replace("74: +0", "");
            string step73 = step74.Replace("73: +0", "");
            string step72 = step73.Replace("72: +0", "");
            string step71 = step72.Replace("71: +0", "");
            string step70 = step71.Replace("70: +0", "");
            string step69 = step70.Replace("69: +0", "");
            string step68 = step69.Replace("68: +0", "");
            string step67 = step68.Replace("67: +0", "");
            string step66 = step67.Replace("66: +0", "");
            string step65 = step66.Replace("65: +0", "");
            string step64 = step65.Replace("64: +0", "");
            string step63 = step64.Replace("63: +0", "");
            string step62 = step63.Replace("62: +0", "");
            string step61 = step62.Replace("61: +0", "");
            string step60 = step61.Replace("60: +0", "");
            string step59 = step60.Replace("59: +0", "");
            string step58 = step59.Replace("58: +0", "");
            string step57 = step58.Replace("57: +0", "");
            string step56 = step57.Replace("56: +0", "");
            string step55 = step56.Replace("55: +0", "");
            string step54 = step55.Replace("54: +0", "");
            string step53 = step54.Replace("53: +0", "");
            string step52 = step53.Replace("52: +0", "");
            string step51 = step52.Replace("51: +0", "");
            string step50 = step51.Replace("50: +0", "");
            string step49 = step50.Replace("49: +0", "");
            string step48 = step49.Replace("48: +0", "");
            string step47 = step48.Replace("47: +0", "");
            string step46 = step47.Replace("46: +0", "");
            string step45 = step46.Replace("45: +0", "");
            string step44 = step45.Replace("44: +0", "");
            string step43 = step44.Replace("43: +0", "");
            string step42 = step43.Replace("42: +0", "");
            string step41 = step42.Replace("41: +0", "");
            string step40 = step41.Replace("40: +0", "");
            string step39 = step40.Replace("39: +0", "");
            string step38 = step39.Replace("38: +0", "");
            string step37 = step38.Replace("37: +0", "");
            string step36 = step37.Replace("36: +0", "");
            string step35 = step36.Replace("35: +0", "");
            string step34 = step35.Replace("34: +0", "");
            string step33 = step34.Replace("33: +0", "");
            string step32 = step33.Replace("32: +0", "");
            string step31 = step32.Replace("31: +0", "");
            string step30 = step31.Replace("30: +0", "");
            string step29 = step30.Replace("29: +0", "");
            string step28 = step29.Replace("28: +0", "");
            string step27 = step28.Replace("27: +0", "");
            string step26 = step27.Replace("26: +0", "");
            string step25 = step26.Replace("25: +0", "");
            string step24 = step25.Replace("24: +0", "");
            string step23 = step24.Replace("23: +0", "");
            string step22 = step23.Replace("22: +0", "");
            string step21 = step22.Replace("21: +0", "");
            string step20 = step21.Replace("20: +0", "");
            string step19 = step20.Replace("19: +0", "");
            string step18 = step19.Replace("18: +0", "");
            string step17 = step18.Replace("17: +0", "");
            string step16 = step17.Replace("16: +0", "");
            string step15 = step16.Replace("15: +0", "");
            string step14 = step15.Replace("14: +0", "");
            string step13 = step14.Replace("13: +0", "");
            string step12 = step13.Replace("12: +0", "");
            string step11 = step12.Replace("11: +0", "");
            string step10 = step11.Replace("10: +0", "");
            string step9 = step10.Replace("9: +0", "");
            string step8 = step9.Replace("8: +0", "");
            string step7 = step8.Replace("7: +0", "");
            string step6 = step7.Replace("6: +0", "");
            string step5 = step6.Replace("5: +0", "");
            string step4 = step5.Replace("4: +0", "");
            string step3 = step4.Replace("3: +0", "");
            string step2 = step3.Replace("2: +0", "");
            string step1 = step2.Replace("1: +0", "");
            string extra = step1.Replace("0: +0", "");
            string extra2 = extra.Replace(" 0;", ";");

            return extra2;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + "," + textBox4.Text + "," + textBox5.Text + "," + textBox6.Text + "," + textBox7.Text + "," + textBox8.Text + "," + textBox9.Text + "," + textBox10.Text + "," + textBox11.Text + "," + textBox12.Text + Environment.NewLine;
            using (StreamWriter writetext = new StreamWriter("write.txt"))
            {
                writetext.WriteLine(text);
            }
        }

        private void button10_Click(object sender, EventArgs e)
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

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
