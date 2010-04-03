using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.Model
{
    public class Sound
    {
        protected string path;
        protected System.Media.SoundPlayer sPlayer;
        
        public Sound(string soundPath) {
            this.path = soundPath;
            this.sPlayer = new System.Media.SoundPlayer();
            this.ReadSound();
        }

        public void ReadSound() {
            string localPath = Model.Consts.Paths.CombinePath(this.path);
            System.IO.FileInfo fInfo = new System.IO.FileInfo(localPath);
            if (fInfo.Exists) {
                this.sPlayer.SoundLocation = localPath;
                this.sPlayer.Load();
            } else { 
                // todo error handling
            }
        }

        public System.Media.SoundPlayer SoundPlayer {
            get {
                return this.sPlayer;    
            }
        }

    }
}
