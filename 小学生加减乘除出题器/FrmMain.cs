/* ===================================
 * 项目名称：小学生加减乘除出题器 
 * 功能描述：Form1  
 * 创 建 者：hackgsl
 * 创建日期：2020-04-13 22:32:40
 * CLR Ver ：4.0.30319.42000
 * =================================*/
using System;
using System.Windows.Forms;

namespace 小学生加减乘除出题器
{
    public partial class FrmMain : Form
    {
        int sum, num = 1, right, wrong, result, number_1, number_2;
        TimeSpan dateBegin, dateEnd, tspan;
        DateTime dtNow, dtSet;//定义两个DateTime类型的变量，分别用来记录当前时间和设置的到期时间


        public FrmMain()
        {
            InitializeComponent();
            groupBox2.Visible = false;
            label5.Text = "";
            label8.Text = "";
        }


        private void btnInit_Click(object sender, EventArgs e)
        {
            btnInit.Text = "重新出题";
            sum = 1;
            num = 1;
            right = 0;
            wrong = 0;
            question();
            data();
            groupBox2.Visible = true;
            label6.Text = "";
            txtAnswer.Focus();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            judge();
            dateBegin = new TimeSpan(DateTime.Now.Ticks);//计时开始
            txtAnswer.Focus();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            txtAnswer.Text = txtAnswer.Text.Trim();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            //回车计算结果
            if (e.KeyValue != 13)
            {
                return;
            }

            judge();
            txtAnswer.Focus();
            dateBegin = new TimeSpan(DateTime.Now.Ticks);//计时开始
        }

        public void question()
        {

            Random random = new Random();

            //判断运算符
            if (radioButton1.Checked)
            {
                question(1);
            }
            else if (radioButton2.Checked)
            {
                question(2);
            } //减法

            else if (radioButton3.Checked)
            {
                question(3);
            } //乘法

            else if (radioButton4.Checked)
            {
                question(4);
            } //除法
            else if (radioButton5.Checked)
            {
                question(random.Next(1, 5));
            } //随机
            label2.Text = $"第 {num} 题：";
            num++;
            sum++;
        }

        public void question(int i)
        {
            while (true)
            {
                Random random = new Random();
                number_1 = random.Next(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                number_2 = random.Next(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                switch (i)
                {
                    //随机判断运算符
                    case 1://加法
                        result = number_1 + number_2;
                        label4.Text = number_1 + " + " + number_2 + " =";
                        break;
                    case 2://减法
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

                            break;
                        }
                    case 3://乘法
                        result = number_1 * number_2;
                        label4.Text = number_1 + " x " + number_2 + " =";
                        break;
                    case 4://除法
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

                            break;
                        }
                }
                //textBox3.Text = result.ToString();//显示答案
                break;
            }
        }

        public void judge()
        {
            if (txtAnswer.Text == "") return;

            if (txtAnswer.Text == result.ToString())
            {
                label8.Text = "恭喜你答对啦，请再接再厉！";
                label5.Text = $"上一题：{label4.Text} {txtAnswer.Text}";
                right++;
                txtAnswer.Text = "";
                question();
                data();
            }
            else
            {
                label8.Text = "答错了哦，再想一想呢，奥利给！";
                sum++;
                wrong++;
                data();
                txtAnswer.Text="";
            }
            //结束答题计时
            dateEnd = new TimeSpan(DateTime.Now.Ticks);
            tspan = dateBegin.Subtract(dateEnd).Duration();
            label7.Text = $"答题耗时(ms)：\n{tspan}";

        }

        public void data()
        {
            float Percentage = ((float)right / (sum - 2) * 100f);
            label6.Text = $"累计已答：{sum - 2}   对：{right}   错：{wrong}   正确率：{Percentage}%";
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("小朋友练习完了吗，确定要退出序？", "确认信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                Environment.Exit(Environment.ExitCode);
                //Application.Exit();//用这个程序会两次跳进MainForm_FormClosing事件，因为Application.Exit(e);会触发MainForm_FormClosing事件；
            }
            else
            {
                e.Cancel = true;
            }
        }

    }
}
