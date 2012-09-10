using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PatricksLeagueTimers
{
    public partial class Form1 : Form
    {
        public delegate void setTimerCallback();
        public Countdown dragon;
        public Countdown baron;
        public Configuration config;

        public Form1()
        {
            InitializeComponent();

            config = new Configuration(this);
            dragon = new Countdown(progressBar1, label1, config, this);
            baron = new Countdown(progressBar2, label2, config, this);

            Hotkey drag_hotkey = new Hotkey(config.getDragonKeys(), false, false, false, false);
            drag_hotkey.Pressed += new HandledEventHandler(button1_Click);
            drag_hotkey.Register(this);

            Hotkey baron_hotkey = new Hotkey(config.getBaronKeys(), false, false, false, false);
            baron_hotkey.Pressed += new HandledEventHandler(button2_Click);
            baron_hotkey.Register(this);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            dragon.timerStart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baron.timerStart();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dragon.timerStart();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            baron.timerStart();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.Start();
            t.IsBackground = true;
        }
        public void ThreadProc()
        {
            Application.Run(new options(this,config));
        }
    }
}
