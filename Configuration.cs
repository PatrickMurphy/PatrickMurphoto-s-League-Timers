using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PatricksLeagueTimers
{
    public class Configuration
    {
        public Form main;

        private Boolean playSounds;
        private Double opacity;
        private Boolean alwaysOnTop;
        private Keys dragonKeys;
        private Keys baronKeys;

        public Configuration(Form f)
        {
            main = f;
            setOpacity(.8);
            setPlaySounds(true);
            setAlwaysOnTop(true);
            setDragonKeys(Keys.F9);
            setDragonKeys(Keys.F10);
        }

        // Set and Get PlaySounds
        public void setPlaySounds(Boolean ps)
        {
            this.playSounds = ps;
        }

        public Boolean getPlaySounds()
        {
            return this.playSounds;
        }

        // Set and get Opacity
        public void setOpacity(Double opac)
        {
            this.opacity = opac;
            main.Opacity = this.opacity;
        }
        
        public Double getOpacity()
        {
            return this.opacity;
        }

        //Set and Get Always on top
        public void setAlwaysOnTop(Boolean aot)
        {
            this.alwaysOnTop = aot;
            main.TopMost = this.alwaysOnTop;
        }

        public Boolean getAlwaysOnTop()
        {
            return this.alwaysOnTop;
        }

        // Set and Get dragon keys
        public void setDragonKeys(Keys k)
        {
            this.dragonKeys = k;
        }

        public Keys getDragonKeys()
        {
            return this.dragonKeys;
        }

        // Set and Get Baron keys
        public void setBaronKeys(Keys k)
        {
            this.baronKeys = k;
        }

        public Keys getBaronKeys()
        {
            return this.baronKeys;
        }
    }
}
