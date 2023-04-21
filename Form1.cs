using NCalc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator_2
{
    public partial class Kalkulator : Form
    {
        public Kalkulator()
        {
            InitializeComponent();
        }

        char[] operations_ch2 = new char[] { '+', '-', '*', '/' };
        string[] operations_ch20 = new string[] { "+", "-", "*", "/" };
        int miejsce_oper, first, num;
        double a, b;
        char ostatnia;
        string oper;
        bool spr, iscomma;
        
        private void result_tmp()
        {
            string[] splitt = result.Text.Split(operations_ch2);
            string oper = result.Text[result.Text.Length - splitt[splitt.Length - 1].Length - 1].ToString();

            a = double.Parse(splitt[splitt.Length - 2]);
            b = double.Parse(splitt[splitt.Length - 1]);
            if (result.Text[0] == '-')
            {
                a = double.Parse("-" + a.ToString());
            }
            if (oper == "+")
            {
                result.Text = (a + b).ToString();
            }
            else if (oper == "-")
            {
                result.Text = (a - b).ToString();
            }
            else if (oper == "*")
            {
                result.Text = (a * b).ToString();
            }
            else if (oper == "/")
            {
                result.Text = (a / b).ToString();
            }
            
            string wynik_s = result.Text;

            if (wynik_s == "NaN")
            {
                wynik_s = "0";
                errorProvider1.SetError(result, "NIE MOZNA DZIELIC PRZEZ 0");
            }
            if (wynik_s == "∞" || wynik_s == "-∞")
            {
                wynik_s = "0";
                errorProvider1.SetError(result, "NIE MOZNA DZIELIC PRZEZ 0");
            }
            result.Text = Math.Round((double.Parse(wynik_s)), 4).ToString();
        }


        private void add(string s)
        {
            errorProvider1.Clear();
            if (result.TextLength < 11)
            {
                string[] splitt = result.Text.Split(operations_ch2);
                iscomma = false;
                if (splitt[splitt.Length - 1].Contains(","))
                {
                    iscomma = true;
                }
                first = 0;
                spr = false;
                foreach (char i in result.Text)
                {
                    if (first == 1)
                    {
                        if (operations_ch2.Contains(i))
                        {
                            spr = true;
                        }
                    }
                    first = 1;
                }
                if (operations_ch20.Contains(s) && result.Text[result.Text.Length - 1] != ',')
                {
                    if (spr == false && result.Text != "-")
                    {
                        result.Text += s;
                        return;
                    }
                    else
                    {
                        if (!operations_ch20.Contains(result.Text[result.Text.Length - 1].ToString()))
                        {
                            result_tmp();
                            result.Text += s;
                            return;
                        }
                        else
                        {
                            result.Text = result.Text.Substring(0, result.Text.Length - 1) + s;
                        }
                        return;
                    }
                }
                if (s == ",")
                {
                    if (iscomma == false && !operations_ch20.Contains(result.Text[result.Text.Length - 1].ToString()))
                    {
                        result.Text += s;
                        return;
                    }
                    return;
                }

                if (s == "0")
                {
                    if (splitt[splitt.Length - 1] != "0")
                    {
                        result.Text += s;
                        return;
                    }
                    return;
                }

                if (result.Text == "0")
                {
                    result.Text = s;
                    return;
                }


                if (int.TryParse(s, out num))
                {
                    result.Text += s;
                }
            }
        }

        private void clear()
        {
            if (result.Text.Length > 1)
            {
                result.Text = result.Text.Substring(0, result.Text.Length - 1);
            }
            else if (result.Text.Length == 1)
            {
                result.Text = "0";
            }
            if (result.Text[result.Text.Length - 1] == ' ') //antybug
            {
                result.Text = result.Text.Substring(0, result.Text.Length - 1);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            add("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            add("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            add("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            add("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            add("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            add("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            add("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            add("9");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            add("0");
        }

        private void textDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void comma_Click(object sender, EventArgs e)
        {
            add(",");
        }

        private void plusminus_Click(object sender, EventArgs e)
        {
            if (result.Text != "0" && !operations_ch2.Contains(result.Text[result.Text.Length - 1]))
            {
                
                first = 0;
                spr = false;
                string[] splitt = result.Text.Split(operations_ch2);
                
                foreach (char i in result.Text)
                {
                    if (first == 1)
                    {
                        if (operations_ch2.Contains(i))
                        {
                            spr = true;
                        }
                    }
                    first = 1;
                }

                miejsce_oper = 1;
                oper = "+";

                if (spr == true)
                {

                    miejsce_oper = result.Text.Length - splitt[splitt.Length - 1].Length - 1;
                    oper = result.Text[miejsce_oper].ToString();
                }

                string[] split = result.Text.Split(operations_ch2);

                if (split.Length > 1 && !operations_ch20.Contains(split[split.Length - 1]) && spr == true)
                {
                    if (oper == "-")
                    {
                        result.Text = result.Text.Substring(0, miejsce_oper) + "+" + result.Text.Substring(miejsce_oper + 1, splitt[splitt.Length - 1].Length);
                    }
                    else
                    {
                        result.Text = result.Text.Substring(0, miejsce_oper) + "-" + result.Text.Substring(miejsce_oper + 1, splitt[splitt.Length - 1].Length);

                    }
                }
                else if (result.Text != "0" && !operations_ch20.Contains(result.Text) && !operations_ch20.Contains(split[split.Length - 1]))
                {
                    if (result.Text[0] == '-')
                    {
                        result.Text = result.Text.Substring(1, result.Text.Length - 1);
                    }
                    else
                    {
                        result.Text = '-' + result.Text;
                    }
                }
            }
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clearall_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void equal_Click(object sender, EventArgs e)
        {
            first = 0;
            spr = false;
            foreach (char i in result.Text)
            {
                if (first == 1)
                {
                    if (operations_ch2.Contains(i))
                    {
                        spr = true;
                    }
                }
                first = 1;
            }

            ostatnia = result.Text[result.Text.Length - 1];
            if (ostatnia != ',' && !operations_ch2.Contains(ostatnia) && spr == true && !operations_ch20.Contains(result.Text[result.Text.Length - 1].ToString()))
            {
                result_tmp();
            }
        }

        private void plus_Click(object sender, EventArgs e)
        {
            add("+");
        }

        private void minus_Click(object sender, EventArgs e)
        {
            add("-");
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            add("*");
        }

        private void divide_Click(object sender, EventArgs e)
        {
            add("/");
        }

        private void Kalkulator_Load(object sender, EventArgs e)
        {

        }
    }
}
