using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; 

namespace 簡易電子琴
{
    public partial class frmBeepPlayer : Form
    {
        [DllImport("kernel32.dll")]
        public static extern bool Beep(int frequency, int duration); 

        int[] freq = { 523, 587, 659, 698, 784, 880, 988, 1046 };
        public frmBeepPlayer()
        {
            InitializeComponent();
        }
        int initWidth = 0; 
        int initHeight = 0; 
        Dictionary<string, Rectangle> initControl = new Dictionary<string, Rectangle>(); 
        private void btn1_Click(object sender, EventArgs e)
        {
     
            Button btn = sender as Button; 
            btn.Enabled = false; 
            Beep(freq[btn.TabIndex], 300);
            btn.Enabled = true;
            
        }
        private void InitializeButton() 
        {
            
            btn2.Click += btn1_Click; 
            btn3.Click += btn1_Click; 
            btn4.Click += btn1_Click; 
            btn5.Click += btn1_Click; 
            btn6.Click += btn1_Click; 
            btn7.Click += btn1_Click; 
            btn8.Click += btn1_Click; 
        }

        private void frmBeepPlayer_Load(object sender, EventArgs e)
        {
            InitializeButton(); // 記得呼叫剛剛寫的按鈕綁定！

            this.initWidth = this.palMain.Width; 
            this.initHeight = this.palMain.Height; 
            foreach (Control ctl in this.palMain.Controls) 
            {
                this.initControl.Add(ctl.Name, new Rectangle(ctl.Left, ctl.Top, ctl.Width, ctl.Height)); 
            }
        }

        private void frmBeepPlayer_SizeChanged(object sender, EventArgs e)
        {
            if (initWidth == 0) return; // 防呆機制，避免一開始還沒 Load 就觸發報錯

            double width = this.palMain.Width; 
            double height = this.palMain.Height; 
            double iRatioWith = width / this.initWidth; 
            double iRatioHeight = height / this.initHeight; 

            foreach (Control ctl in this.palMain.Controls) 
            {
                ctl.Left = (int)(initControl[ctl.Name].Left * iRatioWith);
                ctl.Top = (int)(initControl[ctl.Name].Top * iRatioHeight); 
                ctl.Width = (int)(initControl[ctl.Name].Width * iRatioWith); 
                ctl.Height = (int)(initControl[ctl.Name].Height * iRatioHeight);
            }
        }
    }
}
