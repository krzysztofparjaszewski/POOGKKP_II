using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.View
{
    public class PlayButton : System.Windows.Forms.Button 
    {
        static private int __nextIndex = 0;

        public int x;
        public int y;
        public int width;
        public int height;

        private Model.Sound sound;


        static public int getNextIndex()
        {
            return __nextIndex++;
        }

      

        public Model.Sound Sound {
            get {
                return sound;
            }
        }

        public PlayButton(string title, Model.Sound sound, int _x, int _y, int _width, int _heigth)
        {
            int index = getNextIndex();

            this.Name = "playButton" + Convert.ToString(index);
            this.TabIndex = index;
            this.Text = title;
            this.UseVisualStyleBackColor = true;

            this.sound = sound;

            this.x = _x;
            this.y = _y;
            this.width = _width;
            this.height = _heigth;
           
            //Console.WriteLine(Path.Combine(Application.StartupPath, fileName));
            //this.__player = new SoundPlayer(Path.Combine(Application.StartupPath, fileName));

            //this.Click += new System.EventHandler(this.onClick);
        }
        public PlayButton SetIcon(string iconPath) {
            string localPath = Model.Consts.Paths.CombinePath(iconPath);
            this.Image = System.Drawing.Image.FromFile(localPath);      
            return this;
        }

        private void onClick(object sender, EventArgs e)
        {
            //this.__player.Play();
        }


    }
}
