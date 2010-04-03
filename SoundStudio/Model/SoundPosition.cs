using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.Model
{
    // Describes position of a sound in Melody
    public class SoundPosition : IComparable<SoundPosition>
    {

    #region " Properties, Constructor "

        // position in the melody
        private int position;

        public SoundPosition(int x) {
            this.position = x;
        }

    #endregion
   
    #region " Overrides "
    
        public int Compare(SoundPosition x, SoundPosition y) {
            return x.Position.CompareTo(y.Position);
        }

        public int CompareTo(SoundPosition x) {
            return this.Position.CompareTo(x.Position);
        }

    #endregion

    #region " Fields "

        public int Position
        {
            get { 
                return position; 
            }
            set { 
                position = value; 
            }

        }

    #endregion

    }
}
