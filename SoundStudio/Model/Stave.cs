using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.Model
{
    public class Stave : System.Collections.Generic.List<View.MovablePictureBox>
    {
        Melody melody;
        public Stave(Melody melody) {
            this.melody = melody;
        }
        public new void Add(View.MovablePictureBox movablePictureBox) {
            base.Add(movablePictureBox);
        }
    }
}
