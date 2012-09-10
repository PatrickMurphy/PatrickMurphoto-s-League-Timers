using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace PatricksLeagueTimers
{
    public class Countdown
    {
        public System.Timers.Timer countdown_timer;
        public ProgressBar bar;
        public Label label;
        public Form1 form;
        public Configuration config;

        public Countdown(ProgressBar b, Label l, Configuration c, Form1 f)
        {
            bar = b;
            label = l;
            form = f;
            config = c;

            countdown_timer = new System.Timers.Timer();
            countdown_timer.Elapsed += new System.Timers.ElapsedEventHandler(tick);
            countdown_timer.Interval = 1000;
        }

        public void timerStart() {
            bar.Value = 0;
            countdown_timer.Enabled = true;
        }

        public void tick(object sender, EventArgs e)
        {
            form.Invoke(new PatricksLeagueTimers.Form1.setTimerCallback(this.setProgressbar));
        }
       
        public void setProgressbar()
        {
            if (bar.Value < bar.Maximum)
            {
                bar.Value++;
                label.Text = secondsToMinutes(bar.Maximum - bar.Value) + " / " + secondsToMinutes(bar.Maximum);
                if (bar.Maximum-bar.Value <= 10 && config.getPlaySounds())
                    playWarningSound();
            }
            else
                timerComplete();
        }

        public void timerComplete() 
        {
            if (config.getPlaySounds())
                playFinishSound();
            countdown_timer.Enabled = false;
        }

        public void playFinishSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Exclamation.wav");
            simpleSound.Play();
        }

        public void playWarningSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chord.wav");
            simpleSound.Play();
        }

        public static string secondsToMinutes(int startSecs)
        {
            string endSecsString;
            int min = startSecs / 60;
            int endSecs = startSecs % 60;
            if (endSecs < 10)
                endSecsString = "0" + endSecs;
            else
                endSecsString = endSecs + "";
            return min + ":" + endSecsString;
        }
    }
}
