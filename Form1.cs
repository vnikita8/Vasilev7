using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vasilev7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool goOne = int.TryParse(FirstOne.Text, out int one);
            if (goOne)
            {
                bool goTwo = int.TryParse(FirstTwo.Text, out int two);
                if (goTwo)
                    FirstAnswer.Text = Laba7.FindMax(one, two).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool goOne = int.TryParse(ThreeOne.Text, out int num);
            if (goOne & num >= 0)
            {
                bool oper = Laba7.Factorial(num, out long res);
                if (oper)
                {
                    ThreeAnswer.Text = res.ToString();
                    ThreeCBox.Checked = oper;
                }
                else
                {
                    ThreeAnswer.Text = "Переполнение";
                    ThreeCBox.Checked = oper;
                }
            }
            else
            {
                ThreeAnswer.Text = "Введите число";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string one = TwiceOne.Text;
            string two = TwiceTwo.Text;
            Laba7.NumSwitch(ref one, ref two);
            TwiceOne.Text = one;
            TwiceTwo.Text = two;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool goOne = int.TryParse(FourOne.Text, out int num);
            if (goOne & num >=0)
            {
                int res = Laba7.RecursFactorial(num);
                if (res < 0)
                {
                    FourCBox.Checked = false;
                    FourAnswer.Text = "Переполнение";
                }
                else
                {
                    FourCBox.Checked = true;
                    FourAnswer.Text = res.ToString();
                }

            }
            else
            {
                ThreeAnswer.Text = "Введите подходящее число";
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked)
                    FiveAnswer.Text = Laba7.NOD(int.Parse(FiveOne.Text), int.Parse(FiveTwo.Text), int.Parse(FiveThree.Text)).ToString();
                else
                    FiveAnswer.Text = Laba7.NOD(int.Parse(FiveOne.Text), int.Parse(FiveTwo.Text)).ToString();
            }
            catch
            {
                FiveAnswer.Text = "Введите правильные числа";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                FiveThree.Enabled = true;
            else
                FiveThree.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool goOne = int.TryParse(SixOne.Text, out int num);
            if (goOne & num >= 0)
            {
                int res = Laba7.FibonachiRow(num);
                if (res != -1)
                    SixAnswer.Text = res.ToString();
                else
                    SixAnswer.Text = "Переполнение";

            }
            else if (goOne)
                SixAnswer.Text = "Ошибка значений";
        }
    }

    public static class Laba7
    {
        public static int FindMax(int one, int two)
        {
            if (one > two)
                return one;
            else
                return two;
        }
        public static void NumSwitch(ref string one, ref string two)
        {
            string prom = one;
            one = two;
            two = prom;
        }
        public static bool Factorial(int num, out long res)
        {
            res = 1;
            try
            {
                for (int i = 1; i <= num; i++)
                {
                    checked { res *= i; }
                }
                return true;
            }
            catch
            {
                res = 0;
                return false;
            }
        }
        public static int RecursFactorial(int num)
        {
            try
            {
                if (num > 0)
                {
                    checked
                    {
                        if (num == 1)
                            return 1;
                        else
                            return num * RecursFactorial(num - 1);
                    }
                }
                else
                    return -1;
                
            }
            catch { return -1; }
        }
        public static int NOD (int one, int two)
        {
            while (one != 0 & two != 0)
            {
                if (one > two)
                    one = one % two;
                else
                    two = two % one;
            }
            return one + two;
        }
        public static int NOD (int one, int two, int three)
        {
            return NOD(NOD(one, two), three);
        }
        public static int FibonachiRow(int RowNumber)
        {
            int Row1 = 1;
            int Row2 = 1;
            int result = 0;
            if (RowNumber > 2)
            {
                try
                {
                    for (int i = 2; i < RowNumber; i++)
                    {
                        checked
                        {
                            result = Row1 + Row2;
                        }
                        Row1 = Row2;
                        Row2 = result;
                    }
                    return result;
                }
                catch
                {
                    return -1;
                }
                
            }
            else if (RowNumber == 0)
                return 0;
            else
                return 1;
            
        }
    }
}
