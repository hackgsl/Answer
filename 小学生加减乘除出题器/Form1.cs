/* ===================================
 * 项目名称：小学生加减乘除出题器 
 * 功能描述：Form1  
 * 创 建 者：hackgsl
 * 创建日期：2020-04-13 22:32:40
 * CLR Ver ：4.0.30319.42000
 * =================================*/
using System;
using System.Linq;
using System.Windows.Forms;

namespace 小学生加减乘除出题器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int sum, num = 1, right, wrong, result, number_1, number_2, number_3;
        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            label5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "重新出题";
            sum = 1;
            num = 1;
            right = 0;
            wrong = 0;
            question();
            data();
            groupBox2.Visible = true;
            label6.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            judge();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.Trim();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            //回车计算结果
            if (e.KeyValue == 13)
            {
                judge();
            }
        }

        public void question()
        {
            while (true)
            {
                //取2个随机数
                Random random = new Random();
                number_1 = random.Next(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                number_2 = random.Next(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                number_3 = random.Next(1, 5);

                //判断运算符
                if (radioButton1.Checked)
                {
                    result = number_1 + number_2;
                    label4.Text = number_1 + " + " + number_2 + " =";
                } //加法

                else if (radioButton2.Checked)
                {
                    if (number_1 < number_2) //前小后大就颠倒下位置
                    {
                        result = number_2 - number_1;
                        label4.Text = number_2 + " - " + number_1 + " =";
                    }
                    else
                    {
                        result = number_1 - number_2;
                        label4.Text = number_1 + " - " + number_2 + " =";
                    }
                } //减法

                else if (radioButton3.Checked)
                {
                    result = number_1 * number_2;
                    label4.Text = number_1 + " x " + number_2 + " =";
                } //乘法

                else if (radioButton4.Checked)
                {
                    if (number_1 < number_2) //前小后大就颠倒下位置
                    {
                        if (number_2 % number_1 != 0)//取模，不是整数就重新取一个
                        {
                            continue;
                        }

                        result = number_2 / number_1;
                        label4.Text = number_2 + " ÷ " + number_1 + " =";
                    }
                    else
                    {
                        if (number_1 % number_2 != 0)
                        {
                            continue;
                        }

                        result = number_1 / number_2;
                        label4.Text = number_1 + " ÷ " + number_2 + " =";
                    }
                } //除法
                else if (radioButton5.Checked)
                {
                    question(number_3);
                } //随机
                break;
            }
            label2.Text = $"第 {num} 题：";
            num++;
            sum++;
        }

        public void question(int i)
        {
            while (true)
            {
                switch (i)
                {
                    //随机判断运算符
                    case 1:
                        result = number_1 + number_2;
                        label4.Text = number_1 + " + " + number_2 + " ="; //加法
                        break;
                    case 2:
                    {
                        if (number_1 < number_2) //前小后大就颠倒下位置
                        {
                            result = number_2 - number_1;
                            label4.Text = number_2 + " - " + number_1 + " =";
                        }
                        else
                        {
                            result = number_1 - number_2;
                            label4.Text = number_1 + " - " + number_2 + " =";
                        } //减法

                        break;
                    }
                    case 3:
                        result = number_1 * number_2;
                        label4.Text = number_1 + " x " + number_2 + " ="; //乘法
                        break;
                    case 4:
                    {
                        if (number_1 < number_2) //前小后大就颠倒下位置
                        {
                            if (number_2 % number_1 != 0)//取模，不是整数就重新取一个
                            {
                                continue;
                            }

                            result = number_2 / number_1;
                            label4.Text = number_2 + " ÷ " + number_1 + " =";
                        }
                        else
                        {
                            if (number_1 % number_2 != 0)
                            {
                                continue;
                            }

                            result = number_1 / number_2;
                            label4.Text = number_1 + " ÷ " + number_2 + " =";
                        } //除法

                        break;
                    }
                }
                break;
            }
        }

        public void judge()
        {
            if (textBox3.Text == "") return;

            if (textBox3.Text == result.ToString())
            {
                label5.Text = $"上一题：{label4.Text} {textBox3.Text}";
                right++;
                textBox3.Text = "";
                question();
                data();
            }
            else
            {
                MessageBox.Show("您答错了哦，再想一想呢，加油！", "提示信息");
                sum++;
                wrong++;
                data();
            }
        }

        public void data()
        {
            float Percentage = ((float)right / (sum - 2) * 100f);
            label6.Text = $"累计已答：{sum - 2}   对：{right}   错：{wrong}   正确率：{Percentage}%";
        }
    }
}
