using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace BestOil
{
    public partial class Form1 : Form
    {
        string a76;
        string a80;
        string a92;
        string a95;
        string a98;
        double price = 0.0;

        public Form1()
        {
            InitializeComponent();
            a76 = "А-76";
            a80 = "А-80";
            a92 = "А-92";
            a95 = "А-95";
            a98 = "А-98";


            string[] items = { a76, a80, a92, a95, a98 };
            comboBox1.Items.AddRange(items);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedItem.ToString();
            if (selectedValue == a76)
            {
                textBox1.Text = "33,23";
            }
            if (selectedValue == a80)
            {
                textBox1.Text = "35,55";
            }
            if (selectedValue == a92)
            {
                textBox1.Text = "46,12";
            }
            if (selectedValue == a95)
            {
                textBox1.Text = "46,96";
            }
            if (selectedValue == a98)
            {
                textBox1.Text = "49,60";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = true;
            }
            else if (radioButton2.Checked)
            {
                textBox3.ReadOnly = false;
                textBox2.ReadOnly = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double priceOil;
            double countOil;
            bool isPriceValid = double.TryParse(textBox1.Text, out priceOil);
            bool isCountValid = double.TryParse(textBox2.Text, out countOil);

            if (isPriceValid && isCountValid)
            {
                double price = priceOil * countOil;
                label1.Text = price.ToString();
                textBox3.Text = price.ToString();
            }
            else
            {
                label1.Text = "Ошибка";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            double priceOil;
            double countOil;
            bool isPriceValid = double.TryParse(textBox3.Text, out priceOil);
            bool isCountValid = double.TryParse(textBox1.Text, out countOil);
            label1.Text = priceOil.ToString();

            if (isPriceValid && isCountValid)
            {
                double price = priceOil / countOil;
                textBox2.Text = price.ToString();
            }
            else
            {
                label1.Text = "Ошибка";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox11.ReadOnly = false;
            }
            else { textBox11.ReadOnly = true; price = 0.0; }
            if (checkBox2.Checked)
            {
                textBox10.ReadOnly = false;
            }
            else { textBox10.ReadOnly = true; price = 0.0; }
            if (checkBox3.Checked)
            {
                textBox8.ReadOnly = false;
            }
            else { textBox8.ReadOnly = true; price = 0.0; }
            if (checkBox4.Checked)
            {
                textBox9.ReadOnly = false;
            }
            else { textBox9.ReadOnly = true; price = 0.0; }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            int priceProduct = 0;
            if (checkBox1.Checked)
            {
                int.TryParse(textBox11.Text, out count);
                int.TryParse(textBox4.Text, out priceProduct);
                price += count * priceProduct;
                label8.Text = price.ToString();
            }
            if (checkBox2.Checked)
            {
                int.TryParse(textBox10.Text, out count);
                int.TryParse(textBox7.Text, out priceProduct);
                price += count * priceProduct;
                label8.Text = price.ToString();
            }
            if (checkBox3.Checked)
            {
                int.TryParse(textBox8.Text, out count);
                int.TryParse(textBox6.Text, out priceProduct);
                price += count * priceProduct;
                label8.Text = price.ToString();
            } 
            if (checkBox4.Checked)
            {
                int.TryParse(textBox9.Text, out count);
                int.TryParse(textBox5.Text, out priceProduct);
                price += count * priceProduct;
                label8.Text = price.ToString();
            }
        }
    }
}
