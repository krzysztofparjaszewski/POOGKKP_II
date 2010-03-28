using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SoundStudio.Model
{
    public class Icon
    {
        protected System.Windows.Forms.PictureBox pictureBox;
        public System.Drawing.Image image;

        public Icon(string iconPath) {
            string localPath = Model.Consts.Paths.CombinePath(iconPath);
            this.image = System.Drawing.Image.FromFile(localPath);
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox.Image = this.image;
        }

        public System.Drawing.Image Image {
            get {
                return this.image;
            }
        }

        public System.Windows.Forms.PictureBox Control {
            get {
                return this.pictureBox;
            }
        }
                
    }
}
