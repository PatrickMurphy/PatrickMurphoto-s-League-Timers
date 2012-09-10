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
    public partial class options : Form
    {
        public Form form;
        public Boolean ps;
        public delegate void setOptionsCallback();
        public Configuration config;

        public options(Form f,Configuration c)
        {
            form = f;
            config = c;
            InitializeComponent();
            setupForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invoke(new setOptionsCallback(this.setOptions));
        }

        public void setupForm()
        {
            int op = (int)(config.getOpacity()*10);
            switch (op)
            {
                case 2:
                    opacityBox.SelectedIndex = 0;
                    break;
                case 4:
                    opacityBox.SelectedIndex = 1;
                    break;
                case 6:
                    opacityBox.SelectedIndex = 2;
                    break;
                case 8:
                    opacityBox.SelectedIndex = 3;
                    break;
                case 10:
                    opacityBox.SelectedIndex = 4;
                    break;
            }

            //PlaySounds
            checkBox1.Checked = config.getPlaySounds();

            //Always On top
            checkBox2.Checked = config.getAlwaysOnTop();
        }

        public void setOptions() 
        {
            //save opacity
            double d;
            switch (opacityBox.SelectedIndex)
            {
                case 0:
                    d = .2;
                    break;
                case 1:
                    d = .5;
                    break;
                case 2:
                    d = .6;
                    break;
                case 3:
                    d = .8;
                    break;
                default:
                    d = 1;
                    break;
            }
            config.setOpacity(d);
            
            //save sounds
            config.setPlaySounds(checkBox1.Checked);
            
            //save always ontop
            config.setAlwaysOnTop(checkBox2.Checked);

            //close options
            this.Close();
        }
    }
}
