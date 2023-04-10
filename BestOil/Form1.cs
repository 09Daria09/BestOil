using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using Microsoft.VisualBasic;

namespace BestOil
{
    public partial class Form1 : Form
    {
        string a76;
        string a80;
        string a92;
        string a95;
        string a98;
        private int price1 = 0;
        private int price2 = 0;
        private int price3 = 0;
        private int price4 = 0;

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

            MenuItem menu = new MenuItem("Меню");
            MenuItem exit = new MenuItem("Выход");
            MenuItem reset = new MenuItem("Сброс");
            MenuItem mSave = new MenuItem("Сохранение чека");
            exit.Click += new EventHandler(ExitMethod);
            reset.Click += new EventHandler(ResetMethod);
            mSave.Click += new EventHandler(SaveMethod);
            Menu = new MainMenu();
            Menu.MenuItems.Add(menu);
            Menu.MenuItems.Add(exit);
            Menu.MenuItems.Add(reset);
            menu.MenuItems.Add(mSave);

            contextMenuStrip1 = new ContextMenuStrip();
            contextMenuStrip1.Items.Add("Выход", null, ExitMethod);
            contextMenuStrip1.Items.Add("Сброс", null, ResetMethod);
            contextMenuStrip1.Items.Add("Сохранение чек", null, SaveMethod);

            this.ContextMenuStrip = contextMenuStrip1;
        }
        private void ExitMethod(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void SaveMethod(object sender, EventArgs e)
        {

            string userName = Microsoft.VisualBasic.Interaction.InputBox("Введите ваше имя:", "Ввод имени");
            MessageBox.Show("Ваше имя: " + userName);
            using (StreamWriter sw = File.AppendText("ClientChek.txt"))
            {
                sw.WriteLine();
                sw.WriteLine("_____________________________________________\n");
                sw.WriteLine($"Клиент -> {userName}");
                if (comboBox1.SelectedItem != null)
                {
                    sw.WriteLine($"\t*** Автозаправка ***\nБензин: {comboBox1.SelectedItem.ToString()}");
                    sw.WriteLine($"Количество бензина: {textBox2.Text} л.");
                    sw.WriteLine($"К оплате: {label1.Text} грн.");
                }
                sw.WriteLine();
                if (label8.Text != "0.00")
                {
                    sw.WriteLine($"\t*** Мини-кафе ***");
                    if (checkBox1.Checked)
                    {
                        sw.WriteLine($"{checkBox1.Text} {label9.Text} {textBox4.Text} {label10.Text} {textBox11.Text}");
                    }
                    if (checkBox2.Checked)
                    {
                        sw.WriteLine($"{checkBox2.Text} {label9.Text} {textBox7.Text} {label10.Text} {textBox10.Text}");
                    }
                    if (checkBox3.Checked)
                    {
                        sw.WriteLine($"{checkBox3.Text} {label9.Text} {textBox6.Text} {label10.Text} {textBox9.Text}");
                    }
                    if (checkBox4.Checked)
                    {
                        sw.WriteLine($"{checkBox4.Text} {label9.Text} {textBox5.Text} {label10.Text} {textBox8.Text}");
                    }
                    sw.WriteLine($"К оплате: {label8.Text} грн.");
                }
                sw.WriteLine();
                sw.WriteLine($"Всего к оплате: {label7.Text} грн.");
                sw.WriteLine("_____________________________________________");

            }
        }
        private void ResetMethod(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            textBox2.Text = null;
            textBox3.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            label1.Text = "0.00";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            label8.Text = "0.00";
            label7.Text = "0.00";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = null;
            if (comboBox1.SelectedItem != null)
            {
                selectedValue = comboBox1.SelectedItem.ToString();
            }
            if (selectedValue == a76)
            {
                textBox1.Text = "33,23";
            }
            else if (selectedValue == a80)
            {
                textBox1.Text = "35,55";
            }
            else if (selectedValue == a92)
            {
                textBox1.Text = "46,12";
            }
            else if (selectedValue == a95)
            {
                textBox1.Text = "46,96";
            }
            else if (selectedValue == a98)
            {
                textBox1.Text = "49,60";
            }
            else
            {
                textBox1.Text = null;
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

                double num1, num2, result;

                num1 = double.TryParse(label1.Text, out num1) ? num1 : 0;
                num2 = double.TryParse(label8.Text, out num2) ? num2 : 0;

                result = num1 + num2;
                label7.Text = result.ToString();

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
            double num1, num2, result;

            num1 = double.TryParse(label1.Text, out num1) ? num1 : 0;
            num2 = double.TryParse(label8.Text, out num2) ? num2 : 0;

            result = num1 + num2;
            label7.Text = result.ToString();
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
            else
            {
                textBox11.Clear();
                textBox11.ReadOnly = true;

            }
            if (checkBox2.Checked)
            {
                textBox10.ReadOnly = false;
            }
            else
            {
                textBox10.Clear();
                textBox10.ReadOnly = true;
            }
            if (checkBox3.Checked)
            {
                textBox8.ReadOnly = false;
            }
            else
            {
                textBox8.Clear();
                textBox8.ReadOnly = true;
            }
            if (checkBox4.Checked)
            {
                textBox9.ReadOnly = false;
            }
            else
            {
                textBox9.Clear();
                textBox9.ReadOnly = true;
            }

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            int priceProduct = 0;

            int.TryParse(textBox11.Text, out count);
            int.TryParse(textBox4.Text, out priceProduct);

            int price = count * priceProduct;

            price1 = price;


            label8.Text = (price1 + price2 + price3 + price4).ToString();

            double num1, num2, result;

            num1 = double.TryParse(label1.Text, out num1) ? num1 : 0;
            num2 = double.TryParse(label8.Text, out num2) ? num2 : 0;

            result = num1 + num2;
            label7.Text = result.ToString();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            int priceProduct = 0;

            int.TryParse(textBox10.Text, out count);
            int.TryParse(textBox7.Text, out priceProduct);

            int price = count * priceProduct;
            price2 = price;

            label8.Text = (price1 + price2 + price3 + price4).ToString();

            double num1, num2, result;

            num1 = double.TryParse(label1.Text, out num1) ? num1 : 0;
            num2 = double.TryParse(label8.Text, out num2) ? num2 : 0;

            result = num1 + num2;
            label7.Text = result.ToString();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            int priceProduct = 0;

            int.TryParse(textBox9.Text, out count);
            int.TryParse(textBox6.Text, out priceProduct);

            int price = count * priceProduct;
            price3 = price;

            label8.Text = (price1 + price2 + price3 + price4).ToString();

            double num1, num2, result;

            num1 = double.TryParse(label1.Text, out num1) ? num1 : 0;
            num2 = double.TryParse(label8.Text, out num2) ? num2 : 0;

            result = num1 + num2;
            label7.Text = result.ToString();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            int priceProduct = 0;

            int.TryParse(textBox8.Text, out count);
            int.TryParse(textBox5.Text, out priceProduct);

            int price = count * priceProduct;
            price4 = price;

            label8.Text = (price1 + price2 + price3 + price4).ToString();

            double num1, num2, result;

            num1 = double.TryParse(label1.Text, out num1) ? num1 : 0;
            num2 = double.TryParse(label8.Text, out num2) ? num2 : 0;

            result = num1 + num2;
            label7.Text = result.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Оплата прошла успешно :)", "Оплата", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();

        }
    }
}
