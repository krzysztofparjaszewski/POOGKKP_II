using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SoundStudio.Model
{
    public class Icon
    {
        public string path;

        public Icon(int x, int y, View.PlayButton pButton) {
            pButton.Location = new Point(x, y);
            this.path = pButton.gif;
        
        }

        
    }
}
