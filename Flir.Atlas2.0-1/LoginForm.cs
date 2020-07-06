using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flir.Atlas2._0
{
    public partial class LoginForm : Form
    {

        //指定窗体完全透明  
        private double m_CurrentOpacity = 0;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            this.Opacity = m_CurrentOpacity;

          
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (this.m_CurrentOpacity < 1)
            {
                //如果当前的透明度小于1，则继续增加透明度
                this.m_CurrentOpacity += 0.05;
                this.Opacity = this.m_CurrentOpacity;
            }
            else
            {
                //如果当前已经完全不透明，则停止timer
                this.timer1.Stop();
                this.timer1.Enabled = false;

                timer2.Interval = 1000;
                timer2.Start();
            }
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            MainForm frmMain = new MainForm();
            frmMain.Show();
            //this.Hide();

            this.Dispose(false);



            timer2.Stop();
            this.timer2.Enabled = false;
        }
    }
}
